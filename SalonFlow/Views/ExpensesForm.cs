using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class ExpensesForm : Form
    {
        public ExpensesForm()
        {
            InitializeComponent();
        }

        private static readonly RecordSet Definition = new("Expenses", "expenses",
            "id,branch_id,category,description,amount,spent_on", "branch_id,category,description,amount,spent_on", Access.Supervisor);
        private readonly Session? session;
        private int? editingId;

        public ExpensesForm(Session user) : this()
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
                txtBranch.Text = Input.Cell(row, "branch_id");
                txtCategory.Text = Input.Cell(row, "category");
                txtDescription.Text = Input.Cell(row, "description");
                txtAmount.Text = Input.Cell(row, "amount");
                txtDate.Text = Input.Cell(row, "spent_on", "yyyy-MM-dd");
                lblTitle.Text = $"Editing record #{editingId}";
            });
        }

        private void ClearFields(object? sender, EventArgs e)
        {
            editingId = null;
            txtBranch.Clear();
            txtCategory.Clear();
            txtDescription.Clear();
            txtAmount.Clear();
            txtDate.Clear();
            lblTitle.Text = "Expenses";
        }

        private void SaveRecord(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                var values = new object?[]
                {
                    Input.Number(txtBranch, "Branch ID", 1, int.MaxValue),
                    Input.Text(txtCategory, "Category", 80),
                    Input.Text(txtDescription, "Description", 160),
                    Input.Money(txtAmount, "Amount (RWF)", 0.01m),
                    Input.Date(txtDate)
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
