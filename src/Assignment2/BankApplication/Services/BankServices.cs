using BankApplication.Models;

namespace BankApplication.Services
{
    /// <summary>
    /// Provides services for creating bank accounts
    /// and validating account-related input.
    /// </summary>
    internal static class BankServices
    {
        /// <summary>
        /// Creates a savings account using the specified account number.
        /// </summary>
        /// <param name="accountNumber">
        /// The account number used to create the savings account.
        /// </param>
        /// <returns>
        /// A <see cref="SavingsAccount"/> object if the account number is valid;
        /// otherwise, <c>null</c>.
        /// </returns>
        public static SavingsAccount? CreateSavingsAccount(string accountNumber)
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

        /// <summary>
        /// Creates a checking account using the specified account number.
        /// </summary>
        /// <param name="accountNumber">
        /// The account number used to create the checking account.
        /// </param>
        /// <returns>
        /// A <see cref="CheckingAccount"/> object if the account number is valid;
        /// otherwise, <c>null</c>.
        /// </returns>
        public static CheckingAccount? CreateCheckingAccount(string accountNumber)
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

        /// <summary>
        /// Validates the account number.
        /// An account number must contain at least ten digits
        /// and consist only of numeric characters.
        /// </summary>
        /// <param name="accountNumber">
        /// The account number to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the account number is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool ValidateInput(string accountNumber)
        {
            if (accountNumber.Length < 10)
            {
                return false;
            }

            foreach (char c in accountNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the balance of bank account
        /// </summary>
        /// <param name="bankAccount">
        /// The account to check balance.
        /// </param>
        /// <returns>
        /// balance of the bank account
        /// </returns>
        public static decimal CheckBalance(BankAccount bankAccount)
        {
            return bankAccount.CheckBalance();
        }
    }
}