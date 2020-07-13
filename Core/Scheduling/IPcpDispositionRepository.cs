using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IPcpDispositionRepository
    {
        void Save(PcpDisposition pcpAppointment);
        IEnumerable<PcpDisposition> GetByEventCustomerId(long eventCustomerId);
        IEnumerable<PcpDisposition> GetByCustomerIdEventId(long customerId, long eventId);
        IEnumerable<PcpDisposition> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);
    }
}