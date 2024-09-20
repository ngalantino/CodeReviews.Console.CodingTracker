
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
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

            // Use anonymous object to parse DateTime and TimeSpan to strings.
            var data = new {
                startTime = codingSession.startTime.ToString(),
                endTime = codingSession.endTime.ToString(),
                timeSpan = codingSession.timeSpan.ToString()
            };

            var rowsAffected = connection.Execute(sql, data);

            Console.WriteLine($"{rowsAffected} row(s) inserted.");

            connection.Close();
        }
    }

    public List<CodingSession> GetRecords() {
        using (SqliteConnection connection = new SqliteConnection(ConfigurationManager.AppSettings.Get("sqliteDB"))) {
            
            List<CodingSession> dbRecords = new List<CodingSession>();

            connection.Open();

            dbRecords = connection.Query("SELECT * FROM coding_tracker").Select(record => new CodingSession {
                startTime = DateTime.ParseExact(record.StartTime, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                endTime = DateTime.ParseExact(record.EndTime, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            }).ToList();           

            connection.Close();

            return dbRecords;
        }
    }

    public void Update(CodingSession codingSession) {
        using (SqliteConnection connection = new SqliteConnection(ConfigurationManager.AppSettings.Get("sqliteDB"))) {
            connection.Open();

            var sql = @"UPDATE coding_tracker SET 
                        StartTime = @startTime,
                        EndTime = @endTime,
                        Duration = @timeSpan
                        WHERE Id = @Id";

            var affectedRows = connection.Execute(sql, codingSession);

            connection.Close();
        }
    }

    public void Delete(CodingSession codingSession) {
        using (SqliteConnection connection = new SqliteConnection(ConfigurationManager.AppSettings.Get("sqliteDB"))) {
            connection.Open();

            var sql = @"DELETE FROM coding_tracker
                        WHERE Id = @Id";

            var affectedRows = connection.Execute(sql, codingSession);

            connection.Close();
        }
    }

    public void SeedDb() {
        CodingSession codingSession = new CodingSession() {
            startTime = new DateTime(2024, 9, 20),
            endTime = new DateTime(2024, 9, 4),
        };

        Insert(codingSession);
    }
}