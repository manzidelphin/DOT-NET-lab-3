using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class BranchesForm : Form
    {
        public BranchesForm()
        {
            InitializeComponent();
        }

        private static readonly RecordSet Definition = new("Branches", "branches",
            "id,name,address,phone,tax_rate", "name,address,phone,tax_rate", user => user.Role == "Owner");
        private readonly Session? session;
        private int? editingId;

        public BranchesForm(Session user) : this()
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
                txtName.Text = Input.Cell(row, "name");
                txtAddress.Text = Input.Cell(row, "address");
                txtPhone.Text = Input.Cell(row, "phone");
                txtTax.Text = Input.Cell(row, "tax_rate");
                lblTitle.Text = $"Editing record #{editingId}";
            });
        }

        private void ClearFields(object? sender, EventArgs e)
        {
            editingId = null;
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtTax.Clear();
            lblTitle.Text = "Branches and settings";
        }

        private void SaveRecord(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                var values = new object?[]
                {
                    Input.Text(txtName, "Branch name", 100),
                    Input.Text(txtAddress, "Address", 160),
                    Input.Text(txtPhone, "Phone", 24),
                    Input.Money(txtTax, "Tax rate (%)", 0, 100)
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
