using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSF.ApiCalculations
{
    public class HealthCarePremiumCalcs
    {
        internal static decimal ThirdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
        {
            // See if there are any premiums to calculate
            if (parentAHealthCare > 0 || parentBHealthCare > 0)
            {
                // Get the total amount being paid in Insurance Premiums between the parents
                decimal totalPremium = parentAHealthCare + parentBHealthCare;
                decimal parentAShare = totalPremium * incomePercentA;
                decimal parentBShare = totalPremium * incomePercentB;

                return parentAShare - parentAHealthCare;
            }

            // If there is nothing to process than just return 0
            return 0;
        }

        internal static decimal Allocation(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        {
            // 3.05(C) Health Care Premium Allocation 
            // (2) Allocate the children’s net health care premiums between the parents according to the following steps. 
            //   (a) Determine each parent’s monthly health care premium attributable to the children by dividing 
            //       the premium by the number of individuals covered (including the parent) and multiply by the 
            //       number of children covered in this case.

            decimal TotalPremiumPayer = payerHealthCareAmount * childCount;
            decimal TotalPremiumPayee = payeeHealthCareAmount * childCount;

            //   (b) Prorate each parent’s monthly health care premium attributable to the children by multiplying 
            //       it and the other parent’s percentage of family income.

            decimal AllocationPayer = TotalPremiumPayer * payeeIncomePercent;
            decimal AllocationPayee = TotalPremiumPayee * payerIncomePercent;

            //   (c) Offset the prorated premiums attributable to the children by subtracting the support 
            //       recipient’s share of the support payer’s premium from the payer’s share of the recipient’s 
            //       premium, and round to the nearest cent.

            //   (Note: A positive net result means an additional amount must 
            //       be paid to cover the payer’s share of the support recipient’s premium, while a negative result means 
            //       a reduction in base support to offset the support recipient’s share of the payer’s premium).

            return AllocationPayer - AllocationPayee;
        }

    }
}