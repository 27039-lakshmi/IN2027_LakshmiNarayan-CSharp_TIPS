using BankApplication.Models;
using BankApplication.Services;
namespace BankApplication.View
{
    internal class UserViewer
    {
        public static void Start()
        {
            string? userChoice;
            do
            {
                Console.WriteLine("Choose your Bank Account \n" +
                    "[1] Savings Account \n[2] Checking Account\n[3] Exit");
                userChoice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userChoice))
                {
                    userChoice = "0";
                }
                if (int.TryParse(userChoice, out int _))
                {
                    Console.WriteLine("Enter your Account Number");
                    string accountNumber = Console.ReadLine();
                    switch (userChoice)
                    {
                        case "1":
                            var savingsAccount = BankServices.CreateSavingsAccount(accountNumber);
                            if (savingsAccount != null)
                            {
                                Console.WriteLine("Savings Account Created");

                            }
                            else
                            {
                                Console.WriteLine("Account Number should contain digits only");
                            }
                            BankOperation(savingsAccount);
                            break;

                        case "2":
                            var checkingAccount = BankServices.CreateCheckingAccount(accountNumber);
                            if (checkingAccount != null)
                            {
                                Console.WriteLine("Checking Account Created");
                            }
                            else
                            {
                                Console.WriteLine("Account Number should contain digits only");
                            }
                            BankOperation(checkingAccount);
                            break;

                        case "3":
                            Console.WriteLine("Exitting ...");
                            break;
                        default:
                            Console.WriteLine("Enter 1 or 2 or 3");
                            break;
                    }
                }
            }
            while (userChoice != "3");
        }
        public static void BankOperation(BankAccount bankAccount)
        {
            string bankOperation;
            do
            {
                Console.WriteLine("Enter your choice \n[1] Deposit \n[2] Withdraw \n[3] Exit");
                bankOperation = Console.ReadLine();
                switch (bankOperation)
                {
                    case "1":
                        Console.WriteLine("Enter your Deposit Amount");
                        string depositAmount = Console.ReadLine();
                        if (int.TryParse(depositAmount, out int _))
                        {
                            bankAccount.Deposit(int.Parse(depositAmount));
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter your Withdraw Amount");
                        string withdrawAmount = Console.ReadLine();
                        if (int.TryParse(withdrawAmount, out int _))
                        {
                            bankAccount.Withdraw(int.Parse(withdrawAmount));
                        }
                        break;
                    case "3":
                        Console.WriteLine("Exitting ..");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (bankOperation != "3");
        }
    }
}
