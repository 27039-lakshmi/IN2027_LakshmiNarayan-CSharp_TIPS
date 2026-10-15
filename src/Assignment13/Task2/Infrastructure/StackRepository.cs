namespace Task2.Infrastructure
{
    /// <summary>
    /// Represents a generic stack repository that provides
    /// basic stack operations such as push, pop, and size retrieval.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements stored in the stack.
    /// </typeparam>
    public class StackRepository<T>
    {
        private readonly Stack<T> _stack = new ();

        /// <summary>
        /// Pushes an item onto the top of the stack.
        /// </summary>
        /// <param name="c">
        /// The item to add to the stack.
        /// </param>
        public void PushIntoStack(T c)
        {
            this._stack.Push(c);
        }

        /// <summary>
        /// Removes and returns the item at the top of the stack.
        /// </summary>
        /// <returns>
        /// The item removed from the top of the stack.
        /// </returns>
        public T PopFromStack()
        {
            return this._stack.Pop();
        }

        /// <summary>
        /// Gets the number of items currently stored in the stack.
        /// </summary>
        /// <returns>
        /// The total count of items in the stack.
        /// </returns>
        public int GetSize()
        {
            return this._stack.Count;
        }
    }
}