using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Hosts
{
    public class HostFacilityRankingMapper : DomainEntityMapper<HostFacilityViability, HostFacilityRankingEntity>
    {
        protected override void MapDomainFields(HostFacilityRankingEntity entityObject, HostFacilityViability domainObjectToMapTo)
        {
            domainObjectToMapTo.HostId = entityObject.HostId;
            domainObjectToMapTo.Id = entityObject.HostFacilityRankingId;

            if (entityObject.InternetAccess != null && entityObject.InternetAccess.Value > 0)
            {
                domainObjectToMapTo.InternetAccess = InternetAccess.InternetAccessTypes.Find(internetAccess =>
                    internetAccess.PersistenceLayerId == entityObject.InternetAccess.Value);
            }

            domainObjectToMapTo.Notes = entityObject.Notes;
            domainObjectToMapTo.NumberOfPlugPoints = entityObject.NumberOfPlugPoint;
            domainObjectToMapTo.RoomNeedsCleared = entityObject.RoomNeedsCleared;
            domainObjectToMapTo.RoomSize = entityObject.RoomSize;
            domainObjectToMapTo.CreatedOn = entityObject.CreatedDate;

            if (entityObject.IsConfirmedVisually != null)
                domainObjectToMapTo.IsConfirmedVisually = entityObject.IsConfirmedVisually;

            if (entityObject.Ranking != null)
                domainObjectToMapTo.Ranking = HostViabilityRanking.HostRankings.Find(hostRanking =>
                    hostRanking.PersistenceLayerId == entityObject.Ranking);

            domainObjectToMapTo.CreatedBy = new OrganizationRoleUser(entityObject.RankedByOrganizationRoleUserId);
        }

        protected override void MapEntityFields(HostFacilityViability domainObject, HostFacilityRankingEntity entityToMapTo)
        {
            entityToMapTo.HostId = domainObject.HostId;
            entityToMapTo.Notes = domainObject.Notes;

            if (domainObject.NumberOfPlugPoints != null)
                entityToMapTo.NumberOfPlugPoint = (byte)domainObject.NumberOfPlugPoints;
            else
                entityToMapTo.NumberOfPlugPoint = null;

            if (domainObject.RoomNeedsCleared != null)
                entityToMapTo.RoomNeedsCleared = domainObject.RoomNeedsCleared;
            else
                entityToMapTo.RoomNeedsCleared = null;

            entityToMapTo.RoomSize = domainObject.RoomSize;
            
            if (domainObject.InternetAccess != null)
                entityToMapTo.InternetAccess = domainObject.InternetAccess.PersistenceLayerId;
            
            if (domainObject.Ranking != null)
                entityToMapTo.Ranking = domainObject.Ranking.PersistenceLayerId;

            entityToMapTo.CreatedDate = domainObject.CreatedOn;
            entityToMapTo.RankedByOrganizationRoleUserId = domainObject.CreatedBy.Id;
            entityToMapTo.RankedByRole = domainObject.CreatedBy.RoleId;
            entityToMapTo.IsCurrentForRole = true;

            if (domainObject.IsConfirmedVisually != null)
                entityToMapTo.IsConfirmedVisually = domainObject.IsConfirmedVisually;
            else
                entityToMapTo.IsConfirmedVisually = null;

            entityToMapTo.HostFacilityRankingId = domainObject.Id;
        }

    }
}
