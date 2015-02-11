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
            OffSetController sut = new OffSetController();

            // Act
            var result = sut.Get(0, 500, 500) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(-500, result.Content);
        }

        [TestMethod]
        public void OffSet_Case2()
        {
            // Arrange
            OffSetController sut = new OffSetController();

            // Act
            var result = sut.Get(50, 400, 500) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(-396, result.Content);
        }

        [TestMethod]
        public void OffSet_Case3()
        {
            // Arrange
            OffSetController sut = new OffSetController();

            // Act
            var result = sut.Get(100, 1000, 400) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(-929, result.Content);
        }

        [TestMethod]
        public void OffSet_Case4()
        {
            // Arrange
            OffSetController sut = new OffSetController();

            // Act
            var result = sut.Get(200, 400, 400) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(112, result.Content);
        }

        [TestMethod]
        public void OffSet_Case5()
        {
            // Arrange
            OffSetController sut = new OffSetController();

            // Act
            var result = sut.Get(300, 1000, 200) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(188, result.Content);
        }

        [TestMethod]
        public void OffSet_Case6()
        {
            // Arrange
            OffSetController sut = new OffSetController();

            // Act
            var result = sut.Get(365, 0, 100) as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(100, result.Content);
        }
    }
}
