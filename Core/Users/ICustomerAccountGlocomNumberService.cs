using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users
{
    public interface ICustomerAccountGlocomNumberService
    {
        void SaveAccountCheckoutPhoneNumber(CustomerAccountGlocomNumber model);

        PhoneNumber GetGlocomNumber(long accountId, long stateId, long customerId, long? callId = null);

        IEnumerable<OrderedPair<long, PhoneNumber>> GetGlocomNumberForGmsReport(long accountId, IEnumerable<Customer> customers);
    }
}
