using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinjaTests
{
    [TestClass]
    public class HtmlFormatterTests
    {
        [TestMethod]
        public void FormatAsBold_WhenCalled_ShouldEncolseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("abc");
            var expectedResult = "<strong>abc</strong>";

            Assert.IsTrue(result.Equals(expectedResult));
        }
    }
}
