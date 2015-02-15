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
        [HttpGet]
        public async Task<IHttpActionResult> TransitionMultiplier(int childCount)
        {
            decimal multiplier = await LowIncomeRepo.GetLowIncomeTransitionMultiplier(childCount);

            return Ok(multiplier);
        }

        /// <summary>
        /// Returns the monthly amount considered to be minimum income
        /// </summary>
        [HttpGet]
        public async Task<IHttpActionResult> Threshold()
        {
            return Ok(await LowIncomeRepo.GetLowIncomeThresholdAmount());
        }

        /// <summary>
        /// Returns the monthly support obligation for a person below the Low Income Threshold
        /// </summary>
        [HttpGet]
        public IHttpActionResult Obligation(decimal income)
        {
            return Ok(LowIncomeCalcs.Obligation(income));
        }

        /// <summary>
        /// Returns the monthly support obligation for a person slightly above Low Income
        /// </summary>
        [HttpGet]
        public IHttpActionResult TransitionObligation(decimal income, int childCount)
        {
            return Ok(LowIncomeCalcs.TransitionObligation(income, childCount));
        }
    }
}
