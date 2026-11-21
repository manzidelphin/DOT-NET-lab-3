using System.Globalization;

namespace SalonFlow.Views;

internal static class Input
{
    public static string Text(TextBox box, string label, int max, bool optional = false)
    {
        string value = box.Text.Trim();
        if ((!optional && value.Length == 0) || value.Length > max)
            throw new InvalidOperationException($"{label} needs {(optional ? "0" : "1")} to {max} characters.");
        return value;
    }

    public static int Number(TextBox box, string label, int min, int max)
    {
        if (!int.TryParse(box.Text, out int value) || value < min || value > max)
            throw new InvalidOperationException($"{label} must be a whole number from {min} to {max}.");
        return value;
    }

    public static int? OptionalId(TextBox box, string label) =>
        string.IsNullOrWhiteSpace(box.Text) ? null : Number(box, label, 1, int.MaxValue);

    public static decimal Money(TextBox box, string label, decimal min = 0, decimal max = 9999999999.99m)
    {
        if (!decimal.TryParse(box.Text, out decimal value) || value < min || value > max ||
            decimal.Round(value, 2) != value)
            throw new InvalidOperationException($"{label} must be between {min} and {max}, with up to two decimals.");
        return value;
    }

    public static string Choice(TextBox box, string label, params string[] choices)
    {
        foreach (string choice in choices)
            if (string.Equals(choice, box.Text.Trim(), StringComparison.OrdinalIgnoreCase)) return choice;
        throw new InvalidOperationException($"Choose {label}: {string.Join(", ", choices)}.");
    }

    public static DateTime Date(TextBox box, bool time = false)
    {
        string format = time ? "yyyy-MM-dd HH:mm" : "yyyy-MM-dd";
        if (!DateTime.TryParseExact(box.Text.Trim(), format, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out var result))
            throw new InvalidOperationException($"Enter a date in {format} format.");
        return result;
    }

    public static int Selected(DataGridView grid)
    {
        if (grid.SelectedRows.Count != 1)
            throw new InvalidOperationException("Select one row first.");
        return Convert.ToInt32(grid.SelectedRows[0].Cells["id"].Value);
    }

    public static string Cell(DataGridViewRow row, string column, string? format = null)
    {
        object value = row.Cells[column].Value;
        return value is DateTime date && format != null ? date.ToString(format, CultureInfo.InvariantCulture)
            : Convert.ToString(value) ?? "";
    }

    public static void Filter(DataGridView grid, string value)
    {
        grid.CurrentCell = null;
        grid.ClearSelection();
        foreach (DataGridViewRow row in grid.Rows)
        {
            row.Visible = row.Cells.Cast<DataGridViewCell>().Any(cell =>
                (Convert.ToString(cell.Value) ?? "").Contains(value, StringComparison.OrdinalIgnoreCase));
        }
    }
}
