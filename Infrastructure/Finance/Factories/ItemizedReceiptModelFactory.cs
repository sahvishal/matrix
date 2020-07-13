using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Finance.Factories
{
    [DefaultImplementation]
    public class ItemizedReceiptModelFactory : IItemizedReceiptModelFactory
    {
        public CustomerItemizedReceiptModel Create(Customer customer, Host host, Order order, EventPackage package, IEnumerable<EventTest> tests, IEnumerable<OrderedPair<long, long>> orderItemIdTestIdPair, IEnumerable<OrderedPair<long, string>> products)
        {
            var model = new CustomerItemizedReceiptModel
                            {
                                CustomerName = customer.NameAsString,
                                CustomerId = customer.CustomerId,
                                Address = customer.Address,
                                OrderAmount = order.DiscountedTotal,
                                PaidAmount = order.TotalAmountPaid,
                                PaymentMode =
                                    string.Join(", ", order.PaymentsApplied.Select(pa => pa.PaymentType.Name).Distinct()),
                                Host = host.OrganizationName,
                                HostAddress = host.Address,
                                DisplayCode = customer.CustomerId.ToString(),
                                EventId = order.EventId.HasValue ? order.EventId.Value : 0,
                                Package = package != null ? package.Package.Name : string.Empty,
                                Items = CreateReceiptItems(order, package, tests, orderItemIdTestIdPair, products)
                            };

            return model;
        }

        public IEnumerable<CustomerReceiptItem> CreateReceiptItems(Order order, EventPackage package, IEnumerable<EventTest> tests, IEnumerable<OrderedPair<long, long>> orderItemIdTestIdPair, IEnumerable<OrderedPair<long, string>> products)
        {
            var items = new List<CustomerReceiptItem>();

            order.OrderDetails.
                Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess).
                ToList().ForEach(od =>
                                     {
                                         if (od.DetailType == OrderItemType.EventPackageItem)
                                         {
                                             items.AddRange(CreateEventPackageRecieptItems(package.Package.Tests, od));
                                         }
                                         else if (od.DetailType == OrderItemType.EventTestItem)
                                         {
                                             var test = tests.Where(p => p.Id == od.OrderItem.ItemId).Select(p => p.Test).
                                                     SingleOrDefault();

                                             items.Add(CreateEventTestRecieptItems(test, od));
                                         }
                                         else if (od.DetailType == OrderItemType.ProductItem)
                                         {
                                             items.Add(CreateProductinRecieptItems(products, od));
                                         }
                                     });


            return items;
        }

        private static IEnumerable<CustomerReceiptItem> CreateEventPackageRecieptItems(IEnumerable<Test> tests, OrderDetail od)
        {
            var items = new List<CustomerReceiptItem>();
            tests.ToList().ForEach(t => items.Add(new CustomerReceiptItem
                                                     {
                                                         Amount = t.PackagePrice,
                                                         DatePurchased = od.DataRecorderMetaData.DateCreated,
                                                         Description = t.Description,
                                                         ItemId = t.Id,
                                                         Name = t.Name,
                                                         ItemType = od.DetailType
                                                     }));

            return items;
        }

        private static CustomerReceiptItem CreateEventTestRecieptItems(Test test, OrderDetail od)
        {
            return new CustomerReceiptItem
                           {
                               Amount = test.Price,
                               DatePurchased = od.DataRecorderMetaData.DateCreated,
                               Description = test.Description,
                               ItemId = test.Id,
                               Name = test.Name,
                               ItemType = od.DetailType
                           };

        }

        private static CustomerReceiptItem CreateProductinRecieptItems(IEnumerable<OrderedPair<long, string>> products, OrderDetail od)
        {
            var product = products.Where(p => p.FirstValue == od.OrderItemId).SingleOrDefault();
            return new CustomerReceiptItem
                       {
                           Description = product.SecondValue,
                           Name = product.SecondValue,
                           Amount = od.Price,
                           DatePurchased = od.DataRecorderMetaData.DateCreated,
                           ItemType = od.DetailType
                       };
        }
    }
}
