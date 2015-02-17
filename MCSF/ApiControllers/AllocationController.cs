using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MCSF.ApiCalculations;

namespace MCSF.ApiControllers
{
    public class AllocationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult HealthCare3rdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
        {
            decimal allocation = AllocationCalcs.HealthCarePremiumAllocation_3rdParty(parentAHealthCare, incomePercentA, parentBHealthCare, incomePercentB, childCount);

            return Ok(allocation);
        }

        [HttpGet]
        public IHttpActionResult HealthCare(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        {
            decimal allocation = AllocationCalcs.HealthCarePremiumAllocation(payerHealthCareAmount, payerIncomePercent, payeeHealthCareAmount, payeeIncomePercent, childCount);

            return Ok(allocation);
        }

        [HttpGet]
        public IHttpActionResult ChildCare(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)
        {
            decimal allocation = AllocationCalcs.ChildCareAllocation(payerChildCareAmount, payerIncomePercent, payeeChildCareAmount, payeeIncomePercent);

            return Ok(allocation);
        }
    }
}
