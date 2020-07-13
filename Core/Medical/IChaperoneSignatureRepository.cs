using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IChaperoneSignatureRepository
    {
        void Save(ChaperoneSignature domain);

        int GetLatestVersion(long eventCustomerId);

        ChaperoneSignature GetByEventCustomerId(long eventCustomerId);

        IEnumerable<ChaperoneSignature> GetByEventCustomerIds(IEnumerable<long> eventCustomerId);
    }
}
