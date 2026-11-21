using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
        }

        private static readonly RecordSet Definition = new("Staff", "staff",
            "id,name,phone,branch_id,user_id,commission", "name,phone,branch_id,user_id,commission", Access.Supervisor);
        private readonly Session? session;
        private int? editingId;

        public StaffForm(Session user) : this()
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
                txtPhone.Text = Input.Cell(row, "phone");
                txtBranch.Text = Input.Cell(row, "branch_id");
                txtUser.Text = Input.Cell(row, "user_id");
                txtCommission.Text = Input.Cell(row, "commission");
                lblTitle.Text = $"Editing record #{editingId}";
            });
        }

        private void ClearFields(object? sender, EventArgs e)
        {
            editingId = null;
            txtName.Clear();
            txtPhone.Clear();
            txtBranch.Clear();
            txtUser.Clear();
            txtCommission.Clear();
            lblTitle.Text = "Staff directory";
        }

        private void SaveRecord(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                var values = new object?[]
                {
                    Input.Text(txtName, "Full name", 100),
                    Input.Text(txtPhone, "Phone", 24),
                    Input.Number(txtBranch, "Branch ID", 1, int.MaxValue),
                    Input.OptionalId(txtUser, "Stylist account ID (optional)"),
                    Input.Money(txtCommission, "Commission (%)", 0, 100)
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
