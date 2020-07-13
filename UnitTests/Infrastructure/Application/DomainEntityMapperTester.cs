using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Application
{
    [TestFixture]
    public class DomainEntityMapperTester
    {
        private readonly IMapper<FakeDomainObject, FakeEntity> _mapper = new FakeDomainEntityMapper();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenNullDomainObject()
        {
            _mapper.Map((FakeDomainObject)null);
        }

        [Test]
        public void MapSetsIsNewToTrueWhenGivenDomainObjectIdIs0()
        {
            const int id = 0;
            var domainObject = new FakeDomainObject(id);

            FakeEntity entity = _mapper.Map(domainObject);

            Assert.IsTrue(entity.IsNew, "IsNew set to false when given ID was 0.");
        }

        [Test]
        public void MapSetsIsNewToFalseWhenGivenDomainObjectIdIsNot0()
        {
            const int id = 3;
            var domainObject = new FakeDomainObject(id);

            FakeEntity entity = _mapper.Map(domainObject);

            Assert.IsFalse(entity.IsNew, "IsNew set to true when given ID was not 0.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenNullEntity()
        {
            _mapper.Map((FakeEntity)null);
        }
    }
}