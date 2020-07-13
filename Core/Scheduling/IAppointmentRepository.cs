using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IAppointmentRepository : IUniqueItemRepository<Appointment>
    {
        IEnumerable<Appointment> GetAllAppointmentsForEvent(long eventId);
        IEnumerable<Appointment> GetAppointmentsForEvents(IEnumerable<long> eventIds);
        IEnumerable<Appointment> GetBlockedAppointmentsForEvent(long eventId);
        Appointment GetEventCustomerAppointment(long eventId, long customerId);
    }
}
