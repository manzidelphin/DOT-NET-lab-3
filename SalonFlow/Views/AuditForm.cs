using SalonFlow.Controllers;
using SalonFlow.Models;

using System;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    public partial class AuditForm : Form
    {
        public AuditForm()
        {
            InitializeComponent();
        }

        private readonly Session? session;

        public AuditForm(Session user) : this()
        {
            session = user;

            Shown += RefreshRecords;
        }

        private void RefreshRecords(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() => recordsGrid.DataSource = Operations.ListAudit(session, ""));
        }

        private void Search(object? sender, EventArgs e)
        {
            if (session is null) return;
            Ui.Run(() =>
            {
                recordsGrid.DataSource = Operations.ListAudit(session, txtSearch.Text.Trim());
            });
        }

    }
}
