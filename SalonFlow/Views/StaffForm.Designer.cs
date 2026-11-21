using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class StaffForm
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
            this.lblFilter = new Label();
            this.txtFilter = new TextBox();
            this.recordsGrid = new DataGridView();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblBranch = new Label();
            this.txtBranch = new TextBox();
            this.lblUser = new Label();
            this.txtUser = new TextBox();
            this.lblCommission = new Label();
            this.txtCommission = new TextBox();
            this.btnRefresh = new Button();
            this.btnLoad = new Button();
            this.btnNew = new Button();
            this.btnSave = new Button();
            this.btnDelete = new Button();
            ((ISupportInitialize)this.recordsGrid).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(852, 40);
            this.lblTitle.Text = "Staff directory";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Location = new Point(24, 66);
            this.lblFilter.Size = new Size(160, 24);
            this.lblFilter.Text = "Search records";
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.TabIndex = 2;
            this.txtFilter.Location = new Point(140, 64);
            this.txtFilter.Size = new Size(260, 25);
            this.txtFilter.TextChanged += new EventHandler(this.Filter);
            this.recordsGrid.Name = "recordsGrid";
            this.recordsGrid.TabIndex = 3;
            this.recordsGrid.Location = new Point(24, 102);
            this.recordsGrid.Size = new Size(850, 260);
            this.recordsGrid.ReadOnly = true;
            this.recordsGrid.AllowUserToAddRows = false;
            this.recordsGrid.AllowUserToDeleteRows = false;
            this.recordsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.recordsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.recordsGrid.MultiSelect = false;
            this.recordsGrid.RowHeadersVisible = false;
            this.lblName.Name = "lblName";
            this.lblName.TabIndex = 4;
            this.lblName.Location = new Point(24, 382);
            this.lblName.Size = new Size(270, 24);
            this.lblName.Text = "Full name";
            this.txtName.Name = "txtName";
            this.txtName.TabIndex = 5;
            this.txtName.Location = new Point(24, 404);
            this.txtName.Size = new Size(260, 25);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Location = new Point(309, 382);
            this.lblPhone.Size = new Size(270, 24);
            this.lblPhone.Text = "Phone";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.TabIndex = 7;
            this.txtPhone.Location = new Point(309, 404);
            this.txtPhone.Size = new Size(260, 25);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.TabIndex = 8;
            this.lblBranch.Location = new Point(594, 382);
            this.lblBranch.Size = new Size(270, 24);
            this.lblBranch.Text = "Branch ID";
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.TabIndex = 9;
            this.txtBranch.Location = new Point(594, 404);
            this.txtBranch.Size = new Size(260, 25);
            this.lblUser.Name = "lblUser";
            this.lblUser.TabIndex = 10;
            this.lblUser.Location = new Point(24, 445);
            this.lblUser.Size = new Size(270, 24);
            this.lblUser.Text = "Stylist account ID (optional)";
            this.txtUser.Name = "txtUser";
            this.txtUser.TabIndex = 11;
            this.txtUser.Location = new Point(24, 467);
            this.txtUser.Size = new Size(260, 25);
            this.lblCommission.Name = "lblCommission";
            this.lblCommission.TabIndex = 12;
            this.lblCommission.Location = new Point(309, 445);
            this.lblCommission.Size = new Size(270, 24);
            this.lblCommission.Text = "Commission (%)";
            this.txtCommission.Name = "txtCommission";
            this.txtCommission.TabIndex = 13;
            this.txtCommission.Location = new Point(309, 467);
            this.txtCommission.Size = new Size(260, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Location = new Point(24, 518);
            this.btnRefresh.Size = new Size(115, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.RefreshRecords);
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.TabIndex = 15;
            this.btnLoad.Location = new Point(150, 518);
            this.btnLoad.Size = new Size(140, 33);
            this.btnLoad.Text = "Load selected";
            this.btnLoad.Click += new EventHandler(this.LoadSelected);
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnNew.Name = "btnNew";
            this.btnNew.TabIndex = 16;
            this.btnNew.Location = new Point(300, 518);
            this.btnNew.Size = new Size(120, 33);
            this.btnNew.Text = "Clear fields";
            this.btnNew.Click += new EventHandler(this.ClearFields);
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 17;
            this.btnSave.Location = new Point(430, 518);
            this.btnSave.Size = new Size(120, 33);
            this.btnSave.Text = "Add / save";
            this.btnSave.Click += new EventHandler(this.SaveRecord);
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Location = new Point(560, 518);
            this.btnDelete.Size = new Size(145, 33);
            this.btnDelete.Text = "Delete selected";
            this.btnDelete.Click += new EventHandler(this.DeleteRecord);
            this.btnDelete.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 575);
            this.Text = "SalonFlow - Staff directory";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StaffForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblCommission);
            this.Controls.Add(this.txtCommission);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            ((ISupportInitialize)this.recordsGrid).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private Label lblFilter = null!;
        private TextBox txtFilter = null!;
        private DataGridView recordsGrid = null!;
        private Label lblName = null!;
        private TextBox txtName = null!;
        private Label lblPhone = null!;
        private TextBox txtPhone = null!;
        private Label lblBranch = null!;
        private TextBox txtBranch = null!;
        private Label lblUser = null!;
        private TextBox txtUser = null!;
        private Label lblCommission = null!;
        private TextBox txtCommission = null!;
        private Button btnRefresh = null!;
        private Button btnLoad = null!;
        private Button btnNew = null!;
        private Button btnSave = null!;
        private Button btnDelete = null!;
    }
}
