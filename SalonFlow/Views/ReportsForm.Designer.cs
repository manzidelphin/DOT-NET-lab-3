using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class ReportsForm
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
            this.lblType = new Label();
            this.txtType = new TextBox();
            this.lblFrom = new Label();
            this.txtFrom = new TextBox();
            this.lblTo = new Label();
            this.txtTo = new TextBox();
            this.btnRefresh = new Button();
            this.btnPrint = new Button();
            ((ISupportInitialize)this.recordsGrid).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(852, 40);
            this.lblTitle.Text = "Reports";
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
            this.lblType.Name = "lblType";
            this.lblType.TabIndex = 2;
            this.lblType.Location = new Point(24, 352);
            this.lblType.Size = new Size(270, 24);
            this.lblType.Text = "Report type";
            this.txtType.Name = "txtType";
            this.txtType.TabIndex = 3;
            this.txtType.Location = new Point(24, 374);
            this.txtType.Size = new Size(260, 25);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Location = new Point(309, 352);
            this.lblFrom.Size = new Size(270, 24);
            this.lblFrom.Text = "From (yyyy-MM-dd)";
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.TabIndex = 5;
            this.txtFrom.Location = new Point(309, 374);
            this.txtFrom.Size = new Size(260, 25);
            this.lblTo.Name = "lblTo";
            this.lblTo.TabIndex = 6;
            this.lblTo.Location = new Point(594, 352);
            this.lblTo.Size = new Size(270, 24);
            this.lblTo.Text = "Through (yyyy-MM-dd)";
            this.txtTo.Name = "txtTo";
            this.txtTo.TabIndex = 7;
            this.txtTo.Location = new Point(594, 374);
            this.txtTo.Size = new Size(260, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Location = new Point(24, 430);
            this.btnRefresh.Size = new Size(115, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.RefreshRecords);
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Location = new Point(150, 430);
            this.btnPrint.Size = new Size(166, 33);
            this.btnPrint.Text = "Print / save as PDF";
            this.btnPrint.Click += new EventHandler(this.Print);
            this.btnPrint.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 482);
            this.Text = "SalonFlow - Reports";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ReportsForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnPrint);
            ((ISupportInitialize)this.recordsGrid).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private DataGridView recordsGrid = null!;
        private Label lblType = null!;
        private TextBox txtType = null!;
        private Label lblFrom = null!;
        private TextBox txtFrom = null!;
        private Label lblTo = null!;
        private TextBox txtTo = null!;
        private Button btnRefresh = null!;
        private Button btnPrint = null!;
    }
}
