using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void Create(object? sender, EventArgs e)
        {
            Ui.Run(() =>
            {
                Accounts.Register(txtName.Text, txtEmail.Text, txtPhone.Text, txtPassword.Text, txtConfirm.Text);
                MessageBox.Show("Your account is ready. Log in with your email or phone.", "SalonFlow");
                DialogResult = DialogResult.OK;
            });
        }

    }
}
