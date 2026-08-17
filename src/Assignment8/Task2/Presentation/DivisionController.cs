using Task2.Application.Services;

namespace Task2.Presentation
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
                try
                {
                    int[] arr = new int[] { 1, 2, 3, 0 };
                    int result = this._dividor.DivideTwoNumbers(arr[0], arr[10]);
                    Console.WriteLine("Result : " + result);
                    result = this._dividor.DivideTwoNumbers(arr[0], arr[3]);
                    Console.WriteLine("Result : " + result);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Cannot divide by zero");
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new Exception("Index should be within size of array");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Finally is executing");
            }

        }
    }
}
