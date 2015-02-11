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
    public class OrdinaryMedExpController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Monthly(int childCount)
        {
            OrdinaryMedExpRepo repo = new OrdinaryMedExpRepo();
            OrdinaryMedExp expAvg = await repo.GetOrdinaryMedExp(childCount);
            return Ok(expAvg.MonthlyAmount);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Annual(int childCount)
        {
            OrdinaryMedExpRepo repo = new OrdinaryMedExpRepo();
            OrdinaryMedExp expAvg = await repo.GetOrdinaryMedExp(childCount);
            return Ok(expAvg.AnnualAmount);
        }
    }
}
