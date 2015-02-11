using MCSF;
using MCSF.ApiControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace MCSF.Tests.ApiControllers
{
    [TestClass]
    public class OrdinaryMedExpTest
    {
        // (1, 357, 29.75)
        [TestMethod]
        public async Task OrdinaryMedExp_MonthlyWith1Child()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Monthly(1) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(29.75m, result.Content);
        }

        [TestMethod]
        public async Task OrdinaryMedExp_AnnualWith1Child()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Annual(1) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(357m, result.Content);
        }

        // (2, 715, 59.58)
        [TestMethod]
        public async Task OrdinaryMedExp_MonthlyWith2Children()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Monthly(2) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(59.58m, result.Content);
        }

        [TestMethod]
        public async Task OrdinaryMedExp_AnnualWith2Children()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Annual(2) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(715m, result.Content);
        }

        // (3, 1072, 89.33)
        [TestMethod]
        public async Task OrdinaryMedExp_MonthlyWith3Children()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Monthly(3) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(89.33m, result.Content);
        }

        [TestMethod]
        public async Task OrdinaryMedExp_AnnualWith3Children()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Annual(3) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(1072m, result.Content);
        }

        // (4, 1430, 119.17)
        [TestMethod]
        public async Task OrdinaryMedExp_MonthlyWith4Children()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Monthly(4) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(119.17m, result.Content);
        }

        [TestMethod]
        public async Task OrdinaryMedExp_AnnualWith4Children()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Annual(4) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(1430m, result.Content);
        }

        // (5, 1787, 148.92)
        [TestMethod]
        public async Task OrdinaryMedExp_MonthlyWith5Children()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Monthly(5) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(148.92m, result.Content);
        }

        [TestMethod]
        public async Task OrdinaryMedExp_AnnualWith5Children()
        {
            // Arrange
            OrdinaryMedExpController sut = new OrdinaryMedExpController();

            // Act
            var result = await sut.Annual(5) as OkNegotiatedContentResult<decimal>;

            // Assert
            Assert.AreEqual(1787m, result.Content);
        }
    }
}
