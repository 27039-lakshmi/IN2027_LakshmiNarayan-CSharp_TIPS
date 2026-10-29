namespace SerializationAPI
{
    /// <summary>
    /// Represents an employee with an identifier and salary information.
    /// Used for demonstrating serialization of a simple object.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique employee identifier.
        /// </summary>
        /// <value>Id of the employee</value>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the employee's salary.
        /// </summary>
        /// <value>Salary of the employee</value>
        public double Salary { get; set; }
    }
}