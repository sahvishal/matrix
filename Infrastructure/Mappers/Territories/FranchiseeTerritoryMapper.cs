using Falcon.App.Core.Application;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Territories
{
    public class FranchiseeTerritoryMapper : TerritoryMapper<FranchiseeTerritory>
    {
        public FranchiseeTerritoryMapper(IMapper<ZipCode, ZipEntity> zipCodeMapper) 
            : base(zipCodeMapper)
        { }

        protected override void MapUniqueTerritoryFields(TerritoryEntity territoryEntity,
            FranchiseeTerritory territoryToMapTo)
        {
            long franchiseeOwnerId = territoryEntity.FranchiseeTerritory != null ?
                territoryEntity.FranchiseeTerritory.OrganizationId : 0;

            territoryToMapTo.FranchiseeOwnerId = franchiseeOwnerId;
        }
    }
}