using Task2.Application.Services;
using Task2.Presentation;

namespace Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dividor = new DivisionService();
            var controller = new DivisionController(dividor);
            controller.Divide();
        }
    }
}