using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestNinja.Mocking;

namespace TestNinjaTests
{
    [TestClass]
    public class VideoServiceTests
    {
        IFileReader fileReader;
        IVideoRepository videoRepository;
        Mock<IFileReader> mockFileReader = new Mock<IFileReader>();
        Mock<IVideoRepository> mockVideoRepository = new Mock<IVideoRepository>();

        [TestInitialize]
        public void Initialize()
        {
            fileReader = mockFileReader.Object;
            videoRepository = mockVideoRepository.Object;
        }

        [TestMethod]
        public void ReadVideoTitle_EmptyFile_ReturnsErrorMessage()
        {
            mockFileReader.Setup(fr => fr.Read("video.txt")).Returns(string.Empty);
            VideoService videoService = new VideoService(fileReader, videoRepository);
            var result = videoService.ReadVideoTitle();
            Assert.IsTrue(result.Contains("Error"));
        }

        [TestMethod]
        public void GetUnprocessedVideosAsCSV_AllVideosAreaProcessed_ReturnsEmptyString()
        {
            mockVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());
            VideoService videoService = new VideoService(fileReader, videoRepository);
            var result = videoService.GetUnprocessedVideosAsCsv();
            Assert.IsTrue(result.Equals(string.Empty));
        }

        [TestMethod]
        public void GetUnprocessedVideosAsCSV_AFewUnprocessedVideos_ReturnsAStringsWithIdsOfUnprocessedVideos()
        {
            mockVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>()
            {
                new Video() { Id = 1 },
                new Video() { Id = 2 },
                new Video() { Id = 3 },
            });

            VideoService videoService = new VideoService(fileReader, videoRepository);
            var result = videoService.GetUnprocessedVideosAsCsv();
            Assert.IsTrue(result.Equals("1,2,3"));
        }
    }
}
