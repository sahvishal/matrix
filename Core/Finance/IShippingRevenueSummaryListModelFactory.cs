using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IShippingRevenueSummaryListModelFactory
    {
        ShippingRevenueSummaryListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods,
                                               IEnumerable<OrderedPair<long, int>> eventIdShippingCountPairs,
                                               IEnumerable<OrderedPair<long, decimal>> eventIdShippingRevenuePairs);

        ShippingRevenueDetailListModel CreateShippingRevenueDetail(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<Customer> customers,
            IEnumerable<ShippingDetail> shippingDetails, IEnumerable<OrderedPair<long, long>> shippingDetailIdEventCustomerIdPairs, IEnumerable<ShippingOption> shippingOptions, IEnumerable<Order> orders);
    }
}
