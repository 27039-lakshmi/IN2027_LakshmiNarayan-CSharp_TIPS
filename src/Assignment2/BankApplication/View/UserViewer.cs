using BankApplication.Models;
using BankApplication.Services;

namespace BankApplication.View
{
    /// <summary>
    /// Handles user interaction for bank account creation
    /// and banking operations.
    /// </summary>
    public static class UserViewer
    {
        /// <summary>
        /// Starts the banking application workflow.
        /// Allows the user to create a savings account,
        /// checking account, or exit the application.
        /// </summary>
        public static void Start()
        {
            string userChoice;

            do
            {
                Console.WriteLine(
                    "Choose your Bank Account \n" +
                    "[1] Savings Account \n" +
                    "[2] Checking Account\n" +
                    "[3] Exit");

                userChoice = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(userChoice))
                {
                    userChoice = string.Empty;
                }

                if (int.TryParse(userChoice, out int _))
                {
                    Console.WriteLine("Enter your Account Number");
                    string accountNumber = Console.ReadLine() ?? string.Empty;

                    switch (userChoice)
                    {
                        case "1":
                            var savingsAccount = BankServices.CreateSavingsAccount(accountNumber);

                            if (savingsAccount != null)
                            {
                                Console.WriteLine("Savings Account Created");
                                BankOperation(savingsAccount);
                            }
                            else
                            {
                                Console.WriteLine("Account Number should have 10 digits");
                            }

                            break;

                        case "2":
                            var checkingAccount = BankServices.CreateCheckingAccount(accountNumber);

                            if (checkingAccount != null)
                            {
                                Console.WriteLine("Checking Account Created");
                                BankOperation(checkingAccount);
                            }
                            else
                            {
                                Console.WriteLine("Account Number should contain digits only");
                            }

                            break;

                        case "3":
                            Console.WriteLine("Exitting ...");
                            break;

                        default:
                            Console.WriteLine("Enter 1 or 2 or 3");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            while (userChoice != "3");
        }

        /// <summary>
        /// Performs banking operations on the specified account.
        /// Allows the user to deposit funds, withdraw funds,
        /// or exit the operation menu.
        /// </summary>
        /// <param name="bankAccount">
        /// The bank account on which operations will be performed.
        /// </param>
        public static void BankOperation(BankAccount bankAccount)
        {
            string bankOperation;

            do
            {
                Console.WriteLine(
                    "Enter your choice \n" +
                    "[1] Deposit \n" +
                    "[2] Withdraw \n" +
                    "[3] Exit");

                bankOperation = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(bankOperation, out int _))
                {
                    switch (bankOperation)
                    {
                        case "1":
                            Console.WriteLine("Enter your Deposit Amount\n");
                            string depositAmount = Console.ReadLine() ?? string.Empty;
                            if (!int.TryParse(depositAmount, out int _))
                            {
                                Console.WriteLine("Deposit amount should be a number");
                            }
                            else if (int.Parse(depositAmount) < 0)
                            {
                                Console.WriteLine("Deposit amount cannot be negative");
                                continue;
                            }
                            else
                            {
                                bankAccount.Deposit(int.Parse(depositAmount));
                                Console.WriteLine("Amount Deposited\nCurrent Balance:");
                                Console.WriteLine(BankServices.FindAccountBalance(bankAccount));
                            }

                            break;

                        case "2":
                            if (BankServices.FindAccountBalance(bankAccount) == 0)
                            {
                                Console.WriteLine("Balance is 0. Deposit an amount first\n");
                                continue;
                            }

                            Console.WriteLine("Enter your Withdraw Amount\n");
                            string withdrawAmount = Console.ReadLine() ?? string.Empty;

                            if (!int.TryParse(withdrawAmount, out int _))
                            {
                                Console.WriteLine("Withdraw amount should be a number");
                            }
                            else if (int.Parse(withdrawAmount) < 0)
                            {
                                Console.WriteLine("Withdraw amount cannot be negative");
                                continue;
                            }
                            else
                            {
                                string withdrawSuccessfulMessage = bankAccount.Withdraw(int.Parse(withdrawAmount));

                                if (withdrawSuccessfulMessage == string.Empty)
                                {
                                    Console.WriteLine("Withdrawal Successful\nCurrent Balance");
                                    Console.WriteLine(BankServices.FindAccountBalance(bankAccount));
                                }
                                else
                                {
                                    Console.WriteLine(withdrawSuccessfulMessage);
                                }
                            }

                            break;

                        case "3":
                            Console.WriteLine("Exitting ..\n");
                            break;

                        default:
                            Console.WriteLine("Invalid Choice\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Choice should be an integer\n");
                }
            }
            while (bankOperation != "3");
        }
    }
}