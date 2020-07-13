using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Mappers.Territories;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Geo
{
    [TestFixture]
    public class FranchiseeTerritoryMapperTester
    {
        private readonly IMapper<FranchiseeTerritory, TerritoryEntity> _mapper =
            new FranchiseeTerritoryMapper(new ZipCodeMapper());
            
        [Test]
        public void MapMapsEntityFranchiseeOwnerIdToFranchiseeTerritoryOwnerId()
        {
            const long expectedFranchiseeOwnerId = 2348;
            const long territoryId = 3;
            var territoryEntity = new TerritoryEntity(territoryId)
            {
                Type = (byte)TerritoryType.Franchisee,
                FranchiseeTerritory = 
                    new FranchiseeTerritoryEntity(expectedFranchiseeOwnerId, territoryId)
            };

            Territory territory = _mapper.Map(territoryEntity);

            Assert.AreEqual(expectedFranchiseeOwnerId, 
                ((FranchiseeTerritory)territory).FranchiseeOwnerId,
                "Franchisee Owner Id incorrectly mapped.");
        }

        [Test]
        public void MapSetsFranchiseeOwnerIdTo0WhenTerritoryEntityHasNoFranchiseeTerritory()
        {
            const long expectedFranchiseeOwnerId = 0;
            var territoryEntity = new TerritoryEntity { FranchiseeTerritory = null };

            Territory territory = _mapper.Map(territoryEntity);

            Assert.AreEqual(expectedFranchiseeOwnerId, 
                ((FranchiseeTerritory)territory).FranchiseeOwnerId,
                "Incorrect Franchisee Owner Id returned.");
        }

    }
}