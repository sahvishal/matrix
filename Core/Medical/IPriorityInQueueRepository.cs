using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPriorityInQueueRepository
    {
        PriorityInQueue GetByEventCustomerResultId(long eventCustomerResultId);
        PriorityInQueue Save(PriorityInQueue model);
        long GetMaxPriorityInQueue();
        IEnumerable<PriorityInQueue> GetByEventId(long eventId);
        IEnumerable<PriorityInQueue> GetByEventIds(IEnumerable<long> eventIds);

        PriorityInQueue GetByEventIdCustomerId(long eventId, long customerId);
    }
}
