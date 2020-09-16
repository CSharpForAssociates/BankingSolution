using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace BankingUnitTests
{
    public class NewAccounts
    {

        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            // WTCYWYH (Write the code you wish you had)
            // Given
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object);

            // When
            decimal balance = account.GetBalance();

            // Then
            Assert.Equal(1000M, balance);
        }
    }
}
