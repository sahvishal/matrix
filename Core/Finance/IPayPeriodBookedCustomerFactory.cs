using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IPayPeriodBookedCustomerFactory
    {
        PayPeriodBookedCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel, IEnumerable<Customer> customers,
            IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests);

        ActualCustomerShowedListModel CreateActualCustomerShowed(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel,
            IEnumerable<Customer> customers, IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests, IEnumerable<PayPeriod> payPeriods
            , IEnumerable<PayPeriodCriteria> criterias, IEnumerable<PayRangeCustomerBookedViewModel> payPeriodCustomerBookedByAgent);
    }
}