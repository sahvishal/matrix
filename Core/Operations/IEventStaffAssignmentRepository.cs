using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IEventStaffAssignmentRepository
    {
        IEnumerable<EventStaffAssignment> GetForEvent(long eventId);
        void DeleteFor(long eventId);
        IEnumerable<long> GetTechblockedforSomeotherEventonthesameDayofGivenEvent(long eventId);
        void DeleteFor(long eventId, long podId);
        bool IsTechnicianAssignedForFutureEvent(long technicianId);
        IEnumerable<EventStaffAssignment> GetForEvents(IEnumerable<long> eventIds);
    }
}