using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinjaTests
{
    [TestClass]
    public class CustomerControllerTests
    {
        [TestMethod]
        public void GetCustomer_IdIsZero_ReturnsNotFound()
        {
            var customerController = new CustomerController();
            var result = customerController.GetCustomer(0);

            Assert.IsInstanceOfType(result, typeof(NotFound));
        }

        [TestMethod]
        public void GetCustomer_IdIsNotZero_ReturnsOK()
        {
            var customerController = new CustomerController();
            var result = customerController.GetCustomer(1);

            Assert.IsInstanceOfType(result, typeof(Ok));
        }
    }
}
