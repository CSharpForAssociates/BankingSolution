using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now; // I solemnly swear this is the only place in this whole assembly
            // I will use that stupid DateTime.Now property. It does not play nicely with testing.
            // I have hereby "kicked it into a corner until it learns to play nice"
        }
    }
}
