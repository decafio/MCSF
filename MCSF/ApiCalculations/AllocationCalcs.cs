using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MCSF.DAL;
using System.Threading.Tasks;

namespace MCSF.ApiCalculations
{
    public static class AllocationCalcs
    {
        /// <summary>
        /// If value return is negative Parent B owes. If positive Parent A owes
        /// </summary>
        internal static decimal HealthCarePremiumAllocation_3rdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
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

        /// <summary>
        /// A positive net result means an additional amount must be paid to cover the payer’s share of the support recipient’s premium,
        /// while a negative result means a reduction in base support to offset the support recipient’s share of the payer’s premium
        /// </summary>
        /// <param name="childCount">The number of children this SPECIFIC child support calculation pertains to.</param>
        /// <returns></returns>
        internal static decimal HealthCarePremiumAllocation(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        {
            // 3.05(C) Health Care Premium Allocation 
            // .... 
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childCount">Number of children for this child support calculation.</param>
        /// <returns></returns>
        internal static decimal ChildCareAllocation(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)
        {
            // 3.06(A) Based on each parent’s percentage share of family income, allocate the actual child care expenses for the children 
            //         in the case under consideration which allow a parent or third party custodian to look for employment, retain employment, 
            //         or to attend an educational program to improve employment opportunities. 
            //          (1) When custodians or parents have an established child care pattern and can verify that they have actual, predictable 
            //              and reasonable child care expenses, use the actual costs in the calculation.
            //          (2) When no established pattern of child care expenses exists, base the expenses on estimates of the community’s 
            //              average child care costs or several written quotations from local child care providers. 
            //          (3) In calculating child care expenses, presume that the court's orders for specific parenting time and custody 
            //              will be followed. However, if a child care provider requires payment to retain a slot for a child without 
            //              regard to whether the child actually attends, include those additional costs.

            // 3.06(B) Figure the actual cost of child care by deducting any child care subsidies, credits (including federal tax credit), 
            //         or similar public or private reimbursements from the gross cost of child care. 

            // 3.06(C) The support payer’s net portion of the actual child care expenses should be ordered paid as a monthly child 
            //         care support obligation. The support recipient’s share of child care expenses is directly contributed by the support 
            //         recipient as expenses occur. Allocate net child care costs according to the following steps. 
            //          (1) Determine each individual’s actual monthly child care. 
            //                  (a) Calculate each individual's gross annual child care expenditures.
            //                  (b) Figure the actual cost by deducting any child care subsidies, credits (including tax credits), 
            //                      or reimbursements from the gross cost of child care and convert to a monthly amount. 
            //          (2) Allocate the actual monthly costs by multiplying by the other parent’s percentage share of family income. §3.01(B)(2). 
            //          (3) Offset the two prorated amounts by subtracting the other parent’s share of the support payer’s monthly 
            //              costs from the payer’s share of the other parent’s monthly costs. 

            // 3.06(D) Presume that the need for child care continues until August 31 following the child’s twelfth birthday. 
            //         At the court’s discretion, the child care support obligation may continue beyond that date as a child’s 
            //         health or safety needs require. 

            // 3.06(E) Since child care support obligations accrue based on the assumed continuation of the net expenses used 
            //         to set the currently effective order, custodians and parents need to notify each other of changes in costs, 
            //         and must notify the friend of the court when they stop incurring child care expenses for a child. 

            // 3.06(F) When parents or custodians do not have an established pattern of child care expenses, the court can order a 
            //         reasonable amount for future child care expenses conditioned upon the support recipient providing to the other 
            //         parent and the friend of the court (1) proof of the recipient’s employment or enrollment in a qualifying educational 
            //         or training program, (2) proof of the recipient’s actual out-of-pocket child care expenses, (3) a written request to 
            //         the friend of the court asking for implementation of the conditional child care provision, and (4) proof that the
            //         support payer was provided copies of items (1)-(3).

            // decimal TotalChildCarePayer = payerAdditional.DayCareAmount * childCount;
            // decimal TotalChildCarePayee = payeeAdditional.DayCareAmount * childCount;

            //   (b) Prorate each parent’s monthly health care premium attributable to the children by multiplying 
            //       it and the other parent’s percentage of family income.

            decimal AllocationPayer = payerChildCareAmount * payeeIncomePercent;
            decimal AllocationPayee = payeeChildCareAmount * payerIncomePercent;

            //   (c) Offset the prorated premiums attributable to the children by subtracting the support 
            //       recipient’s share of the support payer’s premium from the payer’s share of the recipient’s 
            //       premium, and round to the nearest cent.

            //   (Note: A positive net result means an additional amount must 
            //       be paid to cover the payer’s share of the support recipient’s premium, while a negative result means 
            //       a reduction in base support to offset the support recipient’s share of the payer’s premium).

            return AllocationPayer - AllocationPayee;
        }

        /// <summary>
        /// Used for Third Party calculations. Splits the cost of Insurance Premium or Child Case paid by a Third Party between the two parents
        /// </summary>
        internal static decimal ThirdPartyShare(decimal thirdPartyPremiumAmount, int childCount, decimal payerIncomeShare)
        {
            return thirdPartyPremiumAmount * childCount * payerIncomeShare;
        }

        /// <summary>
        /// Provides an English written explanation of what to do about paying for Health Insurance
        /// </summary>
        internal static async Task<string> HealthCarePremiumReview(decimal GrossMonthlyIncome, decimal MonthlyInsurancePremium)
        {
            // 3.05(A) Reasonable Cost of Coverage
            //   A reasonable cost for providing private health care coverage for the children does not exceed 5 percent of the providing parent’s gross income. 
            //     (1) Parents with a net income below 133 percent of the federal poverty level or whose child is covered by 
            //         Medicaid based on that parent’s income should not be ordered to contribute toward or provide private coverage, 
            //         unless private coverage is obtainable without any financial contribution by that parent.
            //     (2) A parent’s cost for providing private health care coverage is unreasonable if the parent’s total current 
            //         obligation for support, child care expenses, ordinary health care expenses, plus the parent’s net share of 
            //         health care insurance exceeds 50 percent of the parent's regular aggregate disposable earnings. 

            // Get the Poverty level from db
            int lowIncomeThreshold = await LowIncomeRepo.GetLowIncomeThresholdAmount();
            decimal povertyLevel133Percent = Convert.ToDecimal(lowIncomeThreshold * 1.33);
            int grossIncome5Percent = Convert.ToInt32(GrossMonthlyIncome * .05m);

            string message = "";
            if (GrossMonthlyIncome < povertyLevel133Percent)
            {
                message = "'s gross income is below 133% the federal poverty level and should not be ordered to contribute toward or provide private coverage, unless private coverage is obtainable without any financial contribution by that parent. (2103 MCSF 3.05(A)(1))";
            }
            else if (MonthlyInsurancePremium <= 0)
            {
                message = " currently pays no Health Insurance Premium. If the children’s net determinable portion of health insurance premiums is available at or below $" + grossIncome5Percent + " it should be purchased.";
            }
            else if (MonthlyInsurancePremium < grossIncome5Percent)
            {
                message = " has child insurance costs of $" + MonthlyInsurancePremium + ". This is below their Reasonable Cost of Coverage of $" + grossIncome5Percent + ".";
            }
            else
            {
                message = " has child insurance costs of $" + MonthlyInsurancePremium + ". This is above their Reasonable Cost of Coverage of $" + grossIncome5Percent + ".";
            }

            return message;
        }
    }
}