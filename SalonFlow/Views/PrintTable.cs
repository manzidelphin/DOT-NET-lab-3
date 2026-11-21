using System.Data;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace SalonFlow.Views;

internal static class PrintTable
{
    public static void Show(IWin32Window owner, string title, DataTable table)
    {
        using var document = new PrintDocument { DocumentName = "SalonFlow - " + title };
        using var preview = new PrintPreviewDialog { Document = document, Width = 1000, Height = 700 };
        using var titleFont = new Font("Segoe UI", 17, FontStyle.Bold);
        using var bodyFont = new Font("Segoe UI", 9);
        using var headerFont = new Font("Segoe UI", 9, FontStyle.Bold);
        using var cellStyle = new StringFormat { Trimming = StringTrimming.EllipsisCharacter,
            FormatFlags = StringFormatFlags.NoWrap };
        int next = 0;
        int page = 0;
        document.BeginPrint += (_, _) => { next = 0; page = 0; };
        document.PrintPage += (_, args) =>
        {
            var graphics = args.Graphics!;
            var area = args.MarginBounds;
            page++;
            graphics.DrawString("SalonFlow", titleFont, Brushes.Black, area.Left, area.Top);
            graphics.DrawString(title, headerFont, Brushes.Black, area.Left, area.Top + 31);
            float y = area.Top + 65;
            float cellWidth = (float)area.Width / table.Columns.Count;
            graphics.FillRectangle(Brushes.Gainsboro, area.Left, y, area.Width, 24);
            for (int column = 0; column < table.Columns.Count; column++)
            {
                string name = Regex.Replace(table.Columns[column].ColumnName.Replace("_", " "), @"^.", m => m.Value.ToUpperInvariant());
                graphics.DrawString(name, headerFont, Brushes.Black,
                    new RectangleF(area.Left + column * cellWidth + 4, y + 4, cellWidth - 8, 20), cellStyle);
            }
            y += 26;
            if (table.Rows.Count == 0)
                graphics.DrawString("No results for the selected report.", bodyFont, Brushes.Black, area.Left + 4, y + 4);
            while (next < table.Rows.Count && y + 45 < area.Bottom)
            {
                DataRow row = table.Rows[next];
                if (next % 2 == 1) graphics.FillRectangle(Brushes.WhiteSmoke, area.Left, y, area.Width, 23);
                for (int column = 0; column < table.Columns.Count; column++)
                {
                    string value = row[column] is decimal money ? money.ToString("N2") : Convert.ToString(row[column]) ?? "";
                    graphics.DrawString(value, bodyFont, Brushes.Black,
                        new RectangleF(area.Left + column * cellWidth + 4, y + 4, cellWidth - 8, 19), cellStyle);
                }
                next++;
                y += 23;
            }
            graphics.DrawString($"Page {page}", bodyFont, Brushes.DimGray, area.Left, area.Bottom - 16);
            args.HasMorePages = next < table.Rows.Count;
        };
        using var printer = new PrintDialog { Document = document, UseEXDialog = true };
        if (preview.ShowDialog(owner) == DialogResult.OK) return;
        if (MessageBox.Show(owner, "Choose a printer or save a PDF now?", "SalonFlow",
            MessageBoxButtons.YesNo) == DialogResult.Yes && printer.ShowDialog(owner) == DialogResult.OK)
            document.Print();
    }
}
