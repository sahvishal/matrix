using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventTestRepository : IRepository<EventTest>
    {
        EventTest GetByEventAndTestId(long eventId, long testId);
        List<EventTest> GetByEventAndTestIds(long eventId, IEnumerable<long> testIds);
        IEnumerable<EventTest> GetbyIds(IEnumerable<long> ids);
        IEnumerable<EventTest> GetTestsForEventByRole(long eventId, long roleId, long gender = (long) Gender.Unspecified);
        EventTest GetbyId(long id);
        IEnumerable<OrderedPair<long, long>> GetEventTestIdForOrders(IEnumerable<long> orderIds);
        IEnumerable<EventTest> GetTestsForOrder(long orderId);
        IEnumerable<EventTest> GetTestsForEvent(long eventId, long gender = (long)Gender.Unspecified);
        IEnumerable<OrderedPair<long, string>> GetTestNamesForOrders(IEnumerable<long> orderIds);
        IEnumerable<OrderedPair<long, string>> GetTestIdNamePairs(IEnumerable<long> eventTestIds);
        IEnumerable<EventTest> GetByEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, long>> GetOrderIdTestIdPairsForOrders(IEnumerable<long> orderIds);
        IEnumerable<MedicareEventTestModel> GetTestAliasesByEventIds(IEnumerable<long> eventIds);
        IEnumerable<EventTest> GetEventTestsByEventIds(IEnumerable<long> eventIds);
        IEnumerable<long> GetMammoEnableEventIds(IEnumerable<long> eventids);
        bool EventHasMammoTests(long eventid);
    }
}