using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    // NOTE: Check is not a 'PaymentInstrument' semantically.
    // A Check is only a PaymentInstrument to maintain backwards compatability with the Medical Vendor Payment system.
    // Scott & Yasir
    public class CheckPayment : PaymentInstrument
    {
        public long CheckId { get; set; }
        public Check Check { get; set; }
        public CheckPaymentStatus CheckStatus { get; set; }

        public override PaymentType PaymentType
        {
            get { return PaymentType.Check; }
        }
    }
}