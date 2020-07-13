using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Interfaces
{
    public interface IEventCustomerShippingDetailViewDataFactory
    {
        List<EventCustomerShippingDetailViewData> Create(IEnumerable<ShippingDetail> shippingDetails,
                                                         IEnumerable<OrderedPair<long, long>>
                                                             shippingDetailIdEventCustomerIdPairs,
                                                         IEnumerable<EventCustomer> eventCustomers,
                                                         IEnumerable<Customer> customers, IEnumerable<Event> events,
                                                         IEnumerable<EventCustomerResult> eventCustomerResults,
                                                         IEnumerable<Order> orders,
                                                         IEnumerable<OrderedPair<long, string>> orderPackageIdNamePairs,
                                                         IEnumerable<OrderedPair<long, string>> orderTestIdNamePairs,
                                                         IEnumerable<Address> addresses,
                                                         IEnumerable<ShippingOption> shippingOptions, int totalCount, IEnumerable<OrderedPair<long, string>> orderIdProductnamePairs);
    }
}