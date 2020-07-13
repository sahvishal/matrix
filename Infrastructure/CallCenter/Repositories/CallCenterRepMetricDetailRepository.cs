using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    public class CallCenterRepMetricDetailRepository : PersistenceRepository, ICallCenterRepMetricDetailRepository
    {

        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private readonly IOrderController _orderController = new OrderController();
        private readonly IRoleRepository _roleRepository = new RoleRepository();

        public CallCenterRepMetricDetailRepository()
        { }

        public CallCenterRepMetricDetailRepository(DateTime startDate, DateTime endDate)
            : this(0, startDate, endDate)
        { }

        public CallCenterRepMetricDetailRepository(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            
        }


        private CcrepMetricesTypedView GetCCRepMetricesTypedView(DateTime startDate, DateTime endDate)
        {
            var typedView = new CcrepMetricesTypedView();

            IRelationPredicateBucket predicateBucket = new RelationPredicateBucket(CcrepMetricesFields.RegisteredDate >= startDate);
            predicateBucket.PredicateExpression.AddWithAnd(CcrepMetricesFields.RegisteredDate <= endDate);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(typedView, predicateBucket, false);
            }

            return typedView;
        }


        public List<long> GetBookedEventCustomersByCallCenterRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            var ccRepMetricesTypedView = GetCCRepMetricesTypedView(startDate, endDate);

            var eventCustomerIds =
                ccRepMetricesTypedView.Where(c => c.OrganizationRoleUserId == callCenterCallCenterUserId).Select(
                    c => c.EventCustomerId).Distinct().ToList();

            return eventCustomerIds;

        }

        public List<OrderedPair<long, List<long>>> GetSpouseBookingEventCustomerPairs(long callCenterRepId,
            DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
            

            #region "Dead Code"
            //using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            //{
            //    var linqMetaData = new LinqMetaData(myAdapter);

            //    var orderDetailIdsWithNoPrice = GetTotalPackagePriceDiscountedOrderDetails(startDate, endDate);

            //    var customersForCallCenterRep = (from o in linqMetaData.Order
            //                                     join od in linqMetaData.OrderDetail on o.OrderId equals
            //                                         od.OrderId
            //                                     join ecod in linqMetaData.EventCustomerOrderDetail on
            //                                         od.OrderDetailId equals ecod.OrderDetailId
            //                                     join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals
            //                                         ec.EventCustomerId
            //                                     join oru in linqMetaData.OrganizationRoleUser on
            //                                         o.OrganizationRoleUserCreatorId equals oru.OrganizationRoleUserId
            //                                     join ccccu in linqMetaData.CallCenterCallCenterUser on oru.ShellId
            //                                         equals ccccu.CallCenterId
            //                                     join ccu in linqMetaData.CallCenterUser on ccccu.CallCenterUserId
            //                                         equals
            //                                         ccu.CallCenterUserId
            //                                     join c in linqMetaData.Customers on ec.CustomerId equals c.CustomerId
            //                                     join u in linqMetaData.User on c.UserId equals u.UserId
            //                                     join a in linqMetaData.Address on u.HomeAddressId equals a.AddressId
            //                                     where
            //                                         ecod.IsActive && !ec.NoShow && ec.AppointmentId.HasValue &&
            //                                         !orderDetailIdsWithNoPrice.Contains(od.OrderDetailId) &&
            //                                         o.DateCreated >= startDate && o.DateCreated <= endDate &&
            //                                         ec.DateCreated >= startDate && ec.DateCreated <= endDate &&
            //                                         oru.RoleId == ccccu.RoleId && ccccu.IsActive && ccu.IsActive &&
            //                                         ccu.UserId == oru.UserId &&
            //                                         ccccu.CallCenterCallCenterUserId == callCenterCallCenterUserId
            //                                     select new
            //                                                {
            //                                                    c.CustomerId,
            //                                                    ec.EventCustomerId,
            //                                                    o.DateCreated,
            //                                                    AnonymousAddress = new
            //                                                                           {
            //                                                                               Address1 =
            //                                         a.Address1.ToLower(),
            //                                                                               Address2 =
            //                                         a.Address2.ToLower(),
            //                                                                               a.CityId,
            //                                                                               a.StateId,
            //                                                                               a.ZipId
            //                                                                           }
            //                                                }).ToList();

            //    var allCustomers = (from o in linqMetaData.Order
            //                        join od in linqMetaData.OrderDetail on o.OrderId equals
            //                            od.OrderId
            //                        join ecod in linqMetaData.EventCustomerOrderDetail on
            //                            od.OrderDetailId equals ecod.OrderDetailId
            //                        join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals
            //                            ec.EventCustomerId
            //                        join c in linqMetaData.Customers on ec.CustomerId equals c.CustomerId
            //                        join u in linqMetaData.User on c.UserId equals u.UserId
            //                        join a in linqMetaData.Address on u.HomeAddressId equals a.AddressId
            //                        where
            //                            ecod.IsActive && !ec.NoShow && ec.AppointmentId.HasValue &&
            //                            !orderDetailIdsWithNoPrice.Contains(od.OrderDetailId) &&
            //                            o.DateCreated >= startDate && o.DateCreated <= endDate &&
            //                            ec.DateCreated >= startDate && ec.DateCreated <= endDate
            //                        select new
            //                                   {
            //                                       c.CustomerId,
            //                                       ec.EventCustomerId,
            //                                       o.DateCreated,
            //                                       AnonymousAddress = new
            //                                                              {
            //                                                                  Address1 = a.Address1.ToLower(),
            //                                                                  Address2 = a.Address2.ToLower(),
            //                                                                  a.CityId,
            //                                                                  a.StateId,
            //                                                                  a.ZipId
            //                                                              }
            //                                   }).ToList();


            //    var spouseGroups =
            //        customersForCallCenterRep.GroupJoin(allCustomers, c => c.AnonymousAddress, ac => ac.AnonymousAddress,
            //                                            (mainCustomer, spouseCustomers) =>
            //                                            new
            //                                            {
            //                                                OwnerId = mainCustomer.EventCustomerId,
            //                                                SpouseIds =
            //                                            spouseCustomers.Where(
            //                                            sc =>
            //                                            sc.CustomerId != mainCustomer.CustomerId &&
            //                                            sc.DateCreated > mainCustomer.DateCreated).Select(
            //                                            sc => sc.EventCustomerId).ToList()
            //                                            }).ToList();

            //    var spousePairs =
            //        spouseGroups.Select(sg => new OrderedPair<long, List<long>>(sg.OwnerId, sg.SpouseIds)).ToList();
            //    spousePairs.RemoveAll(sp => sp.SecondValue.IsNullOrEmpty());

            //    return spousePairs;
            //}
            #endregion

        }

        public List<OrderedPair<long, List<long>>> GetAllSpouseEventCustomerPairs(long callCenterCallCenterUserId,
            DateTime startDate, DateTime endDate)
        {
            // Will be revivied, currently commenting the exisiting code. being very complicated it needs to be rewritten.
            #region "Old Code"
            //using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            //{
            //    var linqMetaData = new LinqMetaData(myAdapter);

            //    var orderDetailIdsWithNoPrice = GetTotalPackagePriceDiscountedOrderDetails(startDate, endDate);

            //    var customersForCallCenterRep = (from o in linqMetaData.Order
            //                                     join od in linqMetaData.OrderDetail on o.OrderId equals
            //                                         od.OrderId
            //                                     join ecod in linqMetaData.EventCustomerOrderDetail on
            //                                         od.OrderDetailId equals ecod.OrderDetailId
            //                                     join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals
            //                                         ec.EventCustomerId
            //                                     join oru in linqMetaData.OrganizationRoleUser on
            //                                         o.OrganizationRoleUserCreatorId equals oru.OrganizationRoleUserId
            //                                     join ccccu in linqMetaData.CallCenterCallCenterUser on oru.OrganizationId // TODO: SRE (Hack to resolve build) oru.ShellId
            //                                         equals ccccu.CallCenterId
            //                                     join ccu in linqMetaData.CallCenterUser on ccccu.CallCenterUserId
            //                                         equals
            //                                         ccu.CallCenterUserId
            //                                     join c in linqMetaData.Customers on ec.CustomerId equals c.CustomerId
            //                                     join u in linqMetaData.User on c.UserId equals u.UserId
            //                                     join a in linqMetaData.Address on u.HomeAddressId equals a.AddressId
            //                                     where
            //                                         !orderDetailIdsWithNoPrice.Contains(od.OrderDetailId) &&
            //                                         o.DateCreated >= startDate && o.DateCreated <= endDate &&
            //                                         ec.DateCreated >= startDate && ec.DateCreated <= endDate &&
            //                                         oru.RoleId == ccccu.RoleId && ccccu.IsActive && ccu.IsActive &&
            //                                         ccu.UserId == oru.UserId &&
            //                                         ccccu.CallCenterCallCenterUserId == callCenterCallCenterUserId
            //                                     select new
            //                                                {
            //                                                    c.CustomerId,
            //                                                    ec.EventCustomerId,
            //                                                    o.DateCreated,
            //                                                    AnonymousAddress = new
            //                                                                           {
            //                                                                               Address1 =
            //                                         a.Address1.ToLower(),
            //                                                                               Address2 =
            //                                         a.Address2.ToLower(),
            //                                                                               a.CityId,
            //                                                                               a.StateId,
            //                                                                               a.ZipId
            //                                                                           }
            //                                                }).ToList();

            //    var allCustomers = (from o in linqMetaData.Order
            //                        join od in linqMetaData.OrderDetail on o.OrderId equals
            //                            od.OrderId
            //                        join ecod in linqMetaData.EventCustomerOrderDetail on
            //                            od.OrderDetailId equals ecod.OrderDetailId
            //                        join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals
            //                            ec.EventCustomerId
            //                        join c in linqMetaData.Customers on ec.CustomerId equals c.CustomerId
            //                        join u in linqMetaData.User on c.UserId equals u.UserId
            //                        join a in linqMetaData.Address on u.HomeAddressId equals a.AddressId
            //                        where
            //                            !orderDetailIdsWithNoPrice.Contains(od.OrderDetailId) &&
            //                            o.DateCreated >= startDate && o.DateCreated <= endDate &&
            //                            ec.DateCreated >= startDate && ec.DateCreated <= endDate
            //                        select new
            //                                   {
            //                                       c.CustomerId,
            //                                       ec.EventCustomerId,
            //                                       o.DateCreated,
            //                                       AnonymousAddress = new
            //                                                              {
            //                                                                  Address1 = a.Address1.ToLower(),
            //                                                                  Address2 = a.Address2.ToLower(),
            //                                                                  a.CityId,
            //                                                                  a.StateId,
            //                                                                  a.ZipId
            //                                                              }
            //                                   }).ToList();


            //    var spouseGroups =
            //        customersForCallCenterRep.GroupJoin(allCustomers, c => c.AnonymousAddress, ac => ac.AnonymousAddress,
            //                                            (mainCustomer, spouseCustomers) =>
            //                                            new
            //                                            {
            //                                                OwnerId = mainCustomer.EventCustomerId,
            //                                                SpouseIds =
            //                                            spouseCustomers.Where(
            //                                            sc =>
            //                                            sc.CustomerId != mainCustomer.CustomerId &&
            //                                            sc.DateCreated > mainCustomer.DateCreated).Select(
            //                                            sc => sc.EventCustomerId).ToList()
            //                                            }).ToList();

            //    var spousePairs =
            //        spouseGroups.Select(sg => new OrderedPair<long, List<long>>(sg.OwnerId, sg.SpouseIds)).ToList();
            //    spousePairs.RemoveAll(sp => sp.SecondValue.IsNullOrEmpty());

            //    return spousePairs;
            //}
            #endregion
            throw new NotImplementedException();
        }

        public List<long> GetClosedEventCustomersByCallCenterRep(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            var ccRepMetricesTypedView = GetCCRepMetricesTypedView(startDate, endDate);

            var eventCustomerIds = ccRepMetricesTypedView.Where(c => c.CcrepUserId == c.PaymentRecievedByUserId && GetParentRoleIdByRoleId(c.RoleId) == (long)Roles.CallCenterRep
                            && c.PaymentDate <= c.RegisteredDate.AddHours(1) && c.OrganizationRoleUserId == callCenterCallCenterUserId).
                            Select(c => c.EventCustomerId).Distinct().ToList();

            return eventCustomerIds;

        }

        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }

        public CallCenterRepStatisticsViewData GetBookedEventCustomerStatisticsForCallCenterRep(long callCenterCallCenterUserId,
            DateTime startDate, DateTime endDate)
        {
            List<Core.Finance.Domain.Order> orders =
                 _orderRepository.GetAllOrdersCreatedByCallCenterRep(callCenterCallCenterUserId, startDate, endDate);

            IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();

            int totalCustomers, totalCancelled, totalNoShow, totalAttended;
            totalCustomers = totalCancelled = totalNoShow = totalAttended = 0;

            decimal totalAmount = 0m;

            foreach (var order in orders)
            {
                //It will ignore 100% discounted orders.
                if (GetTotalPackagePriceDiscountPredicate(order))
                    continue;

                totalCustomers++;

                // It will eliminate cancelled records. But add to the the cancelled records.
                if (!order.OrderDetails.Any(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) && od.IsCompleted))
                {
                    totalCancelled++;
                    continue;
                }

                var activeOrderDetail = _orderController.GetActiveOrderDetail(order);

                if (activeOrderDetail != null && activeOrderDetail.EventCustomerOrderDetail != null)
                {
                    var eventCustomer =
                        eventCustomerRepository.GetById(
                            activeOrderDetail.EventCustomerOrderDetail.EventCustomerId);

                    if (eventCustomer.AppointmentId.HasValue && eventCustomer.NoShow)
                    {
                        totalNoShow++;
                        continue;
                    }
                    if (eventCustomer.TestConducted)
                        totalAttended++;
                }
                totalAmount += order.DiscountedTotal;
            }
            return new CallCenterRepStatisticsViewData(totalCustomers, totalCancelled, totalNoShow, totalAttended,
                                                       totalAmount);
        }

        public CallCenterRepStatisticsViewData GetClosedEventCustomerStatisticsForCallCenterRep(long callCenterCallCenterUserId,
            DateTime startDate, DateTime endDate)
        {
            List<Core.Finance.Domain.Order> orders =
                _orderRepository.GetAllOrdersCreatedByCallCenterRep(callCenterCallCenterUserId, startDate, endDate);

            IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();

            int totalCustomers, totalCancelled, totalNoShow, totalAttended;
            totalCustomers = totalCancelled = totalNoShow = totalAttended = 0;

            decimal totalAmount = 0m;

            foreach (var order in orders)
            {
                Core.Finance.Domain.Order currentOrder = order;

                //It will ignore 100% discounted orders.
                if (GetTotalPackagePriceDiscountPredicate(order))
                    continue;

                if (currentOrder != null && !GetReSchedulePredicate(currentOrder) && order.PaymentsApplied.Any(GetClosingCountPredicate(currentOrder)))
                {
                    totalCustomers++;

                    // It will eliminate cancelled records. But add to the the cancelled records.
                    if (!order.OrderDetails.Any(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) && od.IsCompleted))
                    {
                        totalCancelled++;
                        continue;
                    }

                    var activeOrderDetail = _orderController.GetActiveOrderDetail(order);

                    if (activeOrderDetail != null && activeOrderDetail.EventCustomerOrderDetail != null)
                    {
                        var eventCustomer =
                            eventCustomerRepository.GetById(
                                activeOrderDetail.EventCustomerOrderDetail.EventCustomerId);

                        if (eventCustomer.AppointmentId.HasValue && eventCustomer.NoShow)
                        {
                            totalNoShow++;
                            continue;
                        }
                        if (eventCustomer.TestConducted)
                            totalAttended++;
                    }
                    totalAmount += order.DiscountedTotal;
                }
            }
            return new CallCenterRepStatisticsViewData(totalCustomers, totalCancelled, totalNoShow, totalAttended,
                                                                   totalAmount);
        }

        // This method determines if 100% coupon is applied.
        private bool GetTotalPackagePriceDiscountPredicate(Core.Finance.Domain.Order currentOrder)
        {
            var activeOrderDetail = _orderController.GetActiveOrderDetail(currentOrder);
            if (activeOrderDetail != null && activeOrderDetail.SourceCodeOrderDetail != null && ((activeOrderDetail.Price * activeOrderDetail.Quantity) == activeOrderDetail.SourceCodeOrderDetail.Amount))
                return true;
            return false;
        }

        // This method eliminates records which have been rescheduled but not paid after rescheduling.
        private bool GetReSchedulePredicate(Core.Finance.Domain.Order currentOrder)
        {
            return currentOrder.DiscountedTotal > 0 && currentOrder.TotalAmountPaid == 0 &&
                   !GetTotalPackagePriceDiscountPredicate(currentOrder);
        }

        private Func<PaymentInstrument, bool> GetClosingCountPredicate(Core.Finance.Domain.Order currentOrder)
        {
            return pa => pa.DataRecorderMetaData != null
                         && pa.DataRecorderMetaData.DataRecorderCreator.Id == currentOrder.DataRecorderMetaData.DataRecorderCreator.Id
                         && pa.DataRecorderMetaData.DateCreated <= currentOrder.DataRecorderMetaData.DateCreated.AddHours(1)
                         && (pa is ECheckPayment || pa is ChargeCardPayment) && pa.Amount > 0;
        }

        private List<long> GetTotalPackagePriceDiscountedOrderDetails(DateTime startDate, DateTime endDate)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var orderDetailIds = from o in linqMetaData.Order
                                     join od in linqMetaData.OrderDetail on o.OrderId equals od.OrderId
                                     join scod in linqMetaData.SourceCodeOrderDetail on od.OrderDetailId equals
                                         scod.OrderDetailId
                                     where
                                         scod.IsActive && o.DateCreated >= startDate && o.DateCreated <= endDate &&
                                         (od.Price * od.Quantity) <= scod.Amount
                                     select od.OrderDetailId;
                return orderDetailIds.ToList();
            }
        }
    }
}