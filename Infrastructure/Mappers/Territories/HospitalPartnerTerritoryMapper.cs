using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Territories
{
    public class HospitalPartnerTerritoryMapper : TerritoryMapper<HospitalPartnerTerritory>
    {
        public HospitalPartnerTerritoryMapper(IMapper<ZipCode, ZipEntity> zipCodeMapper) 
            : base(zipCodeMapper)
        { }

        protected override void MapUniqueTerritoryFields(TerritoryEntity territoryEntity, 
            HospitalPartnerTerritory territoryToMapTo)
        {
            List<long> hospitalPartnerIds = territoryEntity.HospitalPartnerTerritory.
                Select(hpt => hpt.HospitalPartnerId).ToList();
            territoryToMapTo.HospitalPartnerOwnerIds = hospitalPartnerIds;
        }
    }
}