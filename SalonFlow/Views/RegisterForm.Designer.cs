using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class RegisterForm
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
            this.lblIntro = new Label();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConfirm = new Label();
            this.txtConfirm = new TextBox();
            this.btnCreate = new Button();
            this.btnBack = new Button();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(457, 40);
            this.lblTitle.Text = "Create account";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.TabIndex = 1;
            this.lblIntro.Location = new Point(26, 65);
            this.lblIntro.Size = new Size(420, 24);
            this.lblIntro.Text = "Create a SalonFlow customer account.";
            this.lblName.Name = "lblName";
            this.lblName.TabIndex = 2;
            this.lblName.Location = new Point(26, 105);
            this.lblName.Size = new Size(160, 24);
            this.lblName.Text = "Full name";
            this.txtName.Name = "txtName";
            this.txtName.TabIndex = 3;
            this.txtName.Location = new Point(190, 103);
            this.txtName.Size = new Size(270, 25);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Location = new Point(26, 144);
            this.lblEmail.Size = new Size(160, 24);
            this.lblEmail.Text = "Email";
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Location = new Point(190, 142);
            this.txtEmail.Size = new Size(270, 25);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Location = new Point(26, 183);
            this.lblPhone.Size = new Size(160, 24);
            this.lblPhone.Text = "Phone";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.TabIndex = 7;
            this.txtPhone.Location = new Point(190, 181);
            this.txtPhone.Size = new Size(270, 25);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Location = new Point(26, 222);
            this.lblPassword.Size = new Size(160, 24);
            this.lblPassword.Text = "Password";
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TabIndex = 9;
            this.txtPassword.Location = new Point(190, 220);
            this.txtPassword.Size = new Size(270, 25);
            this.txtPassword.UseSystemPasswordChar = true;
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.TabIndex = 10;
            this.lblConfirm.Location = new Point(26, 261);
            this.lblConfirm.Size = new Size(160, 24);
            this.lblConfirm.Text = "Confirm password";
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.TabIndex = 11;
            this.txtConfirm.Location = new Point(190, 259);
            this.txtConfirm.Size = new Size(270, 25);
            this.txtConfirm.UseSystemPasswordChar = true;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Location = new Point(190, 316);
            this.btnCreate.Size = new Size(134, 33);
            this.btnCreate.Text = "Create account";
            this.btnCreate.Click += new EventHandler(this.Create);
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnBack.Name = "btnBack";
            this.btnBack.TabIndex = 13;
            this.btnBack.Location = new Point(330, 316);
            this.btnBack.Size = new Size(130, 33);
            this.btnBack.Text = "Back to log in";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.DialogResult = DialogResult.Cancel;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(505, 374);
            this.Text = "SalonFlow - Create account";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.AcceptButton = this.btnCreate;
            this.CancelButton = this.btnBack;
            this.Name = "RegisterForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnBack);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private Label lblIntro = null!;
        private Label lblName = null!;
        private TextBox txtName = null!;
        private Label lblEmail = null!;
        private TextBox txtEmail = null!;
        private Label lblPhone = null!;
        private TextBox txtPhone = null!;
        private Label lblPassword = null!;
        private TextBox txtPassword = null!;
        private Label lblConfirm = null!;
        private TextBox txtConfirm = null!;
        private Button btnCreate = null!;
        private Button btnBack = null!;
    }
}
