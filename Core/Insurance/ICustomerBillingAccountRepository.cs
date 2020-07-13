using System.Collections.Generic;
using Falcon.App.Core.Insurance.Domain;

namespace Falcon.App.Core.Insurance
{
    public interface ICustomerBillingAccountRepository
    {
        CustomerBillingAccount GetByCustomerIdBillingAccountId(long customerId, long billingAccountId);
        void Save(CustomerBillingAccount domain);
        IEnumerable<CustomerBillingAccount> GetAlreadySyncedCustomers(long[] customerIds, long billingAccountId);
        IEnumerable<CustomerBillingAccount> GetCustomerBillingAccounts(long customerId);
    }
}
