using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MCSF.ApiModels;
using MCSF.DAL;
using MCSF.ApiCalculations;

using System.Threading.Tasks;

namespace MCSF.ApiControllers
{
    public class LowIncomeController : ApiController
    {
        /// <summary>
        /// 2.09(A) “Low Income Threshold” is the individual income level specified in the current MCSF Supplement.
        /// </summary>
        /// <returns>(int) Monthly amount considered to be minimum income.</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Threshold()
        {
            return Ok(await LowIncomeRepo.GetLowIncomeThresholdAmount());
        }

        /// <summary>
        /// 3.02(C) Low Income Equation: When a parent’s monthly net income does not exceed the Low Income Threshold, the 
        /// parent’s base support obligation is 10 percent of that parent’s income.
        /// </summary>
        /// <param name="income"></param>
        /// <returns>Returns the monthly support obligation for a person below the Low Income Threshold.</returns>
        [HttpGet]
        public IHttpActionResult Obligation(decimal income)
        {
            return Ok(LowIncomeCalcs.Obligation(income));
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
        public IHttpActionResult TransitionObligation(decimal income, int childCount)
        {
            return Ok(LowIncomeCalcs.TransitionObligation(income, childCount));
        }
    }
}
