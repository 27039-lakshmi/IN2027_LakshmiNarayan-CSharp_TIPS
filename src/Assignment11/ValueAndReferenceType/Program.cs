using ValueReferenceType.Application.Services;
using ValueReferenceType.Presentation.View;

namespace Assignments
{
    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates the required service and controller instances and
        /// starts the value type and reference type demonstration.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            try
            {
                var service = new ValueReferenceDemoService();
                var view = new ValueReferenceViewer(service);
                view.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}