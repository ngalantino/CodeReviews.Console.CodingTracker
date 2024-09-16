using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;

public class Program()
{
    public static async Task Main(string[] args)
    {
        DatabaseManager db = new DatabaseManager();

        var codingSession = new CodingSession() {startTime = "Learn Dapper", endTime = "", timeSpan = "10s"};

        db.Insert(codingSession);

        var records = await db.GetRecords();

        foreach (var record in records) {
            Console.WriteLine(record.startTime);
        }
    }
}


/*

1 - Start new coding session
2 - End coding session
3 - Show all coding sessions
4 - Update coding session
5 - Delete coding session

*/
