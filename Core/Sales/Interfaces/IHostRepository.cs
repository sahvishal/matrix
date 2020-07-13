using System;
using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface IHostRepository
    {
        List<RegistrationMode> GetEventTypesForHost(long hostId);
        Host GetHostForEvent(long eventId);
        List<Host> GetEventHosts(IEnumerable<long> eventIds);
        bool UpdateHostTaxIdNumber(long hostId, string taxIdNumber);
        string GetTaxIdNumber(long hostId);
        bool SaveHostImages(long hostId, List<HostImage> hostImages);
        List<HostImage> GetHostImages(long hostId);
        bool DeleteHostImages(long hostId, List<long> imageIds);
        bool UpdateHostImages(long hostId, List<HostImage> hostImages);
        OrderedPair<string, string> GetCallCenterandTechnicianNotesforgivenHost(long hostId);
        IEnumerable<string> GetScreenedEventHostNames(string prefixText);
        Host GetHostById(long id);
        Host CreateHost(Host host);
        bool DeleteHost(long hostId);
        bool IsHostAttachedWithEvent(long hostId);
        List<Host> SearchHostByName(string name);
        List<Host> SearchProspectByName(string name);
        Host GetProspectById(long id);
        IEnumerable<OrderedPair<long, long>> GetHostZipId(IEnumerable<long> hostIds);
        List<Host> GetEventHostByHostIds(IEnumerable<long> hostIds);
        IEnumerable<Host> GetHostsForFutureHealthPlanEvents(long accountId, DateTime fromDate);
    }
}