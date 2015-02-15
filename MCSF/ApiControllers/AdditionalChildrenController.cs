using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MCSF.DAL;

using System.Threading.Tasks;
using System.Data.Entity; // Async extensions, Include

namespace MCSF.ApiControllers
{
    public class AdditionalChildrenController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Multiplier(int childCount)
        {
            return Ok(await AdditionalChildrenRepo.GetAdditionalChildren(childCount));
        }
    }
}
