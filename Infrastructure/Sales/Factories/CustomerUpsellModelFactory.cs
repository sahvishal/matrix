using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    [DefaultImplementation]
    public class CustomerUpsellModelFactory : ICustomerUpsellModelFactory
    {
        public CustomerUpsellListModel Create(IEnumerable<Order> orders, IEnumerable<EventBasicInfoViewModel> eventListModel, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, 
            IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, string>> products, IEnumerable<OrderedPair<long, string>> agents)
        {
            var model = new CustomerUpsellListModel();
            var customerUpsellModels = new List<CustomerUpsellModel>();

            orders.ToList().ForEach(o =>
                                        {
                                            var customer = customers.FirstOrDefault(c => c.CustomerId == o.CustomerId);

                                            var eventModel = eventListModel.FirstOrDefault(e => e.Id == o.EventId.Value);

                                            var eventCustomer = new CustomerUpsellModel
                                                               {
                                                                   CustomerId = customer.CustomerId,
                                                                   CustomerCode = customer.CustomerId,
                                                                   EventDate = eventModel.EventDate,
                                                                   Name = customer.Name,
                                                                   Pod = eventModel.PodNames()
                                                               };

                                            Associate(eventCustomer, o, packages, tests, products, agents);

                                            customerUpsellModels.Add(eventCustomer);
                                        });

            model.Collection = customerUpsellModels;
            return model;
        }

        private void Associate(CustomerUpsellModel model, Order order, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests,
            IEnumerable<OrderedPair<long, string>> products, IEnumerable<OrderedPair<long, string>> agents)
        {
            var previousCompositionofOrderItems = GetPreviousSuccesfulCompositionofOrderDetails(order);

            var newValidCompositionofOrderItems = order.OrderDetails.Where(
                od =>
                od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess).ToList();

            model.ScheduledCost = previousCompositionofOrderItems.Sum(od => od.Price);
            model.RevisedCost = newValidCompositionofOrderItems.Sum(od => od.Price);

            var orgRoleUserId = order.OrderDetails.LastOrDefault().DataRecorderMetaData.DataRecorderCreator.Id;
            model.ChangingAgent = agents.Where(a => a.FirstValue == orgRoleUserId).FirstOrDefault().SecondValue;

            model.ScheduledPackage = GetPurchasedProductName(previousCompositionofOrderItems, packages, tests, products);
            model.EventPackage = GetPurchasedProductName(newValidCompositionofOrderItems, packages, tests, products);
        }

        public IEnumerable<OrderDetail> GetPreviousSuccesfulCompositionofOrderDetails(Order order)
        {
            order.OrderDetails.ForEach(od => od.DataRecorderMetaData.DateCreated = Convert.ToDateTime(od.DataRecorderMetaData.DateCreated.ToString("MM/dd/yyyy hh:mm")));
            order.OrderDetails = order.OrderDetails.OrderBy(od => od.Id).ToList();
            var dates = order.OrderDetails.Select(od => od.DataRecorderMetaData.DateCreated).Distinct().OrderByDescending(d => d).ToArray();

            //Picks up the second in list, as is ordered by descending and second means previous order change date
            if (dates.Count() < 2)
                return null;

            var lastOrderDetailwithCancelledStatus =
                order.OrderDetails.Where(od => od.DataRecorderMetaData.DateCreated == dates[1]).LastOrDefault();

            if(lastOrderDetailwithCancelledStatus == null) return null;

            var previousCompositionofOrderItems =
                order.OrderDetails.Where(
                    od =>
                    (od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess ||
                    (od.OrderItemStatus.OrderStatusState == OrderStatusState.Initial && od.DataRecorderMetaData.DateCreated == lastOrderDetailwithCancelledStatus.DataRecorderMetaData.DateCreated)) &&
                    od.Id < lastOrderDetailwithCancelledStatus.Id).ToList();

            previousCompositionofOrderItems.Add(lastOrderDetailwithCancelledStatus);

            return previousCompositionofOrderItems;
        }

        private static string GetPurchasedProductName(IEnumerable<OrderDetail> orderDetails, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> testOrderPair,
            IEnumerable<OrderedPair<long, string>> products)
        {
            var eventPackageId = orderDetails.Where(od => od.DetailType == OrderItemType.EventPackageItem).Select(od => od.OrderItem.ItemId).LastOrDefault();
            var eventTestIds = orderDetails.Where(od => od.DetailType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId).ToArray();
            var productItemIds = orderDetails.Where(od => od.DetailType == OrderItemType.ProductItem).Select(od => od.OrderItemId).ToList();
            var package = packages.Where(p => eventPackageId == p.FirstValue).SingleOrDefault();

            string packageString = string.Empty;

            if (package != null) packageString = package.SecondValue;

            var tests = testOrderPair.Where(t => eventTestIds.Contains(t.FirstValue)).Select(t => t.SecondValue).ToArray();
            if (tests.Count() > 0)
                packageString = (!string.IsNullOrEmpty(packageString) ? (packageString + " + ") : packageString) + string.Join(" + ", tests);

            if (!productItemIds.IsNullOrEmpty())
                packageString = packageString + " (" + string.Join(", ", products.Where(p => productItemIds.Contains(p.FirstValue)).Select(p => p.SecondValue)) + ")";

            return packageString;
        }

    }
}
