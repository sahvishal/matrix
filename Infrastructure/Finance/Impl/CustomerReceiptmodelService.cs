using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Application.Attributes;
using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class CustomerReceiptModelService : ICustomerReceiptModelService
    {
        readonly ICustomerRepository _customerRepository;
        readonly IEventPackageRepository _eventPackageRepository;
        readonly IEventTestRepository _eventTestRepository;
        readonly IOrderRepository _orderRepository;
        readonly IElectronicProductRepository _productRepository;
        readonly IHostRepository _hostRepository;
        readonly IItemizedReceiptModelFactory _itemizedRecieptModelFactory;

        public CustomerReceiptModelService(ICustomerRepository customerRepository,
            IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IOrderRepository orderRepository, 
            IElectronicProductRepository productRepository, IHostRepository hostRepository, IItemizedReceiptModelFactory itemizedRecieptModelFactory)
        {
            _customerRepository = customerRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _hostRepository = hostRepository;
            _itemizedRecieptModelFactory = itemizedRecieptModelFactory;
        }

        // Belongs to Finance Domain
        public CustomerItemizedReceiptModel GetItemizedRecieptModel(long customerId, long eventId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var host = _hostRepository.GetHostForEvent(eventId);
            var order = _orderRepository.GetOrder(customerId, eventId);

            var package = _eventPackageRepository.GetPackageForOrder(order.Id);
            var tests = _eventTestRepository.GetTestsForOrder(order.Id);

            IEnumerable<OrderedPair<long, long>> orderItemIdTestIdPair = null;
            
            //var orderitemIdsforTestitem =
            //    order.OrderDetails.Where(
            //        od =>
            //        od.DetailType == OrderItemType.EventTestItem &&
            //        od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess).Select(od => od.OrderItemId).
            //        ToArray();

            //if (orderitemIdsforTestitem.Count() > 0)
            //    orderItemIdTestIdPair = _eventTestRepository.GetOrderItemIdandTestIdpair(orderitemIdsforTestitem);

            var products = _productRepository.GetProductNameForOrderItems(order.OrderDetails.Where(od => od.DetailType == OrderItemType.ProductItem &&
                                od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess).Select(od => od.OrderItemId).ToArray());

            return _itemizedRecieptModelFactory.Create(customer, host, order, package, tests, orderItemIdTestIdPair, products);
        }

    }
}
