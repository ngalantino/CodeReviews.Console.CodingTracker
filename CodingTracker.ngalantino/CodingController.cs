using System.Data.Common;
using System.Globalization;
using Spectre.Console;
internal static class CodingController
{
    private static DatabaseManager _db;
    static CodingController()
    {
        _db = new DatabaseManager();
    }

    public static void NewCodingSession()
    {
        // TODO: Validate end date is after start date.

        Console.WriteLine("Enter start date and time (M/d/yyyy h:mm AM/PM)");
        DateTime startTime = InputValidation.ParseDateTime();

        Console.WriteLine("Enter end date and time (M/d/yyyy h:mm AM/PM)");
        DateTime endTime = InputValidation.ParseDateTime();

        CodingSession codingSession = new CodingSession { startTime = startTime, endTime = endTime };

        _db.Insert(codingSession);
    }

    public static void ShowAllCodingSessions()
    {
        List<CodingSession> codingSessions = _db.GetRecords();
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Start time");
        table.AddColumn("End time");
        table.AddColumn("Duration");

        foreach (var session in codingSessions)
        {
            table.AddRow(session.Id.ToString(), session.startTime.ToString(), session.endTime.ToString(), session.timeSpan.ToString());
        }
        AnsiConsole.Write(table);
    }

    public static void UpdateCodingSession()
    {

        ShowAllCodingSessions();

        Console.WriteLine("Enter the Id of the coding session you would like to update.");

        string input;
        long Id = 0;
        bool validInput = false;

        while (!validInput)
        {
            try
            {
                input = Console.ReadLine();
                Id = long.Parse(input);
                validInput = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Id, try again.");
                validInput = false;

            }
        }

        Console.WriteLine("Enter start date and time (M/d/yyyy h:mm AM/PM)");
        DateTime startTime = InputValidation.ParseDateTime();

        Console.WriteLine("Enter end date and time (M/d/yyyy h:mm AM/PM)");
        DateTime endTime = InputValidation.ParseDateTime();

        CodingSession updatedCodingSession = new CodingSession
        {
            startTime = startTime,
            endTime = endTime,
            Id = Id
        };

        _db.Update(updatedCodingSession);

    }
}
