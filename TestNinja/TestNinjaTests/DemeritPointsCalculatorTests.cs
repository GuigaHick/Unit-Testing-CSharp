using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinjaTests
{
    [TestClass]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator demeritPointsCalculator;

        [TestInitialize]
        public void Initialize()
        {
            demeritPointsCalculator = new DemeritPointsCalculator();
        }
 
        [TestMethod]
        public void CalculateDemeritPoints_InvalidArgument_ThrowsArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => demeritPointsCalculator.CalculateDemeritPoints(-1));
        }

        [TestMethod]
        [DataRow(50)]
        [DataRow(64)]
        [DataRow(65)]
        public void CalculateDemeritPoints_AllowedSpeed_Returns0(int speed)
        {
            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        [DataRow(81, 3)]
        [DataRow(86, 4)]
        [DataRow(101,7)]
        public void CalculateDemeritPoints_ExceedsSpeed_ReturnsDemeritPoints(int speed, int expected)
        {
            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.IsTrue(result == expected);
        }
    }
}
