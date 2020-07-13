using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;
using System.Collections.Generic;

namespace Falcon.App.Infrastructure.Mappers.Territories
{
    public class PodTerritoryMapper:TerritoryMapper<PodTerritory>
    {
        public PodTerritoryMapper(IMapper<ZipCode, ZipEntity> zipCodeMapper) 
            : base(zipCodeMapper)
        { }

        protected override void MapUniqueTerritoryFields(TerritoryEntity territoryEntity,
            PodTerritory territoryToMapTo)
        {
            List<long> packageIds = territoryEntity.TerritoryPackage.Select(tp => tp.PackageId).ToList();
            territoryToMapTo.PackageIds = packageIds;
        }
    }
}
