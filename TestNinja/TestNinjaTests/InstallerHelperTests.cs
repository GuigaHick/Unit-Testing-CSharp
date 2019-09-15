using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using TestNinja.Mocking;

namespace TestNinjaTests
{
    [TestClass]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> mockFileDowloader;
        private InstallerHelper installer;

        [TestInitialize]
        public void Initialize()
        {
            mockFileDowloader = new Mock<IFileDownloader>();
            installer = new InstallerHelper(mockFileDowloader.Object);
        }

        [TestMethod]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            mockFileDowloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            Assert.IsFalse(installer.DownloadInstaller("customer", "installer"));
        }

        [TestMethod]
        public void DownloadInstaller_DownloadCompletes_ReturnsFalse()
        {
            mockFileDowloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));
            Assert.IsTrue(installer.DownloadInstaller("customer", "installer"));
        }
    }
}
