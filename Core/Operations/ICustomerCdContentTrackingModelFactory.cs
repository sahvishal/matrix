using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Operations
{
    public interface ICustomerCdContentTrackingModelFactory
    {
        CustomerCdContentTrackingListModel Create(IEnumerable<EventCustomer> eventCustomers,
                                                  IEnumerable<Customer> customers,
                                                  IEnumerable<OrderedPair<long, long>> orderIds,
                                                  IEnumerable<CdContentGeneratorTracking> cdContentGeneratorTrackings,
                                                  IEnumerable<OrderedPair<long, string>> idNamePairs);
    }
}
