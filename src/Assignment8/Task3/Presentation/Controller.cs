using Task3.Application.Services;
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
        /// Service used to perform division operations.
        /// </summary>
        private readonly DivisionService _dividor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="dividor">
        /// The division service used to perform arithmetic operations.
        /// </param>
        public Controller(DivisionService dividor)
        {
            this._dividor = dividor;
        }

        /// <summary>
        /// Reads user input and performs division operations while demonstrating
        /// multiple exception handling scenarios.
        /// </summary>
        public void Start()
        {
            try
            {
                try
                {
                    Console.WriteLine("Task 1: Divide by zero exception");
                    Console.WriteLine("Enter dividor ");
                    if (int.TryParse(Console.ReadLine(), out int inputNum))
                    {
                        int result = this._dividor.DivideTwoNumbers(10, inputNum);
                        Console.WriteLine("Result : " + result);
                    }

                    Console.WriteLine("Task 3: Throw custom exception");
                    Console.WriteLine("Enter input as null or whitespace to execute custom exception");
                    string? userInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        throw new InvalidUserInputException(
                            "User input should not be null");
                    }
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero");
                }
                catch (InvalidUserInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
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
    }
}