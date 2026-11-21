using MySqlConnector;

namespace SalonFlow.Views;

internal static class Ui
{
    public static void Run(Action action)
    {
        try { action(); }
        catch (InvalidOperationException error) { MessageBox.Show(error.Message, "SalonFlow"); }
        catch (IOException error) { MessageBox.Show(error.Message, "SalonFlow"); }
        catch (MySqlException error)
        {
            string message = error.Number switch
            {
                1062 => "A record with those details already exists.",
                1451 => "This record is used by another record and cannot be removed.",
                1452 => "One of the selected records no longer exists. Refresh and try again.",
                _ => "Database error. Check XAMPP MySQL and Database.config.\n" + error.Message
            };
            MessageBox.Show(message, "SalonFlow");
        }
    }
}
