using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class ApplyGiftCertificateResultModel
    {
        public GiftCertificate GiftCertificate { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
    }
}
