using System.Data;
using MySqlConnector;

namespace SalonFlow.Data;

internal static class Database
{
    public static MySqlConnection Open()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "Database.config");
        var connection = new MySqlConnection(File.ReadAllText(path).Trim());
        try
        {
            connection.Open();
            return connection;
        }
        catch
        {
            connection.Dispose();
            throw;
        }
    }

    public static MySqlCommand Command(MySqlConnection connection, MySqlTransaction? transaction,
        string sql, params (string Name, object? Value)[] values)
    {
        var command = new MySqlCommand(sql, connection, transaction);
        foreach (var value in values)
            command.Parameters.AddWithValue(value.Name, value.Value ?? DBNull.Value);
        return command;
    }

    public static DataTable Read(string sql, params (string Name, object? Value)[] values)
    {
        using var connection = Open();
        using var command = Command(connection, null, sql, values);
        using var reader = command.ExecuteReader();
        var table = new DataTable();
        table.Load(reader);
        return table;
    }

    public static int Execute(MySqlConnection connection, MySqlTransaction transaction,
        string sql, params (string Name, object? Value)[] values)
    {
        using var command = Command(connection, transaction, sql, values);
        return command.ExecuteNonQuery();
    }

    public static object? Scalar(MySqlConnection connection, MySqlTransaction transaction,
        string sql, params (string Name, object? Value)[] values)
    {
        using var command = Command(connection, transaction, sql, values);
        return command.ExecuteScalar();
    }
}
