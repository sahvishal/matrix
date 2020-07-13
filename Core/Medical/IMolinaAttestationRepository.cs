using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IMolinaAttestationRepository
    {
        IEnumerable<MolinaAttestation> GetbyEventCustumerResultId(long eventCustomerResultId);
        void Save(IEnumerable<MolinaAttestation> attestations);
        bool Save(MolinaAttestation attestations);
        void Delete(long eventCustomerResultId);
    }
}
