using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling
{
    public interface IRequiredTestRepository
    {
        IEnumerable<RequiredTest> GetByCustomerId(long customerId);
        void SaveRequiredTests(long customerId, IEnumerable<long> testIds, long createdByOrgRoleUserId, int forYear);
        bool IsRequiredTestAvailble(long customerId);
        IEnumerable<string> GetRequiredTests(long customerId);
        IEnumerable<RequiredTest> GetByRequiredTestByCustomerIdAndYear(long customerId, int forYear);
    }
}
