using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IPreApprovedPackageRepository
    {
        IEnumerable<PreApprovedPackage> GetByCustomerId(long customerId);
        long CheckPreApprovedPackages(long customerId);
        void SavePreApprovedPackages(long customerId, long packageIds, long createdByOrgRoleUserId);

        IEnumerable<OrderedPair<long, string>> GetByCustomerIds(long[] customerIds);
        IEnumerable<OrderedPair<long, long>> GetIdByCustomerIds(long[] customerIds);
        IEnumerable<OrderedPair<long, string>> GetPreApprovedPackageTestByCustomerIds(long[] customerIds);
        IEnumerable<string> GetPreApprovedPackageTest(long customerId);
    }
}
