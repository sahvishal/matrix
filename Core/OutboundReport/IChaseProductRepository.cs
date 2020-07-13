using System.Collections.Generic;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface IChaseProductRepository
    {
        ChaseProduct GetById(long id);

        IEnumerable<ChaseProduct> GetByIds(IEnumerable<long> ids);

        ChaseProduct Save(ChaseProduct domain);

        IEnumerable<CustomerChaseProduct> GetCustomerChaseProductsByCustomerId(long customerId);

        IEnumerable<CustomerChaseProduct> GetCustomerChaseProductsByProductId(long chaseProductId);

        IEnumerable<CustomerChaseProduct> SaveCustomerChaseProducts(IEnumerable<CustomerChaseProduct> domains);
        
        ChaseProduct GetByNameAndLevel(string productName, int level);
        
        CustomerChaseProduct SaveCustomerChaseProduct(CustomerChaseProduct domain);

        void DeleteByCustomerId(long customerId);
    }
}
