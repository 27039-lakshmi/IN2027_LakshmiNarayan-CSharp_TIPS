using Task3.Domain.Exceptions;

namespace Task3.Presentation
{
    /// <summary>
    /// Controller responsible for handling user input, performing division operations,
    /// and demonstrating the handling of custom and system exceptions.
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Demonstrates nested exception handling for division operation and custom exception.
        /// </summary>
        public void Start()
        {
            try
            {
                this.ExecuteCustomExceptionTask();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Finally is executing");
            }
        }

        /// <summary>
        /// Demonstrates exception handling with custom exception.
        /// </summary>
        private void ExecuteCustomExceptionTask()
        {
            try
            {
                Console.WriteLine("Task 3: Throw custom exception");
                Console.WriteLine("Enter input as null or whitespace to execute custom exception");
                string? userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    throw new InvalidUserInputException("User input should not be null");
                }
            }
            catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}