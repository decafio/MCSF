using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks;
using MCSF.ApiModels;
using System.Data.Entity; // Async extensions, Include

namespace MCSF.DAL
{
    public static class OrdinaryMedExpRepo
    {

        internal static async Task<decimal> Monthly(int childCount)
        {
            return (await GetOrdinaryMedExp(childCount)).MonthlyAmount;
        }

        internal static async Task<decimal> Annual(int childCount)
        {
            return (await GetOrdinaryMedExp(childCount)).AnnualAmount;
        }

        /// <summary>
        /// Returns the Average Medical Expense Average Monthly amount from MCSF Supp Sec 2.02 Pg1
        /// </summary>
        private static async Task<OrdinaryMedicalExpense> GetOrdinaryMedExp(int childCount)
        {
            CalculationContext calcContext = new CalculationContext();

            // Formula only goes up to 5 children
            if (childCount > 5) childCount = 5;

            if (childCount < 1) return new OrdinaryMedicalExpense() { };
            else
            {
                OrdinaryMedicalExpense ordinaryMedExpAvg = await calcContext.OrdinaryMedExps.Where(c => c.ChildCount == childCount).FirstAsync();

                return ordinaryMedExpAvg;
            }
        }
    }
}