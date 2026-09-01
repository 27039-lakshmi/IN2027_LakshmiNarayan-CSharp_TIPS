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
        private readonly DivisionService _dividor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="dividor">
        /// Service responsible for performing arithmetic division operations.
        /// </param>
        public Controller(DivisionService dividor)
        {
            this._dividor = dividor;
        }

        /// <summary>
        /// Validates user input and demonstrates handling of different exception types.
        /// </summary>
        public void Start()
        {
            try
            {
                try
                {
                    Console.WriteLine("Task 3: Throw custom exception");
                    Console.WriteLine("Enter input as null to execute custom exception");
                    string? userInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        throw new InvalidUserInputException(
                            "User input should not be null");
                    }

                    int[] arr = new int[] { 1, 2, 3, 0 };

                    Console.WriteLine("Task 1: Divide by zero exception");
                    Console.WriteLine("Enter dividor ");
                    if (int.TryParse(Console.ReadLine(), out int inputNum))
                    {
                        int result = this._dividor.DivideTwoNumbers(10, inputNum);
                        Console.WriteLine("Result : " + result);
                    }

                    Console.WriteLine("Task 4: Use appdomain for unhandle exception.");
                    Console.WriteLine("Enter a string to get exception");
                    string input = Console.ReadLine() ?? string.Empty;
                    this.ConvertStringToInt(input);
                    Console.WriteLine("Task 2: Index out of range exception");
                    Console.WriteLine(arr[10]);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero");
                }
                catch (IndexOutOfRangeException)
                {
                    throw new Exception(
                        "Index should be within size of array");
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
        /// <param name="input"> input string for converting string to int</param>
        /// <remarks>
        /// This method intentionally throws a
        /// <see cref="FormatException"/> because the string
        /// "Hello" cannot be converted to an integer.
        /// </remarks>
        public void ConvertStringToInt(string input)
        {
            int a = int.Parse(input);
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
        /// <remarks>
        /// This handler is executed when an exception is not caught by any
        /// try-catch block in the application. It logs the exception message
        /// and stack trace for debugging and diagnostic purposes before the
        /// application terminates.
        /// </remarks>
        public void OnUnhandledException(
            object sender,
            UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;

            Console.WriteLine(ex.Message);

            Console.WriteLine("Stack trace:");
            Console.WriteLine(ex.StackTrace);
        }
    }
}