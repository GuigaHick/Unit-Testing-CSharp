using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinjaTests
{
    [TestClass]
    public class ErrorLogTests
    {
        ErrorLogger logger;

        [TestInitialize]
        public void Initialize()
        {
            logger = new ErrorLogger();
        }
        //Testing Void Methods
        [TestMethod]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            string error = "error87";
            logger.Log(error);

            Assert.IsTrue(logger.LastError.Equals(error));
        }

        //Testing Exceptions
        [TestMethod]
        public void Log_InvalidError_ThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { logger.Log(null); });
        }

        //Testing Raise Events
        [TestMethod]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");

            Assert.IsFalse(id == Guid.Empty);
        }
    }
}
