using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class PromotionsForm : Form
    {
        public PromotionsForm()
        {
            InitializeComponent();
        }

        private static readonly RecordSet Definition = new("Promotions", "promotions",
            "id,code,discount,starts_on,ends_on", "code,discount,starts_on,ends_on", Access.Supervisor);
        private readonly Session? session;
        private int? editingId;

        public PromotionsForm(Session user) : this()
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
                txtCode.Text = Input.Cell(row, "code");
                txtDiscount.Text = Input.Cell(row, "discount");
                txtStart.Text = Input.Cell(row, "starts_on", "yyyy-MM-dd");
                txtEnd.Text = Input.Cell(row, "ends_on", "yyyy-MM-dd");
                lblTitle.Text = $"Editing record #{editingId}";
            });
        }

        private void ClearFields(object? sender, EventArgs e)
        {
            editingId = null;
            txtCode.Clear();
            txtDiscount.Clear();
            txtStart.Clear();
            txtEnd.Clear();
            lblTitle.Text = "Promotions";
        }

        private void SaveRecord(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                var values = new object?[]
                {
                    Input.Text(txtCode, "Promotion code", 40),
                    Input.Money(txtDiscount, "Discount (%)", 0, 100),
                    Input.Date(txtStart),
                    Input.Date(txtEnd)
                };
                if ((DateTime)values[3]! < (DateTime)values[2]!)
                    throw new InvalidOperationException("The end date must be on or after the start date.");

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
