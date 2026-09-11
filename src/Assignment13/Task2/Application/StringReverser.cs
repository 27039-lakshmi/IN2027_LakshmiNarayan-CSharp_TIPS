using System.Text;
using Task2.Infrastructure;

namespace Task2.Application
{
    /// <summary>
    /// Provides functionality to reverse a string using a stack.
    /// Characters are pushed onto the stack and then popped in
    /// reverse order to generate the reversed string.
    /// </summary>
    public class StringReverser
    {
        private StackRepository<char> _stackRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReverser"/> class.
        /// </summary>
        /// <param name="stackRepository">
        /// Repository used to store characters in a stack.
        /// </param>
        public StringReverser(StackRepository<char> stackRepository)
        {
            this._stackRepository = stackRepository;
        }

        /// <summary>
        /// Pushes each character of the specified string onto the stack.
        /// </summary>
        /// <param name="value">
        /// The string whose characters will be added to the stack.
        /// </param>
        public void AddString(string value)
        {
            foreach (char c in value)
            {
                this._stackRepository.PushIntoStack(c);
            }
        }

        /// <summary>
        /// Retrieves the characters from the stack in reverse order
        /// and constructs the reversed string.
        /// </summary>
        /// <returns>
        /// A string containing the characters in reverse order.
        /// </returns>
        public string GetReversedString()
        {
            int stackSize = this._stackRepository.GetSize();
            StringBuilder reversedString = new ();

            for (int i = 0; i < stackSize; i++)
            {
                reversedString.Append(this._stackRepository.PopFromStack());
            }

            return reversedString.ToString();
        }
    }
}