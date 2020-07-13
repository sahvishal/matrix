using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface ICustomerAccountGlocomNumberRepository
    {
        IEnumerable<CustomerAccountGlocomNumber> GetByCustomerId(long customerId);
        void Save(CustomerAccountGlocomNumber model, bool refatch = true);
        void Update(CustomerAccountGlocomNumber model);
        CustomerAccountGlocomNumber GetByCustomerIdAndGlocomNumber(long customerId, string glocomNumber);
        IEnumerable<CustomerAccountGlocomNumber> GetByCustomerIds(IEnumerable<long> customerIds);
    }
}
