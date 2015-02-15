using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSF.Utilities
{
    public class SupportFormula
    {
        private readonly String name;
        private readonly int value;

        public static readonly SupportFormula LowIncome = new SupportFormula(1, "Low Income");
        public static readonly SupportFormula LowIncomeTransition = new SupportFormula(2, "Low Income Transition");
        public static readonly SupportFormula Standard = new SupportFormula(3, "Standard");

        private SupportFormula(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }
    }
}