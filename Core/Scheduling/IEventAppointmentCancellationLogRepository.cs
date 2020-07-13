using System;
using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventAppointmentCancellationLogRepository
    {
        EventAppointmentCancellationLog Save(EventAppointmentCancellationLog domain);
        IEnumerable<EventAppointmentCancellationLog> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);
        IEnumerable<EventAppointmentCancellationLog> GetByEventIdCustomerId(long eventId, long customerId);

        IEnumerable<EventAppointmentCancellationLog> GetCancellationByCusomerIds(IEnumerable<long> customerIds, DateTime cancellationDate);
    }
}