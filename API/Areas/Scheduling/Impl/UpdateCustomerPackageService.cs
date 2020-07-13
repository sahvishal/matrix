using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using API.Areas.Finance;
using API.Areas.Scheduling.Models;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Operations.Impl;
using Falcon.App.Infrastructure.Repositories.Order;

namespace API.Areas.Scheduling.Impl
{
    public class UpdateCustomerPackageService : IUpdateCustomerPackageService
    {
        private readonly IOrderController _orderController;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IPatientShippingDetailFactory _patientShippingDetailFactory;
        private readonly IElectronicProductRepository _electronicProductRepository;
        //private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IShippingDetailOrderDetailRepository _shippingDetailOrderDetailRepository;
        private readonly ICustomerPaymentService _customerPaymentService;

        private readonly long _creatorOrganizationRoleUser;

        public UpdateCustomerPackageService(IOrderController orderController, ISessionContext sessionContext,
            IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository,
            IPatientShippingDetailFactory patientShippingDetailFactory,
            IElectronicProductRepository electronicProductRepository, IEventCustomerRepository eventCustomerRepository,
            IShippingDetailOrderDetailRepository shippingDetailOrderDetailRepository, ICustomerPaymentService customerPaymentService)
        {
            _orderController = orderController;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _patientShippingDetailFactory = patientShippingDetailFactory;
            _electronicProductRepository = electronicProductRepository;
          //  _eventCustomerRepository = eventCustomerRepository;
            _shippingDetailOrderDetailRepository = shippingDetailOrderDetailRepository;
            _customerPaymentService = customerPaymentService;

            _creatorOrganizationRoleUser = sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        }

        private Order GetOrder(long customerId, long eventId)
        {
            IOrderRepository orderRepository = new OrderRepository();

            return orderRepository.GetOrder(customerId, eventId);
        }

