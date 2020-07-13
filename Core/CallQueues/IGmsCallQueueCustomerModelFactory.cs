using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.CallQueues
{
    public interface IGmsCallQueueCustomerModelFactory
    {
        IEnumerable<GmsCallQueueCustomerViewModel> Create(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<EventListGmsModel> events, IEnumerable<Host> eventHosts,
            CorporateAccount healthPlan, Organization account, IEnumerable<OrderedPair<long, PhoneNumber>> customerIdCheckoutNumberPair, bool setAdditionalField = false);
    }
}
