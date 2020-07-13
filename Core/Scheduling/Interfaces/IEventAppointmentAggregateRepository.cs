using System.Collections.Generic;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventAppointmentAggregateRepository
    {
        IEnumerable<EventAppointmentAggregate> GetEventAppointmentAggregates(IEnumerable<long> appointmentsIds);
    }
}