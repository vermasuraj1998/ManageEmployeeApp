#region One Single Operation 
//using ManageEmployeeApp.Helpers;

//namespace ManageEmployeeApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ShowHelp(); // Show available commands

//            Console.Write("\n Enter command: ");
//            string input = Console.ReadLine();

//            // Parse the input like command-line args
//            args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

//            if (args.Length == 0)
//            {
//                Console.WriteLine("No command entered.");
//                return;
//            }

//            string command = args[0].ToLower();

//            switch (command)
//            {
//                case "-list":
//                    string filter = args.Length > 1 ? args[1] : null;
//                    EmployeeManager.ListEmployees(filter);
//                    break;

//                case "-titles":
//                    EmployeeManager.ListTitles();
//                    break;

//                case "-add":
//                    EmployeeManager.AddEmployee();
//                    break;

//                default:
//                    Console.WriteLine(" Invalid command.");
//                    break;
//            }

//            Console.WriteLine("\nDone. Press any key to exit...");
//            Console.ReadKey();
//        }

//        static void ShowHelp()
//        {
//            Console.WriteLine(" Usage Instructions:");
//            Console.WriteLine("  -list                 : List all employees and current salary");
//            Console.WriteLine("  -list [filter]        : Filter by name or title");
//            Console.WriteLine("  -titles               : Show all titles with min and max salary");
//            Console.WriteLine("  -add                  : Add a new employee via prompts");
//        }
//    }
//}
#endregion

using ManageEmployeeApp.Helpers;

namespace ManageEmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShowHelp();

                Console.Write("\nEnter command (or type 'exit' to quit): ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Empty command. Try again.");
                    continue;
                }

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(" Exiting the application...");
                    break;
                }

                // Simulate command-line args
                args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = args[0].ToLower();
                string filter = args.Length > 1 ? args[1] : null;

                switch (command)
                {
                    case "-list":
                        EmployeeManager.ListEmployees(filter);
                        break;

                    case "-titles":
                        EmployeeManager.ListTitles();
                        break;

                    case "-add":
                        EmployeeManager.AddEmployee();
                        break;

                    default:
                        Console.WriteLine(" Invalid command.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear(); // Optional: clears console before showing menu again
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine(" Usage Instructions: ");
            Console.WriteLine("  -list                 : List all employees and current salary");
            Console.WriteLine("  -list [filter]        : Filter by name or title");
            Console.WriteLine("  -titles               : Show all titles with min and max salary");
            Console.WriteLine("  -add                  : Add a new employee via prompts");
            Console.WriteLine("  exit                  : Exit the application");
        }
    }
}
