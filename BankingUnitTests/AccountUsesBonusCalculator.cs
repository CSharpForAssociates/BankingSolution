using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountUsesBonusCalculator
    {
        [Fact]
        public void BonusIsAppliedToTheDeposit()
        {
            // given (I have an account that is uses my fake, stubbed version)
            var stubbedBonusCalculator = new Mock<ICalculateBankAccountBonuses>();
            stubbedBonusCalculator.Setup(c => c.GetDepositBonusFor(1000, 500)).Returns(42);
            var account = new BankAccount(stubbedBonusCalculator.Object);
            var openingBalance = account.GetBalance();

            // when I make a deposit (it should ask the stubbed version!)
            account.Deposit(500);

            // then
            Assert.Equal(
                openingBalance + 500 + 42,
                account.GetBalance()
                );

        }
    }
}
