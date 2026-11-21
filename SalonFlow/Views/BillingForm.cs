using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class BillingForm : Form
    {
        public BillingForm()
        {
            InitializeComponent();
        }

        private readonly Session? session;

        public BillingForm(Session user) : this()
        {
            session = user;
            btnDiscount.Enabled = btnVoid.Enabled = Access.Supervisor(user);
            Shown += RefreshRecords;
        }

        private void RefreshRecords(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() => recordsGrid.DataSource = Billing.List(session));
        }

        private void CreateBill(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Billing.Create(session, Input.Number(txtCustomer, "Customer ID", 1, int.MaxValue), Input.Number(txtBranch, "Branch ID", 1, int.MaxValue), Input.OptionalId(txtAppointment, "Appointment ID"));
                RefreshRecords(sender, e);
            });
        }

        private void AddItem(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                Billing.AddItem(session, BillId(), Input.Choice(txtKind, "item kind", "Service", "Retail"), Input.Number(txtItem, "Item ID", 1, int.MaxValue), Input.Number(txtQuantity, "Quantity", 1, 100000));
                RefreshRecords(sender, e);
            });
        }

        private void Pay(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                decimal change = Billing.Pay(session, BillId(), Input.Choice(txtMethod, "payment method", "Cash", "Mobile money", "Card"), Input.Money(txtAmount, "Payment amount", 0.01m), Input.Text(txtReference, "Reference", 100, true));
                MessageBox.Show($"Payment recorded. Cash change: {change:N2} RWF.", "SalonFlow");
                RefreshRecords(sender, e);
            });
        }

        private void Receipt(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                int id = BillId();
                PrintTable.Show(this, $"Receipt SF-{id:000000}", Billing.Receipt(session, id));
            });
        }

        private void Discount(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                string code = Input.Text(txtReference, "Promotion code", 40, true);
                Billing.Discount(session, BillId(), code.Length == 0 ? Input.Money(txtAmount, "Discount") : 0, code);
                RefreshRecords(sender, e);
            });
        }

        private void Void(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                if (MessageBox.Show("Void this unpaid bill and return stock?", "SalonFlow", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                Billing.Void(session, BillId());
                RefreshRecords(sender, e);
            });
        }

        private int BillId() => Input.Selected(recordsGrid);

    }
}
