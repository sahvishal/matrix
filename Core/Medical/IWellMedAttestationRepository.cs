using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IWellMedAttestationRepository
    {
        IEnumerable<WellMedAttestation> GetbyEventCustumerResultId(long eventCustomerResultId);
        void Save(IEnumerable<WellMedAttestation> attestations);
        void Delete(long eventCustomerResultId);
    }
}
