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
            decimal medExp = await OrdinaryMedExpRepo.Monthly(childCount);

            return Ok(medExp);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Annual(int childCount)
        {
            decimal medExp = await OrdinaryMedExpRepo.Annual(childCount);

            return Ok(medExp);
        }
    }
}
