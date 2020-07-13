using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.Data.Sql;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    // TODO: This repository is now working more as service so probably it should be nuked after moving its methods to appropriate service.
    public class CallCenterRepMetricRepository : PersistenceRepository, ICallCenterRepMetricRepository
    {
        private const string NEW_CUSTOMER_CALL_STATUS = "Register New Customer";
        private const string EXISTING_CUSTOMER_CALL_STATUS = "Existing Customer";
        private readonly List<string> _callStatusesFilter = new List<string> { NEW_CUSTOMER_CALL_STATUS, EXISTING_CUSTOMER_CALL_STATUS };

        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private readonly IOrderController _orderController = new OrderController();
        private readonly IRoleRepository _roleRepository = new RoleRepository();

        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly long _callCenterCallCenterUserId;

        private List<Order> _orders;
        private List<OrderedPair<long, List<Order>>> _orderedPairs;

        public CallCenterRepMetricRepository()
        { }

        public CallCenterRepMetricRepository(DateTime startDate, DateTime endDate)
            : this(0, startDate, endDate)
        { }

        public CallCenterRepMetricRepository(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
            _callCenterCallCenterUserId = callCenterCallCenterUserId;
        }

        public int GetNumberOfCallsForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var numberOfCallsQuery =
                    linqMetaData.Calls.Where(
                        c =>
                        c.CreatedByOrgRoleUserId == callCenterCallCenterUserId && c.TimeCreated >= startDate &&
                        c.TimeCreated <= endDate && _callStatusesFilter.Contains(c.CallStatus) &&
                        c.CalledCustomerId.HasValue && c.CalledCustomerId > 0);

                return numberOfCallsQuery.Count();
            }
        }

        public int GetNumberOfBookingsForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            List<Order> orders = GetAllOrdersCreatedByCallCenterRep(callCenterCallCenterUserId,
                                                                                      startDate, endDate);

            return GetBookingCountFromOrders(orders);
        }

        public int GetNumberOfSpouseBookingsForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfClosingsForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            List<Order> orders = GetAllOrdersCreatedByCallCenterRep(callCenterCallCenterUserId,
                                                                                      startDate, endDate);

            return GetClosingCountFromOrders(orders);
        }

        public decimal GetAverageSaleAmountForRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            List<Order> orders = GetAllOrdersCreatedByCallCenterRep(callCenterCallCenterUserId,
                                                                                      startDate, endDate);

            return GetAverageSalesAmountFromOrders(orders);
        }

        private CcrepMetricesTypedView GetCCRepMetricesTypedView(DateTime startDate, DateTime endDate)
        {
            var typedView = new CcrepMetricesTypedView();

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(CcrepMetricesFields.RegisteredDate >= startDate);
            predicateBucket.PredicateExpression.AddWithAnd(CcrepMetricesFields.RegisteredDate <= endDate);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                DataAccessAdapter.SetArithAbortFlag(true);
                myAdapter.FetchTypedView(typedView, predicateBucket, false);
                DataAccessAdapter.SetArithAbortFlag(false);
            }

            return typedView;
        }

        public List<OrderedPair<long, int>> GetListOfNumberOfCalls(DateTime startDate, DateTime endDate)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var numberOfCallsQuery =
                    linqMetaData.Calls.Where(
                        c =>
                        c.TimeCreated >= startDate && c.TimeCreated <= endDate &&
                        _callStatusesFilter.Contains(c.CallStatus) && c.CalledCustomerId.HasValue &&
                        c.CalledCustomerId > 0).GroupBy(c => c.CreatedByOrgRoleUserId).Select(
                        group => new OrderedPair<long, int>(group.Key, group.Count()));

                return numberOfCallsQuery.ToList();
            }
        }

        public List<OrderedPair<long, int>> GetListOfNumberOfBookings(DateTime startDate, DateTime endDate)
        {
            var ccRepMetricesTypedView = GetCCRepMetricesTypedView(startDate, endDate);
            
            var eventCustomerCCRepUserId =
                ccRepMetricesTypedView.Select(metricesItem => new OrderedPair<long, long>(metricesItem.EventCustomerId, metricesItem.OrganizationRoleUserId))
                    .ToList();

            var distinctEventCustomerCCRepUserId = eventCustomerCCRepUserId.GroupBy(b => new { b.FirstValue, b.SecondValue }).Select(b => b.Key);
            
            var bookingCountPairs = distinctEventCustomerCCRepUserId.GroupBy(ec => ec.SecondValue).Select(ec => new OrderedPair<long, int>(ec.Key, ec.Count())).ToList();

            return bookingCountPairs;

            //var callCenterRepOrderGroups = GetCallCenterRepOrderPairs(startDate, endDate);

            //var bookingCountPairs = new List<OrderedPair<long, int>>();

            //foreach (var callCenterRepOrderGroup in callCenterRepOrderGroups)
            //{
            //    if (callCenterRepOrderGroup != null)
            //    {
            //        bookingCountPairs.Add(new OrderedPair<long, int>(callCenterRepOrderGroup.FirstValue,
            //                                                         GetBookingCountFromOrders(
            //                                                             callCenterRepOrderGroup.SecondValue)));
            //    }
            //}

        }

        public List<OrderedPair<long, int>> GetListOfNumberOfSpouseBookings(DateTime startDate, DateTime endDate)
        {
            return null;
            
        }

        public List<OrderedPair<long, int>> GetListOfNumberOfClosings(DateTime startDate, DateTime endDate)
        {
            var ccRepMetricesTypedView = GetCCRepMetricesTypedView(startDate, endDate);
            var query =
                ccRepMetricesTypedView.Where(
                    c => c.CcrepUserId == c.PaymentRecievedByUserId && GetParentRoleIdByRoleId(c.RoleId) == (long) Roles.CallCenterRep
                         && c.PaymentDate <= c.RegisteredDate.AddHours(1)).GroupBy(c => c.OrderId)
                    .Select(
                        c =>
                        new
                            {
                                OrderId = c.Key,
                                PaymentDifference =
                            c.Sum(a => a.PaidAmount) -
                            (c.Max(a => a.OrderAmount) + c.Max(a => a.ShippingAmount) - c.Max(a => a.DiscountAmount))
                            });

            var orderIds = query.Where(a => a.PaymentDifference == 0).Select(a => a.OrderId).ToArray();

            var eventCustomerCCRepUserId = ccRepMetricesTypedView.Where(c => c.CcrepUserId == c.PaymentRecievedByUserId && GetParentRoleIdByRoleId(c.RoleId) == (long)Roles.CallCenterRep
                            && c.PaymentDate <= c.RegisteredDate.AddHours(1) && orderIds.Contains(c.OrderId)).
                            Select(metricesItem => new OrderedPair<long, long>(metricesItem.EventCustomerId, metricesItem.OrganizationRoleUserId)).ToList();

            var distinctEventCustomerCCRepUserId = eventCustomerCCRepUserId.GroupBy(b => new { b.FirstValue, b.SecondValue }).Select(b => b.Key);


            var closingCountPairs = distinctEventCustomerCCRepUserId.GroupBy(ec => ec.SecondValue).Select(ec => new OrderedPair<long, int>(ec.Key, ec.Count())).ToList();

            return closingCountPairs;
        }

        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }

        public List<OrderedPair<long, decimal>> GetListOfAverageSaleAmounts(DateTime startDate, DateTime endDate)
        {
            var ccRepMetricesTypedView = GetCCRepMetricesTypedView(startDate, endDate);

            var asrListData = ccRepMetricesTypedView.Select(c => new { c.EventCustomerId, c.OrganizationRoleUserId, c.OrderAmount, c.DiscountAmount, c.ShippingAmount }).Distinct().ToList();
            var averageSalesPairs = asrListData.GroupBy(asrData => asrData.OrganizationRoleUserId).Select(a => new OrderedPair<long, decimal>(a.Key, (decimal)a.Sum(b => b.OrderAmount - b.DiscountAmount + b.ShippingAmount) / (decimal)a.Count())).ToList();

            return averageSalesPairs;
        }

        private int GetBookingCountFromOrders(IEnumerable<Order> orders)
        {
            int bookingCount = 0;
            foreach (var order in orders)
            {
                if (order != null)
                {
                    // It will eliminate cancelled and 100% dicounted records.
                    if (!order.OrderDetails.Any(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) && od.IsCompleted) || GetTotalPackagePriceDiscountPredicate(order))
                        continue;

                    bookingCount++;
                }
            }
            return bookingCount;
        }

        private int GetClosingCountFromOrders(IEnumerable<Order> orders)
        {
            int closingCount = 0;

            foreach (var order in orders)
            {
                if (order != null)
                {
                    // It will eliminate cancelled and 100% dicounted records.
                    if (!order.OrderDetails.Any(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) && od.IsCompleted) || GetTotalPackagePriceDiscountPredicate(order))
                        continue;

                    Order currentOrder = order;
                    if (!GetReSchedulePredicate(currentOrder) && order.PaymentsApplied.Where(GetClosingCountPredicate(currentOrder)).Sum(pa => pa.Amount) == order.DiscountedTotal)
                        closingCount++;
                }
            }
            return closingCount;
        }

        private decimal GetAverageSalesAmountFromOrders(IEnumerable<Order> orders)
        {
            decimal totalAmount = 0m;
            int orderCount = 0;
            foreach (var order in orders)
            {
                if (order != null)
                {
                    // It will eliminate cancelled and 100% dicounted records.
                    if (!order.OrderDetails.Any(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) && od.IsCompleted) || GetTotalPackagePriceDiscountPredicate(order))
                        continue;

                    totalAmount += order.DiscountedTotal;
                    orderCount++;
                }
            }

            return totalAmount == 0m || orderCount == 0 ? 0m : totalAmount / orderCount;
        }

        private Func<PaymentInstrument, bool> GetClosingCountPredicate(Order currentOrder)
        {
            return pa => pa.DataRecorderMetaData != null
                         && pa.DataRecorderMetaData.DataRecorderCreator.Id == currentOrder.DataRecorderMetaData.DataRecorderCreator.Id
                         && pa.DataRecorderMetaData.DateCreated <= currentOrder.DataRecorderMetaData.DateCreated.AddHours(1)
                         && (pa is ECheckPayment || pa is ChargeCardPayment) && pa.Amount > 0;
        }

        //// This method eliminates records which have been rescheduled but not paid after rescheduling.
        private bool GetReSchedulePredicate(Order currentOrder)
        {
            return currentOrder.DiscountedTotal > 0 && currentOrder.TotalAmountPaid == 0 &&
                   !GetTotalPackagePriceDiscountPredicate(currentOrder);
        }

        //// This method determines if 100% coupon is applied.
        private bool GetTotalPackagePriceDiscountPredicate(Order currentOrder)
        {
            var activeOrderDetail = _orderController.GetActiveOrderDetail(currentOrder);
            if (activeOrderDetail != null && activeOrderDetail.SourceCodeOrderDetail != null && ((activeOrderDetail.Price * activeOrderDetail.Quantity) == activeOrderDetail.SourceCodeOrderDetail.Amount))
                return true;
            return false;
        }

        //// This method is written for optimization, since we call same method multiple times with same arguments.
        private List<Order> GetAllOrdersCreatedByCallCenterRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            if (startDate != _startDate || endDate != _endDate || callCenterCallCenterUserId != _callCenterCallCenterUserId)
                return _orderRepository.GetAllActiveOrdersCreatedByCallCenterRep(callCenterCallCenterUserId, startDate, endDate);

            if (startDate == _startDate && endDate == _endDate && _callCenterCallCenterUserId == callCenterCallCenterUserId && _orders == null)
                _orders = _orderRepository.GetAllActiveOrdersCreatedByCallCenterRep(callCenterCallCenterUserId, startDate, endDate);

            return _orders;
        }

        //// This method is written for optimization, since we call same method multiple times with same arguments.
        private List<OrderedPair<long, List<Order>>> GetCallCenterRepOrderPairs(DateTime startDate, DateTime endDate)
        {
            if (startDate != _startDate || endDate != _endDate)
                return _orderRepository.GetCallCenterRepActiveOrderPairs(startDate, endDate);

            if (startDate == _startDate && endDate == _endDate && _orderedPairs == null)
                _orderedPairs = _orderRepository.GetCallCenterRepActiveOrderPairs(startDate, endDate);

            return _orderedPairs;
        }
    }
}