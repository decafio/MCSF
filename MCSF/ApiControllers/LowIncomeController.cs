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
    }
}
