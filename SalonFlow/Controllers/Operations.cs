using System.Data;
using SalonFlow.Data;
using SalonFlow.Models;

namespace SalonFlow.Controllers;

internal static class Operations
{
    public static DataTable ListAccounts(Session user)
    {
        Access.Require(Access.Supervisor(user));
        return Database.Read("SELECT id,name,email,phone,role,IF(active,'Active','Inactive') AS status FROM users ORDER BY id");
    }

    public static DataTable ListAudit(Session user, string value)
    {
        Access.Require(user.Role == "Owner");
        return Database.Read("SELECT a.id,u.name,a.action,a.details,a.recorded_at FROM audit_log a " +
            "JOIN users u ON u.id=a.user_id WHERE CONCAT_WS(' ',u.name,a.action,a.details) LIKE @value " +
            "ORDER BY a.id DESC", ("@value", "%" + value + "%"));
    }

    public static DataTable BookingServices() =>
        Database.Read("SELECT id,name,price,minutes FROM services WHERE active=1 ORDER BY name");

    public static DataTable BookingStaff() =>
        Database.Read("SELECT s.id,s.name,b.name AS branch FROM staff s JOIN branches b ON b.id=s.branch_id ORDER BY s.name");

    public static DataTable BookingCustomers(Session user)
    {
        Access.Require(Access.Desk(user));
        return Database.Read("SELECT id,name,phone FROM customers ORDER BY name");
    }

    public static DataTable ListAppointments(Session user) => Database.Read(
        "SELECT a.id,c.name AS customer,c.id AS customer_id,s.name AS stylist,s.id AS stylist_id," +
        "v.name AS service,v.id AS service_id,a.start_at,a.end_at,a.price,a.status " +
        "FROM appointments a JOIN customers c ON c.id=a.customer_id JOIN staff s ON s.id=a.staff_id " +
        "JOIN services v ON v.id=a.service_id WHERE @desk=1 OR a.customer_id=@customer OR s.user_id=@stylist " +
        "ORDER BY a.start_at DESC", ("@desk", Access.Desk(user) ? 1 : 0),
        ("@customer", user.CustomerId), ("@stylist", user.Role == "Stylist" ? user.Id : (int?)null));

    public static void Book(Session actor, int? id, int customer, int staff, int service, DateTime start)
    {
        Access.Require(Access.Desk(actor) || actor.CustomerId == customer);
        if (start < DateTime.Now) throw new InvalidOperationException("Choose a future appointment time.");
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        // Lock the stylist row so two users cannot reserve overlapping times at once.
        if (Database.Scalar(connection, transaction, "SELECT id FROM staff WHERE id=@id FOR UPDATE", ("@id", staff)) is null)
            throw new InvalidOperationException("Choose an existing stylist.");
        using var command = Database.Command(connection, transaction,
            "SELECT minutes,price FROM services WHERE id=@id AND active=1", ("@id", service));
        using var reader = command.ExecuteReader();
        if (!reader.Read()) throw new InvalidOperationException("Choose an active service.");
        DateTime end = start.AddMinutes(reader.GetInt32(0));
        decimal price = reader.GetDecimal(1);
        reader.Close();

        if (Database.Scalar(connection, transaction,
            "SELECT id FROM appointments WHERE staff_id=@staff AND status NOT IN ('Cancelled','No-show') " +
            "AND start_at<@end AND end_at>@start AND (@id IS NULL OR id<>@id) LIMIT 1 FOR UPDATE",
            ("@staff", staff), ("@end", end), ("@start", start), ("@id", id)) is not null)
            throw new InvalidOperationException("This stylist is already booked at that time.");

        var values = new (string, object?)[] { ("@customer", customer), ("@staff", staff), ("@service", service),
            ("@start", start), ("@end", end), ("@price", price), ("@id", id), ("@desk", Access.Desk(actor) ? 1 : 0) };
        if (id.HasValue)
        {
            int updated = Database.Execute(connection, transaction,
                "UPDATE appointments SET customer_id=@customer,staff_id=@staff,service_id=@service,start_at=@start," +
                "end_at=@end,price=@price,status='Booked' WHERE id=@id AND status IN ('Booked','Confirmed') " +
                "AND (@desk=1 OR (customer_id=@customer AND start_at>NOW()))", values);
            if (updated == 0) throw new InvalidOperationException("This appointment cannot be rescheduled.");
        }
        else
        {
            Database.Execute(connection, transaction,
                "INSERT INTO appointments(customer_id,staff_id,service_id,start_at,end_at,price,status) " +
                "VALUES(@customer,@staff,@service,@start,@end,@price,'Booked')", values);
        }
        transaction.Commit();
    }

