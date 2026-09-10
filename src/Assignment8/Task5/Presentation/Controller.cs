using Task5.Application.Services;
using Task5.Domain.Exceptions;

namespace Task5.Presentation
{
    /// <summary>
    /// Controller responsible for validating user input, performing division operations,
    /// and demonstrating various exception handling mechanisms including custom exceptions,
    /// nested try-catch blocks, and application-level unhandled exception handling.
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
        /// Demonstrates nested exception handling for division operation, custom exception and app domain unhandle exception.
        /// </summary>
        public void Start()
        {
            try
            {
                this.ExecuteDivisionTask();
                this.ExecuteCustomExceptionTask();
                this.ExecuteAppDomainTask();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally is executing");
            }
        }

        /// <summary>
        /// Handles unhandled exceptions raised in the current application domain.
        /// </summary>
        /// <param name="sender">
        /// The object that raised the event.
        /// </param>
        /// <param name="e">
        /// Contains information about the unhandled exception.
        /// </param>
        public void OnUnhandledException(
            object sender,
            UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;

            Console.WriteLine(ex.Message);

            Console.WriteLine("Stack trace:");
            Console.WriteLine(ex.StackTrace);
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

        /// <summary>
        /// Demonstrates exception handling with App Domain unhandled exception.
        /// </summary>
        private void ExecuteAppDomainTask()
        {
            Console.WriteLine("Task 4: Use appdomain for unhandle exception.");
            Console.WriteLine("Enter a string to get exception");
            string input = Console.ReadLine() ?? string.Empty;
            this.ConvertStringToInt(input);
        }

        /// <summary>
        /// Attempts to convert a string value to an integer.
        /// </summary>
        /// <param name="input"> string input given by user</param>
        private void ConvertStringToInt(string input)
        {
            int a = int.Parse(input);
        }
    }
}