using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IItemizedReceiptModelFactory
    {
        CustomerItemizedReceiptModel Create(Customer customer, Host host, Order order, EventPackage package, IEnumerable<EventTest> tests, IEnumerable<OrderedPair<long, long>> orderItemIdTestIdPair, IEnumerable<OrderedPair<long, string>> products);
    }
}