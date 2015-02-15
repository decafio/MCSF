using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks;
using System.Data.Entity; // Async extensions, Include

using MCSF.DAL;
using MCSF.ApiModels;
using MCSF.Utilities;

namespace MCSF.ApiCalculations
{
    public class ObligationCalcs
    {
        internal static async Task<int> StandardSupport(decimal combinedNetIncome, decimal incomePercent, int childCount)
        {
            // Child count only goes to 5
            if (childCount > 5) childCount = 5;

            //      {A + [B x (C – D)]} x E = G 
            //          A = Base Support (General Care Support table, column 3) 
            //          B = Marginal Percentage (General Care Support table, column 4) 
            //          C = Monthly Net Family Income (§3.02(B)(1)) 
            //          D = Monthly Income Level (General Care Support table, first column) 
            //          E = Parent’s Percentage Share of Family Income (§3.01(B)(1)) 
            //          G = (BSO) Base Support obligation using the General Care Equation (round to the nearest whole dollar) 

            GeneralCareSupport GCS = await GeneralCareSupportRepo.GetGeneralSupportBracket(combinedNetIncome, childCount);

            //       G  = {    A           + [    B               x (C                 -     D                      )]} x E
            decimal BSO = (GCS.BaseSupport + (GCS.MarginalPercent * (combinedNetIncome - GCS.IncomeBracket.IncomeMin))) * incomePercent;

            // This returns an INT because part G of this equations reads "round to the nearest whole dollar"
            return Convert.ToInt32(BSO);
        }

        /// <summary>
        /// Return "Base Support Obligation (BSO)"
        /// General Care Support Tables MCSF Supplement Section 2.03 Pg 1-3
        /// 2.03(A) Based on the estimated costs of raising children, the General Care Equation (2013 MCSF 3.02(B))
        /// uses variable percentages of family income to determine a child support obligation. The General Care Support 
        /// Tables contain those figures and percentages exclude medical or child care expenses.
        /// </summary>
        internal static async Task<BaseSupports> BaseSupport(decimal parentANetIncome, decimal parentBNetIncome, int childCount)
        {
            BaseSupports supports = new ApiModels.BaseSupports();

            // Get Low Income Threshold
            // int LowIncomeThreshold = MCSF.GetLowIncomeThreshold();
            int LowIncomeThreshold = await LowIncomeRepo.GetLowIncomeThresholdAmount();

            // If either parent's income is below the threshold do not include it in the combined income
            decimal combinedNetIncome = 0;
            combinedNetIncome = parentANetIncome + parentBNetIncome;
            if (parentANetIncome < LowIncomeThreshold && parentBNetIncome < LowIncomeThreshold)
            {
                // F x 10% = L 
                // F = Parent’s Monthly Net Income, when below the Low Income Threshold (§2.09(A)) 
                // 10% = Percentage for Income below the threshold 
                // L = Base Support (round to the nearest whole dollar)

                // This returns an INT because Support Obligation is stated to be "round to the nearest whole dollar"
                supports.ParentA.BaseObligation = LowIncomeCalcs.Obligation(parentANetIncome); // GetLowIncomeObligation(parentANetIncome);
                supports.ParentA.FormulaUsed = SupportFormula.LowIncome.ToString();

                supports.ParentB.BaseObligation = LowIncomeCalcs.Obligation(parentBNetIncome);
                supports.ParentB.FormulaUsed = SupportFormula.LowIncome.ToString();
            }
            else if (parentANetIncome < LowIncomeThreshold)
            {
                supports.ParentA.BaseObligation = LowIncomeCalcs.Obligation(parentANetIncome);
                supports.ParentA.FormulaUsed = SupportFormula.LowIncome.ToString();

                // Since Parent A's income is below low income only Parent B's income is used as the "Combined Net Income"
                supports.ParentB.BaseObligation = await StandardSupport(parentBNetIncome, 1m, childCount);
                supports.ParentB.FormulaUsed = SupportFormula.Standard.ToString();

                int parentBLowIncomeBaseSupport = await LowIncomeCalcs.TransitionObligation(parentBNetIncome, childCount);

                if (parentBLowIncomeBaseSupport < supports.ParentB.BaseObligation)
                {
                    supports.ParentB.BaseObligation = parentBLowIncomeBaseSupport;
                    supports.ParentB.FormulaUsed = SupportFormula.LowIncomeTransition.ToString();
                }
            }
            else if (parentBNetIncome < LowIncomeThreshold)
            {
                supports.ParentB.BaseObligation = LowIncomeCalcs.Obligation(parentBNetIncome);
                supports.ParentB.FormulaUsed = SupportFormula.LowIncome.ToString();

                // Since Parent A's income is below low income only Parent B's income is used as the "Combined Net Income"
                supports.ParentA.BaseObligation = await StandardSupport(parentANetIncome, 1m, childCount);
                supports.ParentA.FormulaUsed = SupportFormula.Standard.ToString();

                int parentALowIncomeBaseSupport = await LowIncomeCalcs.TransitionObligation(parentANetIncome, childCount);

                if (parentALowIncomeBaseSupport < supports.ParentA.BaseObligation)
                {
                    supports.ParentA.BaseObligation = parentALowIncomeBaseSupport;
                    supports.ParentA.FormulaUsed = SupportFormula.LowIncomeTransition.ToString();
                }
            }
            else
            {
                // Get Income Percents
                decimal parentAIncomePercent = Income.Percent(parentANetIncome, parentBNetIncome);
                decimal parentBIncomePercent = 1 - parentAIncomePercent;

                // Since both parents are above the Low Income Threshold we will combine their income
                supports.ParentA.BaseObligation = await StandardSupport(combinedNetIncome, parentAIncomePercent, childCount);
                supports.ParentA.FormulaUsed = SupportFormula.Standard.ToString();

                int parentALowIncomeBaseSupport = await LowIncomeCalcs.TransitionObligation(parentANetIncome, childCount);

                if (parentALowIncomeBaseSupport < supports.ParentA.BaseObligation)
                {
                    supports.ParentA.BaseObligation = parentALowIncomeBaseSupport;
                    supports.ParentA.FormulaUsed = SupportFormula.LowIncomeTransition.ToString();
                }

                supports.ParentB.BaseObligation = await StandardSupport(combinedNetIncome, parentBIncomePercent, childCount);
                supports.ParentB.FormulaUsed = SupportFormula.Standard.ToString();

                int parentBLowIncomeBaseSupport = await LowIncomeCalcs.TransitionObligation(parentBNetIncome, childCount);

                if (parentBLowIncomeBaseSupport < supports.ParentB.BaseObligation)
                {
                    supports.ParentB.BaseObligation = parentBLowIncomeBaseSupport;
                    supports.ParentB.FormulaUsed = SupportFormula.LowIncomeTransition.ToString();
                }
            }

            return supports;
        }

