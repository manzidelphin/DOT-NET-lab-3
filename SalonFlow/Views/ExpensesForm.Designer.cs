using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class ExpensesForm
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
            this.lblBranch = new Label();
            this.txtBranch = new TextBox();
            this.lblCategory = new Label();
            this.txtCategory = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblAmount = new Label();
            this.txtAmount = new TextBox();
            this.lblDate = new Label();
            this.txtDate = new TextBox();
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
            this.lblTitle.Text = "Expenses";
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
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.TabIndex = 4;
            this.lblBranch.Location = new Point(24, 382);
            this.lblBranch.Size = new Size(270, 24);
            this.lblBranch.Text = "Branch ID";
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.TabIndex = 5;
            this.txtBranch.Location = new Point(24, 404);
            this.txtBranch.Size = new Size(260, 25);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Location = new Point(309, 382);
            this.lblCategory.Size = new Size(270, 24);
            this.lblCategory.Text = "Category";
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.TabIndex = 7;
            this.txtCategory.Location = new Point(309, 404);
            this.txtCategory.Size = new Size(260, 25);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Location = new Point(594, 382);
            this.lblDescription.Size = new Size(270, 24);
            this.lblDescription.Text = "Description";
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.TabIndex = 9;
            this.txtDescription.Location = new Point(594, 404);
            this.txtDescription.Size = new Size(260, 25);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.TabIndex = 10;
            this.lblAmount.Location = new Point(24, 445);
            this.lblAmount.Size = new Size(270, 24);
            this.lblAmount.Text = "Amount (RWF)";
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.TabIndex = 11;
            this.txtAmount.Location = new Point(24, 467);
            this.txtAmount.Size = new Size(260, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.TabIndex = 12;
            this.lblDate.Location = new Point(309, 445);
            this.lblDate.Size = new Size(270, 24);
            this.lblDate.Text = "Date (yyyy-MM-dd)";
            this.txtDate.Name = "txtDate";
            this.txtDate.TabIndex = 13;
            this.txtDate.Location = new Point(309, 467);
            this.txtDate.Size = new Size(260, 25);
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
            this.Text = "SalonFlow - Expenses";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExpensesForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtDate);
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
        private Label lblBranch = null!;
        private TextBox txtBranch = null!;
        private Label lblCategory = null!;
        private TextBox txtCategory = null!;
        private Label lblDescription = null!;
        private TextBox txtDescription = null!;
        private Label lblAmount = null!;
        private TextBox txtAmount = null!;
        private Label lblDate = null!;
        private TextBox txtDate = null!;
        private Button btnRefresh = null!;
        private Button btnLoad = null!;
        private Button btnNew = null!;
        private Button btnSave = null!;
        private Button btnDelete = null!;
    }
}
