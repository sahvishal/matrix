using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class ParticipationConsentSignatureModel
    {
        public long EventCustomerId { get; set; }

        public string SignatureBytes { get; set; }
        
        public string InsuranceSignatureBytes { get; set; }
    }
}
