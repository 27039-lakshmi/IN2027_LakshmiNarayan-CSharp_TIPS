using EmployeeManager.Services;
namespace EmployeeManager.View
{
    internal class UserViewer
    {
        public static void Start()
        {            
            string? userChoice;
            do
            {
                Console.WriteLine("Choose your position \n" +
                    "[1] Developer \n[2] Manager\n[3] Exit");
                userChoice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userChoice))
                {
                    userChoice = "0";
                }
                if (int.TryParse(userChoice, out int _))
                {
                    Console.WriteLine("Enter your name");
                    string name=Console.ReadLine();
                    Console.WriteLine("Enter your salary");
                    string salary=Console.ReadLine();
                    switch (userChoice)
                    {
                        case "1":
                            bool isDeveloperCreated = EmployeeService.CreateDeveloper(name, salary);
                            if(isDeveloperCreated)
                            {
                                Console.WriteLine("Developer Created");
                                
                            }
                            else
                            {
                                Console.WriteLine("Salary should be a decimal");
                            }
                            break;

                        case "2":
                            bool isManagerCreated = EmployeeService.CreateManager(name, salary);
                            if (isManagerCreated)
                            {
                                Console.WriteLine("Manager Created");
                            }
                            else
                            {
                                Console.WriteLine("Salary should be a decimal");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Exitting ...");
                            break;
                        default:
                            Console.WriteLine("Enter 1 or 2 or 3");
                            break;
                    }
                }
            }
            while (userChoice != "3");
        }

        public static string GetColorInput(string shape)
        {
            Console.WriteLine($"Enter color of {shape}");
            return Console.ReadLine()!;
        }
    }
}
