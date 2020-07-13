using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IParticipationConsentSignatureRepository
    {
        void Save(ParticipationConsentSignature domain);

        int GetLatestVersion(long eventCustomerId);

        ParticipationConsentSignature GetByEventCustomerId(long eventCustomerId);

        bool IsSaved(long eventCustomerId);

        IEnumerable<ParticipationConsentSignature> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);
    }
}
