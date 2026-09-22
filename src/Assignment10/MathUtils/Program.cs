using Calculator.Application.Service;
using Calculator.Presentation.View;

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
        /// <see cref="MathUtilViewer"/>, then starts the calculator.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            try
            {
                var mathUtils = new MathUtils();
                var view = new MathUtilViewer(mathUtils);
                view.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}