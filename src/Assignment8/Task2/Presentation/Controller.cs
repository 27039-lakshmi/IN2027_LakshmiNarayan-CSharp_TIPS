using Task2.Application.Services;

namespace Task2.Presentation
{
    /// <summary>
    /// Controller responsible for handling division operations and
    /// demonstrating exception handling scenarios such as
    /// divide-by-zero and array index access violations.
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
        /// Demonstrates nested exception handling for division and array access operations.
        /// </summary>
        public void Start()
        {
            try
            {
                this.ExecuteDivisionTask();
                this.ExecuteArrayAccessTask();
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

        /// <summary>
        /// Demonstrates exception handling for index out of range.
        /// </summary>
        private void ExecuteArrayAccessTask()
        {
            try
            {
                int[] arr = { 1, 2, 3, 0 };
                Console.WriteLine("Task 2: Index out of range exception");
                Console.WriteLine(arr[10]);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception("Index should be within the size of the array.", ex);
            }
        }
    }
}