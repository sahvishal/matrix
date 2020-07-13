using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Interfaces
{
    public interface IEventMetricsViewDataFactory
    {
        EventMetricsViewData CreateEventMetricsViewData(IEnumerable<Core.Finance.Domain.Order> orders, IEnumerable<EventPackage> eventPackages, 
            IEnumerable<EventTest> eventTests, OrganizationRoleUser organizationRoleUser, IEnumerable<EventCustomer> eventCustomers);
    }
}