using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class MapperTester
    {
        private readonly IMapper<FakeDomainObject, FakeEntity> _mapper = new FakeMapper();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapMultipleThrowsExceptionWhenGivenNullCollection()
        {
            _mapper.MapMultiple((IEnumerable<FakeEntity>)null);
        }

        [Test]
        public void MapMultipleReturnsEmptyCollectionWhenGivenEmptyCollection()
        {
            IEnumerable<FakeEntity> entities = new List<FakeEntity>();

            IEnumerable<FakeDomainObject> domainObjects = _mapper.MapMultiple(entities);

            Assert.IsEmpty(domainObjects.ToList());
        }

        [Test]
        public void MapMultipleReturnsCollectionWithOneObjectWhenOneEntityGiven()
        {
            IEnumerable<FakeEntity> entities = new List<FakeEntity> {new FakeEntity()};
            int expectedNumberOfDomainObjects = entities.Count();

            IEnumerable<FakeDomainObject> domainObjects = _mapper.MapMultiple(entities);

            Assert.AreEqual(expectedNumberOfDomainObjects, domainObjects.Count(),
                "Incorrect number of domain objects returned.");
        }

        [Test]
        public void MapMultipleReturns3DomainObjectsWhenThreeEntitiesGiven()
        {
            IEnumerable<FakeEntity> entities = new List<FakeEntity>
                                                   {new FakeEntity(), new FakeEntity(), new FakeEntity()};
            int expectedNumberOfDomainObjects = entities.Count();
            
            IEnumerable<FakeDomainObject> domainObjects = _mapper.MapMultiple(entities);

            Assert.AreEqual(expectedNumberOfDomainObjects, domainObjects.Count(),
                "Incorrect number of domain objects returned.");
        }

        [Test]
        public void MapMultipleReturnsSameObjectAsMapDoes()
        {
            var entityToMap = new FakeEntity {Id = 5};
            long expectedId = _mapper.Map(entityToMap).Id;
            IEnumerable<FakeEntity> entities = new List<FakeEntity> { entityToMap };

            IEnumerable<FakeDomainObject> domainObjects = _mapper.MapMultiple(entities);

            Assert.AreEqual(expectedId, domainObjects.Single().Id, 
                "The domain object returned did not have its fields mapped correctly.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapMultipleThrowsExceptionWhenGivenNullCollectionOfDomainObjects()
        {
            _mapper.MapMultiple((IEnumerable<FakeDomainObject>)null);
        }

        [Test]
        public void MapMultipleReturnsEmptyCollectionWhenGivenEmptyCollectionOfDomainObjects()
        {
            IEnumerable<FakeDomainObject> domainObjects = new List<FakeDomainObject>();

            IEnumerable<FakeEntity> entities = _mapper.MapMultiple(domainObjects);

            Assert.IsEmpty(entities.ToList());
        }

        [Test]
        public void MapMultipleReturnsCollectionWithOneObjectWhenOneDomainObjectGiven()
        {
            IEnumerable<FakeDomainObject> domainObjects = new List<FakeDomainObject> 
                                                              { new FakeDomainObject() };
            int expectedNumberOfEntities = domainObjects.Count();

            var entities = _mapper.MapMultiple(domainObjects);

            Assert.AreEqual(expectedNumberOfEntities, entities.Count(),
                "Incorrect number of entities returned.");
        }

        [Test]
        public void MapMultipleReturns3DomainObjectsWhenThreeDomainObjectsGiven()
        {
            IEnumerable<FakeDomainObject> domainObjects = new List<FakeDomainObject> 
                { new FakeDomainObject(), new FakeDomainObject(), new FakeDomainObject() };
            int expectedNumberOfEntities = domainObjects.Count();

            IEnumerable<FakeEntity> entities = _mapper.MapMultiple(domainObjects);

            Assert.AreEqual(expectedNumberOfEntities, entities.Count(),
                "Incorrect number of entities returned.");
        }

        [Test]
        public void MapMultipleReturnsSameEntityObjectAsMapDoes()
        {
            var domainObjectToMap = new FakeDomainObject { Id = 5 };
            long expectedId = _mapper.Map(domainObjectToMap).Id;
            IEnumerable<FakeDomainObject> domainObjects = new List<FakeDomainObject> { domainObjectToMap };

            IEnumerable<FakeEntity> entities = _mapper.MapMultiple(domainObjects);

            Assert.AreEqual(expectedId, entities.Single().Id,
                "The entity returned did not have its fields mapped correctly.");
        }
    }
}