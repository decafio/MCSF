using System;
// using System.Collections.Generic;
// using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; // IHttpActionResult

using MCSF.ApiModels;
using MCSF.DAL;
using System.Threading.Tasks;
// using System.Data.Entity; // Async extensions, Include

namespace MCSF.ApiControllers
{
    /// <summary>
    /// MCSF-S 2.02 Ordinary Medical Expense Amounts: (A) On average, families spend $357 for one child annually on 
    /// ordinary medical expenses. The Ordinary Medical Expense Averages table states the amounts families are presumed to 
    /// spend on ordinary medical expenses. 
    /// </summary>
    public class OrdinaryMedExpController : ApiController
    {
        /// <summary>
        /// MCSF-S 2.02 Ordinary Medical Expense Averages table. The average amount familes are presumed to spend in a month. 
        /// </summary>
        /// <param name="childCount">Number of children in-common</param>
        /// <returns>(decimal) Monthly Medical Expense Average</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Monthly(int childCount)
        {
            decimal medExp = await OrdinaryMedExpRepo.Monthly(childCount);

            return Ok(medExp);
        }

        /// <summary>
        /// MCSF-S 2.02 Ordinary Medical Expense Averages table. The average amount familes are presumed to spend annualy.
        /// </summary>
        /// <param name="childCount">Number of children in-common</param>
        /// <returns>(decimal) Monthly Medical Expense Average</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Annual(int childCount)
        {
            decimal medExp = await OrdinaryMedExpRepo.Annual(childCount);

            return Ok(medExp);
        }
    }
}
