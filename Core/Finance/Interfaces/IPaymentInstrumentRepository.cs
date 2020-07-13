using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IPaymentInstrumentRepository
    {
        IEnumerable<PaymentInstrument> GetByPaymentId(long paymentId);
        IEnumerable<PaymentInstrument> GetByPaymentIds(IEnumerable<long> paymentIds);

        PaymentType PaymentType { get; }

        PaymentInstrument SavePaymentInstrument(PaymentInstrument paymentInstrument);
    }
}