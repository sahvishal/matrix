using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IPaymentInstructionRepository
    {
        PaymentInstructions Save(PaymentInstructions paymentInstruction);
        PaymentInstructions Get(long id);
    }
}
