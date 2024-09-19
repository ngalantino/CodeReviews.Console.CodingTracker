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
                    "Start new coding session",
                    "End coding session",
                    "Show all coding sessions",
                    "Update coding session",
                    "Delete coding session",
                    "Exit program"
                })
            );

            switch (menuChoice)
            {
                case "Start new coding session":
                    Console.WriteLine("TODO: Start new coding session");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "End coding session":
                    Console.WriteLine("TODO: End coding session");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "Show all coding sessions":
                    Console.WriteLine("TODO: Show all coding sessions");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "Update coding session":
                    Console.WriteLine("TODO: Update coding session");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;

                case "Delete coding session":
                    Console.WriteLine("TODO: Delete coding session");
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