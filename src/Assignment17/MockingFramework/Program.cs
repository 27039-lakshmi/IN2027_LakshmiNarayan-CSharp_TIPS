using MockingFramework;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application demonstrating the use of the MockFactory to 
    /// create a mock implementation of the ICalculator interface.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        public static void Main()
        {
            try
            {
                var mock = MockFactory.CreateMock<IMessage>();
                Console.WriteLine(mock.GetMessage());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}