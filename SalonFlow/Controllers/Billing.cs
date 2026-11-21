using System.Data;
using SalonFlow.Data;
using SalonFlow.Models;

namespace SalonFlow.Controllers;

internal static class Billing
{
    public static DataTable List(Session actor)
    {
        Access.Require(Access.Desk(actor));
        return Database.Read("""
            SELECT b.id,c.name AS customer,b.branch_id,b.appointment_id,b.created_at,b.total,
            COALESCE(SUM(p.amount),0) AS paid,b.total-COALESCE(SUM(p.amount),0) AS balance,
            IF(b.voided,'Voided',IF(COALESCE(SUM(p.amount),0)=b.total AND b.total>0,'Paid','Open')) AS status
            FROM bills b JOIN customers c ON c.id=b.customer_id LEFT JOIN payments p ON p.bill_id=b.id
            GROUP BY b.id,c.name,b.branch_id,b.appointment_id,b.created_at,b.total,b.voided ORDER BY b.id DESC
            """);
    }

    public static void Create(Session actor, int customer, int branch, int? appointment)
    {
        Access.Require(Access.Desk(actor));
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        if (appointment.HasValue)
        {
            if (Database.Scalar(connection, transaction, """
                SELECT a.id FROM appointments a JOIN staff s ON s.id=a.staff_id
                WHERE a.id=@id AND a.customer_id=@customer AND s.branch_id=@branch AND a.status='Completed'
                """, ("@id", appointment), ("@customer", customer), ("@branch", branch)) is null)
                throw new InvalidOperationException("Choose a completed appointment for this customer and branch.");
        }
        using var command = Database.Command(connection, transaction,
            "INSERT INTO bills(customer_id,branch_id,appointment_id,subtotal,discount,tax,total) VALUES(@c,@b,@a,0,0,0,0)",
            ("@c", customer), ("@b", branch), ("@a", appointment));
        command.ExecuteNonQuery();
        int bill = checked((int)command.LastInsertedId);
        if (appointment.HasValue)
        {
            Database.Execute(connection, transaction, """
                INSERT INTO bill_items(bill_id,service_id,item_name,quantity,price)
                SELECT @bill,a.service_id,s.name,1,a.price FROM appointments a JOIN services s ON s.id=a.service_id
                WHERE a.id=@appointment
                """, ("@bill", bill), ("@appointment", appointment));
            Recalculate(connection, transaction, bill, 0);
        }
        Records.Audit(connection, transaction, actor, "Create bill", $"Bill #{bill}");
        transaction.Commit();
    }

    public static void AddItem(Session actor, int bill, string kind, int item, int quantity)
    {
        Access.Require(Access.Desk(actor));
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        LockBill(connection, transaction, bill);
        if (Paid(connection, transaction, bill) > 0)
            throw new InvalidOperationException("Items cannot change after a payment has been recorded.");
        if (kind == "Retail")
        {
            int changed = Database.Execute(connection, transaction, """
                UPDATE products SET quantity=quantity-@quantity WHERE id=@item AND kind='Retail' AND quantity>=@quantity
                """, ("@quantity", quantity), ("@item", item));
            if (changed == 0) throw new InvalidOperationException("Choose a retail product with enough stock.");
        }

        string sql = kind == "Retail"
            ? "INSERT INTO bill_items(bill_id,product_id,item_name,quantity,price) SELECT @bill,id,name,@q,price FROM products WHERE id=@id"
            : "INSERT INTO bill_items(bill_id,service_id,item_name,quantity,price) SELECT @bill,id,name,@q,price FROM services WHERE id=@id AND active=1";
        if (Database.Execute(connection, transaction, sql, ("@bill", bill), ("@q", quantity), ("@id", item)) == 0)
            throw new InvalidOperationException("Choose an active service or a retail product.");
        decimal discount = Convert.ToDecimal(Database.Scalar(connection, transaction,
            "SELECT discount FROM bills WHERE id=@id", ("@id", bill)));
        Recalculate(connection, transaction, bill, discount);
        transaction.Commit();
    }

    public static void Discount(Session actor, int bill, decimal discount, string promotion)
    {
        Access.Require(Access.Supervisor(actor));
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        LockBill(connection, transaction, bill);
        if (Paid(connection, transaction, bill) > 0)
            throw new InvalidOperationException("Discounts cannot change after payment.");
        decimal subtotal = Convert.ToDecimal(Database.Scalar(connection, transaction,
            "SELECT subtotal FROM bills WHERE id=@id", ("@id", bill)));
        if (promotion.Length > 0)
        {
            var rate = Database.Scalar(connection, transaction,
                "SELECT discount FROM promotions WHERE code=@code AND CURDATE() BETWEEN starts_on AND ends_on",
                ("@code", promotion));
            if (rate is null) throw new InvalidOperationException("This promotion is unavailable.");
            discount = decimal.Round(subtotal * Convert.ToDecimal(rate) / 100, 2);
        }
        if (discount > subtotal)
            throw new InvalidOperationException("The discount cannot exceed the subtotal.");
        var previous = Database.Scalar(connection, transaction, "SELECT discount FROM bills WHERE id=@id", ("@id", bill));
        Recalculate(connection, transaction, bill, discount);
        Records.Audit(connection, transaction, actor, "Bill discount", $"Bill #{bill} | {previous} → {discount} RWF");
        transaction.Commit();
    }

