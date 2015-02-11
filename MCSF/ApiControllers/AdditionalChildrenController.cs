using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MCSF.ApiModels;
using MCSF.DAL;
using System.Threading.Tasks;
using System.Data.Entity; // Async extensions, Include

namespace MCSF.ApiControllers
{
    public class AdditionalChildrenController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get(int childCount)
        {
            return Ok(await GetAdditionalChildren(childCount));
        }

        /// <summary>
        /// Retrieves the Adjustment Multiplier (percentage) from the "Additional Children" table based on the childCount
        /// When no addtional children will return 1 -- MCSF Pg12
        /// </summary>
        private async Task<decimal> GetAdditionalChildren(int additionalChildCount)
        {
            CalculationContext calcContext = new CalculationContext();

            // If there are no additional children just return 1 (100%)
            if (additionalChildCount < 1) return 1;

            AdditionalChildren additionalChildren = new AdditionalChildren();

            if (additionalChildCount > 5)
                additionalChildren = await calcContext.AdditionalChildren.Where(a => a.ChildCount == 5).FirstAsync();
            else
                additionalChildren = await calcContext.AdditionalChildren.Where(a => a.ChildCount == additionalChildCount).FirstAsync();

            return additionalChildren.Multiplier;
        }
    }
}
