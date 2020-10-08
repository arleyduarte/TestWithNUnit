using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public  class VideoServiceTests
    {

        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
          
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.Read("video.tx")).Returns("");


            var service = new VideoService(fileReader.Object);

            var result = service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
