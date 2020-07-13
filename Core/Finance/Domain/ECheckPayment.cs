using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    // NOTE: Check is not a 'PaymentInstrument' semantically.
    // A Check is only a PaymentInstrument to maintain backwards compatability with the Medical Vendor Payment system.
    // Scott & Yasir
    public class ECheckPayment : PaymentInstrument
    {
        public Check ECheck { get; set; }
        public long ECheckId { get; set; }

        public string ProcessorResponse { get; set; }
        public ECheckPaymentStatus ECheckPaymentStatus { get; set; }

        public override PaymentType PaymentType
        {
            get { return PaymentType.ElectronicCheck; }
        }
    }
}