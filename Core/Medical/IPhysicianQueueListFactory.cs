using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianQueueListFactory
    {
        PhysicianQueueListModel Create(IEnumerable<PhysicianQueueListItem> queue, IEnumerable<OrderedPair<long, string>> physiciansIdNamePair, IEnumerable<EventCustomer> eventCustomers, bool overReadRecords,
                                       IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<Event> events, IEnumerable<Pod> pods, IEnumerable<PriorityInQueue> priorityInQueues);
    }
}