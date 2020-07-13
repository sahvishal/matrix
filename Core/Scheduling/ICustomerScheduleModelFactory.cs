using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomerScheduleModelFactory
    {
        EventCustomerScheduleListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel, 
                                      IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, string>> products);

        EventCustomerScheduleModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments,
                                  IEnumerable<Order> orders, EventVolumeModel eventModel,
                                  IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages,
                                  IEnumerable<OrderedPair<long, string>> tests,
                                  IEnumerable<OrderedPair<long, string>> products);
    }
}