using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IFluConsentSignatureRepository
    {
        void Save(FluConsentSignature domain);

        int GetLatestVersion(long eventCustomerId);

        FluConsentSignature GetByEventCustomerId(long eventCustomerId);

        bool IsSaved(long eventCustomerId);

        IEnumerable<FluConsentSignature> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);
    }
}
