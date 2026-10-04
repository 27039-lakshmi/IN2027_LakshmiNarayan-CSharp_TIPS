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
        /// Demonstrates nested exception handling for division and array access operations.
        /// </summary>
        public void Start()
        {
            try
            {
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