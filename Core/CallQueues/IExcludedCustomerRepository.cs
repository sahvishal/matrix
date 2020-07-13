using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IExcludedCustomerRepository
    {
        CallQueueCustomersStatsViewModel GetExcludedCustomers(OutboundCallQueueFilter filter, CallQueue callQueue);
    }
}