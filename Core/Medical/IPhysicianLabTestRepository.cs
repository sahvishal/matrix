using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianLabTestRepository
    {
        IEnumerable<PhysicianLabTest> GetPhysicicanLabTestByStateId(long stateId);
        IEnumerable<PhysicianLabTest> GetPhysicicanLabTestByStateIds(IEnumerable<long> stateIds);
    }
}
