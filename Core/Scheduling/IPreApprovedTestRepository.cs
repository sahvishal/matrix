using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IPreApprovedTestRepository
    {
        IEnumerable<PreApprovedTest> GetByCustomerId(long customerId);
        void SavePreApprovedTests(long customerId, IEnumerable<long> testIds, long createdByOrgRoleUserId);
        IEnumerable<OrderedPair<long, string>> GetPreApprovedTests(IEnumerable<long> customerIds);

        IEnumerable<OrderedPair<long, long>> GetPreApprovedTestIdsByCustomerIds(IEnumerable<long> customerIds);

        bool CheckPreApprovedTestForCustomer(long customerId, IEnumerable<long> testIds);
        IEnumerable<string> GetPreApprovedTests(long customerId);
    }
}
