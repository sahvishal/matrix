using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    //Need to rename it.
    [DefaultImplementation]
    public class FinanceReportingService : IFinanceReportingService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        private readonly IEventReportingService _eventReportingService;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IElectronicProductRepository _productRepository;
        private readonly ICustomerUpsellModelFactory _customerUpsellModelFactory;
        private readonly IChargeCardPaymentRepository _chargeCardPaymentRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly IPodRepository _podRepository;
        private readonly ICreditCardReconcileListModelFactory _creditCardReconcileListModelFactory;
        private readonly IHostRepository _hostRepository;
        private readonly IDeferredRevenueListModelFactory _deferredRevenueListModelFactory;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IShippingRevenueSummaryListModelFactory _shippingRevenueSummaryListModelFactory;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IDetailOpenOrderModelFactory _detailOpenOrderModelFactory;
        private readonly IInsurancePaymentListModelFactory _insurancePaymentListModelFactory;
        private readonly IEligibilityService _eligibilityService;
        private readonly IEventService _eventService;
        private readonly IGiftCertificateReportFactory _giftCertificateReportFactory;


        public FinanceReportingService(ICustomerRepository customerRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IOrderRepository orderRepository,
            IEventReportingService eventReportingService, IOrganizationRoleUserRepository organizationRoleUserRepository, IElectronicProductRepository productRepository,
            ICustomerUpsellModelFactory customerUpsellModelFactory, IChargeCardPaymentRepository chargeCardPaymentRepository, IPaymentRepository paymentRepository, IEventCustomerRepository eventCustomerRepository,
            IChargeCardRepository chargeCardRepository, IPodRepository podRepository, IEventRepository eventRepository, ICreditCardReconcileListModelFactory creditCardReconcileListModelFactory, IHostRepository hostRepository,
            IDeferredRevenueListModelFactory deferredRevenueListModelFactory, IShippingDetailRepository shippingDetailRepository, IShippingRevenueSummaryListModelFactory shippingRevenueSummaryListModelFactory,
            IShippingOptionRepository shippingOptionRepository, IDetailOpenOrderModelFactory detailOpenOrderModelFactory, ICorporateAccountRepository corporateAccountRepository, IInsurancePaymentListModelFactory insurancePaymentListModelFactory,
            IEligibilityService eligibilityService, IEventService eventService, IGiftCertificateReportFactory giftCertificateReportFactory)
        {
            _customerRepository = customerRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _orderRepository = orderRepository;
            _eventReportingService = eventReportingService;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _productRepository = productRepository;
            _customerUpsellModelFactory = customerUpsellModelFactory;
            _chargeCardPaymentRepository = chargeCardPaymentRepository;
            _paymentRepository = paymentRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _chargeCardRepository = chargeCardRepository;
            _podRepository = podRepository;
            _eventRepository = eventRepository;
            _creditCardReconcileListModelFactory = creditCardReconcileListModelFactory;
            _hostRepository = hostRepository;
            _deferredRevenueListModelFactory = deferredRevenueListModelFactory;
            _shippingDetailRepository = shippingDetailRepository;
            _shippingRevenueSummaryListModelFactory = shippingRevenueSummaryListModelFactory;
            _shippingOptionRepository = shippingOptionRepository;
            _detailOpenOrderModelFactory = detailOpenOrderModelFactory;
            _corporateAccountRepository = corporateAccountRepository;
            _insurancePaymentListModelFactory = insurancePaymentListModelFactory;
            _eligibilityService = eligibilityService;
            _eventService = eventService;
            _giftCertificateReportFactory = giftCertificateReportFactory;
        }

        // Belongs to Sales Domain ??
        public ListModelBase<CustomerUpsellModel, CustomerUpsellListModelFilter> GetCustomerUpsellModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var orders = _orderRepository.GetAllUpgradedDowngradedOrders(pageNumber, pageSize, filter as CustomerUpsellListModelFilter, out totalRecords);
            if (orders.IsNullOrEmpty())
            {
                return null;
            }

            //var eventModel = _eventReportingService.GetEventVolumeModel(orders.Select(o => o.EventId.Value).ToArray());
            var eventModels = _eventService.GetEventBasicInfoEventIds(orders.Select(o => o.EventId.Value).ToArray());
            var customers = _customerRepository.GetCustomers(orders.Select(o => o.CustomerId).ToArray());

            var orderPackageNamePair = _eventPackageRepository.GetEventPackageIdNamePairs(orders.SelectMany(o => o.OrderDetails.Where(od => od.DetailType == OrderItemType.EventPackageItem).Select(od => od.OrderItem.ItemId)).ToArray());
            var orderTestNamePair = _eventTestRepository.GetTestIdNamePairs(orders.SelectMany(o => o.OrderDetails.Where(od => od.DetailType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId)).ToArray());

            var orderItemProductNamePair = _productRepository.GetProductNameForOrderItems(orders.SelectMany(o => o.OrderDetails.Select(od => od.OrderItemId)).ToArray());

            var orderAgents =
                _organizationRoleUserRepository.GetNameIdPairofUsers(
                    orders.SelectMany(
                        o =>
                        o.OrderDetails.Where(
                            od => od.DataRecorderMetaData != null && od.DataRecorderMetaData.DataRecorderCreator != null)
                            .
                            Select(od => od.DataRecorderMetaData.DataRecorderCreator.Id)).ToArray());

            return _customerUpsellModelFactory.Create(orders, eventModels, customers, orderPackageNamePair, orderTestNamePair, orderItemProductNamePair, orderAgents);
        }

        public ListModelBase<CreditCardReconcileModel, CreditCardReconcileModelFilter> GetCreditCardReconcileList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var chargeCardPayments = _chargeCardPaymentRepository.Get(filter as CreditCardReconcileModelFilter, pageNumber, pageSize, out totalRecords);
            if (chargeCardPayments == null || chargeCardPayments.Count() < 1) return null;

            var chargeCards = _chargeCardRepository.GetByIds(chargeCardPayments.Select(p => p.ChargeCardId).ToArray());

            var orderPaymentPair =
                _paymentRepository.GetOrderPaymentOrderedPairbyPaymentIds(chargeCardPayments.Select(p => p.PaymentId).ToArray());

            var orderEventCustomerPair =
                _orderRepository.GetOrderEventCustomeridPairforOrderIds(orderPaymentPair.Select(p => p.FirstValue).ToArray());

            var orders =
                _orderRepository.GetByIds(orderPaymentPair.Select(p => p.FirstValue).ToArray());

            var eventCustomers = _eventCustomerRepository.GetByIds(orderEventCustomerPair.Select(oep => oep.SecondValue).ToArray());

            var customers =
                _organizationRoleUserRepository.GetNameIdPairofUsers(orders.Select(o => o.CustomerId).ToArray());

            var pods = _podRepository.GetPodNamesforEventIds(eventCustomers.Select(ec => ec.EventId).ToArray());

            var events = _eventRepository.GetEventswithPodbyIds(orders.Where(o => o.EventId.HasValue && o.EventId > 0).Select(od => od.EventId.Value).ToArray());

            var corporateAccounts = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(events.Select(x => x.Id));

            return _creditCardReconcileListModelFactory.Create(chargeCardPayments, chargeCards, orderPaymentPair, orders, customers, events, pods, corporateAccounts);
        }

        public CustomerOrderListModel GetAllOrdersForCustomer(long customerId)
        {
            var eventCustomers = _eventCustomerRepository.GetbyCustomerId(customerId);
            var customers = _customerRepository.GetCustomer(customerId);
            if (eventCustomers.Count() > 0)
            {
                var customerOrders = new CustomerOrderListModel();
                customerOrders.Orders = new List<CustomerOrderModel>();
                customerOrders.CustomerId = customers.CustomerId;
                customerOrders.CustomerName = customers.Name.FullName;
                foreach (var eventCustomer in eventCustomers)
                {
                    var eventData = _eventRepository.GetById(eventCustomer.EventId);
                    var order = _orderRepository.GetOrder(customerId, eventCustomer.EventId);
                    var host = _hostRepository.GetHostForEvent(eventCustomer.EventId);
                    var customerOrder = new CustomerOrderModel
                                            {
                                                EventId = eventCustomer.EventId,
                                                EventDate = eventData.EventDate,
                                                Location = host.OrganizationName + " - " +
                                                           host.Address.City + ", " +
                                                           host.Address.State + ", " + host.Address.ZipCode.Zip,
                                                OrderId = order.Id,
                                                DiscountedTotal = order.DiscountedTotal,
                                                TotalPayment = order.TotalAmountPaid
                                            };
                    customerOrders.Orders.Add(customerOrder);
                }
                customerOrders.Orders = customerOrders.Orders.OrderByDescending(o => o.EventDate).ToList();
                return customerOrders;
            }
            return null;
        }

        public ListModelBase<DeferredRevenueViewModel, DeferredRevenueListModelFilter> GetDeferredRevenue(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var evenCustomers = _eventCustomerRepository.GetEventCustomersForDeferredRevenue(pageNumber, pageSize, filter as DeferredRevenueListModelFilter, out totalRecords);

            if (evenCustomers == null || evenCustomers.Count() < 1)
                return null;

            var events = _eventRepository.GetEventswithPodbyIds(evenCustomers.Select(ecr => ecr.EventId).Distinct().ToArray());
            events = events.OrderByDescending(e => e.EventDate);
            var pods = ((IUniqueItemRepository<Pod>)_podRepository).GetByIds(events.SelectMany(e => e.PodIds).Distinct());
            var hosts = _hostRepository.GetEventHosts(evenCustomers.Select(ecr => ecr.EventId).Distinct().ToArray());
            var customers = _customerRepository.GetCustomers(evenCustomers.Select(ecr => ecr.CustomerId).Distinct().ToArray());

            var eventCustomerIds = evenCustomers.Select(ecr => ecr.Id).ToArray();
            var orderEventCustomerIdPair =
                _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomerIds);

            var orderIds = orderEventCustomerIdPair.Select(o => o.FirstValue).ToArray();



            var orderAndeventPackagepairs = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderAndTestpairs = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var ecAndPackagePairs = (from p in orderEventCustomerIdPair
                                     join oep in orderAndeventPackagepairs on p.FirstValue equals oep.FirstValue
                                     select new OrderedPair<long, string>(p.SecondValue, oep.SecondValue)).ToArray();


            var ecAndTestPairs = (from p in orderEventCustomerIdPair
                                  join oet in orderAndTestpairs on p.FirstValue equals oet.FirstValue
                                  select new OrderedPair<long, string>(p.SecondValue, oet.SecondValue)).ToArray();

            var eventWiseRevenueDetails = _paymentRepository.GetEventWiseRevenueDetails(evenCustomers.Select(ecr => ecr.EventId).Distinct().ToArray());

            var eventCustomerIdOrderTotalPairs = _paymentRepository.GetEventCustomerIdOrderTotalPair(eventCustomerIds);

            var eventCustomerIdTotalPaymentPairs = _paymentRepository.GetEventCustomerIdTotalPaymentPair(eventCustomerIds);


            return _deferredRevenueListModelFactory.Create(evenCustomers, events, pods, customers, ecAndPackagePairs,
                                                           ecAndTestPairs, orderEventCustomerIdPair, hosts, eventWiseRevenueDetails, eventCustomerIdOrderTotalPairs, eventCustomerIdTotalPaymentPairs);

        }

        public ListModelBase<ShippingRevenueSummaryViewModel, ShippingRevenueListModelFilter> GetShippingRevenueSummary(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var events = _eventRepository.GetEventsForShippingRevenueSummary(pageNumber, pageSize, filter as ShippingRevenueListModelFilter, out totalRecords);

            if (events.IsNullOrEmpty())
                return null;
            var eventIds = events.Select(e => e.Id).ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);
            var eventIdShippingCountPairs = _shippingDetailRepository.GetEventIdShippingCountPair(eventIds);
            var eventIdShippingRevenuePairs = _shippingDetailRepository.GetEventIdShippingRevenuePair(eventIds);

            return _shippingRevenueSummaryListModelFactory.Create(events, hosts, pods, eventIdShippingCountPairs, eventIdShippingRevenuePairs);

        }

        public ListModelBase<ShippingRevenueDetailViewModel, ShippingRevenueListModelFilter> GetShippingRevenueDetail(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomersForShippingRevenueDetail(pageNumber, pageSize, filter as ShippingRevenueListModelFilter, out totalRecords);

            if (eventCustomers.IsNullOrEmpty())
                return null;

            var eventIds = eventCustomers.Select(e => e.EventId).ToArray();
            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray(), true);
            var shippingDetailIds = orders.SelectMany(o => o.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId))).ToArray();
            var shippingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds);
            shippingDetails = shippingDetails.Where(sd => sd.ActualPrice > 0).Select(sd => sd).ToArray();
            var shippingDetailIdEventCustomerIdPairs = _shippingDetailRepository.GetShippingDetailIdEventCustomerIdPairs(shippingDetails.Select(sd => sd.Id));
            var shippingOptions = _shippingOptionRepository.GetAllShippingOptions();
            return _shippingRevenueSummaryListModelFactory.CreateShippingRevenueDetail(eventCustomers, events, hosts, pods, customers, shippingDetails, shippingDetailIdEventCustomerIdPairs, shippingOptions, orders);
        }

        public ListModelBase<CustomerOpenOrderViewModel, CustomerOpenOrderListModelFilter> GetCustomerOpenOrder(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetCustomerOpenOrder(pageNumber, pageSize, filter as CustomerOpenOrderListModelFilter, out totalRecords);

            if (eventCustomers.IsNullOrEmpty())
                return null;

            var eventIds = eventCustomers.Select(e => e.EventId).ToArray();
            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());
            var eventCustomerIdOrderTotalPairs = _orderRepository.GetOpenOrderTotalForEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());
            var eventCustomerIdRevenuePairs = _orderRepository.GetOutstandingRevenueForEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());
            var orderIdEventCustomerIdPair = _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());

            return _detailOpenOrderModelFactory.CreateCustomerOpenOrder(eventCustomers, events, hosts, pods, customers, eventCustomerIdOrderTotalPairs, eventCustomerIdRevenuePairs, orderIdEventCustomerIdPair);
        }

        public ListModelBase<CorporateAccountInvoiceLineItemViewModel, CorporateAccountInvoiceListModelFilter> GetCorporateAccountInvoiceList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var objFilter = filter == null
                                ? new CorporateAccountInvoiceListModelFilter()
                                : filter as CorporateAccountInvoiceListModelFilter;

            var eventCustomers = _eventCustomerRepository.GetEventsforCorporateAccountInvoice(pageNumber, pageSize, objFilter, out totalRecords);

            var model = CorporateAccountInvoiceListModel.Empty();
            model.Filter = objFilter;

            if (eventCustomers == null || !eventCustomers.Any())
            {
                return model;
            }

            var events = _eventRepository.GetEventswithPodbyIds(eventCustomers.Select(ec => ec.EventId).Distinct().ToArray());

            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var orderIds = orders.Select(o => o.Id).ToArray();

            var eventPackagePairs = _eventPackageRepository.GetPackageNamesForOrder(orderIds);

            var eventTestPairs = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var corporates = _corporateAccountRepository.GetByIds(events.Select(e => e.AccountId.Value).Distinct());

            var list = new List<CorporateAccountInvoiceLineItemViewModel>();

            foreach (var eventCustomer in eventCustomers)
            {
                var theEvent = events.Single(e => e.Id == eventCustomer.EventId);
                var corporate = corporates.Single(c => c.Id == theEvent.AccountId.Value);

                var customer = customers.Single(c => c.CustomerId == eventCustomer.CustomerId);

                var order = orders.Single(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId);

                string purchased = "";

                var eventPackagePair = eventPackagePairs.Where(ep => ep.FirstValue == order.Id).ToArray();
                var eventTestPairforCustomer = eventTestPairs.Where(et => et.FirstValue == order.Id).ToArray();

                if (eventPackagePair.Any())
                    purchased = string.Join(", ", eventPackagePair.Select(ep => ep.SecondValue));

                if (eventTestPairforCustomer.Any())
                {
                    if (string.IsNullOrEmpty(purchased))
                        purchased = string.Join(", ", eventTestPairforCustomer.Select(et => et.SecondValue));
                    else
                        purchased += " + " + string.Join(", ", eventTestPairforCustomer.Select(et => et.SecondValue));

                }

                var obj = new CorporateAccountInvoiceLineItemViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.NameAsString,
                    EmployeeId = customer.EmployeeId,
                    EventDate = theEvent.EventDate,
                    OrderCost = order.UndiscountedTotal,
                    OrderPurchased = purchased,
                    AccountName = corporate.Name,
                    CorpCode = corporate.AccountCode,
                    EventId = theEvent.Id
                };

                list.Add(obj);

            }

            model.Collection = list;

            return model;
        }

        public ListModelBase<InsurancePaymentViewModel, InsurancePaymentListModelFilter> GetInsurancePayment(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetInsurancePayment(pageNumber, pageSize, filter as InsurancePaymentListModelFilter, out totalRecords);

            if (eventCustomers.IsNullOrEmpty())
                return null;

            var eventIds = eventCustomers.Select(e => e.EventId).ToArray();
            var eventCustomerId = eventCustomers.Select(ec => ec.Id).ToArray();
            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerId);
            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);
            var insuranceDetailViewModels = _eligibilityService.GetInsuranceDetailByEventCustomerIds(eventCustomerId);

            return _insurancePaymentListModelFactory.Create(eventCustomers, events, customers, orders, orderPackageIdNamePair, orderTestIdNamePair, insuranceDetailViewModels);
        }

        public ListModelBase<GiftCertificateReportViewModel, GiftCertificateReportFilter> GetGiftCertificateReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetForGiftCertificateReport(pageNumber, pageSize, filter as GiftCertificateReportFilter, out totalRecords);

            if (!eventCustomers.Any()) return null;

            var customerIds = eventCustomers.Select(x => x.CustomerId).ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            return _giftCertificateReportFactory.Create(customers, eventCustomers, model, orders, orderPackageIdNamePair, orderTestIdNamePair);
        }
    }
}
