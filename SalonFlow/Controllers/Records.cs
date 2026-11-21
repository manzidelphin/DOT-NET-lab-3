using System.Data;
using MySqlConnector;
using SalonFlow.Data;
using SalonFlow.Models;

namespace SalonFlow.Controllers;

internal record RecordSet(string Module, string Table, string Columns, string Editable,
    Func<Session, bool> CanWrite)
{
    public string[] Fields => Editable.Split(',', StringSplitOptions.RemoveEmptyEntries);
}

internal static class Records
{
    public static DataTable List(Session user, RecordSet set)
    {
        Access.Require(Access.CanOpen(user, set.Module));
        return Database.Read($"SELECT {set.Columns} FROM {set.Table} ORDER BY id DESC");
    }

    public static void Save(Session user, RecordSet set, int? id, object?[] values)
    {
        Access.Require(set.CanWrite(user));
        var fields = set.Fields;
        var parameters = fields.Select((field, index) => ("@" + field, values[index])).ToList();
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        string previous = id.HasValue ? Snapshot(connection, transaction, set, id.Value) : "";
        if (id.HasValue)
        {
            parameters.Add(("@id", id.Value));
            string assignments = string.Join(",", fields.Select(field => $"{field}=@{field}"));
            Database.Execute(connection, transaction,
                $"UPDATE {set.Table} SET {assignments} WHERE id=@id", parameters.ToArray());
        }
        else
        {
            string placeholders = string.Join(",", fields.Select(field => "@" + field));
            using var command = Database.Command(connection, transaction,
                $"INSERT INTO {set.Table} ({set.Editable}) VALUES ({placeholders})", parameters.ToArray());
            command.ExecuteNonQuery();
            id = checked((int)command.LastInsertedId);
        }

        Audit(connection, transaction, user, "Save " + set.Module,
            $"#{id} | Before: {previous} | After: {Snapshot(connection, transaction, set, id.Value)}");
        transaction.Commit();
    }

    public static void Delete(Session user, RecordSet set, int id)
    {
        Access.Require(set.CanWrite(user));
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        string previous = Snapshot(connection, transaction, set, id);
        Database.Execute(connection, transaction, $"DELETE FROM {set.Table} WHERE id=@id", ("@id", id));
        Audit(connection, transaction, user, "Delete " + set.Module, $"#{id} | {previous}");
        transaction.Commit();
    }

    private static string Snapshot(MySqlConnection connection, MySqlTransaction transaction, RecordSet set, int id)
    {
        using var command = Database.Command(connection, transaction,
            $"SELECT {set.Editable} FROM {set.Table} WHERE id=@id FOR UPDATE", ("@id", id));
        using var reader = command.ExecuteReader();
        if (!reader.Read()) throw new InvalidOperationException("This record has changed. Refresh the list.");
        return string.Join(" | ", set.Fields.Select((field, index) => $"{field}={reader.GetValue(index)}"));
    }

    public static void Audit(MySqlConnection connection, MySqlTransaction transaction, Session user,
        string action, string details)
    {
        Database.Execute(connection, transaction,
            "INSERT INTO audit_log(user_id,action,details) VALUES(@user,@action,@details)",
            ("@user", user.Id), ("@action", action), ("@details", details));
    }
}
