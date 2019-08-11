using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinjaTests
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void GetOutput_NumberIsDivisiblePerThreeAndFive_ReturnsFizzBuzz()
        {
            int number = 45;
            var result = FizzBuzz.GetOutput(number);
            string expectedResult = "FizzBuzz";
            Assert.IsTrue(result.Equals(expectedResult, StringComparison.CurrentCultureIgnoreCase));
        }

        [TestMethod]
        public void GetOutput_NumberIsDivisiblePerThree_ReturnsFizz()
        {
            int number = 21;
            var result = FizzBuzz.GetOutput(number);
            string expectedResult = "Fizz";

            Assert.IsTrue(result.Equals(expectedResult, StringComparison.CurrentCultureIgnoreCase));
        }

        [TestMethod]
        public void GetOutput_NumberIsDivisiblePerFive_ReturnsBuzz()
        {
            int number = 25;
            var result = FizzBuzz.GetOutput(number);
            string expectedResult = "Buzz";

            Assert.IsTrue(result.Equals(expectedResult, StringComparison.CurrentCultureIgnoreCase));
        }

        [TestMethod]
        public void GetOutput_NumberIsNotDivisiblePerThreeAndFive_ReturnsSameNumber()
        {
            int number = 1;
            var result = FizzBuzz.GetOutput(number);
            string expectedResult = number.ToString();

            Assert.IsTrue(result.Equals(expectedResult, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
