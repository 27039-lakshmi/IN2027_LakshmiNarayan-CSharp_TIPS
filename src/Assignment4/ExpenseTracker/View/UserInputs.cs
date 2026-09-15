using ExpenseTracker.Enums;
using ExpenseTracker.Helper;
using ExpenseTracker.Models;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Handles user related inputs for transaction details
    /// </summary>
    public class UserInputs
    {
        /// <summary>
        /// Collects income details from the user.
        /// </summary>
        /// <returns>
        /// A tuple containing the created income object and a flag indicating success.
        /// </returns>
        public Income? GetIncomeDetails()
        {
            var (date, amount, isValid) = this.GetDateAndAmount("income");
            if (isValid)
            {
                Console.WriteLine(Messages.EnterIncomeSource);
                var (source, isSourceValid) = this.GetTextInput("Source");
                if (isSourceValid)
                {
                    return new Income(date, amount, source);
                }

                return null;
            }

            return null;
        }

        /// <summary>
        /// Reads and validates a text input field such as Source or Category.
        /// </summary>
        /// <param name="fieldName">Name of the field being validated.</param>
        /// <returns>
        /// A tuple containing the input value and a validation result.
        /// </returns>
        public (string, bool) GetTextInput(string fieldName)
        {
            string input = Console.ReadLine() ?? string.Empty;

            if (Validator.IsValidText(input))
            {
                return (input, true);
            }

            WriteColored(
                $"{fieldName} should contain only letters and spaces",
                ConsoleColor.Red);

            return (string.Empty, false);
        }

        /// <summary>
        /// Collects expense details from the user.
        /// </summary>
        /// <returns>
        /// A tuple containing the created expense object and a flag indicating success.
        /// </returns>
        public Expense? GetExpenseDetails()
        {
            var (date, amount, isValid) = this.GetDateAndAmount("expense");
            if (isValid)
            {
                Console.WriteLine(Messages.EnterExpenseCategory);
                var (category, isCategoryValid) = this.GetTextInput("Category");
                if (isCategoryValid)
                {
                    return new Expense(date, amount, category);
                }

                return null;
            }

            return null;
        }

        /// <summary>
        /// Collects and validates a transaction date and amount.
        /// </summary>
        /// <param name="message">
        /// The transaction type displayed to the user (income or expense).
        /// </param>
        /// <returns>
        /// A tuple containing the date, amount, and validation result.
        /// </returns>
        public (DateOnly, int, bool) GetDateAndAmount(string message)
        {
            var failureResult = (DateOnly.MinValue, 0, false);
            Console.WriteLine(Messages.DateOption);
            var (date, isDateValid) = this.GetDateInput();
            if (isDateValid)
            {
                Console.WriteLine($"Enter {message} amount");
                (int amount, bool isAmountValid) = this.GetAmountInput();
                if (isAmountValid)
                {
                    return (date, amount, true);
                }
            }

            return failureResult;
        }

        /// <summary>
        /// Gets a transaction date from the user.
        /// </summary>
        /// <returns>
        /// A tuple containing the selected date and validation result.
        /// </returns>
        public (DateOnly, bool) GetDateInput()
        {
            var failureResult = (DateOnly.MinValue, false);
            Console.WriteLine(Messages.DateMenu);
            string choiceInput = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsChoiceValid(choiceInput, out var userDateChoice))
            {
                WriteColored(Messages.InvalidChoice, ConsoleColor.Red);
            }
            else
            {
                switch ((DateOptions)userDateChoice)
                {
                    case DateOptions.ManualDate:
                        string dateInput = Console.ReadLine() ?? string.Empty;
                        if (Validator.IsValidDate(dateInput, out var date))
                        {
                            return (date, true);
                        }
                        else
                        {
                            WriteColored(Messages.InvalidDate, ConsoleColor.Red);
                        }

                        break;
                    case DateOptions.TodayDate:
                        date = DateOnly.FromDateTime(DateTime.Today);
                        return (date, true);
                    default:
                        WriteColored(Messages.DefaultMessage, ConsoleColor.Red);
                        break;
                }
            }

            return failureResult;
        }

        /// <summary>
        /// Allows the user to update an existing transaction date.
        /// </summary>
        /// <param name="oldDate">The current transaction date.</param>
        /// <returns>
        /// The updated date if valid; otherwise the original date.
        /// </returns>
        public DateOnly GetUpdatedDate(DateOnly oldDate)
        {
            Console.WriteLine($"Current Date: {oldDate}");
            Console.Write("Do you want to edit the date (Enter y): ");

            string input = (Console.ReadLine() ?? "n").ToLower();

            if (string.Equals(input, "y"))
            {
                var (newDate, isDateValid) = this.GetDateInput();
                if (!isDateValid)
                {
                    Console.WriteLine("Date is not valid. Keeping old date");
                }

                return isDateValid ? newDate : oldDate;
            }

            return oldDate;
        }

        /// <summary>
        /// Allows the user to update an existing transaction amount.
        /// </summary>
        /// <param name="oldAmount">The current amount.</param>
        /// <returns>
        /// The updated amount if valid; otherwise the original amount.
        /// </returns>
        public int GetUpdatedAmount(int oldAmount)
        {
            Console.Write($"Current amount {oldAmount}\n" +
                              $"do you want to edit the amount (Enter y)");
            string input = (Console.ReadLine() ?? "n").ToLower();
            if (string.Equals(input, "y"))
            {
                var (newAmount, isAmountValid) = this.GetAmountInput();
                if (!isAmountValid)
                {
                    Console.WriteLine("Amount is not valid. Keeping old amount");
                }

                return isAmountValid ? newAmount : oldAmount;
            }

            return oldAmount;
        }

        /// <summary>
        /// Allows the user to update an expense category and income source.
        /// </summary>
        /// <param name="oldText">The current text value.</param>
        /// <param name="inputType">The inputType whether its source or category</param>
        /// <returns>
        /// The updated text if valid; otherwise the original text.
        /// </returns>
        public string GetUpdatedText(string oldText, string inputType)
        {
            Console.Write($"Current {inputType} {oldText}\n" +
                              $"do you want to edit the {inputType} (y/n)");
            string input = (Console.ReadLine() ?? "n").ToLower();
            if (string.Equals(input, "y"))
            {
                var (newText, isTextValid) = this.GetTextInput(inputType);
                return isTextValid ? newText : oldText;
            }

            return oldText;
        }

        /// <summary>
        /// Reads and validates a transaction amount.
        /// </summary>
        /// <returns>
        /// A tuple containing the amount and validation result.
        /// </returns>
        public (int, bool) GetAmountInput()
        {
            var failureResult = (0, false);
            string amountInput = Console.ReadLine() ?? string.Empty;
            if (Validator.IsAmountValid(amountInput, out int amount))
            {
                return (amount, true);
            }

            WriteColored(Messages.InvalidAmount, ConsoleColor.Red);
            return failureResult;
        }

        /// <summary>
        /// Writes a message to the console using the specified color.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="color">The color used to display the message.</param>
        private static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
