using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http; // IHttpActionResult
using MCSF.ApiModels;
using MCSF.DAL;
using System.Threading.Tasks;

namespace MCSF.ApiControllers
{
    public class ParentalTimeOffSetController : ApiController
    {
        /// <summary>
        /// MCSF 3.03 Adjusting Base Obligation with the Parental Time Offset: Presuming that as parents spend more 
        /// time with their children they will directly contribute a greater share of the children’s expenses, a base 
        /// support obligation needs to offset some of the costs and savings associated with time spent with each parent
        /// </summary>
        /// <param name="parentANights"></param>
        /// <param name="parentASupport"></param>
        /// <param name="parentBSupport"></param>
        /// <returns>(int) A negative result means that parent A pays and a positive result means parent B pays.</returns>
        [HttpGet]
        public IHttpActionResult Support(double parentANights, int parentASupport, int parentBSupport)
        {
            return Ok(ParentalTimeOffSetSupport(parentANights, parentASupport, parentBSupport));
        }

        /// <summary>
        /// A negative result means that parent A pays and a positive result means parent B pays.
        /// </summary>
        private int ParentalTimeOffSetSupport(double OvernightsA, int SupportObligationA, int SupportObligationB)
        {
            // 3.03 Adjusting Base Obligation with the Parental Time Offset
            //
            //                          (Ao)^3 · (Bs) - (Bo)^3 · (As)
            //                          -----------------------------
            //                                 (Ao)^3 + (Bo)^3
            //
            //          Ao = Approximate annual number of overnights the children will likely spend with parent A 
            //          Bo = Approximate annual number of overnights the children will likely spend with parent B 
            //          As = Parent A's base support obligation 
            //          Bs = Parent B's base support obligation 
            //          Note: A negative result means that parent A pays and a positive result means parent B pays.

            double OA3 = Math.Pow(OvernightsA, 3);
            double OB3 = Math.Pow((365-OvernightsA), 3);
            double SOB = Convert.ToDouble(SupportObligationB);
            double SOA = Convert.ToDouble(SupportObligationA);

            int baseWOffset = Convert.ToInt32(((OA3 * SOB) - (OB3 * SOA)) / (OA3 + OB3));

            return baseWOffset;
        }
    }
}