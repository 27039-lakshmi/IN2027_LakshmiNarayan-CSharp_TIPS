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
        private readonly DivisionService _divisionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="divisionService">
        /// The division service used to perform arithmetic operations.
        /// </param>
        public Controller(DivisionService divisionService)
        {
            this._divisionService = divisionService;
        }

        /// <summary>
        /// Demonstrates nested exception handling for division operation and custom exception.
        /// </summary>
        public void Start()
        {
            try
            {
                this.ExecuteDivisionTask();
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
        /// Demonstrates exception handling for division operation.
        /// </summary>
        private void ExecuteDivisionTask()
        {
            try
            {
                Console.WriteLine("Task 1: Divide by zero exception");
                Console.WriteLine("Enter divisor as zero to throw DivideByZeroException");

                if (int.TryParse(Console.ReadLine(), out int inputNum))
                {
                    int result = this._divisionService.DivideTwoNumbers(10, inputNum);
                    Console.WriteLine($"Result: {result}");
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer.");
                }
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
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