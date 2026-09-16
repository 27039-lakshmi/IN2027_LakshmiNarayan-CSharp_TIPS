namespace EmployeeManager.Models
{
    /// <summary>
    /// Represents a Developer employee.
    /// Inherits common employee properties and behavior from the Employee class.
    /// Provides developer-specific bonus calculation and detail printing.
    /// </summary>
    public class Developer : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name">The name of the developer.</param>
        /// <param name="salary">The salary of the developer.</param>
        public Developer(string name, string salary)
            : base(name, salary)
        {
        }

        /// <summary>
        /// Calculates the bonus for the developer.
        /// Developers receive 10% of their salary as a bonus.
        /// </summary>
        /// <returns>The calculated bonus amount.</returns>
        public override decimal CalculateBonus()
        {
            return this.Salary / 10;
        }

        /// <summary>
        /// Displays the developer's details, including
        /// name, position, salary, and calculated bonus.
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine(
                $"Employee Name {this.Name} \n" +
                $"Position Developer \n" +
                $"Salary {this.Salary} \n" +
                $"Bonus {this.CalculateBonus():F2}");
        }
    }
}