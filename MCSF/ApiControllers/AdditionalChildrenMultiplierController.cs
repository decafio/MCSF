using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MCSF.DAL;

using System.Threading.Tasks; // Task
using System.Data.Entity; // Async extensions, Include

namespace MCSF.ApiControllers
{
    public class AdditionalChildrenMultiplierController : ApiController
    {
        /// <summary>
        /// MCSF 2.08 Additional Children Multiplier is a percentage that is multiplied toward the 
        /// net income of the parent to reduce the net so as to take into account the income reserved for 
        /// supporting those additional children.
        /// </summary>
        /// <param name="childCount">Additional children include biological, adopted, and 
        /// children in common who live with a third party.</param>
        /// <returns>decimal percentage</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(int childCount)
        {
            return Ok(await AdditionalChildrenRepo.GetAdditionalChildren(childCount));
        }
    }
}
