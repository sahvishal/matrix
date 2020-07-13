using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public  interface IWellmedAttestationService
    {
        void Save(WellMedAttestationListModel model);
        IEnumerable<WellMedAttestationViewModel> GetbyEventCustumerResultId(long eventCustomerResultId);
        bool Save(WellMedAttestationViewModel wellMedAttestation);
        void Delete(long eventCustomerResultId);
    }
}
