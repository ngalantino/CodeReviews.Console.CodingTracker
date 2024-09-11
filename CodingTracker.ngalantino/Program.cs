using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;

// string sAttr;

// sAttr = ConfigurationManager.AppSettings.Get("Key0");

// Console.WriteLine("The value of Key0 is "+sAttr);

public class Program()
{
    public static void Main(string[] args)
    {

        using (var connection = new SqliteConnection(ConfigurationManager.AppSettings.Get("sqliteDB")))
        {
            connection.Open();

            SqliteCommand tableCmd = connection.CreateCommand();

            tableCmd.CommandText =
            @"CREATE TABLE IF NOT EXISTS coding_tracker (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                StartTime TEXT,
                EndTime TEXT,
                Duration INTEGER
                )";

            tableCmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
