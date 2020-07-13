using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IPaymentInstrumentRepository
    {
        List<PaymentInstrument> GetPaymentInstrumentsForPayment(long medicalVendorPaymentId);
        List<PaymentInstrument> GetPaymentInstrumentsForInvoice(long medicalVendorInvoiceId);

        List<PaymentInstrument> GetPaymentInstrumentsForOrder(long orderId);
    }
}