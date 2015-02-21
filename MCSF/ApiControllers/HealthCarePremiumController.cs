using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MCSF.ApiCalculations;

namespace MCSF.ApiControllers
{
    public class HealthCarePremiumController : ApiController
    {
        /// <summary>
        /// Determines if one parent owes the other for healthcare premiums when the child is in the custody of a third party.
        /// </summary>
        /// <param name="parentAHealthCare"></param>
        /// <param name="incomePercentA"></param>
        /// <param name="parentBHealthCare"></param>
        /// <param name="incomePercentB"></param>
        /// <param name="childCount"></param>
        /// <returns>If value return is negative Parent B owes. If positive Parent A owes.</returns>
        [HttpGet]
        public IHttpActionResult ThirdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
        {
            decimal allocation = HealthCarePremiumCalcs.ThirdParty(parentAHealthCare, incomePercentA, parentBHealthCare, incomePercentB, childCount);

            return Ok(allocation);
        }

        /// <summary>
        ///     MCSF 3.05(C) Health Care Premium Allocation: Allocate the children’s net health care premiums between the parents. 
        /// </summary>
        /// <param name="payerHealthCareAmount"></param>
        /// <param name="payerIncomePercent"></param>
        /// <param name="payeeHealthCareAmount"></param>
        /// <param name="payeeIncomePercent"></param>
        /// <param name="childCount"></param>
        /// <returns>
        ///     A positive net result means an additional amount must be paid to cover the payer’s share of the support 
        ///     recipient’s premium, while a negative result means a reduction in base support to offset the support 
        ///     recipient’s share of the payer’s premium.
        /// </returns>
        [HttpGet]
        public IHttpActionResult Allocation(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        {
            decimal allocation = HealthCarePremiumCalcs.Allocation(payerHealthCareAmount, payerIncomePercent, payeeHealthCareAmount, payeeIncomePercent, childCount);

            return Ok(allocation);
        }
    }
}
