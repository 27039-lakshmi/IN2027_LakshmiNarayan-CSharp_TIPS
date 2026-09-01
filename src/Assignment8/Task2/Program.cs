using Task2.Application.Services;
using Task2.Presentation;

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
            var dividor = new DivisionService();
            var controller = new Controller(dividor);
            controller.Start();
        }
    }
}