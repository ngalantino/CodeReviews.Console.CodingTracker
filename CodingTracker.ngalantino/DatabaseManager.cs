
using System.Configuration;
using Dapper;
using Microsoft.Data.Sqlite;

public class DatabaseManager
{
    public DatabaseManager()
    {
        using (SqliteConnection connection = new SqliteConnection(ConfigurationManager.AppSettings.Get("sqliteDB")))
        {
            connection.Open();

            SqliteCommand tableCmd = connection.CreateCommand();

            tableCmd.CommandText =
            @"CREATE TABLE IF NOT EXISTS coding_tracker (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                StartTime TEXT,
                EndTime TEXT,
                Duration TEXT
                )";

            tableCmd.ExecuteNonQuery();

            connection.Close();
        }
    }

    public void Insert(CodingSession codingSession) {
        using (SqliteConnection connection = new SqliteConnection(ConfigurationManager.AppSettings.Get("sqliteDB"))) {
            connection.Open();

            var sql = @"INSERT INTO coding_tracker (StartTime, EndTime, Duration) VALUES (@startTime, @endTime, @timeSpan)";

            var rowsAffected = connection.Execute(sql, codingSession);

            Console.WriteLine($"{rowsAffected} row(s) inserted.");

            connection.Close();
        }
    }

    public void GetRecords() {

    }

    public void Update() {

    }

    public void Delete() {

    }
}