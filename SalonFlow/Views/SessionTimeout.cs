namespace SalonFlow.Views;

internal sealed class SessionTimeout : IMessageFilter, IDisposable
{
    private long lastInput = Environment.TickCount64;
    private readonly System.Windows.Forms.Timer timer = new() { Interval = 10000 };
    private readonly Form dashboard;

    public SessionTimeout(Form dashboard)
    {
        this.dashboard = dashboard;
        Application.AddMessageFilter(this);
        timer.Tick += Check;
        timer.Start();
    }

    public bool PreFilterMessage(ref Message message)
    {
        if (message.Msg is 0x0100 or 0x0104 or 0x0200 or 0x0201 or 0x0204 or 0x020A)
            lastInput = Environment.TickCount64;
        return false;
    }

    private void Check(object? sender, EventArgs e)
    {
        if (Environment.TickCount64 - lastInput < TimeSpan.FromMinutes(30).TotalMilliseconds) return;
        timer.Stop();
        // Close modal screens from the innermost one back to the dashboard.
        foreach (Form openForm in Application.OpenForms.Cast<Form>().Reverse().ToArray())
        {
            if (openForm == dashboard) break;
            openForm.Close();
        }
        dashboard.DialogResult = DialogResult.Retry;
    }

    public void Dispose()
    {
        timer.Dispose();
        Application.RemoveMessageFilter(this);
    }
}
