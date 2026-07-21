using EmployeeManager.Models;
namespace EmployeeManager.Services
{
    internal static class EmployeeService
    {
        public static bool CreateDeveloper(string name , string salary)
        {
            if (ValidateInput(salary))
            {
                var developer = new Developer(name, salary);
                PrintDetails(developer);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool CreateManager(string name, string salary)
        {
            if (ValidateInput(salary))
            {
                var manager = new Manager(name, salary);
                PrintDetails(manager);
                return true;
            }
            else 
            {
                return false;
            }
        }

        public static bool ValidateInput(string salary)
        {
            return decimal.TryParse(salary, out decimal _);
        }

        public static void PrintDetails(Employee employee)
        {
            employee.PrintDetails();
        }
    }
}
