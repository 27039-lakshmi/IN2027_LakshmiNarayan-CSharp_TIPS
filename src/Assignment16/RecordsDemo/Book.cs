namespace RecordsDemo
{
    /// <summary>
    /// Represents a book with a title, author name, and ISBN number.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="authorName">The name of the author.</param>
    /// <param name="isbn">The ISBN number of the book.</param>
    public record Book(string title, string authorName, int isbn);
}