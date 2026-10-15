namespace Calculator.Application.Service
{
    /// <summary>
    /// Provides basic arithmetic operations for the calculator application.
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="number1">The first integer.</param>
        /// <param name="number2">The second integer.</param>
        /// <returns>The sum of <paramref name="number1"/> and <paramref name="number2"/>.</returns>
        public int PerformAddition(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Subtracts the second integer from the first integer.
        /// </summary>
        /// <param name="number1">The minuend.</param>
        /// <param name="number2">The subtrahend.</param>
        /// <returns>The difference between <paramref name="number1"/> and <paramref name="number2"/>.</returns>
        public int PerformSubtraction(int number1, int number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Multiplies two integers and returns the result.
        /// </summary>
        /// <param name="number1">The first integer.</param>
        /// <param name="number2">The second integer.</param>
        /// <returns>The product of <paramref name="number1"/> and <paramref name="number2"/>.</returns>
        public int PerformMultiplication(int number1, int number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Divides the first number by the second number.
        /// </summary>
        /// <param name="number1">The dividend.</param>
        /// <param name="number2">The divisor.</param>
        /// <returns>The quotient of <paramref name="number1"/> divided by <paramref name="number2"/>.</returns>
        /// <exception cref="DivideByZeroException">
        /// Thrown when <paramref name="number2"/> is zero.
        /// </exception>
        public double PerformDivision(double number1, double number2)
        {
            if (number2 == 0)
            {
                throw new ArgumentException("Divisor should not be zero");
            }

            return number1 / number2;
        }
    }
}