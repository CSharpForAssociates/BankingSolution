namespace BankingDomain
{
    public interface INotifyTheFeds
    {
        void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw);
    }
}