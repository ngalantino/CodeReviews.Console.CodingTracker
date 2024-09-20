using System.Data.Common;
using Spectre.Console;

public class Menu
{
    public void Display()
    {
        bool continueProgram = true;
        while (continueProgram)
        {
            Console.Clear();

            var menuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select an option")
                .PageSize(10)
                .MoreChoicesText("(Move up and down to reveal more options)")
                .AddChoices(new[] {
                    "Log new coding session",
                    "Show all coding sessions",
                    "Update previous coding session",
                    "Delete coding session",
                    "Exit program"
                })
            );

            switch (menuChoice)
            {
                case "Log new coding session":
                    CodingController.NewCodingSession();

                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "Show all coding sessions":
                    CodingController.ShowAllCodingSessions();

                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "Update previous coding session":
                    
                    Console.WriteLine("TODO: Update coding session");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "Delete coding session":
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "Exit program":
                    continueProgram = false;
                    break;

                default:
                    break;

            }
        }

    }

}