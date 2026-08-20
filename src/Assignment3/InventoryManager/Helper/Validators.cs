namespace InventoryManager.Helper
{
    /// <summary>
    /// Provides validation helper methods used throughout the inventory system.
    /// </summary>
    public class Validators
    {
        /// <summary>
        /// Validates whether the specified value represents
        /// a positive decimal price.
        /// </summary>
        /// <param name="value">
        /// The string value to validate.
        /// </param>
        /// <param name="decimalValue">
        /// The parsed decimal value is stored and passed to caller
        /// </param>
        /// <returns>
        /// <c>true</c> if the value can be parsed as a decimal
        /// and is greater than zero; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPriceValid(string value, out decimal decimalValue)
        {
            return decimal.TryParse(value, out decimalValue) && decimalValue > 0;
        }

        /// <summary>
        /// Validates whether the specified value represents
        /// a non-negative product quantity.
        /// </summary>
        /// <param name="value">
        /// The string value to validate.
        /// </param>
        /// <param name="intValue">
        /// The parsed integer value is stored and passed to caller
        /// </param>
        /// <returns>
        /// <c>true</c> if the value can be parsed as an integer
        /// and is greater than or equal to zero; otherwise,
        /// <c>false</c>.
        /// </returns>
        public bool IsQuantityValid(string value, out int intValue)
        {
            return int.TryParse(value, out intValue) && intValue >= 0;
        }

        /// <summary>
        /// Validates whether the specified string is valid or not
        /// </summary>
        /// <param name="value">
        /// The string value to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the value is neither null nor whitespace; otherwise,
        /// <c>false</c>.
        /// </returns>
        public bool IsValidString(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}