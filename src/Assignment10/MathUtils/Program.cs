using Calculator.Application.Service;
using Calculator.Presentation.Controller;

namespace Assignments
{
    /// <summary>
    /// Entry point for the Calculator application.
    /// Responsible for creating required dependencies and
    /// starting the calculator workflow.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry method.
        /// Creates instances of <see cref="MathUtils"/> and
        /// <see cref="MathUtilController"/>, then starts the calculator.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            MathUtils mathUtils = new MathUtils();
            MathUtilController controller = new MathUtilController(mathUtils);

            controller.Start();
        }
    }
}