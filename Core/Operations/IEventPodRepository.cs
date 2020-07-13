using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IEventPodRepository
    {
        EventPod Save(EventPod domain);
        void Deactivate(long eventId);
        void DeactivateEventPod(long eventId, IEnumerable<long> podIds);
        IEnumerable<EventPod> GetByEventId(long eventId);
        EventPod GetByEventIdPodId(long eventId, long podId);
        bool IsKynIntegrationEnabled(long eventId);
        IEnumerable<EventPod> GetByEventIds(IEnumerable<long> eventIds);
        bool IsBloodworkFormAttached(long eventId);
    }
}
