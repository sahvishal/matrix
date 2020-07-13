using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface ITestsBookedModelFactory
    {
        TestsBookedListModel Create(IEnumerable<OrderedPair<long, long>> eventCustomerTestOrderedPairs, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events,  IEnumerable<Customer> customers,
            IEnumerable<Pod> pods, IEnumerable<Test> tests);
    }
}