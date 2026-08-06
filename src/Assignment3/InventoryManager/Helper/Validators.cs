namespace InventoryManager.Helper
{
    /// <summary>
    /// Provides validation helper methods used throughout the inventory system.
    /// </summary>
    public static class Validators
    {
        /// <summary>
        /// Validates whether the specified value represents
        /// a positive decimal price.
        /// </summary>
        /// <param name="value">
        /// The string value to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the value can be parsed as a decimal
        /// and is greater than zero; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPriceValid(string value)
        {
            if (decimal.TryParse(value, out decimal decimalValue))
            {
                if (decimalValue > 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Validates whether the specified value represents
        /// a non-negative product quantity.
        /// </summary>
        /// <param name="value">
        /// The string value to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the value can be parsed as an integer
        /// and is greater than or equal to zero; otherwise,
        /// <c>false</c>.
        /// </returns>
        public static bool IsQuantityValid(string value)
        {
            if (int.TryParse(value, out int intValue))
            {
                if (intValue >= 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}