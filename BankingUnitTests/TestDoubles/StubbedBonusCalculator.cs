using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingUnitTests.TestDoubles
{
    public class StubbedBonusCalculator : ICalculateBankAccountBonuses
    {
        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            return balance == 1000 && amountToDeposit == 500 ? 42 : 0;
        }
    }
}