    public static decimal Pay(Session actor, int bill, string method, decimal tendered, string reference)
    {
        Access.Require(Access.Desk(actor));
        if (method != "Cash" && string.IsNullOrWhiteSpace(reference))
            throw new InvalidOperationException("Enter the transaction reference from the payment provider.");
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        decimal total = LockBill(connection, transaction, bill);
        decimal balance = total - Paid(connection, transaction, bill);
        if (balance <= 0) throw new InvalidOperationException("This bill has no amount due.");
        if (method != "Cash" && tendered > balance)
            throw new InvalidOperationException("The payment cannot exceed the balance.");
        decimal applied = Math.Min(tendered, balance);
        Database.Execute(connection, transaction,
            "INSERT INTO payments(bill_id,amount,method,reference) VALUES(@bill,@amount,@method,@ref)",
            ("@bill", bill), ("@amount", applied), ("@method", method), ("@ref", reference));
        Records.Audit(connection, transaction, actor, "Record payment", $"Bill #{bill} | {method} | {applied} RWF");
        if (applied == balance)
            Database.Execute(connection, transaction, """
                UPDATE customers c JOIN bills b ON b.customer_id=c.id
                SET c.points=c.points+FLOOR(b.total/1000) WHERE b.id=@id
                """, ("@id", bill));
        transaction.Commit();
        return tendered - applied;
    }

    public static void Void(Session actor, int bill)
    {
        Access.Require(Access.Supervisor(actor));
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        LockBill(connection, transaction, bill);
        if (Paid(connection, transaction, bill) > 0)
            throw new InvalidOperationException("Only unpaid bills can be voided.");
        Database.Execute(connection, transaction, """
            UPDATE products p JOIN (SELECT product_id,SUM(quantity) AS qty FROM bill_items
              WHERE bill_id=@bill AND product_id IS NOT NULL GROUP BY product_id) i ON p.id=i.product_id
            SET p.quantity=p.quantity+i.qty
            """, ("@bill", bill));
        Database.Execute(connection, transaction, "UPDATE bills SET voided=1,appointment_id=NULL WHERE id=@bill", ("@bill", bill));
        Records.Audit(connection, transaction, actor, "Void unpaid bill", $"Bill #{bill}");
        transaction.Commit();
    }

    public static DataTable Receipt(Session actor, int bill)
    {
        Access.Require(Access.Desk(actor));
        return Database.Read("""
            SELECT 'Item' AS section,item_name AS description,quantity,ROUND(price*quantity,2) AS amount
              FROM bill_items WHERE bill_id=@id
            UNION ALL SELECT 'Discount','Bill discount',NULL,discount FROM bills WHERE id=@id
            UNION ALL SELECT 'Tax','Tax',NULL,tax FROM bills WHERE id=@id
            UNION ALL SELECT 'Total','Total bill',NULL,total FROM bills WHERE id=@id
            UNION ALL SELECT 'Payment',method,NULL,amount FROM payments WHERE bill_id=@id
            UNION ALL SELECT 'Balance',IF(voided,'Voided bill','Amount due'),NULL,
              total-(SELECT COALESCE(SUM(amount),0) FROM payments WHERE bill_id=@id) FROM bills WHERE id=@id
            """, ("@id", bill));
    }

    private static decimal LockBill(MySqlConnector.MySqlConnection connection,
        MySqlConnector.MySqlTransaction transaction, int bill)
    {
        var amount = Database.Scalar(connection, transaction,
            "SELECT total FROM bills WHERE id=@bill AND voided=0 FOR UPDATE", ("@bill", bill));
        if (amount is null) throw new InvalidOperationException("Select a bill that has not been voided.");
        return Convert.ToDecimal(amount);
    }

    private static decimal Paid(MySqlConnector.MySqlConnection connection,
        MySqlConnector.MySqlTransaction transaction, int bill) => Convert.ToDecimal(Database.Scalar(
            connection, transaction, "SELECT COALESCE(SUM(amount),0) FROM payments WHERE bill_id=@bill", ("@bill", bill)));

    private static void Recalculate(MySqlConnector.MySqlConnection connection,
        MySqlConnector.MySqlTransaction transaction, int bill, decimal discount)
    {
        decimal subtotal = Convert.ToDecimal(Database.Scalar(connection, transaction,
            "SELECT COALESCE(SUM(price*quantity),0) FROM bill_items WHERE bill_id=@bill", ("@bill", bill)));
        decimal rate = Convert.ToDecimal(Database.Scalar(connection, transaction,
            "SELECT r.tax_rate FROM branches r JOIN bills b ON b.branch_id=r.id WHERE b.id=@bill", ("@bill", bill)));
        decimal tax = Math.Round((subtotal-discount)*rate/100, 2, MidpointRounding.AwayFromZero);
        Database.Execute(connection, transaction,
            "UPDATE bills SET subtotal=@sub,discount=@discount,tax=@tax,total=@total WHERE id=@bill",
            ("@sub", subtotal), ("@discount", discount), ("@tax", tax),
            ("@total", subtotal-discount+tax), ("@bill", bill));
    }
}
