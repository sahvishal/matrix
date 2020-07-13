using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ICustomerTargetedRepository
    {
        CustomerTargeted GetByCustomerIdAndYear(long customerId, int year);
        void Save(CustomerTargeted customerTargeted);
        IEnumerable<CustomerTargeted> GetCustomerTargetedByCustomerIdsAndYear(IEnumerable<long> customerIds, int forYear);
        IEnumerable<CustomerTargeted> GetCustomerTargetedByCustomerId(long customerId);
    }
}
