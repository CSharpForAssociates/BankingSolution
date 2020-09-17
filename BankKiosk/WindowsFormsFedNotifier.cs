using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankKiosk
{
    public class WindowsFormsFedNotifier : INotifyTheFeds
    {
        public void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw)
        {
            // the code to notify the feds here. We won't show a message box. because that is sort of dumb and annoying.
            // You should NOT notify the user you are notifying the feds. The feds like to surprise people.
        }
    }
}