        internal static async Task<BaseSupport> BaseSupport_3rdParty(decimal parentNetIncome, int childCount)
        {
            BaseSupport support = new ApiModels.BaseSupport();

            // 4.01 Third Party Custodians

            // 4.01(A) When a third party has custody of a child, both parents should pay support.
            // Determine each parent’s base support obligation according to that parent’s individual income.

            // 4.01(B) Parents are responsible for all medical expenses, health care coverage premiums, 
            // and child care expenses. When possible, apportion them between the parents.

            // 4.01(C) In determining a parent’s net income amount that will be used to calculate support 
            // for children in the care of a third party, treat the parents’ other children-in-common who are 
            // not in the third party’s custody as additional children from other relationships (§2.08(A)).

            // 4.01(D) When a child is in a third party’s physical custody, calculate each parent’s support 
            // obligation for that child based only on that parent’s income, as follows:
            //      (1) Determine each parent’s net income.
            //      (2) Calculate each parent’s base support obligation separately by treating the other parent’s income as zero.
            //      (3) Calculate medical expense and child care support obligations and require payment from only the parents. 
            //          When possible, divide them between the parents based on each parent’s percentage share of family income.
            //      (4) Total a parent’s base support, ordinary medical expense, and child care obligations to determine that 
            //          parent’s total support obligation payable to the third party.
            //      (5) Do not reduce a parent’s base support obligation paid to a third party for health care coverage premiums 
            //          paid by a parent. Allocation of parent-paid premiums between the parents should be handled separately. 
            //          If the third-party custodian purchases health care coverage for the children, then add each parent’s 
            //          share of the children’s net determinable portion of the premiums paid by the third party to that parent’s support payment.

            // ~~TODO~~ Have a message about the allocation of of parent-paid premiums. Either a parent can pay the other or child support 
            //          can be adjusted to to even out the premiums. SEE SECOND LINE in (5) above

            // ~~TODO~~ Need a place to put a number in case a Third-Party is providing health care insurance as the parents will need to remburse 
            // Third-Party for insurance premiums

            // ~~TODO~~ I do not see anywhere that it mentions using the parenting-time off-set for the Third-Party.

            // Get Low Income Threshold
            int LowIncomeThreshold = await LowIncomeRepo.GetLowIncomeThresholdAmount();

            if (parentNetIncome < LowIncomeThreshold)
            {
                support.BaseObligation = LowIncomeCalcs.Obligation(parentNetIncome);
                support.FormulaUsed = SupportFormula.LowIncome.ToString();
            } 
            else
            {
                // Since parent's income is above the Low Income Threshold
                support.BaseObligation = await ObligationCalcs.StandardSupport(parentNetIncome, 1m, childCount);
                support.FormulaUsed = SupportFormula.Standard.ToString();

                int lowIncomeSupportObligation = await LowIncomeCalcs.TransitionObligation(parentNetIncome, childCount);

                if (lowIncomeSupportObligation < support.BaseObligation)
                {
                    support.BaseObligation = lowIncomeSupportObligation;
                    support.FormulaUsed = SupportFormula.LowIncomeTransition.ToString();
                }
            }

            return support;
        }

    }
}