    public static void AppointmentStatus(Session actor, int id, string status)
    {
        Access.Require(Access.Desk(actor) || actor.CustomerId.HasValue && status == "Cancelled");
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        var current = Database.Scalar(connection, transaction,
            "SELECT status FROM appointments WHERE id=@id AND (@desk=1 OR (customer_id=@customer AND start_at>NOW())) FOR UPDATE",
            ("@id", id), ("@desk", Access.Desk(actor) ? 1 : 0), ("@customer", actor.CustomerId)) as string;
        bool allowed = (current, status) switch
        {
            ("Booked", "Confirmed" or "Checked in" or "Cancelled" or "No-show") => true,
            ("Confirmed", "Checked in" or "Cancelled" or "No-show") => true,
            ("Checked in", "In service" or "Cancelled") => Access.Desk(actor),
            ("In service", "Completed" or "Cancelled") => Access.Desk(actor),
            _ => false
        };
        if (!allowed) throw new InvalidOperationException("This status change is unavailable for the selected appointment.");
        Database.Execute(connection, transaction, "UPDATE appointments SET status=@status WHERE id=@id",
            ("@status", status), ("@id", id));
        transaction.Commit();
    }

    public static DataTable ListQueue(Session actor)
    {
        Access.Require(Access.CanOpen(actor, "Queue"));
        return Database.Read("SELECT q.id,c.name AS customer,v.name AS service,s.name AS stylist," +
            "q.arrived_at,q.status FROM queue q JOIN customers c ON c.id=q.customer_id " +
            "JOIN services v ON v.id=q.service_id LEFT JOIN staff s ON s.id=q.staff_id " +
            "ORDER BY q.arrived_at,q.id");
    }

    public static void Enqueue(Session actor, int customer, int service)
    {
        Access.Require(Access.Desk(actor));
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        int count = Database.Execute(connection, transaction,
            "INSERT INTO queue(customer_id,service_id) SELECT @customer,id FROM services WHERE id=@service AND active=1",
            ("@customer", customer), ("@service", service));
        if (count == 0) throw new InvalidOperationException("Choose an active service.");
        transaction.Commit();
    }

    public static void AssignNext(Session actor, int staff)
    {
        Access.Require(Access.Desk(actor));
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        if (Database.Scalar(connection, transaction, "SELECT id FROM staff WHERE id=@staff FOR UPDATE", ("@staff", staff)) is null)
            throw new InvalidOperationException("Choose an existing stylist.");
        if (Database.Scalar(connection, transaction,
            "SELECT id FROM queue WHERE staff_id=@staff AND status='In service' LIMIT 1 FOR UPDATE", ("@staff", staff)) is not null)
            throw new InvalidOperationException("This stylist is already serving a walk-in.");
        int count = Database.Execute(connection, transaction,
            "UPDATE queue SET staff_id=@staff,status='In service' WHERE status='Waiting' ORDER BY arrived_at,id LIMIT 1",
            ("@staff", staff));
        if (count == 0) throw new InvalidOperationException("No customer is waiting.");
        transaction.Commit();
    }

    public static void QueueStatus(Session actor, int id, string status)
    {
        Access.Require(Access.Desk(actor));
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        int count = Database.Execute(connection, transaction,
            "UPDATE queue SET status=@status WHERE id=@id AND (status='In service' OR (status='Waiting' AND @status='Cancelled'))",
            ("@status", status), ("@id", id));
        if (count == 0) throw new InvalidOperationException("This walk-in cannot move to that status.");
        transaction.Commit();
    }
    public static DataTable VisitHistory(Session actor, int customer)
    {
        Access.Require(Access.Desk(actor));
        return Database.Read("""
            SELECT a.start_at AS visit_date,v.name AS service,s.name AS stylist,a.price AS booked_price_rwf,
              b.id AS bill_number
            FROM appointments a JOIN services v ON v.id=a.service_id JOIN staff s ON s.id=a.staff_id
              LEFT JOIN bills b ON b.appointment_id=a.id AND b.voided=0
            WHERE a.customer_id=@customer AND a.status='Completed' ORDER BY a.start_at DESC
            """, ("@customer", customer));
    }
}
