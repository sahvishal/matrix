using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Address = Falcon.App.Core.Geo.Domain.Address;
using Product = Falcon.App.Core.Enum.Product;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class PcpShippingService : IPcpShippingService
    {
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IShippingController _shippingController;
        private readonly IAddressService _addressService;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderController _orderController;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly IShippingDetailOrderDetailRepository _shippingDetailOrderDetailRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;

        public PcpShippingService(IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IShippingOptionRepository shippingOptionRepository,
            IShippingController shippingController, IAddressService addressService, IMediaRepository mediaRepository, ISettings settings, IPdfGenerator pdfGenerator,
            IOrderRepository orderRepository, IOrderController orderController, IElectronicProductRepository electronicProductRepository,
            IShippingDetailOrderDetailRepository shippingDetailOrderDetailRepository, IShippingDetailRepository shippingDetailRepository)
        {
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _shippingController = shippingController;
            _addressService = addressService;
            _mediaRepository = mediaRepository;
            _settings = settings;
            _pdfGenerator = pdfGenerator;
            _orderRepository = orderRepository;
            _orderController = orderController;
            _electronicProductRepository = electronicProductRepository;
            _shippingDetailOrderDetailRepository = shippingDetailOrderDetailRepository;
            _shippingDetailRepository = shippingDetailRepository;
        }

        public bool AddPcpProductShipping(long customerId, long eventId)
        {
            var pcp = _primaryCarePhysicianRepository.Get(customerId);
            if (pcp == null || pcp.Address == null) return false;

            var shippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);
            if (shippingOption == null) return false;

            var order = _orderRepository.GetOrder(customerId, eventId);

            //added As Admin User Role
            var organizationRoleUser = new OrganizationRoleUser { Id = customerId };

            AddProduct(customerId, order, organizationRoleUser);

            AddPcpShipping(order, shippingOption, pcp, organizationRoleUser);

            return true;
        }

        public void AddShippingForPcp(long customerId, long eventId, PrimaryCarePhysician pcp)
        {
            // var pcp = _primaryCarePhysicianRepository.Get(customerId);
            if (pcp == null || pcp.Address == null) return;

            var shippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages, true);
            if (shippingOption == null) return;

            var shippingDetails = _shippingDetailRepository.GetShippingDetailsForEventCustomer(eventId, customerId);

            if (!shippingDetails.IsNullOrEmpty())
            {
                if (shippingDetails.Any(sd => sd.ShippingOption.Id == shippingOption.Id))
                    return;
            }

            var order = _orderRepository.GetOrder(customerId, eventId);

            //added As Admin User Role
            var organizationRoleUser = new OrganizationRoleUser { Id = customerId };

            AddPcpShipping(order, shippingOption, pcp, organizationRoleUser);
        }

        private void AddPcpShipping(Order order, ShippingOption shippingOption, PrimaryCarePhysician pcp, OrganizationRoleUser organizationRoleUser)
        {
            var orderDetail = _orderController.GetActiveOrderDetail(order);

            var shippingDetails = SavePcpShippingDetail(pcp.Address, organizationRoleUser, shippingOption);

            var shippingDetailOrderDetail = new ShippingDetailOrderDetail
            {
                Amount = shippingDetails.ActualPrice,
                IsActive = true,
                OrderDetailId = orderDetail.Id,
                ShippingDetailId = shippingDetails.Id
            };

            _shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);

        }

        private void AddProduct(long customerId, Order order, OrganizationRoleUser organizationRoleUser)
        {
            var product = _electronicProductRepository.GetById((long)Product.UltraSoundImages);
            product.Price = 0;

            var orderables = new List<IOrderable> { product };

            foreach (var orderable in orderables)
            {
                _orderController.AddItem(orderable, 1, customerId, organizationRoleUser.Id, OrderStatusState.FinalSuccess);
            }

            _orderController.PlaceProductOrder(order);
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


        public MediaLocation PrintEventCustomerPcpAppointmentForm(long eventId, long customerId, string fileName)
        {
            var mediaLocation = _mediaRepository.GetTempMediaFileLocation();

            var url = _settings.AppUrl + "/Scheduling/EventCustomerList/ViewPcpAppointment?eventId=" + eventId + "&customerId=" + customerId + "&print=true";

            _pdfGenerator.GeneratePdf(url, mediaLocation.PhysicalPath + fileName);

            return mediaLocation;
        }
    }
}
