using System.Collections.Generic;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Sales
{
    public interface IDetailOpenOrderModelFactory
    {
        DetailOpenOrderListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods,
                                        IEnumerable<OrderedPair<long, int>> bookedSlots,
                                        IEnumerable<OrderedPair<long, int>> unservicedAppts,
                                        IEnumerable<OrderedPair<long, int>> noShowAppts,
                                        IEnumerable<OrderedPair<long, int>> cancelledAppts,
                                        IEnumerable<OrderedPair<long, decimal>> eventIdOpenOrderTotalPairs,
                                        IEnumerable<OrderedPair<long, decimal>> eventIdTotalOutstandingRevenuePairs,
                                        IEnumerable<OrderedPair<long, decimal>> eventIdNoShowOutstandingRevenuePairs,
                                        IEnumerable<OrderedPair<long, decimal>> eventIdCancelledOutstandingRevenuePairs);

        CustomerOpenOrderListModel CreateCustomerOpenOrder(IEnumerable<EventCustomer> eventCustomers,
                                                           IEnumerable<Event> events, IEnumerable<Host> hosts,
                                                           IEnumerable<Pod> pods, IEnumerable<Customer> customers,
                                                           IEnumerable<OrderedPair<long, decimal>> eventCustomerIdOpenOrderTotalPairs,
                                                           IEnumerable<OrderedPair<long, decimal>> eventCustomerIdRevenuePairs, IEnumerable<OrderedPair<long, long>> orderIdEventCustomerIdPairs);
    }
}