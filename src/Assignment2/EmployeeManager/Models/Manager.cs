namespace EmployeeManager.Models
{
    /// <summary>
    /// Represents a Manager employee.
    /// Inherits common employee properties and behavior from the Employee class.
    /// Provides manager-specific bonus calculation and detail printing.
    /// </summary>
    public class Manager : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name">The name of the manager.</param>
        /// <param name="salary">The salary of the manager.</param>
        public Manager(string name, string salary)
            : base(name, salary)
        {
        }

        /// <summary>
        /// Calculates the bonus for the manager.
        /// Managers receive 1/30th of their salary as a bonus.
        /// </summary>
        /// <returns>The calculated bonus amount.</returns>
        public override decimal CalculateBonus()
        {
            return this.Salary / 30;
        }

        /// <summary>
        /// Displays the manager's details, including
        /// name, position, salary, and calculated bonus.
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine(
                $"Employee Name {this.Name} \n" +
                $"Position Manager \n" +
                $"Salary {this.Salary} \n" +
                $"Bonus {this.CalculateBonus()}");
        }
    }
}