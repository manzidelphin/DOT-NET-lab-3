using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class AppointmentsForm : Form
    {
        public AppointmentsForm()
        {
            InitializeComponent();
        }

        private readonly Session? session;

        public AppointmentsForm(Session user) : this()
        {
            session = user;
            txtCustomer.Enabled = user.Role != "Customer";
            btnBook.Enabled = btnReschedule.Enabled = user.Role != "Stylist";
            btnStatus.Enabled = user.Role != "Stylist";
            if (user.Role == "Customer") lblStatus.Text = "New status (Cancelled)";
            Shown += RefreshRecords;
        }

        private void RefreshRecords(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() => recordsGrid.DataSource = Operations.ListAppointments(session));
        }

        private void Book(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Operations.Book(session, null, CustomerId(), StaffId(), ServiceId(), Input.Date(txtStart, true));
                RefreshRecords(sender, e);
            });
        }

        private void Reschedule(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Operations.Book(session, Input.Selected(recordsGrid), CustomerId(), StaffId(), ServiceId(), Input.Date(txtStart, true));
                RefreshRecords(sender, e);
            });
        }

        private void Status(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Operations.AppointmentStatus(session, Input.Selected(recordsGrid), Input.Choice(txtStatus, "status", "Confirmed", "Checked in", "In service", "Completed", "Cancelled", "No-show"));
                RefreshRecords(sender, e);
            });
        }

        private void Directory(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                ShowTable("Services", Operations.BookingServices());
                ShowTable("Stylists", Operations.BookingStaff());
                if (Access.Desk(session)) ShowTable("Customers", Operations.BookingCustomers(session));
            });
        }

        private int CustomerId() => session?.CustomerId ?? Input.Number(txtCustomer, "Customer ID", 1, int.MaxValue);
        private int StaffId() => Input.Number(txtStaff, "Stylist ID", 1, int.MaxValue);
        private int ServiceId() => Input.Number(txtService, "Service ID", 1, int.MaxValue);
        private void ShowTable(string title, System.Data.DataTable data)
        {
            using var window = new Form { Text = title, Width = 650, Height = 340, StartPosition = FormStartPosition.CenterParent };
            window.Controls.Add(new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, DataSource = data });
            window.ShowDialog(this);
        }

    }
}
