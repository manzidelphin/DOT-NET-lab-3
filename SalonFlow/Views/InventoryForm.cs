using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }

        private static readonly RecordSet Definition = new("Inventory", "products",
            "id,sku,name,kind,price,quantity,reorder_level,CASE WHEN quantity <= reorder_level THEN 'Low stock' ELSE 'OK' END AS stock_status", "sku,name,kind,price,quantity,reorder_level", Access.Supervisor);
        private readonly Session? session;
        private int? editingId;

        public InventoryForm(Session user) : this()
        {
            session = user;
            bool canWrite = Definition.CanWrite(user);
            btnSave.Enabled = btnDelete.Enabled = canWrite;
            Shown += RefreshRecords;
        }

        private void RefreshRecords(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                recordsGrid.DataSource = Records.List(session, Definition);
                Filter(sender, e);
            });
        }

        private void Filter(object? sender, EventArgs e)
        {
            if (recordsGrid.DataSource is not null) Input.Filter(recordsGrid, txtFilter.Text.Trim());
        }

        private void LoadSelected(object? sender, EventArgs e)
        {
            Ui.Run(() =>
            {
                editingId = Input.Selected(recordsGrid);
                var row = recordsGrid.SelectedRows[0];
                txtSku.Text = Input.Cell(row, "sku");
                txtName.Text = Input.Cell(row, "name");
                txtKind.Text = Input.Cell(row, "kind");
                txtPrice.Text = Input.Cell(row, "price");
                txtQuantity.Text = Input.Cell(row, "quantity");
                txtReorder.Text = Input.Cell(row, "reorder_level");
                lblTitle.Text = $"Editing record #{editingId}";
            });
        }

        private void ClearFields(object? sender, EventArgs e)
        {
            editingId = null;
            txtSku.Clear();
            txtName.Clear();
            txtKind.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtReorder.Clear();
            lblTitle.Text = "Inventory";
        }

        private void SaveRecord(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                var values = new object?[]
                {
                    Input.Text(txtSku, "SKU", 50),
                    Input.Text(txtName, "Product name", 100),
                    Input.Choice(txtKind, "Retail or Professional", "Retail", "Professional"),
                    Input.Money(txtPrice, "Retail price (RWF)"),
                    Input.Number(txtQuantity, "Quantity on hand", 0, 1000000),
                    Input.Number(txtReorder, "Reorder level", 0, 1000000)
                };

                Records.Save(session, Definition, editingId, values);
                ClearFields(sender, e);
                RefreshRecords(sender, e);
            });
        }

        private void DeleteRecord(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                int id = Input.Selected(recordsGrid);
                if (MessageBox.Show($"Delete record #{id}?", "SalonFlow", MessageBoxButtons.YesNo)
                    != DialogResult.Yes) return;
                Records.Delete(session, Definition, id);
                ClearFields(sender, e);
                RefreshRecords(sender, e);
            });
        }

    }
}
