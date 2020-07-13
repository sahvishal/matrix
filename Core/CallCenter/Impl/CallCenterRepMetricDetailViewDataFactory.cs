using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallCenter.Impl
{
    public class CallCenterRepMetricDetailViewDataFactory : ICallCenterRepMetricDetailViewDataFactory
    {
        public List<CallCenterRepMetricDetailViewData> CreateCallCenterRepMetricDetailViewData(List<EventCustomerRegistrationViewData> eventCustomers,
            List<Order> orders, CallCenterRep callCenterRep)
        {
            var callCenterRepMetricDetailViewData = new List<CallCenterRepMetricDetailViewData>();

            foreach (var eventCustomer in eventCustomers)
            {
                var aggregate = eventCustomer;

                Order currentOrder = null;
                foreach (var order in orders)
                {
                    if (order.OrderDetails.Any(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) && od.IsCompleted))
                    {
                        var activeOrderDetail =
                            order.OrderDetails.SingleOrDefault(
                                od =>
                                (od.DetailType == OrderItemType.EventPackageItem ||
                                 od.DetailType == OrderItemType.EventTestItem) && od.IsCompleted &&
                                od.EventCustomerOrderDetail != null);

                        if (activeOrderDetail != null && activeOrderDetail.EventCustomerOrderDetail != null && 
                            activeOrderDetail.EventCustomerOrderDetail.EventCustomerId == aggregate.EventCustomerId)
                            currentOrder = order;
                    }
                }
                var callCenterRepMetricDetailViewDatum = CreateCallCenterRepMetricDetailViewDatum(aggregate,
                                                                                                  currentOrder,
                                                                                                  callCenterRep);
                callCenterRepMetricDetailViewData.Add(callCenterRepMetricDetailViewDatum);
            }

            return callCenterRepMetricDetailViewData;
        }

        public CallCenterRepMetricDetailViewData CreateCallCenterRepMetricDetailViewDatum(EventCustomerRegistrationViewData eventCustomer,
            Order order, CallCenterRep callCenterRep)
        {
            // It is a cancelled record.
            if (order == null || !order.OrderDetails.Any(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) && od.IsCompleted))
                order = null;
            
            var amount = order != null ? order.DiscountedTotal : 0m;
            var isPrePaid = order != null && order.TotalAmountPaid >= order.DiscountedTotal;

            var paymentDate = isPrePaid && order.DataRecorderMetaData != null
                                  ? (DateTime?) order.DataRecorderMetaData.DateCreated
                                  : null;

            var packageName = eventCustomer.PackageName;
            packageName = !string.IsNullOrEmpty(packageName)
                              ? !string.IsNullOrEmpty(eventCustomer.AdditinalTest)
                                    ? packageName + ", " + eventCustomer.AdditinalTest
                                    : packageName
                              : eventCustomer.AdditinalTest;


            return new CallCenterRepMetricDetailViewData
                       {
                           EventSignUp = eventCustomer.EventSignupDate,
                           EventDate = eventCustomer.EventDate,
                           Customer =
                               eventCustomer.FirstName + " " +
                               eventCustomer.LastName,
                           AttendedState =
                               eventCustomer.EventDate > DateTime.Now
                                   ? "Scheduled"
                                   : "Attended",
                           CustomerId = eventCustomer.CustomerId,
                           Package = packageName,
                           EventId = eventCustomer.EventId,
                           Amount = amount,
                           CallCenterRep = callCenterRep.NameAsString,
                           PaymentDate = paymentDate,
                           IsPrePaid = isPrePaid,
                           CustomerAddress = null
                       };
        }
    }
}
