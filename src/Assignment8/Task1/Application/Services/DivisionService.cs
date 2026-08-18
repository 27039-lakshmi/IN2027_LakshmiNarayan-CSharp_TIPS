namespace Task1.Application.Services
{
    /// <summary>
    /// Provides functionality for performing division operations.
    /// </summary>
    internal class DivisionService
    {
        /// <summary>
        /// Divides one integer by another and returns the result.
        /// </summary>
        /// <param name="a">The dividend (number to be divided).</param>
        /// <param name="b">The divisor (number by which the dividend is divided).</param>
        /// <returns>
        /// The quotient obtained by dividing <paramref name="a"/> by <paramref name="b"/>.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// Thrown when <paramref name="b"/> is zero.
        /// </exception>
        public int DivideTwoNumbers(int a, int b)
        {
            return a / b;
        }
    }
}