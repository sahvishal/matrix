using System;
using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IPodRepository
    {
        List<Pod> GetAllPods();
        List<Pod> GetAllPods(int pagenumber, int pageIze);
        List<Pod> GetPodsAssignedToSalesRep(long salesRepId);
        List<Pod> GetPodsAssignedToFranchisee(long franchiseeId);
        bool AssignPodToSalesRep(long podId, long salesRepId);
        bool UnassignPodFromSalesRep(long podId, long salesRepId);
        List<Pod> GetSalesRepAssignedPodsAvailableForEvent(long salesRepId, DateTime eventDate);
        List<Pod> GetPodsAvailableForEvent(long franchiseeId, DateTime eventDate);
        List<Pod> GetPodsAssignedToSalesRepForEvent(long salesrepId);

        IEnumerable<Pod> GetPodsForEvent(long eventId);
        List<Pod> GetUnallocatedPods();
        bool AssignGivenPodstoaFranchisee(long[] podIds, long franchiseeId);
        IEnumerable<Pod> GetPodsForEvents(IEnumerable<long> eventIds);
        List<Pod> GetPodsAvailableForEventByTerritoryId(long territoryId, DateTime eventDate);
        List<Pod> GetPodsAvailableForEventByTerritoryId(long territoryId);
        List<Pod> GetPodsAvailableForEvent(long franchiseeId);
        void SavePodTerritories(IEnumerable<long> territoryIds, long podId);

        List<OrderedPair<string, OrderedPair<string, string>>> GetPodBookedInformation(long podId, DateTime eventDate, long eventId = 0);

        IEnumerable<OrderedPair<long, string>> GetPodNamesforEventIds(IEnumerable<long> eventIds);
        long GetFirstImmediateEventPodId();
    }
}