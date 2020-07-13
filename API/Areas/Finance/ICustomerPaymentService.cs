using API.Areas.Finance.Models;

namespace API.Areas.Finance
{
    public interface ICustomerPaymentService
    {
        PaymentViewModel Get(long customerId, long eventId);
        bool ProcessPayment(PaymentEditModel model);
    }
}
