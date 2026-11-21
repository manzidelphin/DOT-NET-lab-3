using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class QueueForm : Form
    {
        public QueueForm()
        {
            InitializeComponent();
        }

        private readonly Session? session;

        public QueueForm(Session user) : this()
        {
            session = user;
            btnAdd.Enabled = btnAssign.Enabled = btnUpdate.Enabled = Access.Desk(user);
            Shown += RefreshRecords;
        }

        private void RefreshRecords(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() => recordsGrid.DataSource = Operations.ListQueue(session));
        }

        private void Add(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Operations.Enqueue(session, Input.Number(txtCustomer, "Customer ID", 1, int.MaxValue), Input.Number(txtService, "Service ID", 1, int.MaxValue));
                RefreshRecords(sender, e);
            });
        }

        private void Assign(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Operations.AssignNext(session, Input.Number(txtStaff, "Stylist ID", 1, int.MaxValue));
                RefreshRecords(sender, e);
            });
        }

        private void Update(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Operations.QueueStatus(session, Input.Selected(recordsGrid), Input.Choice(txtStatus, "status", "Completed", "Cancelled"));
                RefreshRecords(sender, e);
            });
        }

    }
}
