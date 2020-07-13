using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Users.Repositories;

namespace Falcon.App.Infrastructure.Factories.Events
{
    [DefaultImplementation]
    public class EventMetricsViewDataFactory : IEventMetricsViewDataFactory
    {
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository = new OrganizationRoleUserRepository();
        private readonly IEventCustomerRepository _eventCustomerRepository = new EventCustomerRepository();
        private readonly IRoleRepository _roleRepository = new RoleRepository();

        public EventMetricsViewData CreateEventMetricsViewData(IEnumerable<Core.Finance.Domain.Order> orders, IEnumerable<EventPackage> eventPackages,
            IEnumerable<EventTest> eventTests, OrganizationRoleUser organizationRoleUser, IEnumerable<EventCustomer> eventCustomers)
        {
            var eventMetricsViewData = new EventMetricsViewData();

            var eventTestIdAndCountPairs = new List<OrderedPair<long, int>>();
            foreach (var order in orders)
            {
                //TODO: move this code in proper place
                var activeOrderDetail = new OrderController().GetActiveOrderDetail(order);
                long eventCustomerId = 0;
                eventCustomerId = activeOrderDetail != null
                                      ? activeOrderDetail.EventCustomerOrderDetail.EventCustomerId
                                      : 0;
                var eventCustomer = eventCustomers.SingleOrDefault(ec => ec.Id == eventCustomerId);



                var noShow = eventCustomer != null ? eventCustomer.NoShow : false;

                // The count is not applicable for no show customers.
                //if (noShow) return;

                eventMetricsViewData.RegisteredCustomersCount++;
                // It means the order is cancelled.
                if (eventCustomer == null || !eventCustomer.AppointmentId.HasValue)
                {
                    eventMetricsViewData.CancelledCustomersCount++;
                    continue;
                }

                eventMetricsViewData.PaidCustomersCount += order.DiscountedTotal <= order.TotalAmountPaid ? 1 : 0;

                //CreatePaymentModeMetrics(eventMetricsViewData, order, noShow);

                CreateRevenueMetrics(eventMetricsViewData, order, noShow);

                //CreateChangeOrderMetrics(eventMetricsViewData, order, organizationRoleUser);

                var eventPackageId =
                    order.OrderDetails.Where(od =>
                        od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess &&
                        od.OrderItem.OrderItemType == OrderItemType.EventPackageItem).Select(od => od.OrderItem.ItemId).
                        SingleOrDefault();

                var eventTestIds =
                    order.OrderDetails.Where(od =>
                                             od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess &&
                                             od.OrderItem.OrderItemType == OrderItemType.EventTestItem).Select(
                                                 od => od.OrderItem.ItemId).ToArray();

                var eventPackage = eventPackages.Where(ep => ep.Id == eventPackageId).SingleOrDefault();

                if (eventPackage != null)
                {
                    eventTestIds = eventTestIds.Concat(eventPackage.Tests.Select(t => t.Id)).ToArray();
                }

                foreach (var eventTestId in eventTestIds)
                {
                    var inList = eventTestIdAndCountPairs.Find(p => p.FirstValue == eventTestId);
                    if (inList != null) inList.SecondValue++;
                    else eventTestIdAndCountPairs.Add(new OrderedPair<long, int>(eventTestId, 1));
                }
            }

            eventMetricsViewData.TestOrderedPair =
                eventTestIdAndCountPairs.Select(et => new OrderedPair<string, int>(eventTests.Where(t => t.Id == et.FirstValue).Select(t => t.Test.Name).SingleOrDefault(), et.SecondValue));

            return eventMetricsViewData;
        }

