namespace BankingDomain
{
    public interface ICalculateBankAccountBonuses
    {
        decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit);
    }
}