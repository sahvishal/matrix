using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Insurance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IInsurancePaymentListModelFactory
    {
        InsurancePaymentListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> packages, 
            IEnumerable<OrderedPair<long, string>> tests, IEnumerable<InsuranceDetailViewModel> insuranceDetailViewModels);
    }
}
