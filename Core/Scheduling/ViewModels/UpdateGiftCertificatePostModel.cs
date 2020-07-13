using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class UpdateGiftCertificatePostModel
    {
        public long EventCustomerId { get; set; }
        public bool IsGiftCertificateDelivered { get; set; }
        public string GiftCode { get; set; }
        public long GcNotGivenReasonId { get; set; }
    }
}
