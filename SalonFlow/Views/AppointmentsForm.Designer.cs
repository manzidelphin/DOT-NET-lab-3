using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class AppointmentsForm
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
            this.lblStaff = new Label();
            this.txtStaff = new TextBox();
            this.lblService = new Label();
            this.txtService = new TextBox();
            this.lblStart = new Label();
            this.txtStart = new TextBox();
            this.lblStatus = new Label();
            this.txtStatus = new TextBox();
            this.btnRefresh = new Button();
            this.btnBook = new Button();
            this.btnReschedule = new Button();
            this.btnStatus = new Button();
            this.btnDirectory = new Button();
            ((ISupportInitialize)this.recordsGrid).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(852, 40);
            this.lblTitle.Text = "Appointments";
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
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.TabIndex = 4;
            this.lblStaff.Location = new Point(309, 352);
            this.lblStaff.Size = new Size(270, 24);
            this.lblStaff.Text = "Stylist ID";
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.TabIndex = 5;
            this.txtStaff.Location = new Point(309, 374);
            this.txtStaff.Size = new Size(260, 25);
            this.lblService.Name = "lblService";
            this.lblService.TabIndex = 6;
            this.lblService.Location = new Point(594, 352);
            this.lblService.Size = new Size(270, 24);
            this.lblService.Text = "Service ID";
            this.txtService.Name = "txtService";
            this.txtService.TabIndex = 7;
            this.txtService.Location = new Point(594, 374);
            this.txtService.Size = new Size(260, 25);
            this.lblStart.Name = "lblStart";
            this.lblStart.TabIndex = 8;
            this.lblStart.Location = new Point(24, 407);
            this.lblStart.Size = new Size(270, 24);
            this.lblStart.Text = "Start (yyyy-MM-dd HH:mm)";
            this.txtStart.Name = "txtStart";
            this.txtStart.TabIndex = 9;
            this.txtStart.Location = new Point(24, 429);
            this.txtStart.Size = new Size(260, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Location = new Point(309, 407);
            this.lblStatus.Size = new Size(270, 24);
            this.lblStatus.Text = "New status";
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.TabIndex = 11;
            this.txtStatus.Location = new Point(309, 429);
            this.txtStatus.Size = new Size(260, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Location = new Point(24, 485);
            this.btnRefresh.Size = new Size(115, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.RefreshRecords);
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnBook.Name = "btnBook";
            this.btnBook.TabIndex = 13;
            this.btnBook.Location = new Point(150, 485);
            this.btnBook.Size = new Size(166, 33);
            this.btnBook.Text = "Book appointment";
            this.btnBook.Click += new EventHandler(this.Book);
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnReschedule.Name = "btnReschedule";
            this.btnReschedule.TabIndex = 14;
            this.btnReschedule.Location = new Point(328, 485);
            this.btnReschedule.Size = new Size(166, 33);
            this.btnReschedule.Text = "Reschedule selected";
            this.btnReschedule.Click += new EventHandler(this.Reschedule);
            this.btnReschedule.UseVisualStyleBackColor = true;
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.TabIndex = 15;
            this.btnStatus.Location = new Point(506, 485);
            this.btnStatus.Size = new Size(166, 33);
            this.btnStatus.Text = "Update status";
            this.btnStatus.Click += new EventHandler(this.Status);
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.TabIndex = 16;
            this.btnDirectory.Location = new Point(684, 485);
            this.btnDirectory.Size = new Size(166, 33);
            this.btnDirectory.Text = "Find booking IDs";
            this.btnDirectory.Click += new EventHandler(this.Directory);
            this.btnDirectory.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 537);
            this.Text = "SalonFlow - Appointments";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AppointmentsForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.txtStaff);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.txtService);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnReschedule);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnDirectory);
            ((ISupportInitialize)this.recordsGrid).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private DataGridView recordsGrid = null!;
        private Label lblCustomer = null!;
        private TextBox txtCustomer = null!;
        private Label lblStaff = null!;
        private TextBox txtStaff = null!;
        private Label lblService = null!;
        private TextBox txtService = null!;
        private Label lblStart = null!;
        private TextBox txtStart = null!;
        private Label lblStatus = null!;
        private TextBox txtStatus = null!;
        private Button btnRefresh = null!;
        private Button btnBook = null!;
        private Button btnReschedule = null!;
        private Button btnStatus = null!;
        private Button btnDirectory = null!;
    }
}
