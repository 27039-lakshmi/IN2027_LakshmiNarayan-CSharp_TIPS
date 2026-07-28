namespace InventoryManager.Helper
{
    /// <summary>
    /// Provides validation helper methods used throughout the inventory system.
    /// </summary>
    internal static class Validators
    {
        /// <summary>
        /// Determines whether the specified string is null or whitespace
        /// </summary>
        /// <param name="value">
        /// The string value to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified value is null or whitespace;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}