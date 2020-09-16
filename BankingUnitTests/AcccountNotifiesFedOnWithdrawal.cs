using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AcccountNotifiesFedOnWithdrawal
    {
        [Fact]
        public void FedIsNotifiedOnWithdrawl()
        {

            // Given
            var mockedFed = new Mock<INotifyTheFeds>();
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, mockedFed.Object);

            // When
            account.Withdraw(1);

            // Then
            // ??? 
            mockedFed.Verify(f => f.NotifyOfWithdraw(account, 1m));
        }
    }
}
