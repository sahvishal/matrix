using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventCustomerPreApprovedTestService
    {
        void UpdateEventCustomerPreApprovedTest(long eventId, long customerId);
        IEnumerable<EventCustomer> GetFutureEventCustomers(long customerId, bool isTodayIncluded = true);
        IEnumerable<EventCusomerAdjustOrderViewModel> MarkcustomerForAdjustOrder(CorporateCustomerEditModel model, IEnumerable<EventCustomer> eventCustomers,
            long createdByOrgRoleUserId, long customerId, long? corporateUploadId);
    }
}