using System.Diagnostics;

namespace Assignments
{
    /// <summary>
    /// Demonstrates the difference between sequential and parallel execution
    /// by calculating and displaying the square of each number in an array.
    /// Measures and compares the execution time of both approaches.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Creates the sample data, executes both sequential and parallel
        /// processing methods, and displays their execution times.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            int[] numbers = CreateIntegerArray();

            double timeTakenForSequential = MeasureTimeForSequentital(numbers);
            double timeTakenForParallel = MeasureTimeForParallel(numbers);

            Console.WriteLine("Time taken for sequential execution : " + timeTakenForSequential);
            Console.WriteLine("Time taken for parallel execution : " + timeTakenForParallel);
        }

        /// <summary>
        /// Creates and initializes an array of integers ranging from 0 to 9999.
        /// </summary>
        /// <returns>
        /// An array containing 10,000 sequential integer values.
        /// </returns>
        private static int[] CreateIntegerArray()
        {
            int[] numbers = new int[10000];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            return numbers;
        }

        /// <summary>
        /// Processes the array sequentially by calculating and
        /// displaying the square of each number.
        /// Measures the total execution time.
        /// </summary>
        /// <param name="numbers">
        /// The array of integers to process.
        /// </param>
        /// <returns>
        /// The time taken for sequential execution in milliseconds.
        /// </returns>
        private static double MeasureTimeForSequentital(int[] numbers)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int number in numbers)
            {
                Console.WriteLine(number * number);
            }

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Processes the array in parallel using <see cref="Parallel.ForEach"/>
        /// by calculating and displaying the square of each number.
        /// Measures the total execution time.
        /// </summary>
        /// <param name="numbers">
        /// The array of integers to process.
        /// </param>
        /// <returns>
        /// The time taken for parallel execution in milliseconds.
        /// </returns>
        private static double MeasureTimeForParallel(int[] numbers)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.ForEach(numbers, number => Console.WriteLine(number * number));

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}