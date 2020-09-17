using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class CannotDoTransactionsWithNegativeAmounts
    {
        // Establish you understand the undesirable behavior - a TEMPORARY test that makes the system do the bad thing.
        // This should PASS until you fix it and then it will FAIL.
        //[Fact]
        //public void DepositsAllowNegativeNumbers()
        //{
        //    var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, new Mock<INotifyTheFeds>().Object);
        //    var openingBalance = account.GetBalance();

        //    account.Deposit(-100);

        //    Assert.Equal(openingBalance - 100, account.GetBalance());
        //}

        // Write a test that shows how it SHOULD work. This will fail until you fix it, then it will pass when you are done.
        [Fact]
        public void DepositsDoNotAllowNegativeNumbers()
        {
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();

            
            Assert.Throws<NoNegativeTransactionsException>(() => account.Deposit(-100));

            Assert.Equal(openingBalance, account.GetBalance());
        }
    }
}
