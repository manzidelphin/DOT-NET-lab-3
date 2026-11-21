using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class AccountsForm
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
            this.recordsGrid = new DataGridView();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblRole = new Label();
            this.txtRole = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnRefresh = new Button();
            this.btnCreateAccount = new Button();
            this.btnToggleAccount = new Button();
            ((ISupportInitialize)this.recordsGrid).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(852, 40);
            this.lblTitle.Text = "User accounts";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.recordsGrid.Name = "recordsGrid";
            this.recordsGrid.TabIndex = 1;
            this.recordsGrid.Location = new Point(24, 73);
            this.recordsGrid.Size = new Size(852, 260);
            this.recordsGrid.ReadOnly = true;
            this.recordsGrid.AllowUserToAddRows = false;
            this.recordsGrid.AllowUserToDeleteRows = false;
            this.recordsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.recordsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.recordsGrid.MultiSelect = false;
            this.recordsGrid.RowHeadersVisible = false;
            this.lblName.Name = "lblName";
            this.lblName.TabIndex = 2;
            this.lblName.Location = new Point(24, 352);
            this.lblName.Size = new Size(270, 24);
            this.lblName.Text = "Full name";
            this.txtName.Name = "txtName";
            this.txtName.TabIndex = 3;
            this.txtName.Location = new Point(24, 374);
            this.txtName.Size = new Size(260, 25);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Location = new Point(309, 352);
            this.lblEmail.Size = new Size(270, 24);
            this.lblEmail.Text = "Email";
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Location = new Point(309, 374);
            this.txtEmail.Size = new Size(260, 25);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Location = new Point(594, 352);
            this.lblPhone.Size = new Size(270, 24);
            this.lblPhone.Text = "Phone";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.TabIndex = 7;
            this.txtPhone.Location = new Point(594, 374);
            this.txtPhone.Size = new Size(260, 25);
            this.lblRole.Name = "lblRole";
            this.lblRole.TabIndex = 8;
            this.lblRole.Location = new Point(24, 407);
            this.lblRole.Size = new Size(270, 24);
            this.lblRole.Text = "Manager, Receptionist or Stylist";
            this.txtRole.Name = "txtRole";
            this.txtRole.TabIndex = 9;
            this.txtRole.Location = new Point(24, 429);
            this.txtRole.Size = new Size(260, 25);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Location = new Point(309, 407);
            this.lblPassword.Size = new Size(270, 24);
            this.lblPassword.Text = "Temporary password";
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TabIndex = 11;
            this.txtPassword.Location = new Point(309, 429);
            this.txtPassword.Size = new Size(260, 25);
            this.txtPassword.UseSystemPasswordChar = true;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Location = new Point(24, 485);
            this.btnRefresh.Size = new Size(115, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.RefreshRecords);
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.TabIndex = 13;
            this.btnCreateAccount.Location = new Point(150, 485);
            this.btnCreateAccount.Size = new Size(166, 33);
            this.btnCreateAccount.Text = "Create staff account";
            this.btnCreateAccount.Click += new EventHandler(this.CreateAccount);
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnToggleAccount.Name = "btnToggleAccount";
            this.btnToggleAccount.TabIndex = 14;
            this.btnToggleAccount.Location = new Point(328, 485);
            this.btnToggleAccount.Size = new Size(166, 33);
            this.btnToggleAccount.Text = "Activate / deactivate";
            this.btnToggleAccount.Click += new EventHandler(this.ToggleAccount);
            this.btnToggleAccount.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 537);
            this.Text = "SalonFlow - User accounts";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AccountsForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnToggleAccount);
            ((ISupportInitialize)this.recordsGrid).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private DataGridView recordsGrid = null!;
        private Label lblName = null!;
        private TextBox txtName = null!;
        private Label lblEmail = null!;
        private TextBox txtEmail = null!;
        private Label lblPhone = null!;
        private TextBox txtPhone = null!;
        private Label lblRole = null!;
        private TextBox txtRole = null!;
        private Label lblPassword = null!;
        private TextBox txtPassword = null!;
        private Button btnRefresh = null!;
        private Button btnCreateAccount = null!;
        private Button btnToggleAccount = null!;
    }
}
