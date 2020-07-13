using System;
using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallBackCallQueueService
    {
        IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId, DateTime? lastGeneratedDate);
    }
}
