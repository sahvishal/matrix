using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface IHostFacilityRankingRepository
    {
        List<HostFacilityViability> GetHostFacilityRanking(long RoleId, long hostId);
        HostFacilityViability Save(HostFacilityViability domainObject);
        bool IsHostRatedByTechnician(long hostId, long eventId);
        bool SetIsHostRatedFlagOn(long hostId, long eventId);
    }
}
