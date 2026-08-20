using Task3.Application.Services;
using Task3.Domain.Exceptions;

namespace Task3.Presentation
{
    /// <summary>
    /// Controller responsible for handling user input, performing division operations,
    /// and demonstrating the handling of custom and system exceptions.
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
        /// Reads user input and performs division operations while demonstrating
        /// multiple exception handling scenarios.
        /// </summary>
        /// <remarks>
        /// This method demonstrates:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Throwing a custom <see cref="InvalidUserInputException"/>
        /// when the user provides empty input.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Handling <see cref="DivideByZeroException"/> when division
        /// is attempted with a divisor of zero.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Handling <see cref="IndexOutOfRangeException"/> when accessing
        /// an array using an invalid index.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Using nested try-catch blocks for exception propagation.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Executing cleanup code through a finally block.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
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

                    Console.WriteLine("Task 2: Index out of range exception");
                    Console.WriteLine(arr[10]);
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