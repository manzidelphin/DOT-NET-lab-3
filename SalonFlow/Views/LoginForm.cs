using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public Session? SignedInUser { get; private set; }

        private void LogIn(object? sender, EventArgs e)
        {
            Ui.Run(() =>
            {
                SignedInUser = Accounts.SignIn(txtUser.Text, txtPassword.Text);
                DialogResult = DialogResult.OK;
            });
        }

        private void Register(object? sender, EventArgs e)
        {
            using var form = new RegisterForm();
            form.ShowDialog(this);
        }

    }
}
