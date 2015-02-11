using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks;
using MCSF.ApiModels;
using System.Data.Entity; // Async extensions, Include

namespace MCSF.DAL
{
    public class OrdinaryMedExpRepo
    {
        /// <summary>
        /// Returns the Average Medical Expense Average Monthly amount from MCSF Supp Sec 2.02 Pg1
        /// </summary>
        public async Task<OrdinaryMedExp> GetOrdinaryMedExp(int childCount)
        {
            CalculationContext calcContext = new CalculationContext();

            // Formula only goes up to 5 children
            if (childCount > 5) childCount = 5;

            if (childCount < 1) return new OrdinaryMedExp() { };
            else
            {
                OrdinaryMedExp ordinaryMedExpAvg = await calcContext.OrdinaryMedExps.Where(c => c.ChildCount == childCount).FirstAsync();

                return ordinaryMedExpAvg;
            }
        }
    }
}