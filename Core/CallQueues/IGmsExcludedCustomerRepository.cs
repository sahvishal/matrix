using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IGmsExcludedCustomerRepository
    {
        IEnumerable<GmsExcludedCustomerViewModel> GetExcludedCallQueueCustomers(int pageNumber, int pageSize, OutboundCallQueueFilter filter, CallQueue callQueue, SuppressionFilterType suppressionType, out int totalRecords);

        IEnumerable<GmsExcludedCustomerViewModel> GetGmsExcludedCallQueueCustomers(int pageNumber, int pageSize, OutboundCallQueueFilter filter, CallQueue callQueue, SuppressionFilterType suppressionType, out int totalRecords);
    }
}
