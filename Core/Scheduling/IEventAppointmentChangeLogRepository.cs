using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventAppointmentChangeLogRepository
    {
        EventAppointmentChangeLog Save(EventAppointmentChangeLog domain);
        IEnumerable<EventAppointmentChangeLog> GetRescheduledAppointment(int pageNumber, int pageSize, RescheduleApplointmentListModelFilter filter, out int totalRecords);
        IEnumerable<EventAppointmentChangeLog> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);
        IEnumerable<long> GetEventCustomerIdByEventId(long eventId);
        List<OrderedPair<long, int>> GetCustomerMovedOutEventOnDayOfEvent(IEnumerable<long> eventIds);
    }
}
