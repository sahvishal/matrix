
using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IConfirmationCallQueueService
    {
        IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId, int noOfDays);
    }
}
