using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ICustomerEligibilityRepository
    {
        CustomerEligibility GetByCustomerIdAndYear(long customerId, int year);
        void Save(CustomerEligibility customerEligibility);
        IEnumerable<CustomerEligibility> GetCustomerEligibilityByCustomerIdsAndYear(IEnumerable<long> customerIds, int forYear);
        IEnumerable<CustomerEligibility> GetCustomerEligibilityByCustomerIds(IEnumerable<long> customerIds);
        IEnumerable<CustomerEligibility> GetByCustomerId(long customerId);
    }
}
