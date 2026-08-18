using Task5.Application.Services;
using Task5.Domain.Exceptions;

namespace Task5.Presentation
{
    /// <summary>
    /// Controller responsible for validating user input, performing division operations,
    /// and demonstrating various exception handling mechanisms including custom exceptions,
    /// nested try-catch blocks, and application-level unhandled exception handling.
    /// </summary>
    internal class Controller
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
        /// <remarks>
        /// This method demonstrates:
        /// <list type="bullet">
        /// <item><description>Custom exception handling using <see cref="InvalidUserInputException"/>.</description></item>
        /// <item><description>Handling <see cref="DivideByZeroException"/>.</description></item>
        /// <item><description>Handling <see cref="IndexOutOfRangeException"/>.</description></item>
        /// <item><description>Registration of an AppDomain unhandled exception handler.</description></item>
        /// <item><description>Execution of a finally block regardless of success or failure.</description></item>
        /// </list>
        /// </remarks>
        public void Start()
        {
            try
            {
                try
                {
                    Console.WriteLine("Enter input");

                    string? userInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        throw new InvalidUserInputException(
                            "User input should not be null");
                    }

                    AppDomain.CurrentDomain.UnhandledException +=
                        this.OnUnhandledException;

                    this.ConvertStringToInt();

                    int[] arr = new int[] { 1, 2, 3, 0 };

                    // Index out of range exception
                    int result = this._dividor.DivideTwoNumbers(arr[0], arr[10]);
                    Console.WriteLine("Result : " + result);

                    // Divide by zero exception
                    result = this._dividor.DivideTwoNumbers(arr[0], arr[3]);
                    Console.WriteLine("Result : " + result);
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
        /// <remarks>
        /// This method intentionally throws a
        /// <see cref="FormatException"/> because the string
        /// "Hello" cannot be converted to an integer.
        /// </remarks>
        public void ConvertStringToInt()
        {
            int a = int.Parse("Hello");
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