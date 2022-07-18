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
                        codingController.Get();
                        break;
                    case "2":
                        ProcessAdd();
                        break;
                    case "3":
                        ProcessDelete();
                        break;
                    case "4":
                        ProcessUpdate();
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command.  Please tyupe a number from 0 to 4.\n");
                        break;
                }                
            }
        }

        private void ProcessUpdate()
        {
            Console.Clear();
            codingController.Get();     //shows the database and the data in it.

            Console.WriteLine("\nPlease enter the record ID of the record you want to UPDATE or type 0 to go back to the main menu\n");
            string commandInput = Console.ReadLine();

            while (!Int32.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) || Int32.Parse(commandInput) < 0)
            {
                Console.WriteLine("\nYou have to type a valid Id (or 0 to return to Main Menu):\n");
                commandInput = Console.ReadLine();
            }
            var id = Int32.Parse(commandInput);

            if (id == 0) MainMenu();

            var coding = codingController.GetById(id);

            while (coding.Id == 0)
            {
                Console.WriteLine($"\nRecord with id {id} doesn't exist!\n");
                Task.Delay(2000).Wait();
                ProcessUpdate();
            }

            var updateInput = "";

            bool updating = true;
            while (updating == true)
            {
                Console.WriteLine($"\nType 'd' for Date \n");
                Console.WriteLine($"\nType 't' for Duration \n");
                Console.WriteLine($"\nType 's' to save update \n");
                Console.WriteLine($"\nType '0' to Go Back to Main Menu \n");

                updateInput = Console.ReadLine();

                switch (updateInput)
                {
                    case "d":
                        coding.Date = GetDateInput();
                        break;

                    case "t":
                        coding.Duration = GetDurationInput();
                        break;

                    case "0":
                        MainMenu();
                        updating = false;
                        break;

                    case "s":
                        updating = false;
                        break;

                    default:
                        Console.WriteLine($"\nType '0' to Go Back to Main Menu \n");
                        break;
                }
            }
            codingController.Update(coding);
            MainMenu();
        }

        private void ProcessAdd()
        {
            Coding coding = new Coding();

            coding.Date = GetDateInput();
            coding.Duration = GetDurationInput();

            codingController.Post(coding);
        }

        private void ProcessDelete()
        {
            Console.Clear();
            codingController.Get();

            Console.WriteLine("\nPlease enter the record ID of the record you want to delete or type 0 to go back to the main menu\n");
            string commandInput = Console.ReadLine();

            while(!Int32.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) || Int32.Parse(commandInput) < 0)
            {
                Console.WriteLine("\nYou have to type a valid Id (or 0 to return to Main Menu):\n");
                commandInput = Console.ReadLine();
            }
            var id = Int32.Parse(commandInput);

            if (id == 0) MainMenu();

            var coding = codingController.GetById(id);

            while (coding.Id == 0)
            {
                Console.WriteLine($"\nRecord with id {id} doesn't exist!\n");
                Task.Delay(2000).Wait();
                ProcessDelete();
            }

            codingController.Delete(id);
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