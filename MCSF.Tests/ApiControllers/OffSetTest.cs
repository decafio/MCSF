using MCSF;
using MCSF.ApiControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace MCSF.Tests.ApiControllers
{
    [TestClass]
    public class OffSetTest
    {
        [TestMethod]
        public void OffSet_Case1()
        {
            // Arrange
            ParentalTimeOffSetController sut = new ParentalTimeOffSetController();

            // Act
            var result = sut.Support(0, 500, 500) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(-500, result.Content);
        }

        [TestMethod]
        public void OffSet_Case2()
        {
            // Arrange
            ParentalTimeOffSetController sut = new ParentalTimeOffSetController();

            // Act
            var result = sut.Support(50, 400, 500) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(-396, result.Content);
        }

        [TestMethod]
        public void OffSet_Case3()
        {
            // Arrange
            ParentalTimeOffSetController sut = new ParentalTimeOffSetController();

            // Act
            var result = sut.Support(100, 1000, 400) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(-929, result.Content);
        }

        [TestMethod]
        public void OffSet_Case4()
        {
            // Arrange
            ParentalTimeOffSetController sut = new ParentalTimeOffSetController();

            // Act
            var result = sut.Support(200, 400, 400) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(112, result.Content);
        }

        [TestMethod]
        public void OffSet_Case5()
        {
            // Arrange
            ParentalTimeOffSetController sut = new ParentalTimeOffSetController();

            // Act
            var result = sut.Support(300, 1000, 200) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(188, result.Content);
        }

        [TestMethod]
        public void OffSet_Case6()
        {
            // Arrange
            ParentalTimeOffSetController sut = new ParentalTimeOffSetController();

            // Act
            var result = sut.Support(365, 0, 100) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(100, result.Content);
        }
    }
}
