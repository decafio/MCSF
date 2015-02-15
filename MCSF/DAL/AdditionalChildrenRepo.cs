using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MCSF.ApiModels;

using System.Threading.Tasks;
using System.Data.Entity; // Async extensions, Include

namespace MCSF.DAL
{
    public static class AdditionalChildrenRepo
    {
        /// <summary>
        /// Retrieves the Adjustment Multiplier (percentage) from the "Additional Children" table based on the childCount
        /// When no addtional children will return 1 -- MCSF Pg12
        /// </summary>
        internal static async Task<decimal> GetAdditionalChildren(int additionalChildCount)
        {
            CalculationContext calcContext = new CalculationContext();

            // If there are no additional children just return 1 (100%)
            if (additionalChildCount < 1) return 1;

            AdditionalChildren additionalChildren = new AdditionalChildren();

            if (additionalChildCount > 5)
                additionalChildren = await calcContext.AdditionalChildren.Where(a => a.ChildCount == 5).FirstAsync();
            else
                additionalChildren = await calcContext.AdditionalChildren.Where(a => a.ChildCount == additionalChildCount).FirstAsync();

            return additionalChildren.Multiplier;
        }
    }
}