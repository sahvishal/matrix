using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Operations
{
    [TestFixture]
    public class PodMapperTester
    {
        private readonly IMapper<Pod, PodDetailsEntity> _podFactory = new PodMapper();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenNullEntity()
        {
            _podFactory.Map((PodDetailsEntity)null);
        }

        [Test]
        public void MapMapsEntityIdToPodId()
        {
            const long expectedPodId = 23845;
            var podDetailsEntity = new PodDetailsEntity(expectedPodId);

            Pod pod = _podFactory.Map(podDetailsEntity);

            Assert.AreEqual(expectedPodId, pod.Id, "Pod ID mapped incorrectly.");
        }

        [Test]
        public void MapMapsEntityNameToPodName()
        {
            const string expectedName = "Bob Ross Pod";
            var podDetailsEntity = new PodDetailsEntity { Name = expectedName};

            Pod pod = _podFactory.Map(podDetailsEntity);

            Assert.AreEqual(expectedName, pod.Name, "Pod Name mapped incorrectly.");
        }
    }
}