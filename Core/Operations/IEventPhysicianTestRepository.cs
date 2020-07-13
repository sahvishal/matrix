using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IEventPhysicianTestRepository
    {
        EventPhysicianTest Save(EventPhysicianTest domain);
        void DeactivateAll(long eventId, long modifiedby);
        void SaveEventPhysicianTests(IEnumerable<EventPhysicianTest> collection);
        IEnumerable<EventPhysicianTest> GetByEventId(long eventId);
        IEnumerable<EventPhysicianTest> GetByEventIdPhysicianId(long eventId, long physicianId);
    }
}
