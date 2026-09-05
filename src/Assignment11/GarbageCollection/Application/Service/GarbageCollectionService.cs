namespace GarbageCollection.Application.Service
{
    /// <summary>
    /// Provides methods for demonstrating memory allocation
    /// and garbage collection behavior in .NET.
    /// </summary>
    public class GarbageCollectionService
    {
        /// <summary>
        /// Creates a large integer array, populates it with values,
        /// and then releases the reference to make it eligible for
        /// garbage collection.
        /// </summary>
        public void CreateAndDestroyMemory()
        {
            int[] array = new int[100000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            Console.ReadKey(); // used for breakpoint
            array = null!;
        }
    }
}