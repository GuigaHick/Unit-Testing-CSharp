using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestNinja.Mocking;

namespace TestNinjaTests
{
    [TestClass]
    public class EmployeeControllerTests
    {
        [TestMethod]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDB()
        {
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            controller.DeleteEmployee(1);

            storage.Verify(s => s.DeleteEmployee(1));
        }
    }
}
