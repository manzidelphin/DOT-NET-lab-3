using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class InventoryForm
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
            this.lblSku = new Label();
            this.txtSku = new TextBox();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblKind = new Label();
            this.txtKind = new TextBox();
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.lblQuantity = new Label();
            this.txtQuantity = new TextBox();
            this.lblReorder = new Label();
            this.txtReorder = new TextBox();
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
            this.lblTitle.Text = "Inventory";
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
            this.lblSku.Name = "lblSku";
            this.lblSku.TabIndex = 4;
            this.lblSku.Location = new Point(24, 382);
            this.lblSku.Size = new Size(270, 24);
            this.lblSku.Text = "SKU";
            this.txtSku.Name = "txtSku";
            this.txtSku.TabIndex = 5;
            this.txtSku.Location = new Point(24, 404);
            this.txtSku.Size = new Size(260, 25);
            this.lblName.Name = "lblName";
            this.lblName.TabIndex = 6;
            this.lblName.Location = new Point(309, 382);
            this.lblName.Size = new Size(270, 24);
            this.lblName.Text = "Product name";
            this.txtName.Name = "txtName";
            this.txtName.TabIndex = 7;
            this.txtName.Location = new Point(309, 404);
            this.txtName.Size = new Size(260, 25);
            this.lblKind.Name = "lblKind";
            this.lblKind.TabIndex = 8;
            this.lblKind.Location = new Point(594, 382);
            this.lblKind.Size = new Size(270, 24);
            this.lblKind.Text = "Retail or Professional";
            this.txtKind.Name = "txtKind";
            this.txtKind.TabIndex = 9;
            this.txtKind.Location = new Point(594, 404);
            this.txtKind.Size = new Size(260, 25);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Location = new Point(24, 445);
            this.lblPrice.Size = new Size(270, 24);
            this.lblPrice.Text = "Retail price (RWF)";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.TabIndex = 11;
            this.txtPrice.Location = new Point(24, 467);
            this.txtPrice.Size = new Size(260, 25);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Location = new Point(309, 445);
            this.lblQuantity.Size = new Size(270, 24);
            this.lblQuantity.Text = "Quantity on hand";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.TabIndex = 13;
            this.txtQuantity.Location = new Point(309, 467);
            this.txtQuantity.Size = new Size(260, 25);
            this.lblReorder.Name = "lblReorder";
            this.lblReorder.TabIndex = 14;
            this.lblReorder.Location = new Point(594, 445);
            this.lblReorder.Size = new Size(270, 24);
            this.lblReorder.Text = "Reorder level";
            this.txtReorder.Name = "txtReorder";
            this.txtReorder.TabIndex = 15;
            this.txtReorder.Location = new Point(594, 467);
            this.txtReorder.Size = new Size(260, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Location = new Point(24, 518);
            this.btnRefresh.Size = new Size(115, 33);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.RefreshRecords);
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.TabIndex = 17;
            this.btnLoad.Location = new Point(150, 518);
            this.btnLoad.Size = new Size(140, 33);
            this.btnLoad.Text = "Load selected";
            this.btnLoad.Click += new EventHandler(this.LoadSelected);
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnNew.Name = "btnNew";
            this.btnNew.TabIndex = 18;
            this.btnNew.Location = new Point(300, 518);
            this.btnNew.Size = new Size(120, 33);
            this.btnNew.Text = "Clear fields";
            this.btnNew.Click += new EventHandler(this.ClearFields);
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 19;
            this.btnSave.Location = new Point(430, 518);
            this.btnSave.Size = new Size(120, 33);
            this.btnSave.Text = "Add / save";
            this.btnSave.Click += new EventHandler(this.SaveRecord);
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Location = new Point(560, 518);
            this.btnDelete.Size = new Size(145, 33);
            this.btnDelete.Text = "Delete selected";
            this.btnDelete.Click += new EventHandler(this.DeleteRecord);
            this.btnDelete.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 575);
            this.Text = "SalonFlow - Inventory";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InventoryForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.recordsGrid);
            this.Controls.Add(this.lblSku);
            this.Controls.Add(this.txtSku);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblKind);
            this.Controls.Add(this.txtKind);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblReorder);
            this.Controls.Add(this.txtReorder);
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
        private Label lblSku = null!;
        private TextBox txtSku = null!;
        private Label lblName = null!;
        private TextBox txtName = null!;
        private Label lblKind = null!;
        private TextBox txtKind = null!;
        private Label lblPrice = null!;
        private TextBox txtPrice = null!;
        private Label lblQuantity = null!;
        private TextBox txtQuantity = null!;
        private Label lblReorder = null!;
        private TextBox txtReorder = null!;
        private Button btnRefresh = null!;
        private Button btnLoad = null!;
        private Button btnNew = null!;
        private Button btnSave = null!;
        private Button btnDelete = null!;
    }
}
