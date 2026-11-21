using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class QueueForm
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
            this.lblCustomer = new Label();
            this.txtCustomer = new TextBox();
            this.lblService = new Label();
            this.txtService = new TextBox();
            this.lblStaff = new Label();
            this.txtStaff = new TextBox();
            this.lblStatus = new Label();
            this.txtStatus = new TextBox();
            this.btnRefresh = new Button();
            this.btnAdd = new Button();
            this.btnAssign = new Button();
            this.btnUpdate = new Button();
            ((ISupportInitialize)this.recordsGrid).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(852, 40);
            this.lblTitle.Text = "Walk-in queue";
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
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Location = new Point(24, 352);
            this.lblCustomer.Size = new Size(270, 24);
            this.lblCustomer.Text = "Customer ID";
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.TabIndex = 3;
            this.txtCustomer.Location = new Point(24, 374);
            this.txtCustomer.Size = new Size(260, 25);
            this.lblService.Name = "lblService";
            this.lblService.TabIndex = 4;
            this.lblService.Location = new Point(309, 352);
            this.lblService.Size = new Size(270, 24);
            this.lblService.Text = "Service ID";
            this.txtService.Name = "txtService";
            this.txtService.TabIndex = 5;
            this.txtService.Location = new Point(309, 374);
            this.txtService.Size = new Size(260, 25);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.TabIndex = 6;
            this.lblStaff.Location = new Point(594, 352);
            this.lblStaff.Size = new Size(270, 24);
            this.lblStaff.Text = "Stylist ID";
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.TabIndex = 7;
            this.txtStaff.Location = new Point(594, 374);
            this.txtStaff.Size = new Size(260, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Location = new Point(24, 407);
            this.lblStatus.Size = new Size(270, 24);
            this.lblStatus.Text = "Completed or Cancelled";
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.TabIndex = 9;
            this.txtStatus.Location = new Point(24, 429);
            this.txtStatus.Size = new Size(260, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Location = new Point(24, 485);
            this.btnRefresh.Size = new Size(115, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.RefreshRecords);
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Location = new Point(150, 485);
            this.btnAdd.Size = new Size(166, 33);
            this.btnAdd.Text = "Add walk-in";
            this.btnAdd.Click += new EventHandler(this.Add);
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.TabIndex = 12;
            this.btnAssign.Location = new Point(328, 485);
            this.btnAssign.Size = new Size(166, 33);
            this.btnAssign.Text = "Assign next waiting";
            this.btnAssign.Click += new EventHandler(this.Assign);
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Location = new Point(506, 485);
            this.btnUpdate.Size = new Size(166, 33);
            this.btnUpdate.Text = "Update selected";
            this.btnUpdate.Click += new EventHandler(this.Update);
            this.btnUpdate.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 537);
            this.Text = "SalonFlow - Walk-in queue";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "QueueForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.txtService);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.txtStaff);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnUpdate);
            ((ISupportInitialize)this.recordsGrid).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private DataGridView recordsGrid = null!;
        private Label lblCustomer = null!;
        private TextBox txtCustomer = null!;
        private Label lblService = null!;
        private TextBox txtService = null!;
        private Label lblStaff = null!;
        private TextBox txtStaff = null!;
        private Label lblStatus = null!;
        private TextBox txtStatus = null!;
        private Button btnRefresh = null!;
        private Button btnAdd = null!;
        private Button btnAssign = null!;
        private Button btnUpdate = null!;
    }
}
