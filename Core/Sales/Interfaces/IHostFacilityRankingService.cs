using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface IHostFacilityRankingService
    {
        HostFacilityViability GetHostFacilityRankingByHSC(long hostId);
        HostFacilityViability GetHostFacilityRankingByTechnician(long hostId);
        HostFacilityViability GetHostFacilityRankingByFranchisee(long hostId);
        HostFacilityViability GetHostFacilityViabilityforEventWizard(long hostId);
        HostFacilityViability SaveHostFacilityRanking(HostFacilityViability hostFacilityViability);
        List<HostImage> GetHostFacilityImagesbyTechnician(long hostId);
        List<HostImage> GetHostFacilityImagesbyHSC(long hostId);
        List<HostImage> GetHostFacilityImages(long hostId);
    }
}
