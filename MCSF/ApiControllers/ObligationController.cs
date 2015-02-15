using System;
using System.Collections.Generic;
// using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Data.Entity; // Async extensions, Include

using MCSF.ApiModels;
using MCSF.DAL;
using MCSF.Utilities;
using MCSF.ApiCalculations;

namespace MCSF.ApiControllers
{
    public class ObligationController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> BaseSupport(decimal NetIncomeA, decimal NetIncomeB, int ChildCount)
        {
            return Ok(await ObligationCalcs.BaseSupport(NetIncomeA, NetIncomeB, ChildCount));
        }

        [HttpGet]
        public async Task<IHttpActionResult> StandardSupport(decimal NetIncome, decimal IncomePercent, int ChildCount)
        {
            return Ok(await ObligationCalcs.StandardSupport(NetIncome, IncomePercent, ChildCount));
        }

        [HttpGet]
        public async Task<IHttpActionResult> BaseSupport_3rdParty(decimal NetIncome, int ChildCount)
        {
            return Ok(await ObligationCalcs.BaseSupport_3rdParty(NetIncome, ChildCount));
        }
    }
}
