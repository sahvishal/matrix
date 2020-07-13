using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface ICancelledCustomerModelFactory
    {
        CancelledCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, long>> orderIdEventCustomerIdPairs,
                                          IEnumerable<CustomerCallNotes> notes, IEnumerable<RefundRequest> refundRequests, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<OrganizationRoleUser> agents,
                                          IEnumerable<Role> roles,IEnumerable<EventAppointmentCancellationLog> appointmentCancellationLogs );
    }
}
