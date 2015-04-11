using MCSF;
using MCSF.ApiControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace MCSF.Tests.ApiControllers
{
    [TestClass]
    public class BaseSupportTest
    {
        [TestMethod]
        public async Task Obligation_StandardSupport_3Children()
        {
            // Arrange
            BaseSupportController sut = new BaseSupportController();
            
            // Act
            var result = await sut.GeneralCareEquation(4372m, .30m, 3) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(507, result.Content);
        }

        [TestMethod]
        public async Task Obligation_StandardSupport_Over5Children()
        {
            // Arrange
            BaseSupportController sut = new BaseSupportController(); ;

            // Act
            var result = await sut.GeneralCareEquation(4372m, .30m, 5) as OkNegotiatedContentResult<int>;
            var result2 = await sut.GeneralCareEquation(4372m, .30m, 7) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(result.Content, result2.Content);
        }

        [TestMethod]
        public async Task LowIncomeTransitionEquation_3Children()
        {
            // Arrange
            BaseSupportController sut = new BaseSupportController();

            // Act
            var result = await sut.LowIncomeTransitionEquation(1000m, 3) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(134, result.Content);
        }
    }
}
