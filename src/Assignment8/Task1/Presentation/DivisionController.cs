using Task1.Application.Services;

namespace Task1.Presentation
{
    /// <summary>
    /// Controller responsible for handling division-related user interactions.
    /// It invokes the <see cref="DivisionService"/> to perform division operations
    /// and manages exception handling and result display.
    /// </summary>
    internal class DivisionController
    {
        /// <summary>
        /// Service used to perform division operations.
        /// </summary>
        private readonly DivisionService _dividor;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionController"/> class.
        /// </summary>
        /// <param name="dividor">
        /// Instance of <see cref="DivisionService"/> used to perform division calculations.
        /// </param>
        public DivisionController(DivisionService dividor)
        {
            this._dividor = dividor;
        }

        /// <summary>
        /// Performs division operations and displays the results.
        /// Handles any <see cref="DivideByZeroException"/> that occurs when attempting
        /// to divide a number by zero.
        /// </summary>
        /// <remarks>
        /// This method demonstrates:
        /// <list type="bullet">
        /// <item><description>Calling a service method.</description></item>
        /// <item><description>Exception handling using try-catch.</description></item>
        /// <item><description>Execution of a finally block.</description></item>
        /// </list>
        /// </remarks>
        public void Divide()
        {
            try
            {
                int result = this._dividor.DivideTwoNumbers(10, 5);
                Console.WriteLine("Result : " + result);

                result = this._dividor.DivideTwoNumbers(10, 0);
                Console.WriteLine("Result : " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero");
            }
            finally
            {
                Console.WriteLine("Finally is executing");
            }
        }
    }
}