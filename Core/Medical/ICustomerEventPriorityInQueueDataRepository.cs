using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerEventPriorityInQueueDataRepository
    {
        CustomerEventPriorityInQueueData GetByCustomerEventScreeningTestId(long customerEventScreeningTestId);
        CustomerEventPriorityInQueueData Save(CustomerEventPriorityInQueueData domainObject, long eventId, long customerId, long testId,  long createdByOrgRoleUserId);

        CustomerEventPriorityInQueueData Get(long eventId, long customerId, long testId);
        void Delete(long customerId, long eventId, long testId, long createdByOrgRoleUserId);

        IEnumerable<CustomerEventPriorityInQueueData> GetByEventCustomerResultId(long evencustomerResultId);

        IEnumerable<long> GetEventCustomerResultIdsForPriorityInQueueNotification(int daysToCheck);

        IEnumerable<CustomerEventPriorityInQueueDataViewModel> GetPriorityInQueueViewDataByEventCustomerResultId(long evencustomerResultId);
    }
}
