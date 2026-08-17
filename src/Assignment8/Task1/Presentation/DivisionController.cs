using Task1.Application.Services;

namespace Task1.Presentation
{
    internal class DivisionController
    {
        DivisionService _dividor;

        public DivisionController(DivisionService dividor)
        {
            this._dividor = dividor;
        }

        public void Divide()
        {
            try
            {
                int result = this._dividor.DivideTwoNumbers(10, 5);
                Console.WriteLine("Result : " + result);
                result = this._dividor.DivideTwoNumbers(10, 0);
                Console.WriteLine("Result : " + result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero");
            }
            finally
            {
                Console.WriteLine("Finally is executing");
            }

        }
    }
}
