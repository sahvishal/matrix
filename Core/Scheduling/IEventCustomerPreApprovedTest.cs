using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCustomerPreApprovedTestRepository
    {
        void Save(long eventcustomerId, IEnumerable<long> testIds);

        IEnumerable<EventCustomerPreApprovedTest> GetEventCustomerResultForGapsClosure(int pageNumber, int pageSize, GapsClosureModelFilter filter, out int totalRecords);

        IEnumerable<OrderedPair<long, string>> GetCustomerIdPreApprovedTests(IEnumerable<long> eventcustomerId);

        IEnumerable<long> GetPreApprovedTestByEventCustomerId(long eventCustomerId);

        IEnumerable<string> GetPreApprovedTestNameByEventCustomerId(long eventCustomerId);

        IEnumerable<OrderedPair<long, long>> GetPreApprovedTestIdsByCustomerIds(IEnumerable<long> eventCustomerIds);
        IEnumerable<string> GetPreApprovedTest(long eventcustomerId);
    }
}