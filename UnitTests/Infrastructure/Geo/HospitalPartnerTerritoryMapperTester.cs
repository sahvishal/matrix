using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Mappers.Territories;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Geo
{
    [TestFixture]
    public class HospitalPartnerTerritoryMapperTester
    {
        private readonly IMapper<HospitalPartnerTerritory, TerritoryEntity>
            _mapper = new HospitalPartnerTerritoryMapper(new ZipCodeMapper());
            
        [Test]
        public void MapSetsHospitalPartnerOwnerIdsToEmptyListWhenNoOwnersAreInGivenEntity()
        {
            var territoryEntity = new TerritoryEntity 
                { Type = (byte)TerritoryType.HospitalPartner };

            Territory territory = _mapper.Map(territoryEntity);

            Assert.IsNotNull(((HospitalPartnerTerritory)territory).HospitalPartnerOwnerIds,
                "Null list of Hospital Partner Owner IDs returned.");
            Assert.IsEmpty(((HospitalPartnerTerritory)territory).HospitalPartnerOwnerIds,
                "Non-empty list of Hospital Partner Owner IDs returned.");
        }

        [Test]
        public void MapMapsEntityHospitalPartnerOwnerIdsToHospitalPartnerTerritoryOwnerIds()
        {
            const long territoryId = 23;
            var expectedHospitalPartnerOwnerIds = new List<long> { 29, 645, 97 };
            var territoryEntity = new TerritoryEntity(territoryId) 
                { Type = (byte)TerritoryType.HospitalPartner };
            var hospitalPartnerTerritoryEntities = new List<HospitalPartnerTerritoryEntity>
            {
                new HospitalPartnerTerritoryEntity(expectedHospitalPartnerOwnerIds[0], territoryId),
                new HospitalPartnerTerritoryEntity(expectedHospitalPartnerOwnerIds[1], territoryId),
                new HospitalPartnerTerritoryEntity(expectedHospitalPartnerOwnerIds[2], territoryId)
            };
            territoryEntity.HospitalPartnerTerritory.AddRange(hospitalPartnerTerritoryEntities);

            Territory territory = _mapper.Map(territoryEntity);

            Assert.AreEqual(expectedHospitalPartnerOwnerIds, 
                ((HospitalPartnerTerritory)territory).HospitalPartnerOwnerIds,
                "Hospital Partner Owner Ids were not mapped correctly.");
        }
    }
}