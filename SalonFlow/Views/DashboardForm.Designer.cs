using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class DashboardForm
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
            this.lblWelcome = new Label();
            this.btnCustomers = new Button();
            this.btnServices = new Button();
            this.btnStaff = new Button();
            this.btnAppointments = new Button();
            this.btnQueue = new Button();
            this.btnBilling = new Button();
            this.btnInventory = new Button();
            this.btnExpenses = new Button();
            this.btnReports = new Button();
            this.btnAccounts = new Button();
            this.btnBranches = new Button();
            this.btnAudit = new Button();
            this.btnPromotions = new Button();
            this.btnPassword = new Button();
            this.btnLogout = new Button();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(652, 40);
            this.lblTitle.Text = "SalonFlow";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Location = new Point(26, 66);
            this.lblWelcome.Size = new Size(650, 24);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Location = new Point(26, 104);
            this.btnCustomers.Size = new Size(205, 33);
            this.btnCustomers.Text = "Customer records";
            this.btnCustomers.Click += new EventHandler(this.OpenModule);
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnServices.Name = "btnServices";
            this.btnServices.TabIndex = 3;
            this.btnServices.Location = new Point(250, 104);
            this.btnServices.Size = new Size(205, 33);
            this.btnServices.Text = "Service catalogue";
            this.btnServices.Click += new EventHandler(this.OpenModule);
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.TabIndex = 4;
            this.btnStaff.Location = new Point(474, 104);
            this.btnStaff.Size = new Size(205, 33);
            this.btnStaff.Text = "Staff directory";
            this.btnStaff.Click += new EventHandler(this.OpenModule);
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.TabIndex = 5;
            this.btnAppointments.Location = new Point(26, 153);
            this.btnAppointments.Size = new Size(205, 33);
            this.btnAppointments.Text = "Appointments";
            this.btnAppointments.Click += new EventHandler(this.OpenModule);
            this.btnAppointments.UseVisualStyleBackColor = true;
            this.btnQueue.Name = "btnQueue";
            this.btnQueue.TabIndex = 6;
            this.btnQueue.Location = new Point(250, 153);
            this.btnQueue.Size = new Size(205, 33);
            this.btnQueue.Text = "Walk-in queue";
            this.btnQueue.Click += new EventHandler(this.OpenModule);
            this.btnQueue.UseVisualStyleBackColor = true;
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.TabIndex = 7;
            this.btnBilling.Location = new Point(474, 153);
            this.btnBilling.Size = new Size(205, 33);
            this.btnBilling.Text = "Billing and payments";
            this.btnBilling.Click += new EventHandler(this.OpenModule);
            this.btnBilling.UseVisualStyleBackColor = true;
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.TabIndex = 8;
            this.btnInventory.Location = new Point(26, 202);
            this.btnInventory.Size = new Size(205, 33);
            this.btnInventory.Text = "Inventory";
            this.btnInventory.Click += new EventHandler(this.OpenModule);
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.TabIndex = 9;
            this.btnExpenses.Location = new Point(250, 202);
            this.btnExpenses.Size = new Size(205, 33);
            this.btnExpenses.Text = "Expenses";
            this.btnExpenses.Click += new EventHandler(this.OpenModule);
            this.btnExpenses.UseVisualStyleBackColor = true;
            this.btnReports.Name = "btnReports";
            this.btnReports.TabIndex = 10;
            this.btnReports.Location = new Point(474, 202);
            this.btnReports.Size = new Size(205, 33);
            this.btnReports.Text = "Reports";
            this.btnReports.Click += new EventHandler(this.OpenModule);
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.TabIndex = 11;
            this.btnAccounts.Location = new Point(26, 251);
            this.btnAccounts.Size = new Size(205, 33);
            this.btnAccounts.Text = "User accounts";
            this.btnAccounts.Click += new EventHandler(this.OpenModule);
            this.btnAccounts.UseVisualStyleBackColor = true;
            this.btnBranches.Name = "btnBranches";
            this.btnBranches.TabIndex = 12;
            this.btnBranches.Location = new Point(250, 251);
            this.btnBranches.Size = new Size(205, 33);
            this.btnBranches.Text = "Branches and settings";
            this.btnBranches.Click += new EventHandler(this.OpenModule);
            this.btnBranches.UseVisualStyleBackColor = true;
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.TabIndex = 13;
            this.btnAudit.Location = new Point(474, 251);
            this.btnAudit.Size = new Size(205, 33);
            this.btnAudit.Text = "Audit history";
            this.btnAudit.Click += new EventHandler(this.OpenModule);
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnPromotions.Name = "btnPromotions";
            this.btnPromotions.TabIndex = 14;
            this.btnPromotions.Location = new Point(26, 300);
            this.btnPromotions.Size = new Size(205, 33);
            this.btnPromotions.Text = "Promotions";
            this.btnPromotions.Click += new EventHandler(this.OpenModule);
            this.btnPromotions.UseVisualStyleBackColor = true;
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.TabIndex = 15;
            this.btnPassword.Location = new Point(250, 300);
            this.btnPassword.Size = new Size(205, 33);
            this.btnPassword.Text = "Change password";
            this.btnPassword.Click += new EventHandler(this.OpenModule);
            this.btnPassword.UseVisualStyleBackColor = true;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.TabIndex = 16;
            this.btnLogout.Location = new Point(26, 365);
            this.btnLogout.Size = new Size(120, 33);
            this.btnLogout.Text = "Log out";
            this.btnLogout.Click += new EventHandler(this.LogOut);
            this.btnLogout.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 423);
            this.Text = "SalonFlow - Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DashboardForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnServices);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnQueue);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnExpenses);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnAccounts);
            this.Controls.Add(this.btnBranches);
            this.Controls.Add(this.btnAudit);
            this.Controls.Add(this.btnPromotions);
            this.Controls.Add(this.btnPassword);
            this.Controls.Add(this.btnLogout);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private Label lblWelcome = null!;
        private Button btnCustomers = null!;
        private Button btnServices = null!;
        private Button btnStaff = null!;
        private Button btnAppointments = null!;
        private Button btnQueue = null!;
        private Button btnBilling = null!;
        private Button btnInventory = null!;
        private Button btnExpenses = null!;
        private Button btnReports = null!;
        private Button btnAccounts = null!;
        private Button btnBranches = null!;
        private Button btnAudit = null!;
        private Button btnPromotions = null!;
        private Button btnPassword = null!;
        private Button btnLogout = null!;
    }
}
