namespace Assignments
{
    /// <summary>
    /// Demonstrates the difference between the var and dynamic keywords in C#.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
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