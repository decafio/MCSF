using System;
// using System.Collections.Generic;
// using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;

namespace MCSF.ApiControllers
{
    public class HealthController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ReasonableCost(int parentMonthlyGrossIncome)
        {
            // Returns the maximum amount of a parent would be reasonably expected to pay.

            // 3.05(A) Reasonable Cost of Coverage 
            // A reasonable cost for providing private health care coverage for the children
            // does not exceed 5 percent of the providing parent’s gross income. 

            return Ok(parentMonthlyGrossIncome * .05m);
        }
    }
}
