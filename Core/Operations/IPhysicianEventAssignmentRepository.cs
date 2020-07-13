using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IPhysicianEventAssignmentRepository
    {
        PhysicianEventAssignment Save(PhysicianEventAssignment physicianEventAssignment);
        PhysicianEventAssignment GetAssignedPhysicians(long eventId);
        IEnumerable<OrderedPair<long, string>> GetPrimaryPhysicianForEvents(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, string>> GetOverReadPhysicianForEvents(IEnumerable<long> eventIds);
        IEnumerable<PhysicianEventAssignment> GetAssignedPhysiciansByEventIds(IEnumerable<long> eventIds);
    }
}
