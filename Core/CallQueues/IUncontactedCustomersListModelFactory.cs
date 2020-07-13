using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues
{
    public interface IUncontactedCustomersListModelFactory
    {
        UncontactedCustomersReportListModel Create(IEnumerable<Customer> customer, IEnumerable<CorporateCustomerCustomTag> customTags, 
                                                   IEnumerable<CustomerEligibility> customerEligibilities); 
    }
}
