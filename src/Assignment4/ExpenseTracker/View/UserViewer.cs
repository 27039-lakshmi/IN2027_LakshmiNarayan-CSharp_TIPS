using ExpenseTracker.Models;
using ExpenseTracker.Service;
namespace ExpenseTracker.View
{
    internal class UserViewer
    {
        private readonly TransactionService transactionService;

        public UserViewer(TransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public void Start()
        {
            string userChoice;
            do
            {
                Console.WriteLine("1.Add income/expense\n" +
                                  "2.Edit income/expense\n" +
                                  "3.Delete income/expense\n" +
                                  "4.View income/expense\n" +
                                  "5.Get Summary\n" +
                                  "6.Exit\n" +
                                  "Enter your Choice");
                userChoice = Console.ReadLine() ?? string.Empty;
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("1.Add income\n" +
                                          "2.Add expense\n" +
                                          "Enter your choice");
                        string userAddChoice = Console.ReadLine() ?? string.Empty;
                        switch (userAddChoice)
                        {
                            case "1":
                                (DateOnly incomeDate, int incomeAmount, string incomeSource, bool isSuccess) = GetIncomeDetails();
                                if (isSuccess)
                                {
                                    transactionService.AddTransaction(new Income(incomeDate, incomeAmount, incomeSource));
                                }

                                break;
                            case "2":
                                (DateOnly expenseDate, int expenseAmount, string category, isSuccess) = GetExpenseDetails();
                                if (isSuccess)
                                {
                                    transactionService.AddTransaction(new Expense(expenseDate, expenseAmount, category));
                                }

                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }

                        break;
                    case "2":
                        Console.WriteLine("1.Edit income\n" +
                                          "2.Edit expense\n" +
                                          "Enter your choice");
                        string userEditChoice = Console.ReadLine() ?? string.Empty;
                        switch (userEditChoice)
                        {
                            case "1":
                                if (transactionService.isIncomeEmpty())
                                {
                                    Console.WriteLine("No income added yet\n");
                                    continue;
                                }
                                Console.WriteLine("Enter income ID");
                                string idToEdit = Console.ReadLine() ?? string.Empty;
                                var existingIncome = (Income)transactionService.SearchTransaction(transactionService.GetRecords("Income"), idToEdit);
                                DateOnly incomeDate = GetUpdatedDate(existingIncome.TransactionDate);
                                int incomeAmount = GetUpdatedAmount(existingIncome.Amount);
                                string incomeSource = GetUpdatedSource(existingIncome.Source);
                                if (existingIncome != null)
                                {
                                    bool isUpdateSuccess = transactionService.UpdateTransaction(idToEdit, new Income(incomeDate, incomeAmount, incomeSource));
                                    if (!isUpdateSuccess)
                                    {
                                        Console.WriteLine("Income Update failed");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Income Update success");
                                    }
                                }

                                break;
                            case "2":
                                if (transactionService.isExpenseEmpty())
                                {
                                    Console.WriteLine("No expense added yet\n");
                                    continue;
                                }
                                Console.WriteLine("Enter expense ID");
                                idToEdit = Console.ReadLine() ?? string.Empty;
                                var existingExpense = (Expense)transactionService.SearchTransaction(transactionService.GetRecords("Expense"), idToEdit);
                                DateOnly expenseDate = GetUpdatedDate(existingExpense.TransactionDate);
                                int expenseAmount = GetUpdatedAmount(existingExpense.Amount);
                                string expenseCategory = GetUpdatedSource(existingExpense.Category);
                                if (existingExpense !=null)
                                {
                                    bool isUpdateSuccess = transactionService.UpdateTransaction(idToEdit, new Expense(expenseDate, expenseAmount, expenseCategory));
                                    if (!isUpdateSuccess)
                                    {
                                        Console.WriteLine("Expense Update failed");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Expense Update success");
                                    }
                                }

                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("1.Delete income\n" +
                                          "2.Delete expense\n" +
                                          "Enter your choice");
                        string userDeleteChoice = Console.ReadLine() ?? string.Empty;
                        switch (userDeleteChoice)
                        {
                            case "1":
                                if (transactionService.isIncomeEmpty())
                                {
                                    Console.WriteLine("No income added yet\n");
                                    continue;
                                }
                                Console.WriteLine("Enter income ID");
                                string idToDelete = Console.ReadLine() ?? string.Empty;
                                bool isDeleteSucess = transactionService.DeleteTransaction(idToDelete, "Income");
                                if (!isDeleteSucess)
                                {
                                    Console.WriteLine("Income Deletion failed");
                                }
                                else
                                {
                                    Console.WriteLine("Income Deletion success");
                                }

                                break;
                            case "2":
                                if (transactionService.isExpenseEmpty())
                                {
                                    Console.WriteLine("No expense added yet\n");
                                    continue;
                                }
                                Console.WriteLine("Enter expense ID");
                                idToDelete = Console.ReadLine() ?? string.Empty;
                                isDeleteSucess = transactionService.DeleteTransaction(idToDelete, "Expense");
                                if (!isDeleteSucess)
                                {
                                    Console.WriteLine("Expense Deletion failed");
                                }
                                else
                                {
                                    Console.WriteLine("Expense Deletion success");
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("1.View income\n" +
                                          "2.View expense\n" +
                                          "Enter your choice");
                        string userViewChoice = Console.ReadLine() ?? string.Empty;
                        switch (userViewChoice)
                        {
                            case "1":
                                var incomeRecords = transactionService.GetRecords("Income");
                                if (transactionService.isIncomeEmpty())
                                {
                                    Console.WriteLine("No income added yet\n");
                                }
                                else
                                {
                                    DisplayRecords(incomeRecords);
                                }

                                break;
                            case "2":
                                var expenseRecords = transactionService.GetRecords("Expense");
                                if (transactionService.isExpenseEmpty())
                                {
                                    Console.WriteLine("No expense added yet\n");
                                }
                                else
                                {
                                    DisplayRecords(expenseRecords);
                                }

                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                        break;
                    case "5":
                        if (transactionService.isIncomeEmpty() && transactionService.isExpenseEmpty())
                        {
                            Console.WriteLine("No transactions made yet\n");
                            continue;
                        }

                        int totalIncome = transactionService.GetTotal("Income");
                        int totalExpense = transactionService.GetTotal("Expense");
                        int balance = transactionService.GetBalance();
                        Console.WriteLine("Your summary\n" +
                                         $"Total Income : {totalIncome}\n" +
                                         $"Total Expense : {totalExpense}\n" +
                                         $"Current Balance : {balance}");

                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
            while (userChoice != "6");
        }

        public (DateOnly, int, string, bool) GetIncomeDetails()
        {
            var failureResult = (DateOnly.MinValue, 0, string.Empty, false);
            (DateOnly date, int amount, bool isValid) = GetDateAndAmount("income");
            if (isValid)
            {
                Console.WriteLine("Enter income source ");
                string source = GetSourceInput();
                return (date, amount, source, true);
            }
            return failureResult;
        }

        public string GetSourceInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public string GetCategoryInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public (DateOnly, int, string, bool) GetExpenseDetails()
        {
            var failureResult = (DateOnly.MinValue, 0, string.Empty, false);
            (DateOnly date, int amount, bool isValid) = GetDateAndAmount("expense");
            if (isValid)
            {
                Console.WriteLine("Enter expense Category ");
                string source = Console.ReadLine() ?? string.Empty;
                return (date, amount, source, true);
            }
            return failureResult;
        }

        public (DateOnly, int, bool) GetDateAndAmount(string message)
        {
            var failureResult = (DateOnly.MinValue, 0, false);
            Console.WriteLine($"Enter {message} date in (YYYY/MM/DD) format");
            (DateOnly date, bool isDateValid) = GetDateInput();
            if (isDateValid)
            {
                Console.WriteLine($"Enter {message} amount");
                (int amount, bool isAmountValid) = GetAmountInput();
                if (isAmountValid)
                {
                    return (date, amount, true);
                }
            }

            return failureResult;
        }

        public (DateOnly, bool) GetDateInput()
        {
            var failureResult = (DateOnly.MinValue, false);
            Console.WriteLine("1. Enter your own date\n" +
                              "2. Todays date");
            string userDateChoice = Console.ReadLine() ?? string.Empty;
            switch (userDateChoice)
            {
                case "1":
                    if (DateOnly.TryParse(Console.ReadLine(), out var date))
                    {
                        return (date, true);
                    }

                    break;
                case "2":
                    date = DateOnly.FromDateTime(DateTime.Today);
                    return (date, true);
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            return failureResult;

        }

        public DateOnly GetUpdatedDate(DateOnly oldDate)
        {
            Console.WriteLine($"Current Date: {oldDate}");
            Console.Write("Do you want to edit the date (Enter y): ");

            string input = (Console.ReadLine() ?? "n").ToLower();

            if (input == "y")
            {
                var (newDate, isValid) = GetDateInput();

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

        public int GetUpdatedAmount(int oldAmount)
        {
            Console.Write($"Current amount {oldAmount}\n" +
                              $"do you want to edit the amount (Enter y)");
            string input = (Console.ReadLine() ?? "n").ToLower();
            if (input == "y")
            {
                var (newAmount, isValid) = GetAmountInput();
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

        public string GetUpdatedSource(string oldSource)
        {
            Console.Write($"Current source {oldSource}\n" +
                              $"do you want to edit the source (Enter y)");
            string input = (Console.ReadLine() ?? "n").ToLower();
            if (input == "y")
            {
                string newSource = GetSourceInput();
                return newSource;
            }
            else
            {
                return oldSource;
            }
        }

        public string GetUpdatedCategory(string category)
        {
            Console.Write($"Current category {category}\n" +
                              $"do you want to edit the category (y/n)");
            string input = (Console.ReadLine() ?? "n").ToLower();
            if (input == "y")
            {
                string newCategory = GetCategoryInput();
                return newCategory;
            }
            else
            {
                return category;
            }
        }

        public (int, bool) GetAmountInput()
        {
            var failureResult = (0, false);
            if (int.TryParse(Console.ReadLine(), out var amount))
             {
                return (amount, true);
             }

            return failureResult;
         }

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
    }
}
