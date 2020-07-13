using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallCenterCallReportListModelFactory
    {
        CallCenterCallReportListModel Create(List<Customer> customers, IEnumerable<Falcon.App.Core.Sales.Domain.CorporateCustomerCustomTag> customerTags, IEnumerable<Call> calls, List<EventCustomer> eventCustomers,
            EventBasicInfoListModel eventBasicInfoListModel, List<Appointment> appointments, IEnumerable<OrderedPair<long, string>> registeredbyAgentNameIdPair, IEnumerable<CallCenterNotes> dispositionNotes,
            IEnumerable<OrderedPair<long, long>> orderedPairsCustomersShippingDetails, IEnumerable<ShippingDetail> customersShippingDetails, List<Address> addresses, IEnumerable<CallQueue> callQueues,
            IEnumerable<CustomerEligibility> customerEligibilities);
    }
}
