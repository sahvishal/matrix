using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class FluVaccineConsentModel
    {
        public long EventCustomerId { get; set; }

        public IEnumerable<FluConsentAnswerModel> CustomerAnswers { get; set; }
        
        public string PatientSignatureBytes { get; set; }

        public string ClinicalProviderSignatureBytes { get; set; }

        public IEnumerable<FluConsentAnswerModel> ClinicalAnswers { get; set; }
    }
}
