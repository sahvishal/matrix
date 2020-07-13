using System;
using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IPodController
    {
        List<Pod> GetPodsAssignedToSalesRep(long salesRepId);
        bool AssignPodToSalesRep(long podId, long salesRepId);
        bool UnassignPodFromSalesRep(long podId, long salesRepId);
        List<Pod> GetPodsAvailableForSalesRep(long salesRepId);
        List<Pod> GetPodsAssignedToFranchisee(long franchiseeId);
        List<Pod> GetPodsAvailableForEvent(long franchiseeId, DateTime eventDate, long territoryId);
        List<Pod> GetPodsAvailableForEvent(long franchiseeId, long territoryId);
    }
}