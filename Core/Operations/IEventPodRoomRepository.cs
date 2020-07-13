using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IEventPodRoomRepository
    {
        EventPodRoom Save(EventPodRoom domain);
        void SaveEventPodRoomTests(IEnumerable<long> testIds, long eventPodRoomId);
        void DeleteEventPodRooms(IEnumerable<long> eventPodRoomIds);
        IEnumerable<EventPodRoom> GetByEventIdAndPodIds(long eventId, IEnumerable<long> podIds);
        IEnumerable<EventPodRoom> GetByEventId(long eventId);
        IEnumerable<EventPodRoomTest> GetEventPodRoomTestsByEventId(long eventId);
        IEnumerable<EventPodRoomTest> GetEventPodRoomTestsForPackageTimeOnlyByEventId(long eventId, long podRoomId);
        IEnumerable<EventPodRoomTest> GetEventPodRoomTestsByEventRoomIds(IEnumerable<long> ids);
        IEnumerable<EventPodRoom> GetByIds(IEnumerable<long> ids);
        IEnumerable<EventPodRoom> GetByEventPodIds(IEnumerable<long> ids);
    }
}
