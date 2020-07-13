using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public abstract class PaymentInstrument : DomainObjectBase
    {
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public decimal Amount { get; set; }
        public abstract PaymentType PaymentType { get; }
        public long PaymentId { get; set; }

        protected PaymentInstrument()
        {}

        protected PaymentInstrument(long paymentInstrumentId)
            : base(paymentInstrumentId)
        {}
    }
}