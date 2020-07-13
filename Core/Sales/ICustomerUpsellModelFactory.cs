using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Sales
{
    public interface ICustomerUpsellModelFactory
    {
        CustomerUpsellListModel Create(IEnumerable<Order> orders, IEnumerable<EventBasicInfoViewModel> eventListModel, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, 
            IEnumerable<OrderedPair<long, string>> products, IEnumerable<OrderedPair<long, string>> agents);

        IEnumerable<OrderDetail> GetPreviousSuccesfulCompositionofOrderDetails(Order order);
    }
}