using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues
{
    public interface ICustomerWithNoEventsInAreaReportListModelFactory
    {
        CustomerWithNoEventsInAreaReportListModel Create(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> customTags);
    }
}
