using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IPcpAppointmentRepository
    {
        void Save(PcpAppointment pcpAppointment);
        PcpAppointment GetByEventCustomerId(long eventCustomerId);
        PcpAppointment GetByCustomerIdEventId(long customerId, long eventId);
        IEnumerable<PcpAppointment> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);

        void DeleteAppointmentForEventCustomers(long eventCustomerId);
    }
}
