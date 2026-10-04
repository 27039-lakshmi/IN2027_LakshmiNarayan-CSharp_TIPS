using Task1.Infrastructure;

namespace Task1.Application
{
    /// <summary>
    /// Provides business logic operations for managing a list of books.
    /// </summary>
    public class BookListService
    {
        private BookListRepository<string> _listRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="listRepository">
        /// Repository used for storing and managing book records.
        /// </param>
        public BookListService(BookListRepository<string> listRepository)
        {
            this._listRepository = listRepository;
        }

        /// <summary>
        /// Adds a new book to the repository.
        /// </summary>
        /// <param name="book">The name or title of the book to add.</param>
        public void AddBook(string book)
        {
            this._listRepository.AddBook(book);
        }

        /// <summary>
        /// Removes an existing book from the repository.
        /// </summary>
        /// <param name="book">The name or title of the book to remove.</param>
        public void RemoveBook(string book)
        {
            this._listRepository.RemoveBook(book);
        }

        /// <summary>
        /// Retrieves all books from the repository.
        /// </summary>
        /// <returns>A list containing all stored book titles.</returns>
        public IEnumerable<string> GetBooks()
        {
            return this._listRepository.GetAllBooks();
        }

        /// <summary>
        /// Determines whether the specified book exists in the repository.
        /// </summary>
        /// <param name="book">The name or title of the book to search for.</param>
        /// <returns>
        /// <c>true</c> if the specified book exists; otherwise, <c>false</c>.
        /// </returns>
        public bool DoesBookExist(string book)
        {
            return this.GetBooks().Contains(book);
        }
    }
}