using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IRefundRequestListModelFactory
    {
        RefundRequestListModel Create(IEnumerable<RefundRequest> requests, IEnumerable<Customer> customers, IEnumerable<Event> events, IEnumerable<Host> hosts,
                                    IEnumerable<OrderedPair<long, string>> idNamePairs, IEnumerable<OrganizationRoleUser> orgRoleUsers,
                                    IEnumerable<Role> roles, IEnumerable<Order> orders, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventAppointmentCancellationLog> appointmentCancellationLogs);
    }
}