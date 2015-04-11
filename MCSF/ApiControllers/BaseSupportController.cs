using System;
using System.Collections.Generic;
// using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Data.Entity; // Async extensions, Include

using MCSF.ApiModels;
using MCSF.DAL;
using MCSF.Utilities;
using MCSF.ApiCalculations;

namespace MCSF.ApiControllers
{
    public class BaseSupportController : ApiController
    {
        /// <summary>
        /// MCSF 3.02 Base Support Obligation: A parent’s child support obligation consists of (1) a base support obligation 
        /// adjusted for parenting time (MCSF 3.03); (2) medical support obligations expenses (MCSF 3.04), health care coverage 
        /// and division of premiums (MCSF 3.05); and (3) child care expense obligations (MCSF 3.06).
        /// </summary>
        /// <param name="NetIncomeA">Parent A Net Income</param>
        /// <param name="NetIncomeB">Parent B Net Income</param>
        /// <param name="ChildCount">Number of Children in common in the marriage in the custody of the parents.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> BaseSupport(decimal NetIncomeA, decimal NetIncomeB, int ChildCount)
        {
            return Ok(await BaseSupportCalcs.BaseSupport(NetIncomeA, NetIncomeB, ChildCount));
        }

        /// <summary>
        /// MCSF 3.02 Base Support Obligation: MCSF 4.01(A) When a third party has custody of a child, 
        /// both parents should pay support.
        /// </summary>
        /// <param name="NetIncome">Individual Parents Income: MCSF 4.01(A) Determine each parent’s base support obligation according to that parent’s 
        /// individual income. </param>
        /// <param name="ChildCount">Number of Children in common in the marriage in the custody of a Third Party.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> ThirdParty(decimal NetIncome, int ChildCount)
        {
            return Ok(await BaseSupportCalcs.BaseSupport_3rdParty(NetIncome, ChildCount));
        }

        /// <summary>
        /// 3.02(B) General Care Equation: (1) Determine the monthly family income by combining the parents’ net incomes.
        /// (2) Solve the following equation using the General Care Support Table (found in the supplement) for the 
        /// appropriate number of children that the parents have in common and its amounts and percentages from the 
        /// highest monthly income level that does not exceed the family’s net monthly income.
        /// </summary>
        /// <param name="NetIncome">Combined income of both parents</param>
        /// <param name="IncomePercent"></param>
        /// <param name="ChildCount"></param>
        /// <returns>(int) Base Support Obligation (rounded to the nearest whole dollar) </returns>
        [HttpGet]
        public async Task<IHttpActionResult> GeneralCareEquation(decimal CombinedNetIncome, decimal IncomePercent, int ChildCount)
        {
            return Ok(await BaseSupportCalcs.GeneralCareEquation(CombinedNetIncome, IncomePercent, ChildCount));
        }

        /// <summary>
        /// 3.02(C) Low Income Equation: When a parent’s monthly net income does not exceed the Low Income Threshold, the 
        /// parent’s base support obligation is 10 percent of that parent’s income.
        /// </summary>
        /// <param name="income"></param>
        /// <returns>Returns the monthly support obligation for a person below the Low Income Threshold.</returns>
        [HttpGet]
        public IHttpActionResult LowIncomeEquation(decimal income)
        {
            return Ok(BaseSupportCalcs.LowIncomeEquation(income));
        }

        /// <summary>
        /// 3.02(D) Low Income Transition Equation: When a parent’s net income exceeds the Low Income Threshold, that parent’s 
        /// base support obligation will generally be determined using the General Care Equation. However, if the following 
        /// equation’s result is lower than the amount calculated using the General Care Equation, a parent’s base support 
        /// obligation is the amount determined by applying this equation.
        /// </summary>        
        /// <param name="income"></param>
        /// <param name="childCount"></param>
        /// <returns>(int) Monthly support obligation for a person slightly above Low Income.</returns>
        [HttpGet]
        public async Task<IHttpActionResult> LowIncomeTransitionEquation(decimal income, int childCount)
        {
            return Ok(await BaseSupportCalcs.LowIncomeTransitionEquation(income, childCount));
        }

    }
}
