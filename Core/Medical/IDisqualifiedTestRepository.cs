using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IDisqualifiedTestRepository
    {
        IEnumerable<DisqualifiedTest> GetAllByEventCustomerId(long customerId, long eventId, int version = 1);
        long GetLatestVersion(long customerId, long eventId);
        void SaveAnswer(IEnumerable<DisqualifiedTest> answers);
        bool DeleteDisqualifiedTests(long customerId, long eventId, long orgUserId);
        IEnumerable<DisqualifiedTestModel> GetByFilter(DisqualifiedTestReportFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<DisqualifiedTest> GetAllByEventIdCustomerId(IEnumerable<long> customerIds, IEnumerable<long> eventIds);
        IEnumerable<long> GetLatestVersionTestId(long customerId, long eventId);
        bool DeleteDisqualifiedTests(long customerId, long[] eventIds, long orgUserId);
    }
}
