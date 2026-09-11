namespace Task3.Infrastructure
{
    /// <summary>
    /// Represents a generic repository for managing a queue of people.
    /// Provides operations to add, remove, and retrieve queue items.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements stored in the queue.
    /// </typeparam>
    public class PersonQueueRepository<T>
    {
        private readonly Queue<T> _personList = new ();

        /// <summary>
        /// Adds a person to the end of the queue.
        /// </summary>
        /// <param name="personName">
        /// The person to be added to the queue.
        /// </param>
        public void Add(T personName)
        {
            this._personList.Enqueue(personName);
        }

        /// <summary>
        /// Removes the person at the front of the queue.
        /// </summary>
        public void Remove()
        {
            this._personList.Dequeue();
        }

        /// <summary>
        /// Retrieves all people currently stored in the queue.
        /// </summary>
        /// <returns>
        /// A list containing all people in the queue in their current order.
        /// </returns>
        public List<T> GetAllPersons()
        {
            return this._personList.ToList();
        }
    }
}