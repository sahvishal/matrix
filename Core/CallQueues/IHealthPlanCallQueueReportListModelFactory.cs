using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCallQueueReportListModelFactory
    {
        CallQueueSchedulingReportListModel Create(IEnumerable<CallQueueCustomerCallDetails> callQueueCustomerCallDetailsView, List<Customer> customers,
            IEnumerable<Core.Sales.Domain.CorporateCustomerCustomTag> customerTags, IEnumerable<OrderedPair<long, string>> registeredbyAgentNameIdPair, IEnumerable<Event> events,
            IEnumerable<Organization> organizations, IEnumerable<CallQueue> callQueues);
    }
}