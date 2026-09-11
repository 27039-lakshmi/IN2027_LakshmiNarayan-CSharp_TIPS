using Task4.Application;
using Task4.Infrastructure;
using Task4.Presentation;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Student Grade Management application.
    /// Responsible for configuring the application's dependencies
    /// and starting the console-based user interface.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes the repository, service, and presentation layers,
        /// then starts the application.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        private static void Main(string[] args)
        {
            StudentGradeRepository<string, int> repo = new ();

            StudentGradeService service = new StudentGradeService(repo);

            StudentGradeConsole controller = new StudentGradeConsole(service);

            controller.Start();
        }
    }
}