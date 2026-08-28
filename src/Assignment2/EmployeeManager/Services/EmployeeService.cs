using EmployeeManager.Models;

namespace EmployeeManager.Services
{
    /// <summary>
    /// Provides functionality for creating employees,
    /// validating input, and displaying employee details.
    /// </summary>
    public static class EmployeeService
    {
        /// <summary>
        /// Creates employee with type developer or manager
        /// </summary>
        /// <param name="name">Name of the employee</param>
        /// <param name="salary">Salary of the employee</param>
        /// <param name="type">Whether he is a manager or developer</param>
        public static void CreateEmployee(string name, string salary, EmployeeType type)
        {
            if (type == EmployeeType.Developer)
            {
                var developer = new Developer(name, salary);
                PrintDetails(developer);
            }
            else
            {
                var manager = new Manager(name, salary);
                PrintDetails(manager);
            }
        }

        /// <summary>
        /// Validates whether the provided salary is a valid decimal value.
        /// </summary>
        /// <param name="salary">The salary value to validate.</param>
        /// <returns>
        /// True if the salary is a valid decimal number; otherwise, false.
        /// </returns>
        public static bool ValidateInputSalary(string salary)
        {
            return decimal.TryParse(salary, out decimal _);
        }

        /// <summary>
        /// Displays the details of the specified employee.
        /// </summary>
        /// <param name="employee">The employee whose details should be displayed.</param>
        public static void PrintDetails(Employee employee)
        {
            employee.PrintDetails();
        }

        /// <summary>
        /// Validates whether the provided employee name is valid.
        /// A valid name cannot be null, empty, or contain numeric characters.
        /// </summary>
        /// <param name="name">The employee name to validate.</param>
        /// <returns>
        /// True if the name is valid; otherwise, false.
        /// </returns>
        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // Ensure the name does not contain digits.
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}