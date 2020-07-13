using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class GiftCertificateSignatureModel
    {
        public long EventCustomerId { get; set; }

        public bool GiftCardReceived { get; set; }

        public string GiftCardNumber { get; set; }

        public long? GcNotGivenReasonId { get; set; }

        public string PatientSignatureBytes { get; set; }
        
        public string TechnicianSignatureBytes { get; set; }
    }
}
