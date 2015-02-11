using System;
using System.Collections.Generic;
// using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MCSF.ApiModels;
using MCSF.DAL;
using System.Threading.Tasks;
using System.Data.Entity; // Async extensions, Include

namespace MCSF.ApiControllers
{
    public class ObligationController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> BaseSupport(decimal combinedNetIncome, decimal incomePercent, int childCount)
        {
            return Ok(await CalculateBaseSupport(combinedNetIncome, incomePercent, childCount));
        }

        private static async Task<int> CalculateBaseSupport(decimal combinedNetIncome, decimal incomePercent, int childCount)
        {
            // Child count only goes to 5
            if (childCount > 5) childCount = 5;

            //      {A + [B x (C – D)]} x E = G 
            //          A = Base Support (General Care Support table, column 3) 
            //          B = Marginal Percentage (General Care Support table, column 4) 
            //          C = Monthly Net Family Income (§3.02(B)(1)) 
            //          D = Monthly Income Level (General Care Support table, first column) 
            //          E = Parent’s Percentage Share of Family Income (§3.01(B)(1)) 
            //          G = (BSO) Base Support obligation using the General Care Equation (round to the nearest whole dollar) 

            GeneralSupportBracketRepo repo = new GeneralSupportBracketRepo();
            GeneralCareSupport GCS = await repo.GetGeneralSupportBracket(combinedNetIncome, childCount);

            //       G  = {    A           + [    B               x (C                 -     D                      )]} x E
            decimal BSO = (GCS.BaseSupport + (GCS.MarginalPercent * (combinedNetIncome - GCS.IncomeBracket.IncomeMin))) * incomePercent;

            // This returns an INT because part G of this equations reads "round to the nearest whole dollar"
            return Convert.ToInt32(BSO);
        }
    }
}
