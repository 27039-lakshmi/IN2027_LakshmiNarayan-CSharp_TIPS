using System;
using System.Security.Cryptography.X509Certificates;
namespace BankApplication.Models
{
    internal class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountNumber)
            :base(accountNumber) { }
        public override string Withdraw(decimal amount)
        {
            
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return "";
            }
            else
            {
                return "Withdraw failed . Insufficient Balance";
            }
        }
    }
}
