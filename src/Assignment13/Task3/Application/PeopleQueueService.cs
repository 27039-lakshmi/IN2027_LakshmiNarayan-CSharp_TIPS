using Task3.Infrastructure;

namespace Task3.Application
{
    /// <summary>
    /// Provides business logic for managing a queue of people.
    /// Acts as an intermediary between the presentation layer
    /// and the queue repository.
    /// </summary>
    public class PeopleQueueService
    {
        private PeopleQueueRepository<string> _queueRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleQueueService"/> class.
        /// </summary>
        /// <param name="queueRepository">
        /// Repository used to store and manage the queue of people.
        /// </param>
        public PeopleQueueService(PeopleQueueRepository<string> queueRepository)
        {
            this._queueRepository = queueRepository;
        }

        /// <summary>
        /// Adds a person to the end of the queue.
        /// </summary>
        /// <param name="personName">
        /// The name of the person to add to the queue.
        /// </param>
        public void AddPerson(string personName)
        {
            this._queueRepository.Add(personName);
        }

        /// <summary>
        /// Removes the person at the front of the queue.
        /// </summary>
        public void RemovePerson()
        {
            this._queueRepository.Remove();
        }

        /// <summary>
        /// Retrieves all people currently in the queue.
        /// </summary>
        /// <returns>
        /// A list containing all people in the queue.
        /// </returns>
        public IEnumerable<string> GetPersonList()
        {
            return this._queueRepository.GetAllPersons();
        }
    }
}