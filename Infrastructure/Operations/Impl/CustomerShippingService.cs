using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class CustomerShippingService : ICustomerShippingService
    {
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IShippingController _shippingController;
        private readonly IAddressService _addressService;

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderController _orderController;

        private readonly IShippingDetailOrderDetailRepository _shippingDetailOrderDetailRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;

        public CustomerShippingService(IShippingOptionRepository shippingOptionRepository, ICustomerRepository customerRepository,
            IShippingController shippingController, IAddressService addressService, IOrderRepository orderRepository, IOrderController orderController,
            IShippingDetailOrderDetailRepository shippingDetailOrderDetailRepository, IShippingDetailRepository shippingDetailRepository)
        {

            _shippingOptionRepository = shippingOptionRepository;
            _customerRepository = customerRepository;
            _shippingController = shippingController;
            _addressService = addressService;

            _orderRepository = orderRepository;
            _orderController = orderController;

            _shippingDetailOrderDetailRepository = shippingDetailOrderDetailRepository;
            _shippingDetailRepository = shippingDetailRepository;
        }

        public void AddFreeShippingForCustomer(long customerId, long eventId)
        {
            var customer = _customerRepository.GetCustomer(customerId);

            var shippingOptions = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess();
            if (shippingOptions == null || !shippingOptions.Any()) return;

            var shippingOption = shippingOptions.FirstOrDefault(x => x.Price == 0);

            if (shippingOption == null) return;

            var shippingDetails = _shippingDetailRepository.GetShippingDetailsForEventCustomer(eventId, customerId);

            if (!shippingDetails.IsNullOrEmpty()) return;

            var order = _orderRepository.GetOrder(customerId, eventId);

            //added As Admin User Role
            var organizationRoleUser = new OrganizationRoleUser { Id = customerId };

            var shippingDetail = SavePcpShippingDetail(customer.Address, organizationRoleUser, shippingOption);

            AddFreeShippingForCustomer(order, shippingDetail);
        }

        private void AddFreeShippingForCustomer(Order order, ShippingDetail shippingDetail)
        {
            var orderDetail = _orderController.GetActiveOrderDetail(order);

            var shippingDetailOrderDetail = new ShippingDetailOrderDetail
            {
                Amount = shippingDetail.ActualPrice,
                IsActive = true,
                OrderDetailId = orderDetail.Id,
                ShippingDetailId = shippingDetail.Id
            };

            _shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);

        }

        private ShippingDetail SavePcpShippingDetail(Address address, OrganizationRoleUser createdByOrgRoleUser, ShippingOption shippingOption)
        {
            address = _addressService.SaveAfterSanitizing(address);
            var shippingDetail = new ShippingDetail
            {
                ShippingOption = new ShippingOption(),
                DataRecorderMetaData =
                    new DataRecorderMetaData
                    {
                        DataRecorderCreator = createdByOrgRoleUser,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                Status = ShipmentStatus.Processing,
                ShippingAddress = address
            };

            shippingDetail.ShippingOption.Id = shippingOption.Id;
            shippingDetail.ActualPrice = shippingOption.Price;

            shippingDetail = _shippingController.OrderShipping(shippingDetail);
            return shippingDetail;
        }
    }
}