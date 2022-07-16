// See https://aka.ms/new-console-template for more information
using System.Globalization;

namespace CodingTracker
{
    internal class GetUserInput
    {
        CodingController codingController = new();
        internal void MainMenu()
        {
            bool closeApp = false;
            while(closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application.");
                Console.WriteLine("Type 1 to View Record");
                Console.WriteLine("Type 2 to Add Record");
                Console.WriteLine("Type 3 to Delete Record");
                Console.WriteLine("Type 4 to Update Record");

                string commandInput = Console.ReadLine();

                while (string.IsNullOrEmpty(commandInput))
                {
                    Console.WriteLine("\nInvalid Command.  Please enter a number from 0 to 4.\n");
                    commandInput = Console.ReadLine();
                }
                switch (commandInput)
                {
                    case "0":
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                        //codingController.Get();
                        break;
                    case "2":
                        ProcessAdd();
                        break;
                    case "3":
                        //ProcessDelete();
                        break;
                    case "4":
                        //ProcessUpdate();
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command.  Please tyupe a number from 0 to 4.\n");
                        break;
                }                
            }
        }
        private void ProcessAdd()
        {
            var date = GetDateInput();
            var duration = GetDurationInput();

            Coding coding = new Coding();

            coding.Date = date;
            coding.Duration = duration;

            codingController.Post(coding);
        }

        internal string GetDurationInput()
        {
            Console.WriteLine("\n\nPlease enter the duration:  (Format: hh:mm) Type 0 to return to the Main Menu.\n\n");

            string durationInput = Console.ReadLine();
            if (durationInput == "0") MainMenu();

            while (!TimeSpan.TryParseExact(durationInput, "hh\\:mm", CultureInfo.InvariantCulture, out _))
            {
                Console.WriteLine("\n\nDuration Invalid.  Please insert the duration: (Format: hh:mm) or type 0 to return to main menu.\n\n");
                durationInput = Console.ReadLine();
                if (durationInput == "0") MainMenu();
            }

            return durationInput;
        }

        private string GetDateInput()
        {
            Console.WriteLine("\n\nPlease insert the date:  (Format: MM-DD-YY) Type 0 to return to the Main Menu.\n\n");

            string dateInput = Console.ReadLine();
            if (dateInput == "0") MainMenu();

            while(!DateTime.TryParseExact(dateInput, "MM-dd-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
            {
                Console.WriteLine("\n\nNot a valid date.  Please insert the date with the format:  MM-DD-YY.\n\n");
                dateInput = Console.ReadLine();
                if (dateInput == "0") MainMenu();
            }

            return dateInput;
        }
    }
}