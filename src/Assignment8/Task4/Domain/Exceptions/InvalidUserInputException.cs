namespace Task4.Domain.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the user provides
    /// invalid, empty, or missing input.
    /// </summary>
    internal class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="InvalidUserInputException"/> class with a specified
        /// error message.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}