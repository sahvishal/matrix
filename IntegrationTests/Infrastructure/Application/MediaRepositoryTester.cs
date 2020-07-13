using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.Web.IntegrationTests.Fakes;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    [TestFixture]
    public class MediaRepositoryTester
    {
        private IMediaRepository _mediaRepository;
        private ISettings _settings;

        [SetUp]
        public void SetUp()
        {
            IoC.Register<ISettings, FakeSettings>();
            IoC.Register<IMediaRepository, MediaRepository>();
            _settings = IoC.Resolve<ISettings>();
            _mediaRepository = IoC.Resolve<IMediaRepository>();
            

        }
        [Test]
        public void GetTempJpgMediaLocation_ReturnsValidLocations()
        {
            var jpgLocation=  _mediaRepository.GetTempJpgFileLocation();

            Assert.IsNotNull(jpgLocation.PhysicalPath);

        }
         
    }
}