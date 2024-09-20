using System.Globalization;

public class InputValidation
{

    public static DateTime ParseDateTime()
    {

        string dateInput = Console.ReadLine();
        DateTime dateOutput;

        while (!DateTime.TryParseExact(dateInput, "M/d/yyyy h:mm tt", new CultureInfo("en-US"), DateTimeStyles.None, out dateOutput))
        {
            Console.WriteLine("\n\nInvalid date. (M/d/yyyy h:mm AM/PM).\n\n");
            dateInput = Console.ReadLine();
        }

        return dateOutput;

    }
}