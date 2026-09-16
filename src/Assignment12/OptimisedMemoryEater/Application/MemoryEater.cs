namespace AdvanceMemoryManagement.Application
{
    /// <summary>
    /// Simulates memory consumption by continuously allocating arrays on the managed heap
    /// until a specified memory threshold is reached.
    /// </summary>
    public class MemoryEater
    {
        /// <summary>
        /// Holds references to allocated arrays, preventing them from being garbage collected
        /// while memory usage is being increased.
        /// </summary>
        private List<int[]>? _memAlloc = new ();

        /// <summary>
        /// Continuously allocates memory on the managed heap until the specified heap limit
        /// is exceeded. After reaching the limit, all references are released and a garbage
        /// collection is explicitly triggered.
        /// </summary>
        /// <param name="heapLimit">
        /// The target heap size in megabytes (MB). Memory allocation stops when the
        /// managed heap usage exceeds this value.
        /// </param>
        public void Allocate(int heapLimit)
        {
            long limitBytes = heapLimit * 1024L * 1024L;
            while (true)
            {
                if (GC.GetTotalMemory(false) > limitBytes)
                {
                    break;
                }

                this._memAlloc!.Add(new int[1000]);
                Console.WriteLine($"Heap Used: {GC.GetTotalMemory(false) / 1024.0 / 1024.0:F2} MB");
                Thread.Sleep(1000);
            }

            this._memAlloc = null;
            GC.Collect();
        }
    }
}