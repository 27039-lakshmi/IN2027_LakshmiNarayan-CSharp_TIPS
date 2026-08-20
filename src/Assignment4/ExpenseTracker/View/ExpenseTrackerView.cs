using ExpenseTracker.Enums;
using ExpenseTracker.Helper;
using ExpenseTracker.Models;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Provides the user interface for the Expense Tracker application.
    /// Displays transaction-related information.
    /// </summary>
    public class ExpenseTrackerView
    {
        private readonly TransactionService _transactionService;
        private readonly UserInputs _userInputs = new ();

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
                Console.WriteLine(Messages.MainMenu);
                if (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    WriteColored(Messages.InvalidChoice, ConsoleColor.Red);
                    continue;
                }

                this.HandleMenuOption((MenuOption)userChoice);
            }
            while ((MenuOption)userChoice != MenuOption.Exit);
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
                    this.DisplayAddMenu();
                    break;
                case MenuOption.Edit:
                    this.DisplayEditMenu();
                    break;
                case MenuOption.Delete:
                    this.DisplayDeleteMenu();
                    break;
                case MenuOption.View:
                    this.DisplayViewMenu();
                    break;

                case MenuOption.Summary:
                    this.ViewSummary();
                    break;

                case MenuOption.Exit:
                    break;

                default:
                    WriteColored(Messages.DefaultMessage, ConsoleColor.Red);
                    break;
            }
        }

        /// <summary>
        /// Collects income details from the user and adds the income transaction.
        /// </summary>
        public void AddIncome()
        {
            var newIncome = this._userInputs.GetIncomeDetails();
            if (newIncome != null)
            {
                this._transactionService.AddTransaction(newIncome);
                WriteColored(Messages.AddIncomeSuccess, ConsoleColor.Green);
            }
            else
            {
                WriteColored(Messages.AddIncomeFailed, ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Collects expense details from the user and adds the expense transaction.
        /// </summary>
        public void AddExpense()
        {
            Expense? newExpense = this._userInputs.GetExpenseDetails();
            if (newExpense != null)
            {
                this._transactionService.AddTransaction(newExpense);
                WriteColored(Messages.AddExpenseSuccess, ConsoleColor.Green);
            }
            else
            {
                WriteColored(Messages.AddExpenseFailed, ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        public void EditIncome()
        {
            if (this._transactionService.IsIncomeEmpty())
            {
                WriteColored(Messages.IncomeEmpty, ConsoleColor.Yellow);
                return;
            }

            Console.WriteLine("Enter income ID");
            string idToEdit = Console.ReadLine() ?? string.Empty;
            Income? existingIncome = this._transactionService.GetExistingIncome(idToEdit);
            if (existingIncome == null)
            {
                WriteColored(Messages.NoIncomeFound, ConsoleColor.Red);
            }
            else
            {
                var incomeDate = this._userInputs.GetUpdatedDate(existingIncome.TransactionDate);
                int incomeAmount = this._userInputs.GetUpdatedAmount(existingIncome.Amount);
                string incomeSource = this._userInputs.GetUpdatedSource(existingIncome.Source);
                bool hasChanges = incomeDate != existingIncome.TransactionDate ||
                                  incomeAmount != existingIncome.Amount ||
                                  incomeSource != existingIncome.Source;
                this._transactionService.UpdateTransaction(existingIncome, new Income(incomeDate, incomeAmount, incomeSource));
                if (hasChanges)
                {
                    WriteColored(Messages.UpdateIncomeSuccess, ConsoleColor.Green);
                }
                else
                {
                    WriteColored(Messages.NoChanges, ConsoleColor.White);
                } 
            }
        }

        /// <summary>
        /// Display add menu
        /// </summary>
        public void DisplayAddMenu()
        {
            Console.WriteLine();
            string choiceInput = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsChoiceValid(choiceInput, out var userAddChoice))
            {
                WriteColored(Messages.InvalidChoice, ConsoleColor.Red);
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
                    WriteColored(Messages.DefaultMessage, ConsoleColor.Red);
                    break;
            }
        }

        /// <summary>
        /// Display edit menu options to user
        /// </summary>
        public void DisplayEditMenu()
        {
            Console.WriteLine();
            string choiceInput = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsChoiceValid(choiceInput, out var userEditChoice))
            {
                WriteColored(Messages.InvalidChoice, ConsoleColor.Red);
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
                    WriteColored(Messages.DefaultMessage, ConsoleColor.Red);
                    break;
            }
        }

        /// <summary>
        /// Display delete menu options to user
        /// </summary>
        public void DisplayDeleteMenu()
        {
            Console.WriteLine(Messages.DeleteMenu);
            string choiceInput = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsChoiceValid(choiceInput, out var userDeleteChoice))
            {
                WriteColored(Messages.InvalidChoice, ConsoleColor.Red);
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
                    WriteColored(Messages.DefaultMessage, ConsoleColor.Red);
                    break;
            }
        }

        /// <summary>
        /// Display view menu options
        /// </summary>
        public void DisplayViewMenu()
        {
            Console.WriteLine(Messages.ViewMenu);
            string choiceInput = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsChoiceValid(choiceInput, out var userViewChoice))
            {
                WriteColored(Messages.InvalidChoice, ConsoleColor.Red);
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
                    WriteColored(Messages.DefaultMessage, ConsoleColor.Red);
                    break;
            }
        }

        /// <summary>
        /// Updates an existing expense transaction.
        /// </summary>
        public void EditExpense()
        {
            if (this._transactionService.IsExpenseEmpty())
            {
                WriteColored(Messages.ExpenseEmpty, ConsoleColor.Yellow);
                return;
            }

            Console.WriteLine("Enter expense ID");
            string idToEdit = Console.ReadLine() ?? string.Empty;
            var existingExpense = this._transactionService.GetExistingExpense(idToEdit);
            if (existingExpense == null)
            {
                WriteColored(Messages.NoExpenseFound, ConsoleColor.Red);
            }
            else
            {
                var expenseDate = this._userInputs.GetUpdatedDate(existingExpense.TransactionDate);
                int expenseAmount = this._userInputs.GetUpdatedAmount(existingExpense.Amount);
                string expenseCategory = this._userInputs.GetUpdatedCategory(existingExpense.Category);
                bool hasChanges = expenseDate != existingExpense.TransactionDate ||
                                  expenseAmount != existingExpense.Amount ||
                                  expenseCategory != existingExpense.Category;
                this._transactionService.UpdateTransaction(existingExpense, new Expense(expenseDate, expenseAmount, expenseCategory));
                if (hasChanges)
                {
                    WriteColored(Messages.UpdateExpenseSuccess, ConsoleColor.Green);
                }
                else
                {
                    WriteColored(Messages.NoChanges, ConsoleColor.Green);
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
                WriteColored(Messages.InvalidId, ConsoleColor.Red);
                return;
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
                WriteColored(Messages.IncomeEmpty, ConsoleColor.Yellow);
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
                WriteColored(Messages.ExpenseEmpty, ConsoleColor.Yellow);
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
                WriteColored(Messages.TransactionEmpty, ConsoleColor.Yellow);
                return;
            }

            var (totalIncome, totalExpense, balance) = this._transactionService.GetSummary();
            Console.WriteLine("\nYour summary\n" +
                             $"Total Income : {totalIncome}\n" +
                             $"Total Expense : {totalExpense}\n" +
                             $"Current Balance : {balance}");
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
