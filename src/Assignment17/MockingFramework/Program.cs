using MockingFramework;

namespace Assignments
{
    public class Program
    {
        public static void Main()
        {
            ICalculator mock = MockFactory.CreateMock<ICalculator>();
            Console.WriteLine(mock.Add());
            Console.WriteLine(mock.GetMessage());
        }
    }
}