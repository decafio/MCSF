using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MCSF.ApiCalculations;

namespace MCSF.ApiControllers
{
    public class ChildCareController : ApiController
    {
        /// <summary>
        /// MCSF 3.06(A) Based on each parent’s percentage share of family income, allocate the actual child care expenses for the children 
        ///         in the case under consideration which allow a parent or third party custodian to look for employment, retain employment, 
        ///         or to attend an educational program to improve employment opportunities. 
        /// </summary>
        /// <param name="payerChildCareAmount"></param>
        /// <param name="payerIncomePercent"></param>
        /// <param name="payeeChildCareAmount"></param>
        /// <param name="payeeIncomePercent"></param>
        /// <returns>(decimal) Amount to be applied to the Base Child Support</returns>
        [HttpGet]
        public IHttpActionResult Allocation(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)
        {
            decimal allocation = AllocationCalcs.ChildCareAllocation(payerChildCareAmount, payerIncomePercent, payeeChildCareAmount, payeeIncomePercent);

            return Ok(allocation);
        }
    }
}
