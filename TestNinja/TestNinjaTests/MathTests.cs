using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math = TestNinja.Fundamentals.Math;
using System.Linq;

namespace TestNinjaTests
{
    [TestClass]
    public class MathTests
    {
        private Math math;

        [TestInitialize]
        public void Initialize()
        {
            math = new Math();
        }

        [TestMethod]
        public void Add_WhenCalled_ReturnsTheSumOfArguments()
        {
            var result = math.Add(1, 2);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void Max_WhenCalled_ReturnTheGreatherArgument()
        {
            var result = math.Max(1, 0);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void Max_WhenCalledWithSameArguments_ReturnTheGreatherArgument()
        {
            var result = math.Max(1, 1);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = math.GetOddNumbers(5);
            int[] expectedResult = new int[] { 1, 3, 5 };

            Assert.IsTrue(result.SequenceEqual(expectedResult));
        }
    }
}
