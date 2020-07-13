using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IDependentDisqualifiedTestRepository
    {
        IEnumerable<DependentDisqualifiedTest> GetAllByEventCustomerId(long customerId, long eventId, int version = 1);

        int GetLatestVersion(long customerId, long eventId);

        void Save(IEnumerable<DependentDisqualifiedTest> answers);

        bool DeleteDependentDisqualifiedTests(long customerId, long eventId, long orgUserId);

        IEnumerable<long> GetLatestVersionTestId(long customerId, long eventId);
        bool DeleteDependentDisqualifiedTests(long customerId, long[] eventIds, long orgUserId);
    }
}
