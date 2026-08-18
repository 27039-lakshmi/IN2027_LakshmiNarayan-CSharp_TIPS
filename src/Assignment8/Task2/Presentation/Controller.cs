using Task2.Application.Services;

namespace Task2.Presentation
{
    /// <summary>
    /// Controller responsible for handling division operations and
    /// demonstrating exception handling scenarios such as
    /// divide-by-zero and array index access violations.
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
        /// Demonstrates nested exception handling for division and array access operations.
        /// </summary>
        /// <remarks>
        /// This method demonstrates:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Handling <see cref="DivideByZeroException"/> when attempting division by zero.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Handling <see cref="IndexOutOfRangeException"/> when accessing an invalid array index.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Rethrowing exceptions with a custom message.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Executing cleanup code using a finally block.
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