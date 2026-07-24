using EmployeeManager.Services;

namespace EmployeeManager.View
{
    /// <summary>
    /// Handles user interaction for employee management.
    /// Collects employee information, validates input,
    /// and delegates employee creation to the service layer.
    /// </summary>
    public class UserViewer
    {
        /// <summary>
        /// Starts the employee management workflow.
        /// Prompts the user for employee details, validates input,
        /// and allows the user to create either a Developer or Manager.
        /// The application continues running until the user chooses to exit.
        /// </summary>
        public static void Start()
        {
            string userChoice = "0";

            do
            {
                Console.WriteLine(
                    "Choose your position \n" +
                    "[1] Developer \n" +
                    "[2] Manager\n" +
                    "[3] Exit");

                userChoice = Console.ReadLine() ?? string.Empty;

                if (string.Equals(userChoice, "3"))
                {
                    Console.WriteLine("Exitting");
                    break;
                }

                Console.WriteLine("Enter your name");
                string name = Console.ReadLine() ?? string.Empty;

                if (!EmployeeService.IsNameValid(name))
                {
                    Console.WriteLine("Name is not valid.");
                    continue;
                }

                Console.WriteLine("Enter your salary");
                var salary = Console.ReadLine() ?? string.Empty;

                if (!int.TryParse(salary, out int _))
                {
                    Console.WriteLine("Salary should be a number");
                    continue;
                }
                else if (int.Parse(salary) < 0)
                {
                    Console.WriteLine("Salary cannot be negative");
                    continue;
                }

                // Handle empty or whitespace input.
                if (string.IsNullOrWhiteSpace(userChoice))
                {
                    userChoice = "0";
                }

                // Validate that the user's choice is numeric.
                if (int.TryParse(userChoice, out int _))
                {
                    switch (userChoice)
                    {
                        case "1":
                            bool isDeveloperCreated =
                                EmployeeService.CreateDeveloper(name, salary);

                            if (isDeveloperCreated)
                            {
                                Console.WriteLine("Developer Created");
                            }
                            else
                            {
                                Console.WriteLine("Salary should be a decimal");
                            }

                            break;

                        case "2":
                            bool isManagerCreated =
                                EmployeeService.CreateManager(name, salary);

                            if (isManagerCreated)
                            {
                                Console.WriteLine("Manager Created");
                            }
                            else
                            {
                                Console.WriteLine("Salary should be a decimal");
                            }

                            break;

                        default:
                            Console.WriteLine("Enter 1 or 2 or 3");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("User choice should be an integer");
                }
            }
            while (userChoice != "3");
        }

        /// <summary>
        /// Prompts the user to enter a color for the specified shape.
        /// </summary>
        /// <param name="shape">
        /// The name of the shape for which the color is requested.
        /// </param>
        /// <returns>
        /// The color entered by the user.
        /// </returns>
        public static string GetColorInput(string shape)
        {
            Console.WriteLine($"Enter color of {shape}");
            return Console.ReadLine() !;
        }
    }
}