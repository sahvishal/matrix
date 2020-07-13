using System.Collections.Generic;
using System.Linq;
using API.Areas.Scheduling.Models;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace API.Areas.Scheduling.Impl
{
    public class CustomerOrderBuilderService : ICustomerOrderBuilderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;

        public CustomerOrderBuilderService(IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, ICustomerRepository customerRepository, IShippingDetailRepository shippingDetailRepository)
        {
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _customerRepository = customerRepository;
            _shippingDetailRepository = shippingDetailRepository;
        }

        public CustomerOrderDetail GetCustomerOrderDetails(long customerId, long eventId)
        {
            var order = _orderRepository.GetOrder(customerId, eventId);
            var customerProfile = _customerRepository.GetCustomer(customerId);
            if (customerProfile == null) return null;

            var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventId);
            var eventTests = _eventTestRepository.GetTestsForEvent(eventId);

            var customerOrder = new CustomerOrderDetail
            {
                OrderId = order.Id,
                EventId = eventId,
                CustomerId = customerId
            };

            var orderPackage = order.OrderDetails.FirstOrDefault(o => o.DetailType == OrderItemType.EventPackageItem && o.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess);

            if (orderPackage != null)
            {
                var eventPackage = eventPackages.SingleOrDefault(x => x.Id == orderPackage.OrderItem.ItemId);
                customerOrder.PackageModel = GetEventPackage(eventPackage);
            }


            var orderTests = order.OrderDetails.Where(o => o.DetailType == OrderItemType.EventTestItem && o.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess).ToList();

            if (orderTests != null)
            {
                var testIds = orderTests.Select(s => s.OrderItem.ItemId).ToArray();
                var evemtTest = eventTests.Where(et => testIds.Contains(et.Id));
                customerOrder.AlaCarteTests = GetTestModels(evemtTest);
            }

            var product = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.ProductItem).Select(od => od.OrderItem.ItemId).FirstOrDefault();

            customerOrder.ProductId = product;

            var shippingDetailIds = order.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Where(sdod => sdod.IsActive).Select(sdod => sdod.ShippingDetailId)).ToArray();

            if (shippingDetailIds.Any())
            {
                var shipingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds).ToList();
                customerOrder.ShippingOptions = shipingDetails.Select(x => new ShippingOptionDetail { Id = x.Id }).ToArray();
            }

            return customerOrder;
        }

        public EventPackageTestModel GetEventPackageTestModel(long eventId)
        {
            return new EventPackageTestModel
            {
                AvilablePackages = GetAvilablePackages(eventId),
                AvilableAlaCarteTests = GetAvilableAlaCarteTests(eventId)
            };
        }

        private IEnumerable<PackageModel> GetAvilablePackages(long eventId)
        {
            var avilablePackages = _eventPackageRepository.GetPackagesForEventByRole(eventId, (long)Roles.Technician);
            return avilablePackages.Select(ep => GetEventPackage(ep));
        }

        private IEnumerable<TestModel> GetAvilableAlaCarteTests(long eventId)
        {
            var eventTest = _eventTestRepository.GetTestsForEventByRole(eventId, (long)Roles.Technician);

            return GetTestModels(eventTest);
        }

        private PackageModel GetEventPackage(EventPackage eventPackage)
        {
            return new PackageModel
               {
                   EventPackageId = eventPackage.Id,
                   Description = eventPackage.Description,
                   Price = eventPackage.Price,

                   PackageName = eventPackage.Package.Name,
                   PackageId = eventPackage.Package.Id,
                   TestItems = GetTestModels(eventPackage.Tests)
               };
        }

        private List<TestModel> GetTestModels(IEnumerable<EventTest> eventTests)
        {
            if (eventTests == null && !eventTests.Any()) return null;

            return eventTests.Select(x => new TestModel
             {
                 TestName = x.Test.Name,
                 Descriptoin = x.Description,
                 TestId = x.Test.Id,
                 TestPrice = x.Price,
                 EventTestId = x.Id,
                 WithPackagePrice = x.Test.PackagePrice
             }).ToList();

        }


    }
}