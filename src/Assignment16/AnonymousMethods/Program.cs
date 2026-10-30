namespace Assignments
{
    /// <summary>
    /// Demonstrates sorting an integer array using Array.Sort
    /// with an anonymous method (delegate).
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// Creates an array, displays its original contents,
        /// sorts it, and then displays the sorted contents.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                int[] numbers = { 5, 2, 6, 4, 7 };
                Console.WriteLine("Original Array");
                PrintArray(numbers);

                SortArray(numbers);

                Console.WriteLine("Sorted Array");
                PrintArray(numbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Sorts the provided integer array in ascending order
        /// using Array.Sort and an anonymous delegate.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        private static void SortArray(int[] arr)
        {
            Array.Sort(
                arr,
                delegate(int firstNumber, int secondNumber)
                {
                    return firstNumber.CompareTo(secondNumber);
                });
        }

        /// <summary>
        /// Prints all elements of the array to the console.
        /// </summary>
        /// <param name="arr">The array whose elements are to be displayed.</param>
        private static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine();
        }
    }
}