using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Operations.Impl;
using Falcon.App.Infrastructure.Repositories.Order;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class RefundRequestService : IRefundRequestService
    {
        private readonly IRefundRequestRepository _refundRequestRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IRefundRequestListModelFactory _refundRequestListFactory;
        private readonly ISessionContext _sessionContext;
        private readonly IOrderController _orderController;
        private readonly ISourceCodeOrderDetailRepository _sourceCodeOrderDetailRepository;
        private readonly IOrderService _orderService;
        private readonly IElectronicProductRepository _productRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IShippingDetailService _shippingDetailService;
        private readonly IEventAppointmentCancellationLogRepository _eventAppointmentCancellationLogRepository;

        public RefundRequestService(IRefundRequestRepository refundRequestRepository, IOrderRepository orderRepository, IEventRepository eventRepository, IHostRepository hostRepository,
            ICustomerRepository customerRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IRoleRepository roleRepository, IRefundRequestListModelFactory refundRequestListFactory,
            ISessionContext context, IOrderController orderController, ISourceCodeOrderDetailRepository sourceCodeOrderDetailRepository, IOrderService orderService, IElectronicProductRepository productRepository,
            IShippingOptionRepository shippingOptionRepository, IShippingDetailRepository shippingDetailRepository, IAddressRepository addressRepository, IEventCustomerRepository eventCustomerRepository,
            IShippingDetailService shippingDetailService, IEventAppointmentCancellationLogRepository eventAppointmentCancellationLogRepository)
        {
            _refundRequestRepository = refundRequestRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _customerRepository = customerRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _roleRepository = roleRepository;
            _refundRequestListFactory = refundRequestListFactory;
            _sessionContext = context;
            _orderRepository = orderRepository;
            _orderController = orderController;
            _sourceCodeOrderDetailRepository = sourceCodeOrderDetailRepository;
            _orderService = orderService;
            _productRepository = productRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _addressRepository = addressRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _shippingDetailService = shippingDetailService;
            _eventAppointmentCancellationLogRepository = eventAppointmentCancellationLogRepository;
        }

        public ListModelBase<RefundRequestBasicInfoModel, RefundRequestListModelFilter> GetPendingRequests(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var refundRequestFilter = filter as RefundRequestListModelFilter;
            var requests = _refundRequestRepository.Get(pageNumber, pageSize, refundRequestFilter, out totalRecords);
            if (requests == null || requests.Count() < 1) return null;

            var customerIds = requests.Select(r => r.CustomerId).ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var eventIds = requests.Select(r => r.EventId).Distinct().ToArray();

            var eventCustomers = _eventCustomerRepository.GetEventCustomersByEventIdsCustomerIds(eventIds, customerIds);
            var appointmentCancellationLog = new List<EventAppointmentCancellationLog>();

            if (!eventCustomers.IsNullOrEmpty())
            {
                var cancellationLog = _eventAppointmentCancellationLogRepository.GetByEventCustomerIds(eventCustomers.Select(x => x.Id));
                if(!cancellationLog.IsNullOrEmpty())
                appointmentCancellationLog.AddRange(cancellationLog);
            }

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var orders = _orderRepository.GetOrderByOrderIds(requests.Select(r => r.OrderId));

            var orgRoleUserIds = requests.Select(r => r.RequestedByOrgRoleUserId).Distinct().ToArray();

            if (refundRequestFilter.RefundRequestStatus < 0 || refundRequestFilter.RefundRequestStatus == (int)RequestStatus.Resolved || refundRequestFilter.RefundRequestStatus == (int)RequestStatus.Reverted)
            {
                var processedbyOrgRoleUserIds = requests.Where(r => r.RefundRequestResult != null).Select(r => r.RefundRequestResult.ProcessedByOrgRoleUserId).Distinct().ToArray();
                if (processedbyOrgRoleUserIds.Count() > 0)
                    orgRoleUserIds = orgRoleUserIds.Concat(processedbyOrgRoleUserIds).ToArray();
            }

            var bookedByOrgRoleUserIds = orders.Select(o => o.DataRecorderMetaData.DataRecorderCreator.Id).ToArray();
            orgRoleUserIds = orgRoleUserIds.Concat(bookedByOrgRoleUserIds).ToArray();

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

            var organizationRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsers(orgRoleUserIds);
            var roles = _roleRepository.GetAll();

            return _refundRequestListFactory.Create(requests, customers, events, hosts, idNamePairs, organizationRoleUsers, roles, orders, eventCustomers, appointmentCancellationLog);
        }

        public RefundRequest SaveRequest(RefundRequestEditModel model)
        {
            try
            {
                var refundRequest = Mapper.Map<RefundRequestEditModel, RefundRequest>(model);
                refundRequest.RequestedOn = DateTime.Now;
                refundRequest.RequestedByOrgRoleUserId =
                    _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                var requestsInDb = _refundRequestRepository.GetbyOrderId(model.OrderId);
                var repository = ((IRepository<RefundRequest>)_refundRequestRepository);
                if (requestsInDb != null)
                {
                    var requestInDb = requestsInDb.Where(rr => rr.RefundRequestType == refundRequest.RefundRequestType).SingleOrDefault();

                    if (requestInDb != null)
                        refundRequest.Id = requestInDb.Id;
                    else if ((refundRequest.RefundRequestType == RefundRequestType.CustomerCancellation || refundRequest.RefundRequestType == RefundRequestType.EventCancellation) && requestsInDb.Count() > 0)
                    {
                        repository.Delete(requestsInDb);
                    }
                }

                refundRequest = repository.Save(refundRequest);
                return refundRequest;
            }
            catch (Exception)
            {
                throw new Exception("Request not generated.");
            }
        }

        public bool CheckifCancelAppointmentRequestExistsforaCustomer(long eventId, long customerId)
        {
            if (customerId < 1 || eventId < 1) return false;
            var order = _orderRepository.GetOrder(customerId, eventId);

            if (order == null) return false;

            var refundRequests = _refundRequestRepository.GetbyOrderId(order.Id);
            if (refundRequests == null) return false;
            return refundRequests.Where(rr => rr.RequestStatus == (long)RequestStatus.Pending && rr.RefundRequestType == RefundRequestType.CustomerCancellation).Count() > 0;
        }

        public void UndoApplySourceCodeRefundRequest(RefundRequest refundRequest)
        {
            var order = _orderRepository.GetOrder(refundRequest.OrderId);
            var activeOrderDetail = _orderController.GetActiveOrderDetail(order);
            var activeSourceCodeOrderDetail = activeOrderDetail.SourceCodeOrderDetail;

            if (activeSourceCodeOrderDetail == null)
                throw new Exception("No Source Code applied.");

            var repository = ((IRepository<RefundRequest>)_refundRequestRepository);

            if (refundRequest.RequestedRefundAmount == activeSourceCodeOrderDetail.Amount)
            {
                _sourceCodeOrderDetailRepository.UpdateStatus(activeSourceCodeOrderDetail.SourceCodeId, activeSourceCodeOrderDetail.OrderDetailId, false);
            }
            else
            {
                var sourceCodeOrderDetails = _sourceCodeOrderDetailRepository.GetForOrder(refundRequest.OrderId);
                var inActiveSourceCodeOrderDetail = sourceCodeOrderDetails.FirstOrDefault(sourceCodeOrderDetail => sourceCodeOrderDetail.Amount == (activeSourceCodeOrderDetail.Amount - refundRequest.RequestedRefundAmount));

                if (inActiveSourceCodeOrderDetail == null)
                    throw new Exception("No Source Code found for request amount.");

                if (inActiveSourceCodeOrderDetail.OrderDetailId == activeSourceCodeOrderDetail.OrderDetailId)
                    _sourceCodeOrderDetailRepository.UpdateStatus(inActiveSourceCodeOrderDetail.SourceCodeId, activeSourceCodeOrderDetail.OrderDetailId, true);
                else
                {
                    inActiveSourceCodeOrderDetail.IsActive = true;
                    inActiveSourceCodeOrderDetail.OrderDetailId = activeSourceCodeOrderDetail.OrderDetailId;
                    _sourceCodeOrderDetailRepository.Save(inActiveSourceCodeOrderDetail);
                }

                _sourceCodeOrderDetailRepository.UpdateStatus(activeSourceCodeOrderDetail.SourceCodeId, activeSourceCodeOrderDetail.OrderDetailId, false);
            }

            refundRequest.RequestStatus = (long)RequestStatus.Reverted;
            refundRequest.RefundRequestResult = new RefundRequestResult
                                                  {
                                                      ProcessedOn = DateTime.Now,
                                                      ProcessedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
                                                  };
            repository.Save(refundRequest);

        }

        public void UndoManualRefundRequest(RefundRequest refundRequest)
        {
            var order = _orderRepository.GetOrder(refundRequest.OrderId);

            var cancelledOrderItemIds = order.OrderDetails.Where(od => od.DetailType == OrderItemType.RefundItem && !od.IsCompleted).Select(od => od.OrderItemId).ToArray();
            var manualRefundOrderDetails = order.OrderDetails.Where(od => od.DetailType == OrderItemType.RefundItem && od.IsCompleted && !cancelledOrderItemIds.Contains(od.OrderItemId))
                                            .Select(od => od).OrderByDescending(od => od.Id).ToList();

            if (manualRefundOrderDetails.IsNullOrEmpty())
                throw new Exception("No Manual Refund item found in the order.");

            IUniqueItemRepository<Refund> refundItemRepository = new RefundRepository();

            var forOrganizationRoleUser = new OrganizationRoleUser(manualRefundOrderDetails.First().ForOrganizationRoleUserId);
            var creatorOrganizationRoleUser = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            if (manualRefundOrderDetails.Count() == 1)
            {
                var manualRefundOrderDetail = manualRefundOrderDetails.FirstOrDefault(mrod => mrod.Price == refundRequest.RequestedRefundAmount);

                if (manualRefundOrderDetail == null)
                    throw new Exception("No Manual Refund item found for request amount.");

                var refundItem = refundItemRepository.GetById(manualRefundOrderDetail.OrderItem.ItemId);
                refundItem.Price = -1 * refundItem.Price;
                _orderService.CancelRefundOrder(new[] { refundItem }, order, creatorOrganizationRoleUser, forOrganizationRoleUser);
            }
            else
            {
                decimal totalAmount = 0;

                var orderables = new List<IOrderable>();
                foreach (var manualRefundOrderDetail in manualRefundOrderDetails)
                {
                    var refundItem = refundItemRepository.GetById(manualRefundOrderDetail.OrderItem.ItemId);

                    if ((totalAmount + refundItem.Price) > refundRequest.RequestedRefundAmount)
                        break;

                    totalAmount += refundItem.Price;
                    refundItem.Price = -1 * refundItem.Price;
                    orderables.Add(refundItem);
                }
                if (totalAmount != refundRequest.RequestedRefundAmount || orderables.IsNullOrEmpty())
                    throw new Exception("No Manual Refund items found for request amount.");

                _orderService.CancelRefundOrder(orderables, order, creatorOrganizationRoleUser, forOrganizationRoleUser);
            }

            var repository = ((IRepository<RefundRequest>)_refundRequestRepository);
            refundRequest.RequestStatus = (long)RequestStatus.Reverted;
            refundRequest.RefundRequestResult = new RefundRequestResult
                                                    {
                                                        ProcessedOn = DateTime.Now,
                                                        ProcessedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
                                                    };
            repository.Save(refundRequest);
        }

        public void UndoCdRemoveRequest(RefundRequest refundRequest)
        {
            var order = _orderRepository.GetOrder(refundRequest.OrderId);
            var activeOrderDetail = _orderController.GetActiveOrderDetail(order);

            var cancelledProductDetail = order.OrderDetails.Where(od => od.DetailType == OrderItemType.ProductItem && !od.IsCompleted)
                                            .Select(od => od).OrderByDescending(od => od.Id).FirstOrDefault();
            if (cancelledProductDetail == null)
                throw new Exception("No CD Removal item found in the order.");

            var eventCustomer = _eventCustomerRepository.GetById(activeOrderDetail.EventCustomerOrderDetail.EventCustomerId);
            var isExclusivelyRequested = _shippingDetailService.CheckShippingIsExclusivelyRequested(eventCustomer.EventId, eventCustomer.CustomerId);

            var product = _productRepository.GetById(cancelledProductDetail.OrderItem.ItemId);
            product.Price = refundRequest.RequestedRefundAmount;

            var forOrganizationRoleUser = new OrganizationRoleUser(cancelledProductDetail.ForOrganizationRoleUserId);
            var creatorOrganizationRoleUser = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            _orderController.AddItem(product, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id, OrderStatusState.FinalSuccess);
            _orderController.PlaceProductOrder(order);

            SaveProductShipping(cancelledProductDetail, activeOrderDetail, isExclusivelyRequested);

            var repository = ((IRepository<RefundRequest>)_refundRequestRepository);
            refundRequest.RequestStatus = (long)RequestStatus.Reverted;
            refundRequest.RefundRequestResult = new RefundRequestResult
                                                    {
                                                        ProcessedOn = DateTime.Now,
                                                        ProcessedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
                                                    };
            repository.Save(refundRequest);
        }

        public void UndoCancelShippingRequest(RefundRequest refundRequest)
        {
            var order = _orderRepository.GetOrder(refundRequest.OrderId);
            var activeOrderDetail = _orderController.GetActiveOrderDetail(order);

            var cancelledShippingDetails = _shippingDetailRepository.GetAllCancelledShippingForOrder(order.Id).OrderByDescending(sd => sd.Id).ToArray();
            var shippingDetail = cancelledShippingDetails.FirstOrDefault(cd => cd.ActualPrice == refundRequest.RequestedRefundAmount);

            if (shippingDetail == null)
                throw new Exception("No cancelled shipping item found in the order for requested amount.");

            var eventCustomer = _eventCustomerRepository.GetById(activeOrderDetail.EventCustomerOrderDetail.EventCustomerId);
            var isExclusivelyRequested = _shippingDetailService.CheckShippingIsExclusivelyRequested(eventCustomer.EventId, eventCustomer.CustomerId);

            var address = _addressRepository.GetAddress(shippingDetail.ShippingAddress.Id);
            address.Id = 0;
            shippingDetail.Id = 0;
            shippingDetail.ShippingAddress = address;
            shippingDetail.Status = ShipmentStatus.Processing;
            shippingDetail.IsExclusivelyRequested = isExclusivelyRequested;
            shippingDetail.DataRecorderMetaData = new DataRecorderMetaData
                                                               {
                                                                   DataRecorderCreator = _organizationRoleUserRepository.GetOrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                                                                   DateCreated = DateTime.Now,
                                                                   DateModified = DateTime.Now
                                                               };

            IShippingController shippingController = new ShippingController();
            shippingDetail = shippingController.OrderShipping(shippingDetail);

            IRepository<ShippingDetailOrderDetail> shippingDetailOrderDetailRepository = new ShippingDetailOrderDetailRepository();

            var shippingDetailOrderDetail = new ShippingDetailOrderDetail
                                                {
                                                    Amount = shippingDetail.ActualPrice,
                                                    IsActive = true,
                                                    OrderDetailId = activeOrderDetail.Id,
                                                    ShippingDetailId = shippingDetail.Id
                                                };

            shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);

            var productDetail = order.OrderDetails.Where(od => od.DetailType == OrderItemType.ProductItem && od.IsCompleted).Select(od => od).OrderByDescending(od => od.Id).FirstOrDefault();
            SaveProductShipping(productDetail, activeOrderDetail, isExclusivelyRequested);

            var repository = ((IRepository<RefundRequest>)_refundRequestRepository);
            refundRequest.RequestStatus = (long)RequestStatus.Reverted;
            refundRequest.RefundRequestResult = new RefundRequestResult
                                                    {
                                                        ProcessedOn = DateTime.Now,
                                                        ProcessedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId
                                                    };
            repository.Save(refundRequest);

        }

        private void SaveProductShipping(OrderDetail productDetail, OrderDetail activeOrderDetail, bool isExclusivelyRequested)
        {
            if (productDetail == null || activeOrderDetail == null)
                return;
            var shippingOption = _shippingOptionRepository.GetShippingOptionByProductId(productDetail.OrderItem.ItemId);
            if (shippingOption != null)
            {
                var resultShippingDetails = _shippingDetailRepository.GetShippingDetailsForCancellation(activeOrderDetail.Id);
                var cdShippingDetails = _shippingDetailRepository.GetProductShippingDetailsForCancellation(activeOrderDetail.Id);

                if (!resultShippingDetails.IsNullOrEmpty() && (cdShippingDetails == null || (cdShippingDetails.Count() < resultShippingDetails.Count())))
                {
                    var address = _addressRepository.GetAddress(resultShippingDetails.First().ShippingAddress.Id);
                    address.Id = 0;
                    var productShippingDetail = new ShippingDetail
                                                    {
                                                        ShippingAddress = address,
                                                        Status = ShipmentStatus.Processing,
                                                        ActualPrice = shippingOption.Price,
                                                        ShippingOption = new ShippingOption { Id = shippingOption.Id },
                                                        IsExclusivelyRequested = isExclusivelyRequested,
                                                        DataRecorderMetaData = new DataRecorderMetaData
                                                                                   {
                                                                                       DataRecorderCreator = _organizationRoleUserRepository.GetOrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                                                                                       DateCreated = DateTime.Now,
                                                                                       DateModified = DateTime.Now
                                                                                   }
                                                    };
                    IShippingController shippingController = new ShippingController();
                    productShippingDetail = shippingController.OrderShipping(productShippingDetail);

                    IRepository<ShippingDetailOrderDetail> shippingDetailOrderDetailRepository = new ShippingDetailOrderDetailRepository();

                    var shippingDetailOrderDetail = new ShippingDetailOrderDetail
                                                        {
                                                            Amount = productShippingDetail.ActualPrice,
                                                            IsActive = true,
                                                            OrderDetailId = activeOrderDetail.Id,
                                                            ShippingDetailId = productShippingDetail.Id
                                                        };

                    shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);
                }
            }
        }
    }
}