using System;

namespace BankingDomain
{
    public enum AccountType { Standard, Gold }
    public class BankAccount
    {
        private decimal _balance = 1000M;

        public AccountType AccountType;
        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            switch(AccountType)
            {
                case AccountType.Standard:
                    {
                        _balance += amountToDeposit;
                        break;
                    }
                case AccountType.Gold:
                    {
                        _balance += amountToDeposit * 1.10M;
                        break;
                    }
            }
            
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