using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        private readonly Session? session;

        public PasswordForm(Session user) : this()
        {
            session = user;
        }

        private void SavePassword(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Accounts.ChangePassword(session, txtCurrent.Text, txtNew.Text, txtConfirm.Text);
                MessageBox.Show("Password updated.", "SalonFlow");
                Close();
            });
        }

    }
}
