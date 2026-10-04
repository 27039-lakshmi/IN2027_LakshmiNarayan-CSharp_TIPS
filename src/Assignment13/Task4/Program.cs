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
            try
            {
                var studentGradeRepository = new StudentGradeRepository<string, int>();
                var studentGradeService = new StudentGradeService(studentGradeRepository);
                var studentGradeConsole = new StudentGradeConsole(studentGradeService);
                studentGradeConsole.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}