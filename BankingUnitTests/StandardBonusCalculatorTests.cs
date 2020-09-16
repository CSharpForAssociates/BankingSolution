using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class StandardBonusCalculatorTests
    {
        // Balances below 1000 never get a bonus (either before or after the cutoff) (2)
        // Balances at or over 1000 
        //      - Before Cutoff get 10%
        //      - After Cutoff get 8%

        [Fact]
        public void BonusBeforeCutoff()
        {
            var calculator = new BeforeCutoffBonusCalculator();
            var bonus = calculator.GetDepositBonusFor(1000, 100);
            Assert.Equal(10, bonus);
        }

        [Fact]
        public void BonusAfterCutoff()
        {
            var calculator = new AfterCutoffBonusCalculator();
            var bonus = calculator.GetDepositBonusFor(1000, 100);
            Assert.Equal(8, bonus);
        }

    }

    public class BeforeCutoffBonusCalculator : StandardBonusCalculator
    {

        protected override bool BeforeCutoff()
        {
            return true;
        }
    }
    public class AfterCutoffBonusCalculator : StandardBonusCalculator
    {
        protected override bool BeforeCutoff()
        {
            return false;
        }
    }
}
