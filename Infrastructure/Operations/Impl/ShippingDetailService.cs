using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class ShippingDetailService : IShippingDetailService
    {
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IUniqueItemRepository<EventCustomer> _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUniqueItemRepository<ShippingOption> _shippingOptionRepository;
        private readonly IEventCustomerShippingDetailViewDataFactory _eventCustomerShippingDetailViewDataFactory;
        private readonly IElectronicProductRepository _productRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public ShippingDetailService(IShippingDetailRepository shippingDetailRepository, IUniqueItemRepository<EventCustomer> eventCustomerRepository, ICustomerRepository customerRepository, IEventRepository eventRepository,
            IEventCustomerResultRepository eventCustomerResultRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IAddressRepository addressRepository,
            IUniqueItemRepository<ShippingOption> shippingOptionRepository, IEventCustomerShippingDetailViewDataFactory eventCustomerShippingDetailViewDataFactory, IElectronicProductRepository productRepository,
            IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier, INotificationTypeRepository notificationTypeRepository, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _shippingDetailRepository = shippingDetailRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _addressRepository = addressRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _eventCustomerShippingDetailViewDataFactory = eventCustomerShippingDetailViewDataFactory;
            _productRepository = productRepository;

            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _notificationTypeRepository = notificationTypeRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }

        public IEnumerable<EventCustomerShippingDetailViewData> GetEventCustomerShippingDetailViewData(int pageNumber, int pageSize, EventCustomerShippingDetailViewDataFilter filter)
        {
            int totalRecords = 0;
            var shippingDetails = _shippingDetailRepository.GetEventCustomerShippingDetailForFilter(pageNumber, pageSize, filter, out totalRecords);
            if (shippingDetails.IsNullOrEmpty())
                return null;
            var shippingDetailIdEventCustomerIdPairs = _shippingDetailRepository.GetShippingDetailIdEventCustomerIdPairs(shippingDetails.Select(sd => sd.Id).ToArray());

            var eventCustomers = _eventCustomerRepository.GetByIds(shippingDetailIdEventCustomerIdPairs.Select(sdec => sdec.SecondValue).ToArray());
            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();
            var eventIds = eventCustomers.Select(ec => ec.EventId).ToArray();

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());
            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var eventCustomerResults = _eventCustomerResultRepository.GetByIds(eventCustomerIds);

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds, true);
            var orderPackageIdNamePairs = _eventPackageRepository.GetPackageNamesForOrder(orders.Select(o => o.Id).ToList());
            var orderTestIdNamePairs = _eventTestRepository.GetTestNamesForOrders(orders.Select(o => o.Id).ToList());
            var addresses = _addressRepository.GetAddresses(shippingDetails.Select(sd => sd.ShippingAddress.Id).ToList());
            var shippingOptions = _shippingOptionRepository.GetByIds(shippingDetails.Select(sd => sd.ShippingOption.Id).Distinct().ToArray());

            var orderIdProductNamePairs = _productRepository.GetProductNamesForOrder(orders.Select(o => o.Id).ToArray());

            return _eventCustomerShippingDetailViewDataFactory.Create(shippingDetails,
                                                                      shippingDetailIdEventCustomerIdPairs,
                                                                      eventCustomers, customers, events,
                                                                      eventCustomerResults, orders,
                                                                      orderPackageIdNamePairs, orderTestIdNamePairs,
                                                                      addresses,
                                                                      shippingOptions, totalRecords, orderIdProductNamePairs);
        }

        public IEnumerable<ShippingDetailEditModel> GetShippingDetailEditModels(long eventId, long customerId)
        {
            var shippingDetails = _shippingDetailRepository.GetShippingDetailsForEventCustomer(eventId, customerId);
            return AutoMapper.Mapper.Map<IEnumerable<ShippingDetail>, IEnumerable<ShippingDetailEditModel>>(shippingDetails);
        }

        public bool UpdateShippingStatus(long shippingDetailId, ShipmentStatus status, long modifiedByOrgRoleUserId)
        {
            var shippingDetail = _shippingDetailRepository.GetById(shippingDetailId);

            shippingDetail.Status = status;
            shippingDetail.DataRecorderMetaData.DateModified = DateTime.Now;
            shippingDetail.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(modifiedByOrgRoleUserId);

            if (status == ShipmentStatus.Shipped)
                shippingDetail.ShippedByOrgRoleUserId = modifiedByOrgRoleUserId;

            shippingDetail = _shippingDetailRepository.Save(shippingDetail);
            if (shippingDetail.Id > 0)
                return true;
            return false;
        }

        public bool CheckShippingIsExclusivelyRequested(long eventId, long customerId)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            var shippingDetails = _shippingDetailRepository.GetShippingDetailsForEventCustomer(eventId, customerId);

            var isNewResultFlow = _eventRepository.IsEventHasNewResultFlow(eventId);

            var isOneShipped = (shippingDetails != null && shippingDetails.Any(sd => sd.Status == ShipmentStatus.Shipped || sd.Status == ShipmentStatus.Delivered));

            return ((eventCustomerResult != null && ((!isNewResultFlow && eventCustomerResult.ResultState == (int)TestResultStateNumber.ResultDelivered) || (isNewResultFlow && eventCustomerResult.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                && (shippingDetails == null || !shippingDetails.Any())) || isOneShipped);

        }

        public void SendPurchaseShippingNotification(long eventId, long customerId, long createdByOrgRoleUserId)
        {
            var notificationTypes = _notificationTypeRepository.GetAll();
            var purchaseShippingNotificationIsActive = notificationTypes.Any(nt => (nt.NotificationTypeAlias == NotificationTypeAlias.PurchaseShippingNotification) && nt.IsActive);
            var eventData = _eventRepository.GetById(eventId);

            if (purchaseShippingNotificationIsActive && eventData.EventDate > DateTime.Now.Date)
            {
                var model = _emailNotificationModelsFactory.GetPurchaseShippingNotificationViewModel(eventId, customerId);
                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.PurchaseShippingNotification, EmailTemplateAlias.PurchaseShippingNotification, model, new string[0], 0, createdByOrgRoleUserId, "Purchase Shipping Notification");
            }
        }

        public IEnumerable<ShippingDetailViewModel> GetShippingDetailsForPopup(long orderDetailId)
        {
            var shippingDetails = _shippingDetailRepository.GetShippingDetailsForOrder(orderDetailId);

            var nameOrgRoleUserIdPairForShippedByName = _organizationRoleUserRepository.GetNameIdPairofUsers(shippingDetails.Where(x => x.ShippedByOrgRoleUserId.HasValue).Select(x => x.ShippedByOrgRoleUserId.Value).ToArray());

            return (from shippingDetail in shippingDetails
                    let shippedByName = nameOrgRoleUserIdPairForShippedByName.FirstOrDefault(x => x.FirstValue == shippingDetail.ShippedByOrgRoleUserId)
                    select new ShippingDetailViewModel
                    {
                        Status = shippingDetail.Status,
                        ShipmentDate = shippingDetail.ShipmentDate,
                        ActualPrice = shippingDetail.ActualPrice,
                        ShippingOption = shippingDetail.ShippingOption,
                        ShippedByName = shippedByName == null ? null : shippedByName.SecondValue
                    }).ToList();
        }
    }
}