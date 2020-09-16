using BankingDomain;
using BankingUnitTests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountOverdraft
    {
        /*
         * Given we have account with a balance
         * When I take out more money than the balance
         * Then
         *  - The amount of the withdrawal should *not* be removed from the balance.
         *  - There should be an exception thrown
         */

        [Fact]
        public void BalanceStaysTheSame()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(openingBalance + 1M);
            }
            catch (OverdraftException)
            {
                // Gulp!
            }

            Assert.Equal(
                openingBalance,
                account.GetBalance());
        }

        [Fact]
        public void OverdraftGivesException()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();
          
           
            
            Assert.Throws<OverdraftException>(() => account.Withdraw(openingBalance + 1M));

        }
    }
}
