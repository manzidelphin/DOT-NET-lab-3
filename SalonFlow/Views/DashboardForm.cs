using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private Session? session;

        public DashboardForm(Session user) : this()
        {
            session = user;
            lblWelcome.Text = $"{user.Name}  |  {user.Role}";
            btnCustomers.Visible = Access.CanOpen(user, "Customers");
            btnServices.Visible = Access.CanOpen(user, "Services");
            btnStaff.Visible = Access.CanOpen(user, "Staff");
            btnAppointments.Visible = Access.CanOpen(user, "Appointments");
            btnQueue.Visible = Access.CanOpen(user, "Queue");
            btnBilling.Visible = Access.CanOpen(user, "Billing");
            btnInventory.Visible = Access.CanOpen(user, "Inventory");
            btnExpenses.Visible = Access.CanOpen(user, "Expenses");
            btnReports.Visible = Access.CanOpen(user, "Reports");
            btnAccounts.Visible = Access.CanOpen(user, "Accounts");
            btnBranches.Visible = Access.CanOpen(user, "Branches");
            btnAudit.Visible = Access.CanOpen(user, "Audit");
            btnPromotions.Visible = Access.CanOpen(user, "Promotions");
            btnPassword.Visible = Access.CanOpen(user, "Password");
        }

        private void OpenModule(object? sender, EventArgs e)
        {
            if (session is null || sender is not Button button) return;
            string module = button.Name.Substring(3);
            if (!Access.CanOpen(session, module)) return;
            Ui.Run(() =>
            {
                using Form form = module switch
                {
                    "Customers" => new CustomersForm(session),
                    "Services" => new ServicesForm(session),
                    "Staff" => new StaffForm(session),
                    "Appointments" => new AppointmentsForm(session),
                    "Queue" => new QueueForm(session),
                    "Billing" => new BillingForm(session),
                    "Inventory" => new InventoryForm(session),
                    "Expenses" => new ExpensesForm(session),
                    "Reports" => new ReportsForm(session),
                    "Accounts" => new AccountsForm(session),
                    "Branches" => new BranchesForm(session),
                    "Audit" => new AuditForm(session),
                    "Promotions" => new PromotionsForm(session),
                    "Password" => new PasswordForm(session),
                    _ => throw new InvalidOperationException("This screen is unavailable.")
                };
                form.ShowDialog(this);
            });
        }

        private void LogOut(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

    }
}
