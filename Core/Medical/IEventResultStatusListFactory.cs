using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IEventResultStatusListFactory
    {
        EventResultStatusListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts,
                                          IEnumerable<OrderedPair<long, int>> totalCustomersCount,
                                          IEnumerable<OrderedPair<long, int>> missingResultsCount,
                                          IEnumerable<OrderedPair<long, int>> preAuditPendingCount,
                                          IEnumerable<OrderedPair<long, int>> reviewPendingCount,
                                          IEnumerable<OrderedPair<long, int>> postAuditPendingCount,
                                          IEnumerable<OrderedPair<long, int>> resultsDeliveredCount,
                                          IEnumerable<long> resultsUploaded, IEnumerable<long> resultsParsed,
                                          IEnumerable<OrderedPair<long, int>> unStableStatesCount, IEnumerable<Pod> pods);
    }
}
