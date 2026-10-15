namespace MockingFramework
{
    /// <summary>
    /// Interface representing a message provider that returns a message indicating the result .
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Returns a message indicating the result of the calculation.
        /// </summary>
        /// <returns>A string message</returns>
        string GetMessage();
    }
}
