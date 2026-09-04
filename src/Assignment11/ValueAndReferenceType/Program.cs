using ValueReferenceType.Application.Services;
using ValueReferenceType.Presentation.Controller;

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
            var service = new ValueReferenceDemoService();
            var controller = new ValueReferenceController(service);
        }
    }
}