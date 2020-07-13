using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class CashPayment : PaymentInstrument
    {
        public CashPayment()
        {}

        public CashPayment(long id)
            : base(id)
        {}

        public override PaymentType PaymentType
        {
            get { return PaymentType.Cash; }
        }
    }
}