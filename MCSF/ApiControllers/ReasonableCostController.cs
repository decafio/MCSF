using System;
// using System.Collections.Generic;
// using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;

namespace MCSF.ApiControllers
{
    public class ReasonableCostController : ApiController
    {
        /// <summary>
        /// MSCF 3.05(A): Reasonable Cost of Coverage: A reasonable cost for providing private health care coverage for the 
        /// children does not exceed 5 percent of the providing parent’s gross income. 
        /// </summary>
        /// <param name="parentMonthlyGrossIncome">Int</param>
        /// <returns>Returns the maximum amount of a parent would be reasonably expected 
        /// to pay towards the childrens share of healthcare premiums.</returns>
        [HttpGet]
        public IHttpActionResult Get(int parentMonthlyGrossIncome)
        {
            return Ok(parentMonthlyGrossIncome * .05m);
        }
    }
}
