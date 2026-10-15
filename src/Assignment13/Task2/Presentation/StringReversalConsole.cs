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
            Console.WriteLine("Enter string");
            string userInput = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Enter a string with atleast one character");
            }
            else
            {
                this._stringReverser.AddString(userInput);
                string reversedString = this._stringReverser.GetReversedString();

                Console.WriteLine("Original string " + userInput);
                Console.WriteLine("Reversed string " + reversedString);
            }
        }
    }
}
