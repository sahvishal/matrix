using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
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
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using FluentValidation;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class EventSchedulerService : IEventSchedulerService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly ITempCartRepository _tempCartRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IOnlineSchedulingDataFactory _onlineSchedulingDataFactory;
        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly IValidator<SourceCodeApplyEditModel> _sourceCodeValidator;
        private readonly IEventCustomerSummaryModelFactory _eventCustomerSummaryModelFactory;
        private readonly IElectronicProductRepository _productRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IShippingController _shippingController;
        private readonly IPaymentController _paymentController;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderController _orderController;
        private readonly IShippingDetailOrderDetailRepository _shipingDetailOrderDetailRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IRefundRequestRepository _refundRequestRepository;
        private readonly IToolTipRepository _toolTipRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IEventSchedulingSlotService _slotService;
        private readonly IEventSchedulingSlotRepository _slotRepository;
        private readonly IEventAppointmentService _eventAppointmentService;
        private readonly IEligibilityRepository _eligibilityRepository;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;


        public EventSchedulerService(IEventRepository eventRepository, IAppointmentRepository appointmentRepository, IEventTestRepository eventTestRepository, IEventPackageRepository eventPackageRepository, IEventCustomerSummaryModelFactory eventCustomerSummaryModelFactory,
            IHostRepository hostRepository, ITempCartRepository tempCartRepository, IOnlineSchedulingDataFactory onlineSchedulingDataFactory, IValidator<SourceCodeApplyEditModel> sourceCodeValidator, ISourceCodeRepository sourceCodeRepository,
            ICustomerRepository customerRepository, IElectronicProductRepository electronicProductRepository, IShippingOptionRepository shippingOptionRepository, IPaymentController paymentController, IEventCustomerRepository eventCustomerRepository,
            IShippingController shippingController, IOrderController orderController, IAddressRepository addressRepository, IHospitalPartnerRepository hospitalPartnerRepository, IShippingDetailOrderDetailRepository shipingDetailOrderDetailRepository,
            IOrganizationRepository organizationRepository, IOrderRepository orderRepository, IRefundRequestRepository refundRequestRepository, IToolTipRepository toolTipRepository, IConfigurationSettingRepository configurationSettingRepository,
            IEventSchedulingSlotService slotService, IEventSchedulingSlotRepository slotRepository, IEventAppointmentService eventAppointmentService, IEligibilityRepository eligibilityRepository, IChargeCardRepository chargeCardRepository, ICorporateAccountRepository corporateAccountRepository)
        {
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _appointmentRepository = appointmentRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _tempCartRepository = tempCartRepository;
            _hostRepository = hostRepository;
            _onlineSchedulingDataFactory = onlineSchedulingDataFactory;
            _sourceCodeValidator = sourceCodeValidator;
            _sourceCodeRepository = sourceCodeRepository;
            _eventCustomerSummaryModelFactory = eventCustomerSummaryModelFactory;
            _productRepository = electronicProductRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _paymentController = paymentController;
            _eventCustomerRepository = eventCustomerRepository;
            _shippingController = shippingController;
            _orderController = orderController;
            _shipingDetailOrderDetailRepository = shipingDetailOrderDetailRepository;
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRepository = organizationRepository;
            _refundRequestRepository = refundRequestRepository;
            _toolTipRepository = toolTipRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _slotService = slotService;
            _slotRepository = slotRepository;
            _eventAppointmentService = eventAppointmentService;
            _eligibilityRepository = eligibilityRepository;
            _chargeCardRepository = chargeCardRepository;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public OnlineSchedulingProcessAndCartViewModel GetOnlineCart(string guid)
        {
            var tempCart = _tempCartRepository.Get(guid);
            if (tempCart == null) return null;
            return GetOnlineCart(tempCart);
        }

        public OnlineSchedulingProcessAndCartViewModel GetOnlineCart(TempCart tempCart)
        {
            var customer = tempCart.CustomerId == null ? null : _customerRepository.GetCustomer(tempCart.CustomerId.Value);
            var appointment = tempCart.AppointmentId.HasValue
                                      ? _slotRepository.GetbyId(tempCart.AppointmentId.Value)
                                      : null;

            string sponsoredBy = "";
            var checkoutPhoneNumber = string.Empty;
            if (tempCart.EventId.HasValue)
            {
                var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(tempCart.EventId.Value);
                if (hospitalPartnerId > 0)
                {
                    var hospitalPartner =
                        _organizationRepository.GetOrganizationbyId(hospitalPartnerId);
                    sponsoredBy = hospitalPartner.Name;
                }
                var account = _corporateAccountRepository.GetbyEventId(tempCart.EventId.Value);
                if (account != null && account.CheckoutPhoneNumber != null && !string.IsNullOrWhiteSpace(PhoneNumber.ToNumber(account.CheckoutPhoneNumber.ToString())))
                {
                    checkoutPhoneNumber = account.CheckoutPhoneNumber.FormatPhoneNumber;
                }
            }

            return _onlineSchedulingDataFactory.Create(tempCart, customer, appointment, sponsoredBy, checkoutPhoneNumber);
        }

        public SourceCodeApplyEditModel ApplySourceCode(SourceCodeApplyEditModel model)
        {
            var result = _sourceCodeValidator.Validate(model);
            if (!result.IsValid)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result.Errors.First().ErrorMessage);
                return model;
            }

            var sourceCode = _sourceCodeRepository.GetSourceCodeByCode(model.SourceCode.Trim());
            model.SourceCodeId = sourceCode.Id;

            switch (sourceCode.DiscountType)
            {
                case DiscountType.PerOrder:
                    model.DiscountApplied = Calculate(sourceCode.CouponValue, model.OrderTotal, sourceCode.DiscountValueType);
                    break;

                case DiscountType.PerPackage:
                    if (sourceCode.PackageDiscounts != null)
                    {
                        var packageDiscount = sourceCode.PackageDiscounts.Where(pd => pd.Id == model.Package.FirstValue).SingleOrDefault();

                        if (packageDiscount != null)
                        {
                            model.DiscountApplied = Calculate(packageDiscount.DiscountAmount, model.Package.SecondValue, packageDiscount.DiscountValueType);
                        }
                    }

                    if (sourceCode.TestDiscounts != null && model.SelectedTests != null)
                    {
                        foreach (var test in model.SelectedTests)
                        {
                            var testDiscount = sourceCode.TestDiscounts.Where(td => td.Id == test.FirstValue).SingleOrDefault();

                            if (testDiscount != null)
                            {
                                model.DiscountApplied += Calculate(testDiscount.DiscountAmount, test.SecondValue, testDiscount.DiscountValueType);
                            }
                        }
                    }
                    break;

                case DiscountType.PerProduct:
                    if (sourceCode.ProductDiscounts != null && model.SelectedProducts != null)
                    {
                        foreach (var product in model.SelectedProducts)
                        {
                            var prooductDiscount = sourceCode.ProductDiscounts.Where(pd => pd.Id == product.FirstValue).SingleOrDefault();

                            if (prooductDiscount != null)
                            {
                                model.DiscountApplied = Calculate(prooductDiscount.DiscountAmount, product.SecondValue, prooductDiscount.DiscountValueType);
                            }
                        }
                    }
                    break;

                case DiscountType.PerShipping:
                    if (sourceCode.ShippingDiscounts != null && model.SelectedShipping != null)
                    {
                        foreach (var shipping in model.SelectedShipping)
                        {
                            var shippingDiscount = sourceCode.ShippingDiscounts.Where(sd => sd.Id == shipping.FirstValue).SingleOrDefault();

                            if (shippingDiscount != null)
                            {
                                model.DiscountApplied = Calculate(shippingDiscount.DiscountAmount, shipping.SecondValue, shippingDiscount.DiscountValueType);
                            }
                        }
                    }
                    break;
            }

            return model;
        }

        public SourceCodeApplyEditModel GetSourceCodeApplied(TempCart tempCart, SourceCodeApplyEditModel sourceCodeModel = null)
        {
            var model = new SourceCodeApplyEditModel
                            {
                                SignUpMode = (int)SignUpMode.Online,
                                SourceCodeHelpDescription = _toolTipRepository.GetToolTipContentByTag(ToolTipType.SourceCodeHelp)
                            };
            if (tempCart == null) return model;

            if (tempCart.EventId.HasValue) model.EventId = tempCart.EventId.Value;

            if (tempCart.CustomerId.HasValue) model.CustomerId = tempCart.CustomerId.Value;

            decimal orderTotal = 0;
            if (tempCart.EventPackageId.HasValue)
            {
                var eventPackage = _eventPackageRepository.GetById(tempCart.EventPackageId.Value);
                model.Package = new OrderedPair<long, decimal>(eventPackage.PackageId, eventPackage.Price);
                orderTotal += model.Package.SecondValue;
            }

            if (!string.IsNullOrEmpty(tempCart.TestId))
            {
                var eventTestIds = tempCart.TestId.Split(new[] { ',' }).Select(t => Convert.ToInt64(t.Trim()));
                var eventTests = _eventTestRepository.GetbyIds(eventTestIds);
                model.SelectedTests = eventTests.Select(et => new OrderedPair<long, decimal>(et.TestId, tempCart.EventPackageId.HasValue ? et.WithPackagePrice : et.Price)).ToArray();
                orderTotal += model.SelectedTests.Sum(s => s.SecondValue);
            }

            if (tempCart.ShippingId.HasValue && tempCart.ShippingId.Value > 0)
            {
                var shippingOption = _shippingOptionRepository.GetById(tempCart.ShippingId.Value);
                model.ShippingAmount = shippingOption.Price;
                orderTotal += model.ShippingAmount;
            }

            if (!string.IsNullOrEmpty(tempCart.ProductId))
            {
                var productids = tempCart.ProductId.Split(new[] { ',' }).Select(t => Convert.ToInt64(t.Trim()));
                var products = _productRepository.GetByIds(productids);
                model.ProductAmount = products.Sum(p => p.Price);
                orderTotal += model.ProductAmount;
            }

            model.OrderTotal = orderTotal;

            if (sourceCodeModel != null && sourceCodeModel.SourceCodeId > 0)
            {
                var sourceCode = _sourceCodeRepository.GetSourceCodeById(sourceCodeModel.SourceCodeId);
                model.SourceCode = sourceCode.CouponCode;
                model = ApplySourceCode(model);
            }
            else if (tempCart.SourceCodeId.HasValue && tempCart.SourceCodeId > 0)
            {
                var sourceCode = _sourceCodeRepository.GetSourceCodeById(tempCart.SourceCodeId.Value);
                model.SourceCode = sourceCode.CouponCode;
                model = ApplySourceCode(model);
            }

            return model;
        }

        private static decimal Calculate(decimal sourceCodeValue, decimal amountToApplyOn, DiscountValueType valueType)
        {
            if (valueType == DiscountValueType.Percent)
            {
                var discountAmount = (amountToApplyOn * (sourceCodeValue / 100));
                return amountToApplyOn <= discountAmount ? amountToApplyOn : discountAmount;
            }

            return amountToApplyOn <= sourceCodeValue ? amountToApplyOn : sourceCodeValue;
        }

        public EventCustomerOrderSummaryModel GetEventCustomerOrderSummaryModel(string cartGuid)
        {
            var tempCart = _tempCartRepository.Get(cartGuid);
            return GetEventCustomerOrderSummaryModel(tempCart);
        }

        public EventCustomerOrderSummaryModel GetEventCustomerOrderSummaryModel(TempCart tempCart, SourceCodeApplyEditModel sourceCodeModel = null)
        {
            if (tempCart == null) return new EventCustomerOrderSummaryModel();

            Event theEvent = null;
            Host eventHost = null;
            if (tempCart.EventId.HasValue)
            {
                theEvent = _eventRepository.GetById(tempCart.EventId.Value);
                eventHost = _hostRepository.GetHostForEvent(tempCart.EventId.Value);
            }

            EventSchedulingSlot appointment = null;
            if (tempCart.AppointmentId.HasValue)
                appointment = _slotRepository.GetbyId(tempCart.AppointmentId.Value);

            EventPackage eventPackage = null;
            if (tempCart.EventPackageId.HasValue)
                eventPackage = _eventPackageRepository.GetById(tempCart.EventPackageId.Value);

            IEnumerable<EventTest> eventTests = null;
            var testIds = new List<long>();
            if (!string.IsNullOrEmpty(tempCart.TestId))
            {
                string[] testIdStrings = tempCart.TestId.Split(new[] { ',' });
                foreach (var testIdString in testIdStrings)
                {
                    int i = 0;
                    if (int.TryParse(testIdString, out i))
                        testIds.Add(i);
                }
            }

            if (testIds.Count > 0)
                eventTests = _eventTestRepository.GetbyIds(testIds);

            IEnumerable<ElectronicProduct> products = null;

            var productIds = new List<long>();
            if (!string.IsNullOrEmpty(tempCart.ProductId))
            {
                string[] productIdStrings = tempCart.ProductId.Split(new[] { ',' });
                foreach (var productIdIdString in productIdStrings)
                {
                    int i = 0;
                    if (int.TryParse(productIdIdString, out i))
                        productIds.Add(i);
                }
            }

            if (productIds.Count > 0)
                products = _productRepository.GetByIds(productIds);

            ShippingOption shippingOption = null;
            if (tempCart.ShippingId.HasValue && tempCart.ShippingId.Value > 0)
            {
                shippingOption = _shippingOptionRepository.GetById(tempCart.ShippingId.Value);
            }


            SourceCodeApplyEditModel applySourceCodemodel = sourceCodeModel ?? GetSourceCodeApplied(tempCart);

            Order order = null;
            if (tempCart.IsCompleted)
            {
                order = _orderRepository.GetOrder(tempCart.CustomerId.Value, tempCart.EventId.Value);
            }

            return _eventCustomerSummaryModelFactory.Create(theEvent, eventHost, appointment, eventPackage, eventTests, products, shippingOption, applySourceCodemodel, order, tempCart.ShippingId);
        }

        public EventCustomerOrderSummaryModel GetEventCustomerOrderSummaryModel(TempCart tempCart, OrderPlaceEditModel orderPlaceEditModel, SourceCodeApplyEditModel sourceCodeModel)
        {
            if (tempCart == null) return new EventCustomerOrderSummaryModel();

            Event theEvent = null;
            Host eventHost = null;
            if (tempCart.EventId.HasValue)
            {
                theEvent = _eventRepository.GetById(tempCart.EventId.Value);
                eventHost = _hostRepository.GetHostForEvent(tempCart.EventId.Value);
            }

            EventSchedulingSlot appointment = null;
            if (tempCart.AppointmentId.HasValue)
                appointment = _slotRepository.GetbyId(tempCart.AppointmentId.Value);

            EventPackage eventPackage = null;
            if (orderPlaceEditModel.SelectedPackageId > 0)
                eventPackage = _eventPackageRepository.GetById(orderPlaceEditModel.SelectedPackageId);

            IEnumerable<EventTest> eventTests = null;
            if (orderPlaceEditModel.SelectedTestIds != null && orderPlaceEditModel.SelectedTestIds.Count() > 0)
                eventTests = _eventTestRepository.GetbyIds(orderPlaceEditModel.SelectedTestIds);

            IEnumerable<ElectronicProduct> products = null;
            if (orderPlaceEditModel.SelectedProductIds != null && orderPlaceEditModel.SelectedProductIds.Count() > 0)
                products = _productRepository.GetByIds(orderPlaceEditModel.SelectedProductIds);

            ShippingOption shippingOption = null;
            if (orderPlaceEditModel.SelectedShippingOptionId > 0)
            {
                shippingOption = _shippingOptionRepository.GetById(orderPlaceEditModel.SelectedShippingOptionId);
            }

            Order order = null;
            if (tempCart.IsCompleted)
            {
                order = _orderRepository.GetOrder(tempCart.CustomerId.Value, tempCart.EventId.Value);
            }
            return _eventCustomerSummaryModelFactory.Create(theEvent, eventHost, appointment, eventPackage, eventTests, products, shippingOption, sourceCodeModel, order, tempCart.ShippingId);
        }

        public void CreateOrder(TempCart tempCart, PaymentEditModel paymentEditModel = null)
        {
            if (tempCart.EventId == null || tempCart.CustomerId == null || tempCart.AppointmentId == null || (tempCart.EventPackageId == null && string.IsNullOrEmpty(tempCart.TestId)))
                return;

            var customer = _customerRepository.GetCustomer(tempCart.CustomerId.Value);
            var inDb = _eventCustomerRepository.Get(tempCart.EventId.Value, tempCart.CustomerId.Value);

            var eventCustomer = new EventCustomer
            {
                Id = inDb != null ? inDb.Id : 0,
                EventId = tempCart.EventId.Value,
                CustomerId = tempCart.CustomerId.Value,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DataRecorderCreator = new OrganizationRoleUser(tempCart.CustomerId.Value),
                    DateCreated = DateTime.Now
                },
                OnlinePayment = true,
                MarketingSource = tempCart.MarketingSource,
                NoShow = false,
                TestConducted = false,
                HIPAAStatus = RegulatoryState.Unknown,
                EnableTexting = customer.EnableTexting
            };

            using (var scope = new TransactionScope())
            {

                var appointment = _eventAppointmentService.CreateAppointment(tempCart.InChainAppointmentSlotIds, tempCart.CustomerId.Value);
                eventCustomer.AppointmentId = appointment.Id;
                eventCustomer = _eventCustomerRepository.Save(eventCustomer);

                //Moved code into ProcessPayment to Extract Common Code for API and Service
                ProcessPayment(paymentEditModel, eventCustomer.Id, customer.CustomerId, false);

                var orderables = new List<IOrderable>();

                if (tempCart.EventPackageId.HasValue)
                {
                    orderables.Add(_eventPackageRepository.GetById(tempCart.EventPackageId.Value));
                }


                var testIds = new List<long>();
                if (!string.IsNullOrEmpty(tempCart.TestId))
                {
                    string[] testIdStrings = tempCart.TestId.Split(new[] { ',' });
                    foreach (var testIdString in testIdStrings)
                    {
                        int i = 0;
                        if (int.TryParse(testIdString, out i))
                            testIds.Add(i);
                    }
                }

                if (testIds.Count > 0)
                {
                    var eventTests = _eventTestRepository.GetbyIds(testIds);
                    if (tempCart.EventPackageId.HasValue)
                    {
                        foreach (var eventTest in eventTests)
                        {
                            eventTest.Price = eventTest.WithPackagePrice;
                        }
                    }
                    orderables.AddRange(eventTests);
                }

                IEnumerable<ElectronicProduct> products = null;
                var productIds = new List<long>();
                if (!string.IsNullOrEmpty(tempCart.ProductId))
                {
                    string[] productIdStrings = tempCart.ProductId.Split(new[] { ',' });
                    foreach (var productIdIdString in productIdStrings)
                    {
                        int i = 0;
                        if (int.TryParse(productIdIdString, out i))
                            productIds.Add(i);
                    }
                }

                if (productIds.Count > 0)
                {
                    products = _productRepository.GetByIds(productIds);
                    orderables.AddRange(products);
                }

                if (orderables.IsNullOrEmpty()) return;

                SourceCode sourceCode = null;
                if (tempCart.SourceCodeId.HasValue && tempCart.SourceCodeId.Value > 0)
                {
                    var sourceCodeModel = GetSourceCodeApplied(tempCart);
                    sourceCode = new SourceCode
                                     {
                                         Id = sourceCodeModel.SourceCodeId,
                                         CouponCode = sourceCodeModel.SourceCode,
                                         CouponValue = sourceCodeModel.DiscountApplied
                                     };
                }

                var shippingAddress = tempCart.ShippingAddressId.HasValue
                                          ? _addressRepository.GetAddress(tempCart.ShippingAddressId.Value)
                                          : null;

                ShippingDetail shippingDetail = null;
                if (tempCart.ShippingId != null && tempCart.ShippingId.Value > 0)
                {
                    var shippingOption = _shippingOptionRepository.GetById(tempCart.ShippingId.Value);
                    shippingDetail = new ShippingDetail
                                         {
                                             ShippingOption = shippingOption,
                                             ShippingAddress = shippingAddress,
                                             Status = ShipmentStatus.Processing,
                                             ActualPrice = shippingOption.Price,
                                             DataRecorderMetaData = new DataRecorderMetaData(tempCart.CustomerId.Value, DateTime.Now, null)
                                         };
                    shippingDetail = _shippingController.OrderShipping(shippingDetail);
                }

                bool indentedLineItemsAdded = false;
                // TODO: applying hook to the system all the indented line items will be attached to the first order item.
                foreach (var orderable in orderables)
                {
                    if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
                    {
                        _orderController.AddItem(orderable, 1, tempCart.CustomerId.Value, tempCart.CustomerId.Value, sourceCode, eventCustomer, shippingDetail, OrderStatusState.FinalSuccess);
                        indentedLineItemsAdded = true;
                    }
                    else
                        _orderController.AddItem(orderable, 1, tempCart.CustomerId.Value, tempCart.CustomerId.Value, OrderStatusState.FinalSuccess);
                }
                var order = _orderRepository.GetOrder(tempCart.CustomerId.Value, tempCart.EventId.Value);
                order = order == null ? _orderController.PlaceOrder(OrderType.Retail, tempCart.CustomerId.Value) : _orderController.ActivateOrder(order);

                if (products != null && products.Count() > 0 && shippingDetail != null)
                {
                    foreach (var electronicProduct in products)
                    {
                        SaveProductShippingDetail(electronicProduct.Id, order, shippingAddress, customer.CustomerId);
                    }
                }

                if (paymentEditModel != null && paymentEditModel.Payments != null && paymentEditModel.Payments.Any(p => p.ChargeCard != null || p.ECheck != null || p.GiftCertificate != null))
                {
                    var paymentId = _paymentController.SavePayment(paymentEditModel, tempCart.CustomerId.Value);
                    _orderRepository.ApplyPaymentToOrder(order.Id, paymentId);
                }

                scope.Complete();
            }

        }

        public void ProcessPayment(PaymentEditModel paymentEditModel, long eventCustomerId, long customerId, bool isAmexFullPayment)
        {
            if (paymentEditModel != null && paymentEditModel.Payments != null && paymentEditModel.Payments.Any(p => p.ChargeCard != null || p.ECheck != null || p.GiftCertificate != null || p.Check != null))
            {
                var aexPayment = paymentEditModel.Payments.SingleOrDefault(p => p.ChargeCard != null && p.ChargeCard.ChargeCard != null && p.ChargeCard.ChargeCard.TypeId == ChargeCardType.AmericanExpress);
                if (aexPayment != null && !isAmexFullPayment)
                {
                    aexPayment.Amount = Math.Round(aexPayment.Amount / 2, 2);
                    aexPayment.ChargeCard.ChargeCardPayment.Amount = aexPayment.Amount;
                }

                _paymentController.ManagePayment(paymentEditModel, customerId, (System.Web.HttpContext.Current != null ? System.Web.HttpContext.Current.Request.UserHostAddress : ""),
                    string.Concat(customerId, "_", eventCustomerId));
            }

            if (paymentEditModel != null && paymentEditModel.Payments != null && paymentEditModel.Payments.Any(p => p.Insurance != null))
            {
                var insurancePayment = paymentEditModel.Payments.Where(p => p.Insurance != null).Select(p => p.Insurance).SingleOrDefault();
                if (insurancePayment != null && insurancePayment.EligibilityId > 0 &&
                    insurancePayment.InsurancePayment.AmountToBePaid > 0)
                {
                    var chargeCard = _chargeCardRepository.GetById(insurancePayment.ChargeCardId);
                    chargeCard.DataRecorderMetaData.DataRecorderCreator.Id = customerId;
                    _chargeCardRepository.Save(chargeCard);
                    _eligibilityRepository.SaveEventCustomerEligibility(eventCustomerId, insurancePayment.EligibilityId, insurancePayment.ChargeCardId);
                }
            }
        }

        private void SaveProductShippingDetail(long productId, Order order, Address shippingAddress, long customerId)
        {
            var shippingOption = _shippingOptionRepository.GetShippingOptionByProductId(productId);
            if (shippingOption == null)
                return;

            OrderDetail orderDetail = _orderController.GetActiveOrderDetail(order);
            var productShippingDetail = new ShippingDetail
                                            {
                                                ShippingOption = shippingOption,
                                                ActualPrice = shippingOption.Price,
                                                Status = ShipmentStatus.Processing,
                                                ShippingAddress = shippingAddress,
                                                DataRecorderMetaData = new DataRecorderMetaData(customerId, DateTime.Now, null)
                                            };

            if (orderDetail != null)
            {
                productShippingDetail = _shippingController.OrderShipping(productShippingDetail);

                var shippingDetailOrderDetail = new ShippingDetailOrderDetail
                {
                    Amount = productShippingDetail.ActualPrice,
                    IsActive = true,
                    OrderDetailId = orderDetail.Id,
                    ShippingDetailId = productShippingDetail.Id
                };

                _shipingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);
            }
        }

        public SourceCodeApplyEditModel ApplySourceCode(long packageId, IEnumerable<long> addOnTestIds, decimal orderTotal, string sourceCode, long eventId, long customerId, SignUpMode signUpMode, decimal shippingAmount = 0, decimal productAmount = 0)
        {
            var model = new SourceCodeApplyEditModel
            {
                OrderTotal = orderTotal,
                SourceCode = sourceCode,
                SignUpMode = (int)signUpMode,
                CustomerId = customerId,
                EventId = eventId
            };

            if (packageId > 0)
            {
                var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
                if (eventPackage != null)
                {
                    model.Package = new OrderedPair<long, decimal>(eventPackage.PackageId, eventPackage.Price);
                }
            }
            if (addOnTestIds != null && addOnTestIds.Count() > 0)
            {
                var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, addOnTestIds);
                if (eventTests != null && eventTests.Count > 0)
                {
                    model.SelectedTests = eventTests.Select(et => new OrderedPair<long, decimal>(et.TestId, packageId > 0 ? et.WithPackagePrice : et.Price));
                }
            }

            model = ApplySourceCode(model);
            return model;
        }

        public OrderedPair<bool, string> DoesEventCustomerAlreadyExists(long customerId, long eventId)
        {
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            if (eventCustomer == null) return new OrderedPair<bool, string>(false, string.Empty);

            if (eventCustomer.AppointmentId != null) return new OrderedPair<bool, string>(true, "Already registered for this Event!");

            var orderId = _orderRepository.GetOrderIdByEventIdCustomerId(eventId, customerId);

            var refundRequest = _refundRequestRepository.GetbyOrderId(orderId);
            if (refundRequest != null && refundRequest.Count() > 0 && refundRequest.Where(rr => rr.RequestStatus == (long)RequestStatus.Pending && rr.RefundRequestType == RefundRequestType.CustomerCancellation).Count() > 0)
            {
                return new OrderedPair<bool, string>(true, "Once registered for this Event, but canceled, and Refund is in process. Can't register!");
            }

            return new OrderedPair<bool, string>(false, string.Empty);
        }

        public AppointmentSelectionEditModel GetAppointmentmentSelectionEditModel(TempCart tempcart)
        {
            if (tempcart.EventId.HasValue && tempcart.EventId.Value > 0 && !tempcart.InChainAppointmentSlotIds.IsNullOrEmpty())
                return _slotService.GetAppointmentSelectionModel(tempcart.EventId.Value, 0, tempcart.InChainAppointmentSlotIds, 0, null);
            return null;
        }

        public PackageSelectionInfoEditModel GetPackageSelectionInfoEditModel(TempCart tempCart, PreQualificationResult preQualificationResult)
        {
            var model = new PackageSelectionInfoEditModel
                           {
                               Gender = !string.IsNullOrEmpty(tempCart.Gender) ? ((int)(Gender)Enum.Parse(typeof(Gender), tempCart.Gender, true)) : (int?)null,
                               Dob = tempCart.Dob,
                               ChestPain = preQualificationResult.ChestPain ?? 0,
                               Diabetic = preQualificationResult.Diabetic ?? 0,
                               HeartDisease = preQualificationResult.HeartDisease ?? 0,
                               HighBloodPressure = preQualificationResult.HighBloodPressure ?? 0,
                               Smoker = preQualificationResult.Smoker ?? 0,
                               DiagnosedHeartProblem = preQualificationResult.DiagnosedHeartProblem ?? 0,
                               HighCholestrol = preQualificationResult.HighCholestrol ?? 0,
                               OverWeight = preQualificationResult.OverWeight ?? 0,
                               SkipPreQualificationQuestion = preQualificationResult.SkipPreQualificationQuestion
                           };
            return model;
        }

    }
}