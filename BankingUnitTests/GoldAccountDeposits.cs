using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class GoldAccountDeposits
    {

        [Fact]
        public void GoldAccountsGetABonusOnDeposits()
        {
            var account = new BankAccount();
            account.AccountType = AccountType.Gold;
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(
                openingBalance + amountToDeposit + 10M,
                account.GetBalance());

        }
    }
}
