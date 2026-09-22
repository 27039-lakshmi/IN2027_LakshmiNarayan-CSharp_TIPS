namespace Assignments
{
    /// <summary>
    /// Demonstrates the use of multiple threads to perform addition and subtraction operations concurrently.
    /// The calculated results are stored in shared static fields and displayed after both threads complete execution.
    /// </summary>
    public class Program
    {
        private static int sum;
        private static int difference;

        /// <summary>
        /// Application entry point.
        /// Creates and starts separate threads for addition and subtraction operations,
        /// waits for both threads to complete, and displays the results.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                var thread1 = new Thread(() => { AddNumbers(4, 5); });
                var thread2 = new Thread(() => { SubtractNumbers(6, 4); });
                thread1.Start();
                thread2.Start();
                thread1.Join();
                thread2.Join();
                Console.WriteLine($"Sum : {sum} Difference : {difference}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Adds two integers and stores the result in the sum field.
        /// </summary>
        /// <param name="firstNumber">The first number to add.</param>
        /// <param name="secondNumber">The second number to add.</param>
        public static void AddNumbers(int firstNumber, int secondNumber)
        {
            sum = firstNumber + secondNumber;
        }

        /// <summary>
        /// Subtracts the second integer from the first and stores the result in the difference field.
        /// </summary>
        /// <param name="firstNumber">The number from which to subtract.</param>
        /// <param name="secondNumber">The number to subtract.</param>
        public static void SubtractNumbers(int firstNumber, int secondNumber)
        {
            difference = secondNumber - firstNumber;
        }
    }
}