using BankApplication.Models;
namespace BankApplication.Services
{
    internal static class BankServices
    {
        public static SavingsAccount CreateSavingsAccount(string accountNumber)
        {
            if (ValidateInput(accountNumber))
            {
                var savingsAccount = new SavingsAccount(accountNumber);
                return savingsAccount;
            }
            else
            {
                return null;
            }

        }

        public static CheckingAccount CreateCheckingAccount(string accountNumber)
        {
            if (ValidateInput(accountNumber))
            {
                var checkingAccount = new CheckingAccount(accountNumber);
                return checkingAccount;
            }
            else
            {
                return null;
            }
        }

        public static bool ValidateInput(string accountNumber)
        {
            foreach (char c in accountNumber)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}
