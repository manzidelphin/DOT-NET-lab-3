using SalonFlow.Models;

namespace SalonFlow.Controllers;

internal static class Access
{
    public static bool Supervisor(Session user) => user.Role is "Owner" or "Manager";
    public static bool Desk(Session user) => Supervisor(user) || user.Role == "Receptionist";

    public static bool CanOpen(Session user, string module) => module switch
    {
        "Password" or "Services" or "Appointments" => true,
        "Customers" or "Queue" or "Inventory" => Desk(user) || user.Role == "Stylist" && module == "Queue",
        "Billing" => Desk(user),
        "Staff" or "Accounts" or "Expenses" or "Promotions" => Supervisor(user),
        "Reports" => Desk(user) || user.Role == "Stylist",
        "Branches" or "Audit" => user.Role == "Owner",
        _ => false
    };

    public static void Require(bool allowed)
    {
        if (!allowed) throw new InvalidOperationException("Your role cannot perform this action.");
    }
}
