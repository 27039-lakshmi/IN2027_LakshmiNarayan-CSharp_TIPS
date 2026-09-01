namespace Calculator.Domain.Enums
{
    /// <summary>
    /// Represents the arithmetic operations supported by the calculator.
    /// </summary>
    public enum CalculatorOperation
    {
        /// <summary>
        /// Performs addition of two numbers.
        /// </summary>
        Add = 1,

        /// <summary>
        /// Performs subtraction of one number from another.
        /// </summary>
        Subtract = 2,

        /// <summary>
        /// Performs multiplication of two numbers.
        /// </summary>
        Multiplication = 3,

        /// <summary>
        /// Performs division of one number by another.
        /// </summary>
        Division = 4,

        /// <summary>
        /// Exits the calculator application.
        /// </summary>
        Exit = 5,

        /// <summary>
        /// Represents an invalid or unsupported operation.
        /// </summary>
        Invalid = 6,
    }
}