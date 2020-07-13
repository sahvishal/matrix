using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.ViewModels;


namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IPaymentRepository : IUniqueItemRepository<Finance.Domain.Payment>
    {
        List<Finance.Domain.Payment> GetByOrderId(long orderId);
        List<long> GetPaymentsForEvent(long eventId);
        IEnumerable<OrderedPair<long, long>> GetOrderPaymentOrderedPairbyPaymentIds(IEnumerable<long> paymentIds);
        IEnumerable<DeferredRevenueViewModel> GetEventWiseRevenueDetails(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, decimal>> GetEventCustomerIdOrderTotalPair(IEnumerable<long> eventCustomerIds);
        IEnumerable<OrderedPair<long, decimal>> GetEventCustomerIdTotalPaymentPair(IEnumerable<long> eventCustomerIds);
        bool UpdatePayment(IEnumerable<Core.Finance.Domain.Payment> payments, long orderId);
    }
}