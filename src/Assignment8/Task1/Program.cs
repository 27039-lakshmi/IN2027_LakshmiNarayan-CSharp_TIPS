using Task1.Application.Services;
using Task1.Presentation;

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
            var divisionService = new DivisionService();
            var controller = new DivisionController(divisionService);
            controller.Divide();
        }
    }
}