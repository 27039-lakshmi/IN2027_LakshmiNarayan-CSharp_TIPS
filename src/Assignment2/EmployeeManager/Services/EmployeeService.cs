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
        /// Creates a Developer employee if the provided salary is valid.
        /// </summary>
        /// <param name="name">The name of the developer.</param>
        /// <param name="salary">The salary of the developer.</param>
        /// <returns>
        /// True if the developer was created successfully; otherwise, false.
        /// </returns>
        public static bool CreateDeveloper(string name, string salary)
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

        /// <summary>
        /// Creates a Manager employee if the provided salary is valid.
        /// </summary>
        /// <param name="name">The name of the manager.</param>
        /// <param name="salary">The salary of the manager.</param>
        /// <returns>
        /// True if the manager was created successfully; otherwise, false.
        /// </returns>
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

        /// <summary>
        /// Validates whether the provided salary is a valid decimal value.
        /// </summary>
        /// <param name="salary">The salary value to validate.</param>
        /// <returns>
        /// True if the salary is a valid decimal number; otherwise, false.
        /// </returns>
        public static bool ValidateInput(string salary)
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