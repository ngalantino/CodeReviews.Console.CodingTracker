using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;

public class Program()
{
    public static void Main(string[] args)
    {
        DatabaseManager db = new DatabaseManager();

        var codingSession = new CodingSession() {startTime = "Learn Dapper", endTime = "It is fun.", timeSpan = "10s"};

        db.Insert(codingSession);
    }
}