        public void ChangePackage(CustomerOrderDetail customerOrderDetail)
        {

            using (var scope = new TransactionScope())
            {
                if (customerOrderDetail.PaymentModel != null)
                {
                    try
                    {
                        _customerPaymentService.ProcessPayment(customerOrderDetail.PaymentModel);
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.Message, exception);
                    }

                }

                try
                {
                    var eventid = customerOrderDetail.EventId;
                    var customerid = customerOrderDetail.CustomerId;
                    //var eventCustomer = _eventCustomerRepository.Get(eventid, customerid);
                    var order = GetOrder(customerid, eventid);

                    SourceCode sourceCode = null;

                    if (customerOrderDetail.SourceCode != null)
                        sourceCode = new SourceCode
                        {
                            Id = customerOrderDetail.SourceCode.SourceCodeId,
                            CouponCode = customerOrderDetail.SourceCode.SourceCode,
                            CouponValue = customerOrderDetail.SourceCode.DiscountApplied
                        };

                    IOrderController orderController = new OrderController();
                    var orderDetail = orderController.GetActiveOrderDetail(order);

                    if (order == null || order.OrderDetails.IsEmpty()) return;

                    ShippingDetail shippingDetails = null;

                    if (customerOrderDetail.IsShippingPurchased && customerOrderDetail.ShippingOptions != null && customerOrderDetail.ShippingOptions.Any())
                    {
                        shippingDetails = _patientShippingDetailFactory.GetShippingDetailData(customerOrderDetail);
                    }

                    var orderables = new List<IOrderable>();
                    var selectedTestIds = new List<long>();

                    if (customerOrderDetail.AlaCarteTests != null && customerOrderDetail.AlaCarteTests.Any())
                    {
                        selectedTestIds = customerOrderDetail.AlaCarteTests.Select(x => x.TestId).ToList();
                    }

                    long packageId = 0;

                    if (customerOrderDetail.PackageModel != null && customerOrderDetail.PackageModel.PackageId > 0)
                    {
                        packageId = customerOrderDetail.PackageModel.PackageId;

                        orderables.Add(_eventPackageRepository.GetByEventAndPackageIds(eventid, packageId));
                        selectedTestIds = RemoveTestsAlreadyInPackage(selectedTestIds, eventid, packageId);
                    }

                    if (!selectedTestIds.IsNullOrEmpty())
                    {
                        var eventTests = _eventTestRepository.GetByEventAndTestIds(eventid, selectedTestIds);
                        if (packageId > 0)
                        {
                            foreach (var eventTest in eventTests)
                            {
                                eventTest.Price = eventTest.WithPackagePrice;
                            }
                        }

                        orderables.AddRange(eventTests);
                    }

                    ElectronicProduct product = null;
                    if (customerOrderDetail.ProductId.HasValue && customerOrderDetail.ProductId.Value > 0)
                    {
                        var productIsAlreadyPurchased =
                            order.OrderDetails.Any(
                                x =>
                                    x.DetailType == OrderItemType.ProductItem &&
                                    x.OrderItem.ItemId == customerOrderDetail.ProductId.Value);

                        if (!productIsAlreadyPurchased)
                        {
                            product = _electronicProductRepository.GetById(customerOrderDetail.ProductId.Value);
                            orderables.Add(product);
                        }
                    }

                    if (customerOrderDetail.IsShippingPurchased && shippingDetails != null)
                    {
                        IShippingController shippingController = new ShippingController();
                        var shippingDetail = shippingController.OrderShipping(shippingDetails);

                        var shippingDetailOrderDetail = new ShippingDetailOrderDetail
                        {
                            Amount = shippingDetail.ActualPrice,
                            IsActive = true,
                            OrderDetailId = orderDetail.Id,
                            ShippingDetailId = shippingDetail.Id
                        };

                        _shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);
                    }

                    var indentedLineItemsAdded = false;

                    // TODO: applying hook to the system all the indented line items will be attached to the first order item.
                    foreach (var orderable in orderables)
                    {
                        if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
                        {
                            _orderController.AddItem(orderable, 1, customerid, _creatorOrganizationRoleUser, sourceCode, null, null, OrderStatusState.FinalSuccess);
                            indentedLineItemsAdded = true;
                        }
                        else
                            _orderController.AddItem(orderable, 1, customerid, _creatorOrganizationRoleUser, OrderStatusState.FinalSuccess);
                    }

                    _orderController.PlaceOrder(order);

                    if (shippingDetails != null)
                    {
                        SaveProductShippingDetail(product, orderDetail, shippingDetails);
                    }
                    scope.Complete();
                }
                catch (Exception exception)
                {
                    if (customerOrderDetail.PaymentModel == null)
                        throw new Exception("An Exception caused while saving the Order.", exception);

                    var paymentInstruments = customerOrderDetail.PaymentModel.Payments;
                    var chargeCardPayment = paymentInstruments.ChargeCard ?? null;

                    if (chargeCardPayment == null || paymentInstruments.Amount <= 0)
                        throw new Exception("An Exception caused while saving the Order.", exception);

                    var paymentGateway = IoC.Resolve<IPaymentProcessor>();

                    paymentGateway.VoidRequestforaPreviousResponse(chargeCardPayment.ChargeCardPayment.ProcessorResponse);
                    throw new Exception("An Exception caused while saving the Order.", exception);
                }
            }
        }

        private void SaveProductShippingDetail(ElectronicProduct product, OrderDetail orderDetail, ShippingDetail shippingDetail)
        {
            var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();

            if (product == null) return;

            var shippingOption = shippingOptionRepository.GetShippingOptionByProductId(product.Id);

            if (shippingOption == null)
                return;

            var productShippingDetail = new ShippingDetail();

            if (shippingDetail != null)
            {
                if (shippingOption.Id == shippingDetail.ShippingOption.Id)
                    return;
                productShippingDetail = shippingDetail;
            }


            productShippingDetail.Id = 0;
            productShippingDetail.ShippingAddress.Id = 0;
            productShippingDetail.ShippingOption.Id = shippingOption.Id;
            productShippingDetail.ActualPrice = shippingOption.Price;
            productShippingDetail.IsExclusivelyRequested = false;

            if (orderDetail != null)
            {
                IShippingController shippingController = new ShippingController();
                productShippingDetail = shippingController.OrderShipping(productShippingDetail);

                var shippingDetailOrderDetail = new ShippingDetailOrderDetail
                {
                    Amount = productShippingDetail.ActualPrice,
                    IsActive = true,
                    OrderDetailId = orderDetail.Id,
                    ShippingDetailId = productShippingDetail.Id
                };

                _shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);
            }

        }

        private List<long> RemoveTestsAlreadyInPackage(List<long> selectedTestIds, long eventId, long packageId)
        {
            if (eventId <= 0) return null;

            var packageRepository = IoC.Resolve<IEventPackageRepository>();
            var eventPackage = packageRepository.GetByEventAndPackageIds(eventId, packageId);

            var package = eventPackage != null ? eventPackage.Package : null;
            if (package == null || selectedTestIds.IsNullOrEmpty()) return null;

            var packageTestIds = package.Tests.Select(t => t.Id);
            selectedTestIds.RemoveAll(packageTestIds.Contains);

            return selectedTestIds;
        }

    }
}