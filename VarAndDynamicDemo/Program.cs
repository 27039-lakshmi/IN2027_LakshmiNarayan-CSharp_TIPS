namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var varTypeVariable = "Hello";
            dynamic dynamicTypeVariable = "Hello";
            Console.WriteLine("Value of var type variable " + varTypeVariable);
            Console.WriteLine("Value of dynamic type variable before change " + dynamicTypeVariable);

            // varTypeVariable = 9; -> Cannot change datatype of a variable declared with var keyword.
            dynamicTypeVariable = 9;
            Console.WriteLine("Value of dynamic type variable after change " + dynamicTypeVariable);
        }
    }
}