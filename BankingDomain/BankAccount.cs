using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 1000M;
        private ICalculateBankAccountBonuses _bonusCalculator;

        public BankAccount(ICalculateBankAccountBonuses bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
        }

       

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            // WTCYWYH
            decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if(amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }
            _balance -= amountToWithdraw;
        }
    }
}