using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueCustomerHelper
    {
        void SaveCallQueueCustomer(IEnumerable<CallQueueCustomer> callQueueCustomers);
        void SaveCallQueueCustomerForCallBack(IEnumerable<CallQueueCustomer> callQueueCustomers);
        void SaveCallQueueCustomerForFillEvent(IEnumerable<CallQueueCustomer> callQueueCustomers, long criteriaId);
    }
}
