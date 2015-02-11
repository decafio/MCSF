using MCSF;
using MCSF.ApiControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace MCSF.Tests.ApiControllers
{
    [TestClass]
    public class ObligationTest
    {
        [TestMethod]
        public async Task Obligation()
        {
            // Arrange
            ObligationController sut = new ObligationController();
            
            // Act
            var result = await sut.BaseSupport(4372m, .30m, 3) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(507, result.Content);
        }

        [TestMethod]
        public async Task Obligation_Over5Children()
        {
            // Arrange
            ObligationController sut = new ObligationController(); ;

            // Act
            var result = await sut.BaseSupport(4372m, .30m, 5) as OkNegotiatedContentResult<int>;
            var result2 = await sut.BaseSupport(4372m, .30m, 7) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(result.Content, result2.Content);
        }
    }
}
