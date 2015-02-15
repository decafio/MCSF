using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSF.Utilities
{
    public static class Income
    {
        public static decimal Percent(decimal forParent, decimal otherParent)
        {
            decimal percent = (forParent / (forParent + otherParent));

            // 3.01(B) Subsection 2 - Percentage is to be between 10 and 90%
            if (percent < .10m) return .10m;
            else if (percent > .90m) return .90m;
            else return Decimal.Round(percent, 4, MidpointRounding.AwayFromZero);
        }
    }
}