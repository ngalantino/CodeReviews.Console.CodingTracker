using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using Spectre.Console;

public class Program()
{
    public static async Task Main(string[] args)
    {
        DatabaseManager db = new DatabaseManager();

        //var codingSession = new CodingSession() {Id = 1, startTime = "Learn Dapper UPDATED", endTime = "", timeSpan = "5s"};

        //db.Insert(codingSession);

        //var records = await db.GetRecords();

        //foreach (var record in records) {
        //    Console.WriteLine(record.startTime);
        //}

        // db.Update(codingSession);
        CodingSession codingSession = new CodingSession() { Id = 2 };
        db.Delete(codingSession);

        var table = new Table();
        table.AddColumn(new TableColumn(new Markup("[yellow]Foo[/]")));
        table.AddColumn(new TableColumn("[blue]Bar[/]"));
        AnsiConsole.Write(table);

        Console.ReadLine();

    }
}


/*

1 - Start new coding session
2 - End coding session
3 - Show all coding sessions
4 - Update coding session
5 - Delete coding session

*/
