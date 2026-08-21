using Task1.Application.Services;

namespace Task1.Presentation
{
    /// <summary>
    /// Controller responsible for handling division-related user interactions.
    /// It invokes the <see cref="DivisionService"/> to perform division operations
    /// and manages exception handling and result display.
    /// </summary>
    public class DivisionController
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
        public void Divide()
        {
            try
            {
                Console.WriteLine("Task 1: Divide by zero exception");
                Console.WriteLine("Dividing 10 by 5");
                int result = this._dividor.DivideTwoNumbers(10, 5);
                Console.WriteLine("Result : " + result);
                Console.WriteLine("Dividing 10 by 0");
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