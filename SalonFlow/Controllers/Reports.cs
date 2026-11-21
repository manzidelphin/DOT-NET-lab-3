using System.Data;
using SalonFlow.Data;
using SalonFlow.Models;

namespace SalonFlow.Controllers;

internal static class Reports
{
    public static DataTable Run(Session actor, string report, DateTime from, DateTime to)
    {
        Access.Require(Access.CanOpen(actor, "Reports"));
        if (to < from || to >= new DateTime(9999, 12, 31))
            throw new InvalidOperationException("Choose a valid reporting date range.");
        if (actor.Role == "Receptionist" && (report != "Sales" || from.Date != to.Date))
            throw new InvalidOperationException("Receptionists can view sales for one day at a time.");
        if (actor.Role == "Stylist" && report != "Commission")
            throw new InvalidOperationException("Stylists can view their own commission.");
        string sql = report switch
        {
            "Sales" => """
                SELECT DATE(p.paid_at) AS day,p.method,COUNT(*) AS payments,SUM(p.amount) AS revenue_rwf
                FROM payments p JOIN bills b ON b.id=p.bill_id WHERE b.voided=0 AND p.paid_at>=@from AND p.paid_at<@end
                GROUP BY DATE(p.paid_at),p.method ORDER BY day,p.method
                """,
            "Services" => """
                SELECT i.item_name AS service,SUM(i.quantity) AS units,SUM(i.price*i.quantity) AS gross_sales_rwf
                FROM bill_items i JOIN bills b ON b.id=i.bill_id
                WHERE b.voided=0 AND i.service_id IS NOT NULL AND b.created_at>=@from AND b.created_at<@end
                  AND b.total=(SELECT COALESCE(SUM(amount),0) FROM payments WHERE bill_id=b.id)
                GROUP BY i.item_name ORDER BY gross_sales_rwf DESC
                """,
            "Commission" => """
                SELECT s.name AS stylist,COUNT(*) AS paid_appointments,
                  SUM(a.price) AS booked_service_value_rwf,ROUND(SUM(a.price*s.commission/100),2) AS commission_rwf
                FROM appointments a JOIN staff s ON a.staff_id=s.id JOIN bills b ON b.appointment_id=a.id
                WHERE b.voided=0 AND b.total>0 AND a.status='Completed' AND a.start_at>=@from AND a.start_at<@end
                  AND (@stylist IS NULL OR s.user_id=@stylist)
                  AND b.total=(SELECT COALESCE(SUM(amount),0) FROM payments WHERE bill_id=b.id)
                GROUP BY s.id,s.name ORDER BY stylist
                """,
            "Stock" => """
                SELECT sku,name,kind,quantity,reorder_level,
                  IF(quantity<=reorder_level,'Low stock','OK') AS status FROM products ORDER BY name
                """,
            "Appointments" => """
                SELECT status,COUNT(*) AS appointments FROM appointments WHERE start_at>=@from AND start_at<@end GROUP BY status
                """,
            "Profit" => """
                SELECT revenue_rwf,expenses_rwf,revenue_rwf-expenses_rwf AS estimated_net_rwf
                FROM (
                  SELECT (SELECT COALESCE(SUM(p.amount),0) FROM payments p JOIN bills b ON b.id=p.bill_id
                    WHERE b.voided=0 AND p.paid_at>=@from AND p.paid_at<@end) AS revenue_rwf,
                    (SELECT COALESCE(SUM(amount),0) FROM expenses WHERE spent_on>=@from AND spent_on<@end) AS expenses_rwf
                ) totals
                """,
            _ => throw new InvalidOperationException("Choose a report type.")
        };
        return Database.Read(sql, ("@from", from.Date), ("@end", to.Date.AddDays(1)),
            ("@stylist", actor.Role == "Stylist" ? actor.Id : (int?)null));
    }
}
