using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        private static readonly RecordSet Definition = new("Customers", "customers",
            "id,name,phone,email,notes,consent,points", "name,phone,email,notes,consent", Access.Desk);
        private readonly Session? session;
        private int? editingId;

        public CustomersForm(Session user) : this()
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
                txtEmail.Text = Input.Cell(row, "email");
                txtNotes.Text = Input.Cell(row, "notes");
                txtConsent.Text = Input.Cell(row, "consent");
                lblTitle.Text = $"Editing record #{editingId}";
            });
        }

        private void ClearFields(object? sender, EventArgs e)
        {
            editingId = null;
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtNotes.Clear();
            txtConsent.Clear();
            lblTitle.Text = "Customer records";
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
                    Input.Text(txtEmail, "Email", 150, true),
                    Input.Text(txtNotes, "Notes and preferences", 255, true),
                    Input.Number(txtConsent, "Message consent (0 or 1)", 0, 1)
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

        private void VisitHistory(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                int id = Input.Selected(recordsGrid);
                var visits = Operations.VisitHistory(session, id);
                using var window = new Form
                {
                    Text = $"SalonFlow - Visits for customer #{id}",
                    Width = 735, Height = 360, StartPosition = FormStartPosition.CenterParent
                };
                window.Controls.Add(new DataGridView { Dock = DockStyle.Fill, DataSource = visits,
                    ReadOnly = true, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill });
                window.ShowDialog(this);
            });
        }
    }
}
