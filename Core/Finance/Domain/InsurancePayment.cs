using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class InsurancePayment : PaymentInstrument
    {
        public InsurancePayment()
        { }

        public InsurancePayment(long id)
            : base(id)
        { }

        public decimal AmountToBePaid { get; set; }
        public override PaymentType PaymentType
        {
            get { return PaymentType.Insurance; }
        }
    }
}
