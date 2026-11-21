using System.Net.Mail;
using System.Security.Cryptography;
using SalonFlow.Data;
using SalonFlow.Models;

namespace SalonFlow.Controllers;

internal static class Accounts
{
    public static Session SignIn(string login, string password)
    {
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        using var command = Database.Command(connection, transaction,
            "SELECT id,name,role,customer_id,active,failures,locked_until,salt,password_hash " +
            "FROM users WHERE email=@login OR phone=@login FOR UPDATE", ("@login", login.Trim()));
        using var reader = command.ExecuteReader();
        if (!reader.Read()) throw InvalidLogin();
        var user = new Session(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
            reader.IsDBNull(3) ? null : reader.GetInt32(3));
        bool active = reader.GetBoolean(4);
        int failures = reader.GetInt32(5);
        DateTime? lockedUntil = reader.IsDBNull(6) ? null : reader.GetDateTime(6);
        string salt = reader.GetString(7);
        string hash = reader.GetString(8);
        reader.Close();
        if (!active) throw InvalidLogin();
        if (lockedUntil > DateTime.UtcNow)
            throw new InvalidOperationException("Too many attempts. Try again in 15 minutes.");
        if (!Matches(password, salt, hash))
        {
            int attempts = lockedUntil.HasValue ? 1 : failures + 1;
            Database.Execute(connection, transaction,
                "UPDATE users SET failures=@attempts,locked_until=@locked WHERE id=@id",
                ("@attempts", attempts), ("@locked", attempts >= 5 ? DateTime.UtcNow.AddMinutes(15) : (DateTime?)null),
                ("@id", user.Id));
            transaction.Commit();
            throw InvalidLogin();
        }
        Database.Execute(connection, transaction, "UPDATE users SET failures=0,locked_until=NULL WHERE id=@id",
            ("@id", user.Id));
        transaction.Commit();
        return user;
    }

    public static void Register(string name, string email, string phone, string password, string confirmation)
    {
        ValidateIdentity(name, email, phone);
        ValidatePassword(password, confirmation);
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        using var command = Database.Command(connection, transaction,
            "INSERT INTO customers(name,phone,email) VALUES(@name,@phone,@email)",
            ("@name", name.Trim()), ("@phone", phone.Trim()), ("@email", email.Trim()));
        command.ExecuteNonQuery();
        InsertUser(connection, transaction, name, email, phone, "Customer", password, command.LastInsertedId);
        transaction.Commit();
    }

    public static void CreateStaff(Session actor, string name, string email, string phone,
        string role, string password)
    {
        Access.Require(actor.Role == "Owner");
        if (role is not ("Manager" or "Receptionist" or "Stylist"))
            throw new InvalidOperationException("Choose Manager, Receptionist or Stylist.");
        ValidateIdentity(name, email, phone);
        ValidatePassword(password, password);
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        InsertUser(connection, transaction, name, email, phone, role, password, null);
        Records.Audit(connection, transaction, actor, "Create account", email + " | " + role);
        transaction.Commit();
    }

    public static void Toggle(Session actor, int id)
    {
        Access.Require(Access.Supervisor(actor) && actor.Id != id);
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        int changed = Database.Execute(connection, transaction,
            "UPDATE users SET active=1-active WHERE id=@id AND role <> 'Owner' " +
            "AND (@owner=1 OR role IN ('Receptionist','Stylist'))",
            ("@id", id), ("@owner", actor.Role == "Owner" ? 1 : 0));
        if (changed == 0) throw new InvalidOperationException("You cannot change this account.");
        Records.Audit(connection, transaction, actor, "Toggle account status", $"Account #{id}");
        transaction.Commit();
    }

    public static void ChangePassword(Session actor, string current, string password, string confirmation)
    {
        ValidatePassword(password, confirmation);
        var table = Database.Read("SELECT email FROM users WHERE id=@id", ("@id", actor.Id));
        if (table.Rows.Count != 1) throw InvalidLogin();
        SignIn((string)table.Rows[0][0], current);
        string salt = Convert.ToHexString(RandomNumberGenerator.GetBytes(16));
        using var connection = Database.Open();
        using var transaction = connection.BeginTransaction();
        Database.Execute(connection, transaction,
            "UPDATE users SET salt=@salt,password_hash=@hash WHERE id=@id",
            ("@salt", salt), ("@hash", Hash(password, salt)), ("@id", actor.Id));
        transaction.Commit();
    }

    private static void InsertUser(MySqlConnector.MySqlConnection connection,
        MySqlConnector.MySqlTransaction transaction, string name, string email, string phone,
        string role, string password, long? customerId)
    {
        string salt = Convert.ToHexString(RandomNumberGenerator.GetBytes(16));
        Database.Execute(connection, transaction,
            "INSERT INTO users(name,email,phone,role,salt,password_hash,customer_id) " +
            "VALUES(@name,@email,@phone,@role,@salt,@hash,@customer)", ("@name", name.Trim()),
            ("@email", email.Trim()), ("@phone", phone.Trim()), ("@role", role),
            ("@salt", salt), ("@hash", Hash(password,salt)), ("@customer", customerId));
    }

    private static void ValidateIdentity(string name, string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Trim().Length > 100 ||
            email.Trim().Length > 150 || !MailAddress.TryCreate(email.Trim(), out var address) ||
            address.Address != email.Trim() || phone.Trim().Length is < 7 or > 24 ||
            !phone.Trim().TrimStart('+').All(char.IsAsciiDigit))
            throw new InvalidOperationException("Enter a full name, a valid email and a phone number.");
    }

    private static void ValidatePassword(string password, string confirmation)
    {
        if (password.Length is < 8 or > 100 || password != confirmation)
            throw new InvalidOperationException("Use 8 to 100 password characters and confirm the same password.");
    }

    private static string Hash(string password, string salt) => Convert.ToHexString(
        Rfc2898DeriveBytes.Pbkdf2(password, Convert.FromHexString(salt), 210000,
            HashAlgorithmName.SHA256, 32));

    private static bool Matches(string password, string salt, string hash) =>
        CryptographicOperations.FixedTimeEquals(Convert.FromHexString(Hash(password, salt)),
            Convert.FromHexString(hash));

    private static InvalidOperationException InvalidLogin() => new("Check your email or phone and password.");
}
