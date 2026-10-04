namespace Task1.Infrastructure
{
    /// <summary>
    /// Represents a generic repository for managing a collection of books.
    /// </summary>
    /// <typeparam name="T">
    /// The type of book object stored in the repository.
    /// </typeparam>
    public class BookListRepository<T>
    {
        private readonly List<T> _books = new ();

        /// <summary>
        /// Adds a book to the repository.
        /// </summary>
        /// <param name="book">
        /// The book instance to add.
        /// </param>
        public void AddBook(T book)
        {
            this._books.Add(book);
        }

        /// <summary>
        /// Removes a book from the repository.
        /// </summary>
        /// <param name="book">
        /// The book instance to remove.
        /// </param>
        public void RemoveBook(T book)
        {
            this._books.Remove(book);
        }

        /// <summary>
        /// Retrieves all books stored in the repository.
        /// </summary>
        /// <returns>
        /// A new list containing all books currently stored in the repository.
        /// </returns>
        public IEnumerable<T> GetAllBooks()
        {
            return this._books.ToList();
        }
    }
}