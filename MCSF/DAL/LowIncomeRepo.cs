using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MCSF.ApiModels;
using System.Threading.Tasks;
using System.Data.Entity; // Async extensions, Include

namespace MCSF.DAL
{
    public static class LowIncomeRepo
    {
        /// <summary>
        /// Returns the percentage to multiply the low monthlyl income by
        /// </summary>
        // [ResponseType(typeof(decimal))]
        internal static async Task<decimal> GetLowIncomeTransitionMultiplier(int childCount)
        {
            CalculationContext calcContext = new CalculationContext();

            // Formula only goes up to 
            if (childCount > 5) childCount = 5;
            TransitionAdjustment transitionAdjustment = await calcContext.TransitionAdjustments.Where(a => a.ChildCount == childCount).FirstAsync();

            return transitionAdjustment.Multiplier;
        }

        internal static async Task<int> GetLowIncomeThresholdAmount()
        {
            CalculationContext calcContext = new CalculationContext();

            LowIncomeThreshold threshold = await calcContext.LowIncomeThresholds.FirstAsync();

            return threshold.Amount;
        }
    }
}