using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class ServicesForm
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
            this.lblCategory = new Label();
            this.txtCategory = new TextBox();
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.lblMinutes = new Label();
            this.txtMinutes = new TextBox();
            this.lblActive = new Label();
            this.txtActive = new TextBox();
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
            this.lblTitle.Text = "Service catalogue";
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
            this.lblName.Text = "Service name";
            this.txtName.Name = "txtName";
            this.txtName.TabIndex = 5;
            this.txtName.Location = new Point(24, 404);
            this.txtName.Size = new Size(260, 25);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Location = new Point(309, 382);
            this.lblCategory.Size = new Size(270, 24);
            this.lblCategory.Text = "Category";
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.TabIndex = 7;
            this.txtCategory.Location = new Point(309, 404);
            this.txtCategory.Size = new Size(260, 25);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Location = new Point(594, 382);
            this.lblPrice.Size = new Size(270, 24);
            this.lblPrice.Text = "Price (RWF)";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.TabIndex = 9;
            this.txtPrice.Location = new Point(594, 404);
            this.txtPrice.Size = new Size(260, 25);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.TabIndex = 10;
            this.lblMinutes.Location = new Point(24, 445);
            this.lblMinutes.Size = new Size(270, 24);
            this.lblMinutes.Text = "Duration in minutes";
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.TabIndex = 11;
            this.txtMinutes.Location = new Point(24, 467);
            this.txtMinutes.Size = new Size(260, 25);
            this.lblActive.Name = "lblActive";
            this.lblActive.TabIndex = 12;
            this.lblActive.Location = new Point(309, 445);
            this.lblActive.Size = new Size(270, 24);
            this.lblActive.Text = "Active (0 or 1)";
            this.txtActive.Name = "txtActive";
            this.txtActive.TabIndex = 13;
            this.txtActive.Location = new Point(309, 467);
            this.txtActive.Size = new Size(260, 25);
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
            this.Text = "SalonFlow - Service catalogue";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ServicesForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.txtActive);
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
        private Label lblCategory = null!;
        private TextBox txtCategory = null!;
        private Label lblPrice = null!;
        private TextBox txtPrice = null!;
        private Label lblMinutes = null!;
        private TextBox txtMinutes = null!;
        private Label lblActive = null!;
        private TextBox txtActive = null!;
        private Button btnRefresh = null!;
        private Button btnLoad = null!;
        private Button btnNew = null!;
        private Button btnSave = null!;
        private Button btnDelete = null!;
    }
}
