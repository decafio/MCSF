using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MCSF.DAL;

using System.Threading.Tasks;

namespace MCSF.ApiCalculations
{
    public static class OrdinaryMedExpCalcs
    {
        /// <summary>
        /// Returns the amount that Payor Parent will need to Pay the other parent each month for Oridnary Medical Expenses
        /// This is added to the Base Support OBligation
        /// </summary>
        internal static async Task<decimal> MonthlyObligation(int childCount, decimal incomePercent)
        {
            decimal OrdinaryMedExpAvg = await OrdinaryMedExpRepo.Monthly(childCount);

            // The medical support and child care obligations’ percentages should be based on both parents’ net incomes 
            // and rounded to the nearest whole percent,
            decimal wholePercent = Decimal.Round(incomePercent, 2, MidpointRounding.AwayFromZero);
            
            // but each parent’s share cannot be less than 10 percent or more than 90 percent.
            if (wholePercent > .90m) wholePercent = .90m;
            else if (wholePercent < .10m) wholePercent = .10m;

            return (OrdinaryMedExpAvg * wholePercent);
        }
    }
}