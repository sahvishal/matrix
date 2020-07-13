using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueReportListModelFactory
    {
        CallQueueReportListModel Create(IEnumerable<CallQueueAssignment> callQueueAssignments, IEnumerable<CallQueue> callQueues, IEnumerable<OrderedPair<long, string>> idNamePairs,
            IEnumerable<CallQueueCustomerStats> totalCustomerStats, IEnumerable<CallQueueCustomerStats> contactedCustomerStats);
    }
}
