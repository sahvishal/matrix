using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface ICorporateAccountDashboardFactory
    {
        CorporateAccountDashboardViewModel Create(IEnumerable<ClientEventVolumeModel> upcomingEvents, CorporateAccountMemberStatusViewModel memberStatus, IEnumerable<EventCustomerResult> recentCriticalCustomers,
            IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<CustomerResultStatusViewModel> customerResultStatusViewModels);
    }
}
