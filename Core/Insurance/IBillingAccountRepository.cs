using System.Collections.Generic;
using Falcon.App.Core.Insurance.Domain;

namespace Falcon.App.Core.Insurance
{
    public interface IBillingAccountRepository
    {
        IEnumerable<BillingAccount> GetAll();
        IEnumerable<BillingAccountTest> GetAllBillingAccountTests();
        BillingAccountTest GetByTestId(long testId);
        void SaveBillingAccountTest(long? billingAccountId, long testId);
    }
}
