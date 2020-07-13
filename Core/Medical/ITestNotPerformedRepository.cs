using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface ITestNotPerformedRepository
    {
        IEnumerable<TestNotPerformed> GetTestNotPerformedForHealthPlan(TestNotPerformedListModelFilter filter,
            int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<OrderedPair<long, long>> GetEventCusromerResultIdTestIdPairs(IEnumerable<long> eventCustomerResultIds);

        IEnumerable<EventCustomerResultTestNotPerformedViewModel> GetEventCustomerResultTestNotPerformed(IEnumerable<long> eventCustomerResultIds);

        bool IsTestNotPerformed(long eventCustomerResultId, long testId);
    }
}