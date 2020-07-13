using Falcon.App.Core.Sales.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Sales
{
    public interface ICustomerOrderHistoryRepository
    {
        void Save(IEnumerable<CustomerOrderHistory> domainList);
    }
}