        private void CreateChangeOrderMetrics(EventMetricsViewData eventMetricsViewData,
            Core.Finance.Domain.Order order, OrganizationRoleUser organizationRoleUser)
        {
            // It means the order has been changed, so either downgrade or upgrade will occur for such cases only.
            if (order.DiscountedTotal == order.TotalAmountPaid && order.OrderDetails.Count > 1)
            {
                order.OrderDetails.ForEach(od =>
                                               {
                                                   od.DataRecorderMetaData.DateCreated =
                                                       od.DataRecorderMetaData.DateCreated.GetDateWithDifferentTime(
                                                           od.DataRecorderMetaData.DateCreated.Hour,
                                                           od.DataRecorderMetaData.DateCreated.Minute,
                                                           od.DataRecorderMetaData.DateCreated.Second);
                                                   if (od.Price < 0) od.Price = 0;
                                               });
                Func<OrderDetail, decimal> amountOfDiscount = od => od.SourceCodeOrderDetail == null ? 0 : od.SourceCodeOrderDetail.Amount;
                var dateCreatedGroups = order.OrderDetails.GroupBy(od => od.DataRecorderMetaData.DateCreated).Select(
                    g =>
                    new
                        {
                            g.Key,
                            TotalValue = g.Sum(od => (od.Price * od.Quantity) - (amountOfDiscount(od))),
                            AvailedValue = g.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess
                                //EventPackageItemStatus.Availed || od.OrderItemStatus == EventTestItemStatus.Availed
                                                         ).Sum(
                        od => ((od.Price * od.Quantity) - amountOfDiscount(od))),
                            CreatorId = g.Select(od => od.DataRecorderMetaData.DataRecorderCreator.Id).ToList()
                        }).ToList();

                var availedPriceToBeAddedToNextGroup = 0m;

                for (int counter = 0; counter < (dateCreatedGroups.Count - 1); counter++)
                {
                    var changedOrderDetailOrganizationRoleUser =
                        _organizationRoleUserRepository.GetOrganizationRoleUser(
                            dateCreatedGroups[counter + 1].CreatorId.LastOrDefault());

                    var originalOrderDetailSum = dateCreatedGroups[counter].TotalValue +
                                                 availedPriceToBeAddedToNextGroup;
                    availedPriceToBeAddedToNextGroup += dateCreatedGroups[counter].AvailedValue;

                    var changedOrderDetailSum = dateCreatedGroups[counter + 1].TotalValue +
                                                availedPriceToBeAddedToNextGroup;

                    if (changedOrderDetailSum == 0) continue;

                    var roleId = GetParentRoleIdByRoleId(organizationRoleUser.RoleId);

                    if (roleId == (int)Roles.Technician)
                    {
                        if (GetParentRoleIdByRoleId(changedOrderDetailOrganizationRoleUser.RoleId) == (int)Roles.Technician)
                        {
                            if (originalOrderDetailSum > changedOrderDetailSum)
                            {
                                eventMetricsViewData.DownGradePaymentCount++;
                                eventMetricsViewData.DownGradePayments += originalOrderDetailSum - changedOrderDetailSum;
                            }
                            if (originalOrderDetailSum < changedOrderDetailSum)
                            {
                                eventMetricsViewData.UpGradePaymentCount++;
                                eventMetricsViewData.UpGradePayments += changedOrderDetailSum - originalOrderDetailSum;
                            }
                        }
                    }
                    else
                    {
                        if (originalOrderDetailSum > changedOrderDetailSum)
                        {
                            eventMetricsViewData.DownGradePaymentCount++;
                            eventMetricsViewData.DownGradePayments += originalOrderDetailSum - changedOrderDetailSum;
                        }
                        if (originalOrderDetailSum < changedOrderDetailSum)
                        {
                            eventMetricsViewData.UpGradePaymentCount++;
                            eventMetricsViewData.UpGradePayments += changedOrderDetailSum - originalOrderDetailSum;
                        }
                    }
                }
            }
        }

        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }

        private void CreatePaymentModeMetrics(EventMetricsViewData eventMetricsViewData,
            Core.Finance.Domain.Order order, bool noShow)
        {
            var organizationRoleUserCreator =
                _organizationRoleUserRepository.GetOrganizationRoleUser(order,
                                                                        o =>
                                                                        o.DataRecorderMetaData.DataRecorderCreator.Id);
            // If the customer is noShow and Unpiad the count remain same.
            if (noShow || order.DiscountedTotal != order.TotalAmountPaid) return;

            var roleId = GetParentRoleIdByRoleId(organizationRoleUserCreator.RoleId);

            if (roleId == (int)Roles.CallCenterRep)
            {
                eventMetricsViewData.PhonePayments += order.DiscountedTotal;
                eventMetricsViewData.PhonePaymentCount++;
            }
            else if (roleId == (int)Roles.Technician)
            {
                eventMetricsViewData.OnsitePaymentCount++;
                eventMetricsViewData.OnsitePayments += order.DiscountedTotal;
            }
            else if (roleId == (int)Roles.Customer)
            {
                eventMetricsViewData.InternetPaymentCount++;
                eventMetricsViewData.InternetPayments += order.DiscountedTotal;
            }
        }

        private void CreateRevenueMetrics(EventMetricsViewData eventMetricsViewData, Core.Finance.Domain.Order order, bool noShow)
        {

            if (order.DiscountedTotal > order.TotalAmountPaid)
            {
                eventMetricsViewData.UnPaidCount++;
                eventMetricsViewData.UnPaidRevenue += order.DiscountedTotal - order.TotalAmountPaid;
                if (!noShow)
                {
                    eventMetricsViewData.UnPaidExcluedeNoShowCount++;
                    eventMetricsViewData.UnPaidExcluedeNoShowRevenue += order.DiscountedTotal - order.TotalAmountPaid;
                }
            }

            //if (order.PaymentsApplied.Any(pa => pa.PaymentType == PaymentType.CreditCard))
            //{
            //    var chargeCardPayment = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.CreditCard);
            //    //eventMetricsViewData.ChargeCardCount += chargeCardPayment.Count();
            //    eventMetricsViewData.ChargeCardCount++;
            //    eventMetricsViewData.ChargeCardRevenue += chargeCardPayment.Sum(ccp => ccp.Amount);
            //}
            //if (order.PaymentsApplied.Any(pa => pa.PaymentType == PaymentType.Check))
            //{
            //    var checkPayment = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.Check);
            //    //eventMetricsViewData.CheckCount += checkPayment.Count();
            //    eventMetricsViewData.CheckCount++;
            //    eventMetricsViewData.CheckRevenue += checkPayment.Sum(ccp => ccp.Amount);
            //}
            //if (order.PaymentsApplied.Any(pa => pa.PaymentType == PaymentType.ElectronicCheck))
            //{
            //    var eCheckPayment = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.ElectronicCheck);
            //    //eventMetricsViewData.ECheckCount += eCheckPayment.Count();
            //    eventMetricsViewData.ECheckCount++;
            //    eventMetricsViewData.ECheckRevenue += eCheckPayment.Sum(ccp => ccp.Amount);
            //}
            //if (order.PaymentsApplied.Any(pa => pa.PaymentType == PaymentType.Cash))
            //{
            //    var cashPayment = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.Cash);
            //    //eventMetricsViewData.CashCount += cashPayment.Count();
            //    eventMetricsViewData.CashCount++;
            //    eventMetricsViewData.CashRevenue += cashPayment.Sum(ccp => ccp.Amount);
            //}
            //if (order.PaymentsApplied.Any(pa => pa.PaymentType == PaymentType.GiftCertificate))
            //{
            //    var giftCertificatePayment =
            //        order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.GiftCertificate);
            //    //eventMetricsViewData.GiftCertificateCount += giftCertificatePayment.Count();
            //    eventMetricsViewData.GiftCertificateCount++;
            //    eventMetricsViewData.GiftCertificateRevenue += giftCertificatePayment.Sum(ccp => ccp.Amount);
            //}
            //eventMetricsViewData.TotalRevenue += order.DiscountedTotal;

        }
    }
}