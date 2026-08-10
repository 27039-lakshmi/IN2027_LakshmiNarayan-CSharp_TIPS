using ExpenseTracker.Enums;
using ExpenseTracker.Helper;
using ExpenseTracker.Models;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Provides the user interface for the Expense Tracker application.
    /// Handles user input and displays transaction-related information.
    /// </summary>
    public class ExpenseTrackerView
    {
        private readonly TransactionService _transactionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTrackerView"/> class.
        /// </summary>
        /// <param name="transactionService">
        /// The service responsible for managing transaction operations.
        /// </param>
        public ExpenseTrackerView(TransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        /// <summary>
        /// Starts the application and displays the main menu until the user exits.
        /// </summary>
        public void Start()
        {
            int userChoice;
            do
            {
                Console.WriteLine("1.Add income/expense\n" +
                                  "2.Edit income/expense\n" +
                                  "3.Delete income/expense\n" +
                                  "4.View income/expense\n" +
                                  "5.Get Summary\n" +
                                  "6.Exit\n" +
                                  "Enter your Choice");
                if (!int.TryParse(Console.ReadLine() ?? string.Empty, out userChoice))
                {
                    WriteColored("Please enter a valid number.\n", ConsoleColor.Red);
                    continue;
                }

                this.HandleMenuOption((MenuOption)userChoice);
            }
            while (userChoice != (int)MenuOption.Exit);
        }

        /// <summary>
        /// Executes the selected main menu option.
        /// </summary>
        /// <param name="userChoice">The menu option selected by the user.</param>
        public void HandleMenuOption(MenuOption userChoice)
        {
            switch (userChoice)
            {
                case MenuOption.Add:
                    Console.WriteLine("1.Add income\n" +
                                      "2.Add expense\n" +
                                      "Enter your choice");
                    string choiceInput = Console.ReadLine() ?? string.Empty;
                    if (!Validator.IsChoiceValid(choiceInput, out var userAddChoice))
                    {
                        WriteColored("Please enter a valid number.\n", ConsoleColor.Red);
                        return;
                    }

                    switch ((AddOption)userAddChoice)
                    {
                        case AddOption.AddIncome:
                            this.AddIncome();
                            break;
                        case AddOption.AddExpense:
                            this.AddExpense();
                            break;
                        default:
                            WriteColored("Invalid Choice\n", ConsoleColor.Red);
                            break;
                    }

                    break;
                case MenuOption.Edit:
                    Console.WriteLine("1.Edit income\n" +
                                      "2.Edit expense\n" +
                                      "Enter your choice");
                    choiceInput = Console.ReadLine() ?? string.Empty;
                    if (!Validator.IsChoiceValid(choiceInput, out var userEditChoice))
                    {
                        WriteColored("Please enter a valid number.\n", ConsoleColor.Red);
                        return;
                    }

                    switch ((EditOption)userEditChoice)
                    {
                        case EditOption.EditIncome:
                            this.EditIncome();
                            break;
                        case EditOption.EditExpense:
                            this.EditExpense();
                            break;
                        default:
                            WriteColored("Invalid Choice\n", ConsoleColor.Red);
                            break;
                    }

                    break;
                case MenuOption.Delete:
                    Console.WriteLine("1.Delete income\n" +
                                      "2.Delete expense\n" +
                                      "Enter your choice");
                    choiceInput = Console.ReadLine() ?? string.Empty;
                    if (!Validator.IsChoiceValid(choiceInput, out var userDeleteChoice))
                    {
                        WriteColored("Please enter a valid number.\n", ConsoleColor.Red);
                        return;
                    }

                    switch ((DeleteOption)userDeleteChoice)
                    {
                        case DeleteOption.DeleteIncome:
                            this.DeleteTransaction(TransactionType.Income);
                            break;
                        case DeleteOption.DeleteExpense:
                            this.DeleteTransaction(TransactionType.Expense);
                            break;
                        default:
                            WriteColored("Invalid Choice\n", ConsoleColor.Red);
                            break;
                    }

                    break;
                case MenuOption.View:
                    Console.WriteLine("1.View income\n" +
                                      "2.View expense\n" +
                                      "Enter your choice");
                    choiceInput = Console.ReadLine() ?? string.Empty;
                    if (!Validator.IsChoiceValid(choiceInput, out var userViewChoice))
                    {
                        WriteColored("Please enter a valid number.\n", ConsoleColor.Red);
                        return;
                    }

                    switch ((ViewOption)userViewChoice)
                    {
                        case ViewOption.ViewIncome:
                            this.ViewIncome();
                            break;
                        case ViewOption.ViewExpense:
                            this.ViewExpense();
                            break;
                        default:
                            WriteColored("Invalid Choice\n", ConsoleColor.Red);
                            break;
                    }

                    break;

                case MenuOption.Summary:
                    this.ViewSummary();
                    break;

                case MenuOption.Exit:
                    break;

                default:
                    WriteColored("Invalid choice\n", ConsoleColor.Red);
                    break;
            }
        }

        /// <summary>
        /// Collects income details from the user and adds the income transaction.
        /// </summary>
        public void AddIncome()
        {
            Income? newIncome = this.GetIncomeDetails();
            if (newIncome != null)
            {
                this._transactionService.AddTransaction(newIncome);
                WriteColored("Income added succesfully.\n", ConsoleColor.Green);
            }
            else
            {
                WriteColored("Income not added.\n", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Collects expense details from the user and adds the expense transaction.
        /// </summary>
        public void AddExpense()
        {
            Expense? newExpense = this.GetExpenseDetails();
            if (newExpense != null)
            {
                this._transactionService.AddTransaction(newExpense);
                WriteColored("Expense added succesfully.\n", ConsoleColor.Green);
            }
            else
            {
                WriteColored("Expense not added.\n", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        public void EditIncome()
        {
            if (this._transactionService.IsIncomeEmpty())
            {
                WriteColored("No income added yet\n", ConsoleColor.Yellow);
                return;
            }

            Console.WriteLine("Enter income ID");
            string idToEdit = Console.ReadLine() ?? string.Empty;
            Income? existingIncome = this._transactionService.GetExistingIncome(idToEdit);
            if (existingIncome == null)
            {
                WriteColored("No matching income found\nCouldn't update the income", ConsoleColor.Red);
            }
            else
            {
                var incomeDate = this.GetUpdatedDate(existingIncome.TransactionDate);
                int incomeAmount = this.GetUpdatedAmount(existingIncome.Amount);
                string incomeSource = this.GetUpdatedSource(existingIncome.Source);
                bool hasChanges = incomeDate != existingIncome.TransactionDate ||
                                  incomeAmount != existingIncome.Amount ||
                                  incomeSource != existingIncome.Source;
                this._transactionService.UpdateTransaction(existingIncome, new Income(incomeDate, incomeAmount, incomeSource));
                if (hasChanges)
                {
                    WriteColored("Income updated successfully\n", ConsoleColor.Green);
                }
                else
                {
                    WriteColored("No changes made\n", ConsoleColor.Green);
                }
            }
        }

        /// <summary>
        /// Updates an existing expense transaction.
        /// </summary>
        public void EditExpense()
        {
            if (this._transactionService.IsExpenseEmpty())
            {
                WriteColored("No expense added yet\n", ConsoleColor.Yellow);
                return;
            }

            Console.WriteLine("Enter expense ID");
            string idToEdit = Console.ReadLine() ?? string.Empty;
            var existingExpense = this._transactionService.GetExistingExpense(idToEdit);
            if (existingExpense == null)
            {
                WriteColored("No matching expense found\nCouldn't update the expense", ConsoleColor.Red);
            }
            else
            {
                var expenseDate = this.GetUpdatedDate(existingExpense.TransactionDate);
                int expenseAmount = this.GetUpdatedAmount(existingExpense.Amount);
                string expenseCategory = this.GetUpdatedCategory(existingExpense.Category);
                bool hasChanges = expenseDate != existingExpense.TransactionDate ||
                                  expenseAmount != existingExpense.Amount ||
                                  expenseCategory != existingExpense.Category;
                this._transactionService.UpdateTransaction(existingExpense, new Expense(expenseDate, expenseAmount, expenseCategory));
                if (hasChanges)
                {
                    WriteColored("Expense updated successfully\n", ConsoleColor.Green);
                }
                else
                {
                    WriteColored("No changes made\n", ConsoleColor.Green);
                }
            }
        }

        /// <summary>
        /// Deletes a transaction of the specified type.
        /// </summary>
        /// <param name="type">The transaction type to delete.</param>
        public void DeleteTransaction(TransactionType type)
        {
            Console.WriteLine($"Enter {type} ID");

            string id = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsValidId(id))
            {
                WriteColored("ID should be in the format I1 for income and E1 for the expense",ConsoleColor.Red);
            }


            bool success = this._transactionService.DeleteTransaction(id, type);

            WriteColored(
                success ? $"{type} deleted successfully" : $"{type} does not exist.\nDeletion failed",
                success ? ConsoleColor.Green : ConsoleColor.Red);
        }

        /// <summary>
        /// Displays all income transactions.
        /// </summary>
        public void ViewIncome()
        {
            var incomeRecords = this._transactionService.GetRecords(TransactionType.Income);
            if (this._transactionService.IsIncomeEmpty())
            {
                WriteColored("No income added yet\n", ConsoleColor.Yellow);
            }
            else
            {
                this.DisplayRecords(incomeRecords);
            }
        }

        /// <summary>
        /// Displays all expense transactions.
        /// </summary>
        public void ViewExpense()
        {
            var expenseRecords = this._transactionService.GetRecords(TransactionType.Expense);
            if (this._transactionService.IsExpenseEmpty())
            {
                WriteColored("No expense added yet\n", ConsoleColor.Yellow);
            }
            else
            {
                this.DisplayRecords(expenseRecords);
            }
        }

        /// <summary>
        /// Displays summary transactions.
        /// </summary>
        public void ViewSummary()
        {
            if (this._transactionService.IsIncomeEmpty() && this._transactionService.IsExpenseEmpty())
            {
                WriteColored("No transactions made yet\n", ConsoleColor.Yellow);
                return;
            }

            int totalIncome = this._transactionService.GetTotal(TransactionType.Income);
            int totalExpense = this._transactionService.GetTotal(TransactionType.Expense);
            int balance = this._transactionService.GetBalance();
            Console.WriteLine("\nYour summary\n" +
                             $"Total Income : {totalIncome}\n" +
                             $"Total Expense : {totalExpense}\n" +
                             $"Current Balance : {balance}");
        }

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
                Console.WriteLine("Enter income source ");
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
                Console.WriteLine("Enter expense Category ");
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
            Console.WriteLine($"Choose your option");
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
            Console.WriteLine("1. Enter your own date in (YYYY/MM/DD) format\n" +
                              "2. Todays date");
            string userDateChoice = Console.ReadLine() ?? string.Empty;
            switch (userDateChoice)
            {
                case "1":
                    string dateInput = Console.ReadLine() ?? string.Empty;
                    if (Validator.IsValidDate(dateInput, out var date))
                    {
                        return (date, true);
                    }
                    else
                    {
                        WriteColored("Enter a valid date", ConsoleColor.Red);
                    }

                    break;
                case "2":
                    date = DateOnly.FromDateTime(DateTime.Today);
                    return (date, true);
                default:
                    WriteColored("Invalid Choice\n", ConsoleColor.Red);
                    break;
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

            if (input == "y")
            {
                var (newDate, isValid) = this.GetDateInput();

                if (isValid)
                {
                    return newDate;
                }

                Console.WriteLine("Invalid date. Keeping old date.");
                return oldDate;
            }
            else
            {
                return oldDate;
            }
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
            if (input == "y")
            {
                var (newAmount, isValid) = this.GetAmountInput();
                if (isValid)
                {
                    return newAmount;
                }

                Console.WriteLine("Invalid amount. Keeping old amount");
                return oldAmount;
            }
            else
            {
                return oldAmount;
            }
        }

        /// <summary>
        /// Allows the user to update an income source.
        /// </summary>
        /// <param name="oldSource">The current source.</param>
        /// <returns>
        /// The updated source if valid; otherwise the original source.
        /// </returns>
        public string GetUpdatedSource(string oldSource)
        {
            Console.Write($"Current source {oldSource}\n" +
                              $"do you want to edit the source (Enter y)");
            string input = (Console.ReadLine() ?? "n").ToLower();
            if (input == "y")
            {
                var (newSource, isSourceValid) = this.GetTextInput("Source");
                if (isSourceValid)
                {
                    return newSource;
                }
                else
                {
                    Console.WriteLine("Invalid source. Keeping old source");
                    return oldSource;
                }
            }
            else
            {
                return oldSource;
            }
        }

        /// <summary>
        /// Allows the user to update an expense category.
        /// </summary>
        /// <param name="category">The current category.</param>
        /// <returns>
        /// The updated category if valid; otherwise the original category.
        /// </returns>
        public string GetUpdatedCategory(string category)
        {
            Console.Write($"Current category {category}\n" +
                              $"do you want to edit the category (y/n)");
            string input = (Console.ReadLine() ?? "n").ToLower();
            if (input == "y")
            {
                var (newCategory, isCategoryValid) = this.GetTextInput("Category");
                if (isCategoryValid)
                {
                    return newCategory;
                }
                else
                {
                    Console.WriteLine("Invalid category. Keeping old category");
                    return category;
                }
            }
            else
            {
                return category;
            }
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

            WriteColored("Enter a valid amount", ConsoleColor.Red);
            return failureResult;
         }

        /// <summary>
        /// Displays a list of transactions with their details.
        /// </summary>
        /// <param name="transactions">The transactions to display.</param>
        public void DisplayRecords(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"ID: {transaction.Id}");
                Console.WriteLine($"Transaction Date: {transaction.TransactionDate}");
                Console.WriteLine($"Amount: {transaction.Amount}");

                if (transaction is Income income)
                {
                    Console.WriteLine($"Source: {income.Source}");
                }
                else if (transaction is Expense expense)
                {
                    Console.WriteLine($"Category: {expense.Category}");
                }

                Console.WriteLine();
            }
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
