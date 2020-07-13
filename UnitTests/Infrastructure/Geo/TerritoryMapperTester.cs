using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Geo
{
    [TestFixture]
    public class TerritoryMapperTester
    {
        private readonly IMapper<FakeTerritory, TerritoryEntity> _territoryFactory = 
            new FakeTerritoryMapper(new ZipCodeMapper());

        private static void SetZipCollectionForTerritoryEntity(TerritoryEntity territoryEntity,
            IEnumerable<ZipEntity> zipEntities)
        {
            territoryEntity.ZipCollectionViaTerritoryZip.IsReadOnly = false;
            territoryEntity.ZipCollectionViaTerritoryZip.Clear();
            territoryEntity.ZipCollectionViaTerritoryZip.AddRange(zipEntities);
        }
        
        [Test]
        public void MapSetsGivenTerritoryIdToEntityTerritoryId()
        {
            const long expectedTerritoryId = 3;
            var fakeTerritory = new FakeTerritory(expectedTerritoryId);

            TerritoryEntity territoryEntity = _territoryFactory.Map(fakeTerritory);

            Assert.AreEqual(expectedTerritoryId, territoryEntity.TerritoryId, 
                "Territory ID was not mapped to entity correctly.");
        }

        [Test]
        public void MapMapsNameToEntityTerritoryName()
        {
            const string expectedName = "Bob's Territory";
            var fakeTerritory = new FakeTerritory { Name = expectedName };

            TerritoryEntity territoryEntity = _territoryFactory.Map(fakeTerritory);

            Assert.AreEqual(expectedName, territoryEntity.Name, 
                "Territory Name was not mapped to entity correctly.");
        }

        [Test]
        public void MapMapsDescriptionToEntityTerritoryDescription()
        {
            const string expectedDescription = "Bob's Territory";
            var fakeTerritory = new FakeTerritory { Description = expectedDescription };

            TerritoryEntity territoryEntity = _territoryFactory.Map(fakeTerritory);

            Assert.AreEqual(expectedDescription, territoryEntity.Description, 
                "Territory Description was not mapped to entity correctly.");
        }

        [Test]
        public void MapMapsTerritoryTypeToEntityTerritoryType()
        {
            const TerritoryType expectedTerritoryType = TerritoryType.Pod;
            var fakeTerritory = new FakeTerritory { FakeTerritoryType = expectedTerritoryType };

            TerritoryEntity territoryEntity = _territoryFactory.Map(fakeTerritory);

            Assert.AreEqual((byte)expectedTerritoryType, territoryEntity.Type, 
                "Territory Type was not mapped to entity correctly.");
        }

        [Test]
        public void MapMapsParentTerritoryIdToEntityParentTerritoryId()
        {
            const long expectedParentTerritoryId = 3;
            var fakeTerritory = new FakeTerritory { ParentTerritoryId = expectedParentTerritoryId };

            TerritoryEntity territoryEntity = _territoryFactory.Map(fakeTerritory);

            Assert.AreEqual(expectedParentTerritoryId, territoryEntity.ParentTerritoryId, 
                "Parent Territory ID not mapped to entity correctly.");
        }

        [Test]
        public void MapSetsParentTerritoryIdToNullIfParentTerritoryIsNull()
        {
            var fakeTerritory = new FakeTerritory { ParentTerritoryId = null };

            TerritoryEntity territoryEntity = _territoryFactory.Map(fakeTerritory);

            Assert.IsNull(territoryEntity.ParentTerritoryId, 
                "Parent Territory ID of entity set to non-null value.");
        }

        [Test]
        public void MapMapsEntityIdToTerritoryId()
        {
            const long expectedTerritoryId = 3;
            var territoryEntity = new TerritoryEntity(expectedTerritoryId);

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.AreEqual(expectedTerritoryId, territory.Id, "Territory ID was not mapped correctly.");
        }

        [Test]
        public void MapMapsEntityNameToTerritoryName()
        {
            const string expectedName = "Bob's Territory";
            var territoryEntity = new TerritoryEntity { Name = expectedName };

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.AreEqual(expectedName, territory.Name, "Territory Name was not mapped correctly.");
        }

        [Test]
        public void MapMapsEntityDescriptionToTerritoryDescription()
        {
            const string expectedDescription = "Bob's Description";
            var territoryEntity = new TerritoryEntity { Description = expectedDescription };

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.AreEqual(expectedDescription, territory.Description, 
                "Territory Description was not mapped correctly.");
        }

        [Test]
        public void MapSetsParentTerritoryIdToTerritoryWithEntityParentTerritoryId()
        {
            const long expectedParentTerritoryId = 3;
            var territoryEntity = new TerritoryEntity 
                { ParentTerritoryId = expectedParentTerritoryId };

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.AreEqual(expectedParentTerritoryId, territory.ParentTerritoryId, 
                "Parent Territory ID was not mapped correctly.");
        }

        [Test]
        public void MapSetsParentTerritoryToNullWhenEntityParentTerritoryIdIsNull()
        {
            var territoryEntity = new TerritoryEntity();

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.IsNull(territory.ParentTerritoryId, "Parent Territory set to non-null value.");
        }

        [Test]
        public void MapCreatesEmptyZipCodeListWhenEntityZipCollectionIsEmpty()
        {
            var territoryEntity = new TerritoryEntity();

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.IsNotNull(territory.ZipCodes, "Null zip code collection returned.");
            Assert.IsEmpty(territory.ZipCodes, "Non-empty zip code collection returned.");
        }

        [Test]
        public void MapReturns1ZipCodeWhen1ZipCodeExistsInEntityZipCollection()
        {
            const int expectedNumberOfZipCodes = 1;
            IEnumerable<ZipEntity> zipEntities = new List<ZipEntity> { new ZipEntity() };
            var territoryEntity = new TerritoryEntity();
            SetZipCollectionForTerritoryEntity(territoryEntity, zipEntities);

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.AreEqual(expectedNumberOfZipCodes, territory.ZipCodes.Count, 
                "Incorrect number of zip codes returned.");
        }

        [Test]
        public void MapReturns3ZipCodesWhen3ZipCodesExistInEntityZipCollection()
        {
            const int expectedNumberOfZipCodes = 3;
            IEnumerable<ZipEntity> zipEntities = new List<ZipEntity> 
                { new ZipEntity(), new ZipEntity(), new ZipEntity() };
            var territoryEntity = new TerritoryEntity();
            SetZipCollectionForTerritoryEntity(territoryEntity, zipEntities);

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.AreEqual(expectedNumberOfZipCodes, territory.ZipCodes.Count, 
                "Incorrect number of zip codes returned.");
        }

        [Test]
        public void MapSetsParentTerritoryIdToEntityParentTerritoryId()
        {
            const long expectedParentTerritoryId = 234;
            var territoryEntity = new TerritoryEntity 
                { ParentTerritoryId = expectedParentTerritoryId };

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.AreEqual(expectedParentTerritoryId, territory.ParentTerritoryId, 
                "Incorrect Parent Territory ID mapped.");
        }

        [Test]
        public void MapSetsParentTerritoryIdToNullWhenNullEntityParentTerritoryIdGiven()
        {
            var territoryEntity = new TerritoryEntity { ParentTerritoryId = null };

            Territory territory = _territoryFactory.Map(territoryEntity);

            Assert.IsNull(territory.ParentTerritoryId, "Non-null Parent Territory ID mapped.");
        }
    }
}