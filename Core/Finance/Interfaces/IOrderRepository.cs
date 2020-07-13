using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Finance.Domain.Order> GetAllOrders(int pageNumber, int pageSize);
        int CountAllOrders();
        
        // TODO: more granular controls necessary -- OrderedPlacedByUser, OrdersVisibleToUser...        
        // maybe move this to infrastructure + add a Func<OrderEntity, bool> parameter
        IEnumerable<Finance.Domain.Order> GetAllOrdersForEvent(long eventId);
        IEnumerable<Finance.Domain.Order> GetAllOrdersForCustomer(long customerId);

        List<Core.Finance.Domain.Order> GetAllOrdersByEventCustomerIds(IEnumerable<long> eventCustomerIds,
                                                                       bool considerCancelled = false);

        Domain.Order GetOrder(long orderId);
        Domain.Order GetOrderByEventCustomerId(long eventCustomerId);
        Domain.Order GetOrder(long customerId, long eventId);
        Domain.Order GetInactiveOrder(long customerId, long eventId);
        List<Domain.Order> GetByIds(IEnumerable<long> orderIds);

        List<Domain.Order> GetAllOrdersCreatedByCallCenterRep(long callCenterCallCenterUserId,
                                                                         DateTime startDate, DateTime endDate);
        List<Domain.Order> GetAllActiveOrdersCreatedByCallCenterRep(long callCenterCallCenterUserId,
                                                                         DateTime startDate, DateTime endDate);

        List<OrderedPair<long, List<Domain.Order>>> GetCallCenterRepActiveOrderPairs(DateTime startDate,
                                                                                          DateTime endDate);
        Domain.Order SaveOrder(Domain.Order orderToSave);

        void ApplyPaymentToOrder(long orderId, long paymentId);

        IEnumerable<Core.Finance.Domain.Order> GetAllUpgradedDowngradedOrders(int pageNumber, int pageSize, Scheduling.ViewModels.CustomerUpsellListModelFilter filter, out int totalRecords);

        IEnumerable<OrderedPair<long, decimal>> GetOrderSumforEventIds(long[] eventIds);
        IEnumerable<OrderedPair<long, long>> GetOrderEventCustomeridPairforOrderIds(IEnumerable<long> orderIds);

        IEnumerable<OrderedPair<long, long>> GetOrderEventCustomerIdPairforEventCustomerIds(
            IEnumerable<long> eventCustomerIds);

        long GetOrderIdByEventCustomerId(long eventCustomerId);
        long GetOrderIdByEventIdCustomerId(long eventId, long customerId);
        IEnumerable<OrderedPair<long, decimal>> GetOpenOrderTotalForEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, decimal>> GetOutstandingRevenueForEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, decimal>> GetNoshowOutstandingRevenueForEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, decimal>> GetCancelledOutstandingRevenueForEventIds(IEnumerable<long> eventIds);
        IEnumerable<OrderedPair<long, decimal>> GetOpenOrderTotalForEventCustomerIds(IEnumerable<long> eventCustomerIds);
        IEnumerable<OrderedPair<long, decimal>> GetOutstandingRevenueForEventCustomerIds(IEnumerable<long> eventCustomerIds);
        IEnumerable<Core.Finance.Domain.Order> GetOrderByOrderIds(IEnumerable<long> orderIds);
    }
}