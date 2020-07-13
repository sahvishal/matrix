using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerTraleRepository
    {
        void Save(CustomerTrale domainObject);
        CustomerTrale GetByCustomerId(long customerId);
        IEnumerable<CustomerTrale> GetByCustomerIds(IEnumerable<long> customerIds);
    }
}
