namespace MathApp
{
    /// <summary>
    /// Provides basic arithmetic operations such as addition,
    /// subtraction, multiplication, and division.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds two numbers and returns the result.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Divides the first number by the second number.
        /// </summary>
        /// <param name="number1">The dividend.</param>
        /// <param name="number2">The divisor.</param>
        /// <returns>The quotient of the division.</returns>
        public static double Divide(double number1, double number2)
        {
            return number1 / number2;
        }

        /// <summary>
        /// Multiplies two numbers and returns the result.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <returns>The product of the two numbers.</returns>
        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Subtracts the second number from the first number.
        /// </summary>
        /// <param name="number1">The number from which to subtract.</param>
        /// <param name="number2">The number to subtract.</param>
        /// <returns>The difference between the two numbers.</returns>
        public static double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        private static void Main(string[] args)
        {
        }
    }
}