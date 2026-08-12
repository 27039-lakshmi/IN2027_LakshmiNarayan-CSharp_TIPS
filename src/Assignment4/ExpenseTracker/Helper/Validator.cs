using System.Text.RegularExpressions;

namespace ExpenseTracker.Helper
{
    /// <summary>
    /// Provides common validation methods used throughout the application.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Validates that the input contains only letters and white spaces.
        /// </summary>
        /// <param name="input">The text to validate.</param>
        /// <returns>
        /// True if the input is not empty and contains only letters or spaces;
        /// otherwise, false.
        /// </returns>
        public static bool IsValidText(string input)
        {
            return !string.IsNullOrWhiteSpace(input) &&
                   input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        /// <summary>
        /// Validates whether the supplied date string can be parsed and is not a future date.
        /// </summary>
        /// <param name="dateInput">The date string entered by the user.</param>
        /// <param name="date">
        /// When this method returns, contains the parsed date if validation succeeds.
        /// </param>
        /// <returns>
        /// True if the date is valid and not greater than today's date;
        /// otherwise, false.
        /// </returns>
        public static bool IsValidDate(string dateInput, out DateTime date)
        {
            return DateTime.TryParse(dateInput, out date) &&
                   date <= DateTime.Today;
        }

        /// <summary>
        /// Validates that the amount is a positive integer.
        /// </summary>
        /// <param name="amountInput">The amount entered by the user.</param>
        /// <param name="amount">
        /// When this method returns, contains the parsed amount if validation succeeds.
        /// </param>
        /// <returns>
        /// True if the amount is a positive integer; otherwise, false.
        /// </returns>
        public static bool IsAmountValid(string amountInput, out int amount)
        {
            return int.TryParse(amountInput, out amount) &&
                   amount > 0;
        }

        /// <summary>
        /// Validates that a menu choice is a valid integer.
        /// </summary>
        /// <param name="choiceInput">The user's menu choice.</param>
        /// <param name="choice">
        /// When this method returns, contains the parsed choice if validation succeeds.
        /// </param>
        /// <returns>
        /// True if the input can be converted to an integer; otherwise, false.
        /// </returns>
        public static bool IsChoiceValid(string choiceInput, out int choice)
        {
            return int.TryParse(choiceInput, out choice);
        }

        /// <summary>
        /// Validates that a ID is valid or not.
        /// </summary>
        /// <param name="id">The user's input for id.</param>
        /// <returns>
        /// True if the input is valid Id; otherwise, false.
        /// </returns>
        public static bool IsValidId(string id)
        {
            return Regex.IsMatch(id, @"^[IE]\d+$");
        }

        /// <summary>
        /// Validates that file path is valid or not.
        /// </summary>
        /// <param name="fileNameInput">User's input for filepath.</param>
        /// <returns>True if the input is valid filepath and extension is json; otherwise, false.</returns>
        public static bool IsFilePathValid(string fileNameInput)
        {
            return Path.IsPathFullyQualified(fileNameInput) && fileNameInput.EndsWith(".json");
        }
    }
}