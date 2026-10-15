using Task5.Presentation;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application
    /// Its calls the controller
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            var controller = new Controller();
            AppDomain.CurrentDomain.UnhandledException += controller.OnUnhandledException;
            controller.Start();
        }
    }
}