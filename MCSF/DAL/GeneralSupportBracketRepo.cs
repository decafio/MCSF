using System;
using System.Collections.Generic;
using System.Linq;
// using System.Web;
using MCSF.DAL;
using System.Threading.Tasks;
using MCSF.ApiModels;
using System.Data.Entity; // Async extensions, Include

namespace MCSF.DAL
{
    public class GeneralSupportBracketRepo
    {
        public async Task<GeneralCareSupport> GetGeneralSupportBracket(decimal combinedNetIncome, int childCount)
        {
            CalculationContext calcContext = new CalculationContext();

            return await calcContext.GeneralCareSupports
                .Where(a => a.IncomeBracket.IncomeMax > combinedNetIncome)
                .Where(a => a.IncomeBracket.IncomeMin < combinedNetIncome)
                .Where(c => c.ChildCount == childCount)
                .FirstAsync();
        }
    }
}