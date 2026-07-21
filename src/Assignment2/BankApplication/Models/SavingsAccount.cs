namespace BankApplication.Models
{
    internal class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountNumber)
           : base(accountNumber) { }
        public override string Withdraw(decimal amount)
        {
            if(Balance-amount >=1000)
            {
                Balance-=amount;
                return "";
            }
            else
            {
                return "Withdraw failed . Balance should not go below minimum balance";
            }
        }
    }
}
