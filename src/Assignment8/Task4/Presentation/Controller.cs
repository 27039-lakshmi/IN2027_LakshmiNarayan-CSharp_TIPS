using Task4.Application.Services;
using Task4.Domain.Exceptions;

namespace Task4.Presentation
{
    /// <summary>
    /// Controller responsible for handling user input, performing division operations,
    /// and demonstrating various exception handling techniques including custom exceptions,
    /// nested try-catch blocks, and AppDomain-level unhandled exception handling.
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
        /// <remarks>
        /// The method demonstrates:
        /// <list type="bullet">
        /// <item><description>Custom exception handling using <see cref="InvalidUserInputException"/>.</description></item>
        /// <item><description>Handling <see cref="DivideByZeroException"/>.</description></item>
        /// <item><description>Handling <see cref="IndexOutOfRangeException"/>.</description></item>
        /// <item><description>Registering an AppDomain unhandled exception handler.</description></item>
        /// <item><description>Execution of a finally block regardless of exceptions.</description></item>
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

                    AppDomain.CurrentDomain.UnhandledException += this.OnUnhandledException;

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
                    throw new Exception("Index should be within size of array");
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
        /// This method intentionally causes a <see cref="FormatException"/>
        /// because the string "Hello" cannot be converted to an integer.
        /// The exception is unhandled within this method.
        /// </remarks>
        public void ConvertStringToInt()
        {
            int a = int.Parse("Hello");
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