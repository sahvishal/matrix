namespace Falcon.App.Core.Medical.ViewModels
{
    public class ParticipationConsentModel
    {
        public string SignatureImageUrl { get; set; }
        public string ConsentSignedDate { get; set; }

        public string InsuranceSignatureImageUrl { get; set; }
        public string InsuranceConsentSignedDate { get; set; }
    }
}
