using Task4.Application.Services;
using Task4.Domain.Exceptions;

namespace Task4.Presentation
{
    /// <summary>
    /// Controller responsible for handling user input, performing division operations,
    /// and demonstrating various exception handling techniques including custom exceptions,
    /// nested try-catch blocks, and AppDomain-level unhandled exception handling.
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
        /// Accepts user input and demonstrates handling of different exception types,
        /// including custom exceptions, divide-by-zero exceptions, index-out-of-range
        /// exceptions, and unhandled exceptions.
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

                    Console.WriteLine("Task 4: Use appdomain for unhandle exception.");
                    Console.WriteLine("Enter a string to get exception");
                    string input = Console.ReadLine() ?? string.Empty;
                    this.ConvertStringToInt(input);
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
            finally
            {
                Console.WriteLine("Finally is executing");
            }
        }

        /// <summary>
        /// Attempts to convert a string value to an integer.
        /// </summary>
        /// <param name="input"> string input given by user</param>
        public void ConvertStringToInt(string input)
        {
            int a = int.Parse(input);
        }

        /// <summary>
        /// Handles unhandled exceptions raised within the current application domain.
        /// </summary>
        /// <param name="sender">
        /// The source of the unhandled exception event.
        /// </param>
        /// <param name="e">
        /// Contains information about the unhandled exception.
        /// </param>
        /// <remarks>
        /// This handler is invoked when an exception is not caught anywhere
        /// in the application's execution flow. It is typically used for
        /// logging and diagnostics before the application terminates.
        /// </remarks>
        public void OnUnhandledException(
            object sender,
            UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Console.WriteLine(ex.Message);
        }
    }
}