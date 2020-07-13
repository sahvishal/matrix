using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomerLeftWithoutScreeningModelFactory
    {
        CustomerLeftWithoutScreeningListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel,
                                      IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, string>> idNamePairs,
                                       IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<CustomerCallNotes> patientLeftNotes, IEnumerable<CorporateAccount> corporateAccounts);
    }
}
