using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling
{
    public interface ITextReminderModelFactory
    {
        TextReminderListModel Create(IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Customer> customers, IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs);
    }
}
