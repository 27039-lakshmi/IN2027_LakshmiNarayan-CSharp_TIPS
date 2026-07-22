namespace EmployeeManager.Models
{
    /// <summary>
    /// Represents the base class for all employee types.
    /// Contains common employee properties and defines
    /// methods that must be implemented by derived classes.
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="salary">The salary of the employee as a string value.</param>
        protected Employee(string name, string salary)
        {
            this.Name = name;
            this.Salary = decimal.Parse(salary);
        }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// A string representing the employee's name.
        /// </value>
        protected string Name { get; set; }

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        /// <value>
        /// A decimal value representing the employee's salary.
        /// </value>
        protected decimal Salary { get; set; }

        /// <summary>
        /// Calculates the bonus amount for the employee.
        /// Each derived employee type must provide its own bonus calculation logic.
        /// </summary>
        /// <returns>The calculated bonus amount.</returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Displays the employee's details.
        /// Each derived employee type must provide its own implementation.
        /// </summary>
        public abstract void PrintDetails();
    }
}