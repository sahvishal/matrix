using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IPhysicianCustomerAssignmentRepository
    {
        PhysicianCustomerAssignment Save(PhysicianCustomerAssignment physicianCustomerAssignment);
        PhysicianCustomerAssignment GetAssignedPhysicians(long eventCustomerId);
        PhysicianCustomerAssignment GetAssignedPhysicians(long eventId, long customerId);
        IEnumerable<PhysicianCustomerAssignment> GetCustomerAssignmentbyEventCustomerIds(IEnumerable<long> eventCustomerIds);
    }
}
