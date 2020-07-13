
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueExcludedCustomerReportListModelFactory
    {
        CallQueueExcludedCustomerReportListModel Create(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> customTags,
            IEnumerable<ProspectCustomer> prospectCustomers, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<User> users, IEnumerable<CallQueueCustomerCriteraAssignmentForStats> callQueueCustomer, IEnumerable<long> healthPlanZipIdPairs,
            CorporateAccount account, IEnumerable<AccountCallQueueSetting> callQueueSettings, IEnumerable<CustomerEligibility> customerEligibilityCollection, IEnumerable<CustomerTargeted> targetedCustomers);

    }
}
