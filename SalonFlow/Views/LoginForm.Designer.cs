using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class LoginForm
    {
        private IContainer? components;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblUser = new Label();
            this.txtUser = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnRegister = new Button();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(447, 40);
            this.lblTitle.Text = "Log in";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblUser.Name = "lblUser";
            this.lblUser.TabIndex = 1;
            this.lblUser.Location = new Point(26, 80);
            this.lblUser.Size = new Size(160, 24);
            this.lblUser.Text = "Email or phone";
            this.txtUser.Name = "txtUser";
            this.txtUser.TabIndex = 2;
            this.txtUser.Location = new Point(190, 78);
            this.txtUser.Size = new Size(270, 25);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Location = new Point(26, 123);
            this.lblPassword.Size = new Size(160, 24);
            this.lblPassword.Text = "Password";
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Location = new Point(190, 121);
            this.txtPassword.Size = new Size(270, 25);
            this.txtPassword.UseSystemPasswordChar = true;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Location = new Point(190, 174);
            this.btnLogin.Size = new Size(105, 33);
            this.btnLogin.Text = "Log in";
            this.btnLogin.Click += new EventHandler(this.LogIn);
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Location = new Point(310, 174);
            this.btnRegister.Size = new Size(150, 33);
            this.btnRegister.Text = "Create account";
            this.btnRegister.Click += new EventHandler(this.Register);
            this.btnRegister.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(495, 258);
            this.Text = "SalonFlow - Log in";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.AcceptButton = this.btnLogin;
            this.Name = "LoginForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private Label lblUser = null!;
        private TextBox txtUser = null!;
        private Label lblPassword = null!;
        private TextBox txtPassword = null!;
        private Button btnLogin = null!;
        private Button btnRegister = null!;
    }
}
