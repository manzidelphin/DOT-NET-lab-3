using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private readonly Session? session;

        public ReportsForm(Session user) : this()
        {
            session = user;
            txtType.Text = user.Role == "Stylist" ? "Commission" : "Sales";
            txtFrom.Text = txtTo.Text = DateTime.Today.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            lblType.Text = user.Role switch
            {
                "Stylist" => "Commission",
                "Receptionist" => "Sales (one day)",
                _ => "Sales / Services / Commission / Stock / Appointments / Profit"
            };
            lblType.AutoSize = true;
            lblType.Location = new Point(24, 337);
            txtType.Enabled = Access.Supervisor(user);
            Shown += RefreshRecords;
        }

        private void RefreshRecords(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() => recordsGrid.DataSource = LoadReport());
        }

        private void Print(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                var result = LoadReport();
                recordsGrid.DataSource = result;
                PrintTable.Show(this, $"{txtType.Text.Trim()} report | {txtFrom.Text} to {txtTo.Text}", result);
            });
        }

        private System.Data.DataTable LoadReport() => Reports.Run(session!,
            Input.Choice(txtType, "report type", "Sales", "Services", "Commission", "Stock", "Appointments", "Profit"),
            Input.Date(txtFrom), Input.Date(txtTo));

    }
}
