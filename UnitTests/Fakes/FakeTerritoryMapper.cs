using Falcon.App.Core.Application;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Mappers.Territories;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeTerritoryMapper : TerritoryMapper<FakeTerritory>
    {
        public FakeTerritoryMapper(IMapper<ZipCode, ZipEntity> zipCodeMapper) 
            : base(zipCodeMapper)
        { }

        protected override void MapUniqueTerritoryFields(TerritoryEntity territoryEntity,
            FakeTerritory territoryToMapTo)
        { }
    }
}