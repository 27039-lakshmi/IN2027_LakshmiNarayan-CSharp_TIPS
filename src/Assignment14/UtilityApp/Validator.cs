namespace UtilityApp
{
    /// <summary>
    /// Provides methods for validating user input,
    /// including numeric values and arithmetic operators.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Determines whether the specified input string
        /// represents a valid numeric value.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>
        /// <c>true</c> if the input can be parsed as a number;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidNumber(string input)
        {
            return double.TryParse(input, out _);
        }

        /// <summary>
        /// Determines whether the specified input string
        /// is a valid arithmetic operator.
        /// </summary>
        /// <param name="input">The operator to validate.</param>
        /// <returns>
        /// <c>true</c> if the input is one of the supported operators
        /// (+, -, *, /); otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidOperator(string input)
        {
            return input == "+" || input == "-" || input == "*" || input == "/";
        }

        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        private static void Main(string[] args)
        {
        }
    }
}