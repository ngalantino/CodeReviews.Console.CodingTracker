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

        bool validDates = false;
        DateTime startTime;
        DateTime endTime;

        while (!validDates)
        {

            Console.WriteLine("Enter start date and time (M/d/yyyy h:mm AM/PM)");
            startTime = InputValidation.ParseDateTime();

            Console.WriteLine("Enter end date and time (M/d/yyyy h:mm AM/PM)");
            endTime = InputValidation.ParseDateTime();

            if ((int)endTime.Subtract(startTime).TotalSeconds < 0)
            {
                Console.WriteLine("End time must be later than start time!");
                validDates = false;
            }

            else
            {
                CodingSession codingSession = new CodingSession { startTime = startTime, endTime = endTime };

                _db.Insert(codingSession);
                
                validDates = true;
            }

        }

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

    public static void DeleteCodingSession()
    {
        ShowAllCodingSessions();

        Console.WriteLine("Enter the Id of the coding session you would like to delete.");

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

        CodingSession codingSession = new CodingSession() { Id = Id };

        _db.Delete(codingSession);
    }
}
