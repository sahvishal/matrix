using System.Collections.Generic;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IDeferredRevenueListModelFactory
    {
        DeferredRevenueListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events,
                                        IEnumerable<Pod> pods, IEnumerable<Customer> customers,
                                        IEnumerable<OrderedPair<long, string>> ecAndPackagePair,
                                        IEnumerable<OrderedPair<long, string>> ecAndTestPair,
                                        IEnumerable<OrderedPair<long, long>> orderIdEventCustomerIdPairs,
                                        IEnumerable<Host> hosts,
                                        IEnumerable<DeferredRevenueViewModel> eventRevenueWiseDetails,
                                        IEnumerable<OrderedPair<long, decimal>> eventCustomerIdOrderTotalPairs,
                                        IEnumerable<OrderedPair<long, decimal>> eventCustomerIdTotalPaymentPairs);
    }
}

