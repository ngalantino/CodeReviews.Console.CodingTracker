
using System.Collections;
using System.Configuration;
using System.Data;
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

    public async Task<IEnumerable<CodingSession>> GetRecords() {
        using (SqliteConnection connection = new SqliteConnection(ConfigurationManager.AppSettings.Get("sqliteDB"))) {
            
            IEnumerable<CodingSession> dbRecords = new List<CodingSession>();

            connection.Open();

            dbRecords = await connection.QueryAsync<CodingSession>("SELECT * FROM coding_tracker");

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
}