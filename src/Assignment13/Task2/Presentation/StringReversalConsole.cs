using Task2.Application;

namespace Task2.Presentation
{
    /// <summary>
    /// Provides a console-based user interface for reversing strings.
    /// Accepts user input, reverses the string, and displays the result.
    /// </summary>
    public class StringReversalConsole
    {
        private StringReverser _stringReverser;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReversalConsole"/> class.
        /// </summary>
        /// <param name="stringReverser">
        /// Service responsible for performing string reversal operations.
        /// </param>
        public StringReversalConsole(StringReverser stringReverser)
        {
            this._stringReverser = stringReverser;
        }

        /// <summary>
        /// Starts the string reversal application.
        /// Prompts the user for input, reverses the string,
        /// and displays both the original and reversed values.
        /// </summary>
        public void Start()
        {
            Stack<char> stack = new ();

            Console.WriteLine("Enter string");
            string userInput = Console.ReadLine() ?? string.Empty;

            string reversedString = string.Empty;

            foreach (char c in userInput)
            {
                stack.Push(c);
            }

            int count = stack.Count;

            for (int i = 0; i < count; i++)
            {
                reversedString += stack.Pop();
            }

            Console.WriteLine("Original string " + userInput);
            Console.WriteLine("Reversed string " + reversedString);
        }
    }
}
