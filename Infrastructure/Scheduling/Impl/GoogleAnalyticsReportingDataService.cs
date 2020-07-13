using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class GoogleAnalyticsReportingDataService : IGoogleAnalyticsReportingDataService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEventTestRepository _eventTestRepository;

        private readonly IElectronicProductRepository _productRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IEventPackageRepository _eventPackageRepository;

        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressService _addressService;

        public GoogleAnalyticsReportingDataService(IOrderRepository orderRepository, IEventTestRepository eventTestRepository, IElectronicProductRepository productRepository, IShippingOptionRepository shippingOptionRepository, IEventPackageRepository eventPackageRepository, ICustomerRepository customerRepository, IAddressService addressService)
        {
            _orderRepository = orderRepository;
            _addressService = addressService;
            _customerRepository = customerRepository;
            _eventPackageRepository = eventPackageRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _productRepository = productRepository;
            _eventTestRepository = eventTestRepository;
        }

        public GoogleAnalyticsEnableReportingDataModel GetGoogleAnalyticsViewModel(TempCart tempCart)
        {
            if (tempCart == null || !tempCart.IsCompleted) return new GoogleAnalyticsEnableReportingDataModel();

            var model = new GoogleAnalyticsEnableReportingDataModel();

            if (tempCart.EventPackageId.HasValue)
                model.EventPackage = _eventPackageRepository.GetById(tempCart.EventPackageId.Value);

            if (!string.IsNullOrEmpty(tempCart.TestId))
            {
                var testIdStrings = tempCart.TestId.Split(new[] { ',' });
                if (testIdStrings.Any())
                {
                    long id;
                    var testIds = testIdStrings.Where(p => long.TryParse(p, out id)).Select(p => Convert.ToInt64(p)).ToArray();
                    if (testIds.Count() > 0)
                        model.EventTests = _eventTestRepository.GetbyIds(testIds);
                }
            }

            if (!string.IsNullOrEmpty(tempCart.ProductId))
            {
                var productIdStrings = tempCart.ProductId.Split(new[] { ',' });
                if (productIdStrings.Any())
                {
                    long id;
                    var productIds = productIdStrings.Where(p => long.TryParse(p, out id)).Select(p => Convert.ToInt64(p)).ToArray();
                    if (productIds.Count() > 0)
                        model.Products = _productRepository.GetByIds(productIds);
                }
            }

            if (tempCart.ShippingId.HasValue && tempCart.ShippingId.Value > 0)
            {
                model.Shipping = _shippingOptionRepository.GetById(tempCart.ShippingId.Value).Price;
            }

            Order order = _orderRepository.GetOrder(tempCart.CustomerId.Value, tempCart.EventId.Value);
            model.TotalPrice = order.DiscountedTotal;

            model.CustomerId = tempCart.CustomerId.Value;

            var customer = _customerRepository.GetCustomer(tempCart.CustomerId.Value);
            model.Address = _addressService.GetAddress(customer.Address.Id);

            return model;
        }

    }
}
