using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class ServicesForm : Form
    {
        public ServicesForm()
        {
            InitializeComponent();
        }

        private static readonly RecordSet Definition = new("Services", "services",
            "id,name,category,price,minutes,active", "name,category,price,minutes,active", Access.Supervisor);
        private readonly Session? session;
        private int? editingId;

        public ServicesForm(Session user) : this()
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
                txtCategory.Text = Input.Cell(row, "category");
                txtPrice.Text = Input.Cell(row, "price");
                txtMinutes.Text = Input.Cell(row, "minutes");
                txtActive.Text = Input.Cell(row, "active");
                lblTitle.Text = $"Editing record #{editingId}";
            });
        }

        private void ClearFields(object? sender, EventArgs e)
        {
            editingId = null;
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtMinutes.Clear();
            txtActive.Clear();
            lblTitle.Text = "Service catalogue";
        }

        private void SaveRecord(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                var values = new object?[]
                {
                    Input.Text(txtName, "Service name", 100),
                    Input.Text(txtCategory, "Category", 80),
                    Input.Money(txtPrice, "Price (RWF)"),
                    Input.Number(txtMinutes, "Duration in minutes", 1, 720),
                    Input.Number(txtActive, "Active (0 or 1)", 0, 1)
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
