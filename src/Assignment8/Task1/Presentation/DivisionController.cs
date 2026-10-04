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
        private readonly DivisionService _divisionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionController"/> class.
        /// </summary>
        /// <param name="divisionService">
        /// Instance of <see cref="DivisionService"/> used to perform division calculations.
        /// </param>
        public DivisionController(DivisionService divisionService)
        {
            this._divisionService = divisionService;
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
                this.ExecuteDivisionTask();
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
    }
}