using Falcon.App.Core.Application;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Territories
{
    public class SalesRepTerritoryMapper : TerritoryMapper<SalesRepTerritory>
    {
        public SalesRepTerritoryMapper(IMapper<ZipCode, ZipEntity> zipCodeMapper) 
            : base(zipCodeMapper)
        { }

        protected override void MapUniqueTerritoryFields(TerritoryEntity territoryEntity,
            SalesRepTerritory territoryToMapTo)
        { }
    }
}