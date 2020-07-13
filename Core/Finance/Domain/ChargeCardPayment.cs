using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class ChargeCardPayment : PaymentInstrument
    {
        public long ChargeCardId { get; set; }
        public string ProcessorResponse { get; set; }
        public ChargeCardPaymentStatus ChargeCardPaymentStatus { get; set; }

        public override PaymentType PaymentType
        {
            get { return PaymentType.CreditCard; }
        }

        public ChargeCardPayment()
        {}

        public ChargeCardPayment(long id)
            : base(id)
        {}
    }
}