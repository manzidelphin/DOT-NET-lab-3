using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class AccountsForm : Form
    {
        public AccountsForm()
        {
            InitializeComponent();
        }

        private readonly Session? session;

        public AccountsForm(Session user) : this()
        {
            session = user;
            btnCreateAccount.Enabled = user.Role == "Owner";
            Shown += RefreshRecords;
        }

        private void RefreshRecords(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() => recordsGrid.DataSource = Operations.ListAccounts(session));
        }

        private void CreateAccount(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Accounts.CreateStaff(session, txtName.Text, txtEmail.Text, txtPhone.Text, Input.Choice(txtRole, "role", "Manager", "Receptionist", "Stylist"), txtPassword.Text);
                txtPassword.Clear();
                RefreshRecords(sender, e);
            });
        }

        private void ToggleAccount(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Accounts.Toggle(session, Input.Selected(recordsGrid));
                RefreshRecords(sender, e);
            });
        }

    }
}
