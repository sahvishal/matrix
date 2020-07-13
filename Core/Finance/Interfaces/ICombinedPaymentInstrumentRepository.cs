using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface ICombinedPaymentInstrumentRepository
    {
        IEnumerable<PaymentInstrument> GetByPaymentId(long paymentId);
        IEnumerable<PaymentInstrument> GetByPaymentId(List<long> paymentIds);
        IEnumerable<PaymentInstrument> GetByOrderId(long orderId);
        void SavePaymentInstrument(PaymentInstrument paymentInstrument);
        void SavePaymentInstruments(IEnumerable<PaymentInstrument> paymentInstruments);
    }
}