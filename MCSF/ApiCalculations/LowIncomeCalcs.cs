using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MCSF.DAL;
using System.Threading.Tasks;
// using System.Web.Http.Description; // ResponseType
using System.Data.Entity; // Async extensions, Include

namespace MCSF.ApiCalculations
{
    public static class LowIncomeCalcs
    {
        internal static int Obligation(decimal income)
        {
            //~TODO~ verify that the income is below the Low Income Threshold

            // F x 10% = L 
            // F = Parent’s Monthly Net Income, when below the Low Income Threshold (§2.09(A)) 
            // 10% = Percentage for Income below the threshold 
            // L = Base Support (round to the nearest whole dollar)

            // This returns an INT because Support Obligation is stated to be "round to the nearest whole dollar"
            return Convert.ToInt32(income * .1m);
        }

        internal static async Task<int> TransitionObligation(decimal income, int childCount)
        {
            // (H x 10%) + [(I - H) x P] = T 
            // H = Low Income Threshold (§2.09(A)) 
            // 10% = Percentage for Income below the threshold (§3.02(C)(1)) 
            // I(income) = Parent’s Monthly Net Income 
            // P = Percentage Multiplier for the appropriate number of children from the Transition Adjustment table 
            // T = Base Support obligation using the Low Income Transition Equation

            // Get Multiplier
            decimal P = await LowIncomeRepo.GetLowIncomeTransitionMultiplier(childCount);
            int lowIncomeThreshold = await LowIncomeRepo.GetLowIncomeThresholdAmount();

            // This returns an INT because Support Obligation is stated to be "round to the nearest whole dollar"
            return Convert.ToInt32((lowIncomeThreshold * .10m) + ((income - lowIncomeThreshold) * P));
        }
    }
}