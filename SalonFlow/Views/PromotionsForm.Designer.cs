using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class PromotionsForm
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
            this.lblCode = new Label();
            this.txtCode = new TextBox();
            this.lblDiscount = new Label();
            this.txtDiscount = new TextBox();
            this.lblStart = new Label();
            this.txtStart = new TextBox();
            this.lblEnd = new Label();
            this.txtEnd = new TextBox();
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
            this.lblTitle.Text = "Promotions";
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
            this.lblCode.Name = "lblCode";
            this.lblCode.TabIndex = 4;
            this.lblCode.Location = new Point(24, 382);
            this.lblCode.Size = new Size(270, 24);
            this.lblCode.Text = "Promotion code";
            this.txtCode.Name = "txtCode";
            this.txtCode.TabIndex = 5;
            this.txtCode.Location = new Point(24, 404);
            this.txtCode.Size = new Size(260, 25);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.TabIndex = 6;
            this.lblDiscount.Location = new Point(309, 382);
            this.lblDiscount.Size = new Size(270, 24);
            this.lblDiscount.Text = "Discount (%)";
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.TabIndex = 7;
            this.txtDiscount.Location = new Point(309, 404);
            this.txtDiscount.Size = new Size(260, 25);
            this.lblStart.Name = "lblStart";
            this.lblStart.TabIndex = 8;
            this.lblStart.Location = new Point(594, 382);
            this.lblStart.Size = new Size(270, 24);
            this.lblStart.Text = "Start date (yyyy-MM-dd)";
            this.txtStart.Name = "txtStart";
            this.txtStart.TabIndex = 9;
            this.txtStart.Location = new Point(594, 404);
            this.txtStart.Size = new Size(260, 25);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.TabIndex = 10;
            this.lblEnd.Location = new Point(24, 445);
            this.lblEnd.Size = new Size(270, 24);
            this.lblEnd.Text = "End date (yyyy-MM-dd)";
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.TabIndex = 11;
            this.txtEnd.Location = new Point(24, 467);
            this.txtEnd.Size = new Size(260, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Location = new Point(24, 518);
            this.btnRefresh.Size = new Size(115, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.RefreshRecords);
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Location = new Point(150, 518);
            this.btnLoad.Size = new Size(140, 33);
            this.btnLoad.Text = "Load selected";
            this.btnLoad.Click += new EventHandler(this.LoadSelected);
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnNew.Name = "btnNew";
            this.btnNew.TabIndex = 14;
            this.btnNew.Location = new Point(300, 518);
            this.btnNew.Size = new Size(120, 33);
            this.btnNew.Text = "Clear fields";
            this.btnNew.Click += new EventHandler(this.ClearFields);
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 15;
            this.btnSave.Location = new Point(430, 518);
            this.btnSave.Size = new Size(120, 33);
            this.btnSave.Text = "Add / save";
            this.btnSave.Click += new EventHandler(this.SaveRecord);
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Location = new Point(560, 518);
            this.btnDelete.Size = new Size(145, 33);
            this.btnDelete.Text = "Delete selected";
            this.btnDelete.Click += new EventHandler(this.DeleteRecord);
            this.btnDelete.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 575);
            this.Text = "SalonFlow - Promotions";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PromotionsForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.txtEnd);
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
        private Label lblCode = null!;
        private TextBox txtCode = null!;
        private Label lblDiscount = null!;
        private TextBox txtDiscount = null!;
        private Label lblStart = null!;
        private TextBox txtStart = null!;
        private Label lblEnd = null!;
        private TextBox txtEnd = null!;
        private Button btnRefresh = null!;
        private Button btnLoad = null!;
        private Button btnNew = null!;
        private Button btnSave = null!;
        private Button btnDelete = null!;
    }
}
