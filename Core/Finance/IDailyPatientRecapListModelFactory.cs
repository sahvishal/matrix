using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IDailyPatientRecapListModelFactory
    {
        DailyPatientRecapListModel CreateListModel(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<ShippingDetail> shippingDetails, ShippingOption cdShippingOption,
            IEnumerable<OrderedPair<long, string>> hospitalPartners, IEnumerable<OrderedPair<long, string>> corporateAccounts, IEnumerable<Appointment> appointments, IEnumerable<Pod> pods, IEnumerable<EventPod> eventPods,
            IEnumerable<Event> events, IEnumerable<OrderedPair<long, long>> orderIdEventPackageTestIdPairs, IEnumerable<OrderedPair<long, long>> orderIdTestIdPairs, IEnumerable<OrderedPair<long, long>> testNotPerformedEventCustomerIdTestIdPairs,
            IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, string>> orderIdPackageNamePairs);

        DailyPatientRecapCustomListModel CreateCustomListModel(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<Order> orders, 
            IEnumerable<OrderedPair<long, string>> corporateAccounts, IEnumerable<Pod> pods, IEnumerable<EventPod> eventPods, IEnumerable<Event> events, 
            IEnumerable<OrderedPair<long, long>> orderIdEventPackageTestIdPairs, IEnumerable<OrderedPair<long, long>> orderIdTestIdPairs, 
            IEnumerable<OrderedPair<long, long>> testNotPerformedEventCustomerIdTestIdPairs, IEnumerable<OrderedPair<long, string>> tests, 
            IEnumerable<OrderedPair<long, string>> orderIdPackageNamePairs);
    }
}
