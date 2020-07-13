using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventAppointmentStatsService
    {
        EventAppointmentStatsModel Get(long eventId);
        IEnumerable<EventAppointmentStatsModel> Get(IEnumerable<long> eventIds);
        IEnumerable<EventAppointmentStatsModel> Get(IEnumerable<Event> events);
        IEnumerable<EventAppointmentStatsModel> GetStats(IEnumerable<Event> events);
    }
}
