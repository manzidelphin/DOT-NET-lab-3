using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class AuditForm
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
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.btnRefresh = new Button();
            this.btnSearch = new Button();
            ((ISupportInitialize)this.recordsGrid).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(852, 40);
            this.lblTitle.Text = "Audit history";
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
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Location = new Point(24, 352);
            this.lblSearch.Size = new Size(270, 24);
            this.lblSearch.Text = "Filter audit history";
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Location = new Point(24, 374);
            this.txtSearch.Size = new Size(260, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Location = new Point(24, 430);
            this.btnRefresh.Size = new Size(115, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.RefreshRecords);
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Location = new Point(150, 430);
            this.btnSearch.Size = new Size(166, 33);
            this.btnSearch.Text = "Filter";
            this.btnSearch.Click += new EventHandler(this.Search);
            this.btnSearch.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 482);
            this.Text = "SalonFlow - Audit history";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AuditForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            ((ISupportInitialize)this.recordsGrid).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private DataGridView recordsGrid = null!;
        private Label lblSearch = null!;
        private TextBox txtSearch = null!;
        private Button btnRefresh = null!;
        private Button btnSearch = null!;
    }
}
