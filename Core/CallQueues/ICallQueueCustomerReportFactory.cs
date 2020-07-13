using System.Collections.Generic;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueCustomerReportFactory
    {
        CallQueueCustomersReportModelListModel GetCallQueueCustomersList(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers,
            IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags, CorporateAccount corporateAccount,  bool isQueueGenerated, HealthPlanCallQueueCriteria criteriaModel);
    }
}