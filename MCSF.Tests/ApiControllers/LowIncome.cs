// using System;
// using System.Collections.Generic;
// using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCSF.ApiControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;

namespace MCSF.Tests.ApiControllers
{
    [TestClass]
    public class LowIncome
    {
        [TestMethod]
        public async Task TransitionMultiplier()
        {
            // Arrange
            LowIncomeController sut = new LowIncomeController();

            // Act
            var result = await sut.TransitionMultiplier(3) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(.60m, result.Content);
        }
    }
}
