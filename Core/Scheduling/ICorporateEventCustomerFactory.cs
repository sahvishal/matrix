using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface ICorporateEventCustomerFactory
    {
        CorporateEventViewModel Create(EventVolumeModel eventModel);
        CorporateEventCustomerListModel CreateCustomerScheduleModelforEvent(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, long eventId,
                IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests);
    }
}
