using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IPaymentViewDataFactory
    {
        PaymentViewData Create(PaymentInstrument paymentInstrument);
        PaymentViewData Create(long paymentId);
    }
}