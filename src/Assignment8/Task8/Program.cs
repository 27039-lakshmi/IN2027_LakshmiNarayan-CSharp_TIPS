using Task5.Application.Services;
using Task5.Presentation;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application
    /// Its calls the controller
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dividor = new DivisionService();
            var controller = new Controller(dividor);
            controller.Start();
        }
    }
}