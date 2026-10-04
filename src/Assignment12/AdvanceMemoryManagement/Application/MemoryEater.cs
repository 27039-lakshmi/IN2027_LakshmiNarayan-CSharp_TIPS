namespace AdvanceMemoryManagement.Application
{
    /// <summary>
    /// Simulates continuous memory allocation on the managed heap
    /// to demonstrate memory consumption behavior and garbage collection.
    /// </summary>
    public class MemoryEater
    {
        /// <summary>
        /// Stores references to allocated integer arrays, preventing them
        /// from being garbage collected while the application is running.
        /// </summary>
        private List<int[]> _memAlloc = new ();

        /// <summary>
        /// Continuously allocates memory by creating integer arrays and adding them
        /// to the internal collection. The current heap usage is displayed after
        /// each allocation cycle.
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                this._memAlloc.Add(new int[1000]);
                Console.WriteLine($"Heap Used: {GC.GetTotalMemory(false) / 1024.0 / 1024.0:F2} MB");
                Thread.Sleep(1000);
            }
        }
    }
}