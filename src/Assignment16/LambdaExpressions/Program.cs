namespace Assignments
{
    /// <summary>
    /// Demonstrates the use of lambda expressions and LINQ methods
    /// to filter and transform a collection of integers.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// Displays the original list, filters odd numbers,
        /// squares them, and prints the results.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            Console.WriteLine("Original List");
            PrintNumbers(numbers);

            var oddNumbers = GetOddNumbers(numbers);

            Console.WriteLine("Odd Numbers");
            PrintNumbers(oddNumbers);

            var squaredNumbers = GetSquaredNumbers(oddNumbers);

            Console.WriteLine("Squared Odd Numbers");
            PrintNumbers(squaredNumbers);
        }

        /// <summary>
        /// Prints the numbers in the provided collection.
        /// </summary>
        /// <param name="numbers">The collection of integers to display.</param>
        private static void PrintNumbers(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Squares each number in the collection using a lambda expression
        /// and returns the resulting sequence.
        /// </summary>
        /// <param name="numbers">The collection of integers to square.</param>
        /// <returns>A collection containing the squared values.</returns>
        private static IEnumerable<int> GetSquaredNumbers(IEnumerable<int> numbers)
        {
            return numbers.Select(n => n * n);
        }

        /// <summary>
        /// Filters and returns only the odd numbers from the collection
        /// using the LINQ Where method and a lambda expression.
        /// </summary>
        /// <param name="numbers">The collection of integers to filter.</param>
        /// <returns>A collection containing only odd numbers.</returns>
        private static IEnumerable<int> GetOddNumbers(IEnumerable<int> numbers)
        {
            return numbers.Where(n => n % 2 != 0);
        }
    }
}
