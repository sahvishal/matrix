using System.Collections;
using System.Collections.Generic;
using HealthYes.Web.Core.Domain.Hosts;
using HealthYes.Web.Core.Enum;

namespace HealthYes.Web.Core.Interfaces
{
    public interface IHostRepository
    {
        List<EventType> GetEventTypesForHost(long hostId);
        List<Host> GetEventHosts(long eventId);
        List<Host> GetEventHosts(IEnumerable<long> eventIds);
    }
}