namespace ValueReferenceType.Application.Services
{
    /// <summary>
    /// Provides methods to demonstrate the behavior of value types,
    /// reference types, stack memory, and heap memory in .NET.
    /// </summary>
    public class ValueReferenceDemoService
    {
        /// <summary>
        /// Demonstrates the difference between passing a value type and
        /// a reference type to a method.
        /// </summary>
        /// <param name="value">
        /// The value type parameter whose changes remain local to the method.
        /// </param>
        /// <param name="array">
        /// The reference type parameter whose contents can be modified within the method.
        /// </param>
        /// <param name="newValue">
        /// The new value assigned to both the value parameter and the first element of the array.
        /// </param>
        public void ChangeValue(int value, int[] array, int newValue)
        {
            value = newValue;
            array[0] = newValue;
        }

        /// <summary>
        /// Creates and initializes a large array to demonstrate heap memory allocation.
        /// </summary>
        /// <param name="size">
        /// The number of elements to allocate in the array.
        /// </param>
        public void CreateLargeArray(int size)
        {
            Console.WriteLine("Creating large array...");
            var largeArray = new int[size];
            for (int i = 0; i < largeArray.Length; i++)
            {
                largeArray[i] = i;
            }
        }

        /// <summary>
        /// Performs a simple calculation using local variables to demonstrate
        /// stack memory usage.
        /// </summary>
        public void PerformLargeCalculation()
        {
            Console.WriteLine("Performing large calculation...");
            int a1 = 1;
            int a2 = 2;
            int a3 = 3;
            int a4 = 4;
            int a5 = 5;
            int a6 = 6;
            int a7 = 7;
            int a8 = 8;
            int a9 = 9;
            int a10 = 10;
            long result =
                a1 + a2 + a3 + a4 + a5 +
                a6 + a7 + a8 + a9 + a10;
        }
    }
}