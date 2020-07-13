using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianRecordRequestSignatureRepository
    {
        void Save(PhysicianRecordRequestSignature domain);

        int GetLatestVersion(long eventCustomerId);

        PhysicianRecordRequestSignature GetByEventCustomerId(long eventCustomerId);

        bool IsSaved(long eventCustomerId);

        IEnumerable<PhysicianRecordRequestSignature> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);
    }
}
