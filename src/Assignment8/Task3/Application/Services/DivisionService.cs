namespace Task3.Application.Services
{
    /// <summary>
    /// Provides functionality for performing division operations.
    /// </summary>
    public class DivisionService
    {
        /// <summary>
        /// Divides one integer by another and returns the result.
        /// </summary>
        /// <param name="a">The dividend.</param>
        /// <param name="b">The divisor.</param>
        /// <returns>
        /// The quotient obtained after division.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// Thrown when divisor is zero.
        /// </exception>
        public int DivideTwoNumbers(int a, int b)
        {
            return a / b;
        }
    }
}