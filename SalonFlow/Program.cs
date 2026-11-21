using SalonFlow.Views;

namespace SalonFlow;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        while (true)
        {
            using var login = new LoginForm();
            if (login.ShowDialog() != DialogResult.OK || login.SignedInUser is null) return;
            using var dashboard = new DashboardForm(login.SignedInUser);
            using var timeout = new SessionTimeout(dashboard);
            if (dashboard.ShowDialog() != DialogResult.Retry) return;
        }
    }
}
