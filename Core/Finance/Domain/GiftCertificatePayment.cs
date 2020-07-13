using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class GiftCertificatePayment : PaymentInstrument
    {
        public long GiftCertificateId { get; set; }

        public override PaymentType PaymentType
        {
            get { return PaymentType.GiftCertificate; }
        }
    }
}