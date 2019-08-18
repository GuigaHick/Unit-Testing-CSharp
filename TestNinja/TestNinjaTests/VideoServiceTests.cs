using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestNinja.Mocking;

namespace TestNinjaTests
{
    [TestClass]
    public class VideoServiceTests
    {
        IFileReader fileReader;
        
        [TestInitialize]
        public void Initialize()
        {
            Mock<IFileReader> mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(fr => fr.Read("video.txt")).Returns(string.Empty);
            fileReader = mockFileReader.Object;
        }

        [TestMethod]
        public void ReadVideoTitle_EmptyFile_ReturnsErrorMessage()
        {
            VideoService videoService = new VideoService(fileReader);
            var result = videoService.ReadVideoTitle();
            Assert.IsTrue(result.Contains("Error"));
        }
    }
}
