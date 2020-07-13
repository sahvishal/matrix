using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class OperationsReportingService : IOperationsReportingService
    {
        readonly IEventCustomerRepository _eventCustomerRepository;
        readonly IUniqueItemRepository<Event> _eventRepository;
        readonly IOrderDetailRepository _orderDetailRepository;
        readonly ICdImageStatusModelFactory _cdImageStatusModelFactory;
        readonly ICustomerRepository _customerRepository;
        readonly IOrderRepository _orderRepository;
        private readonly ICdContentGeneratorTrackingRepository _cdContentGeneratorTrackingRepository;
        private readonly IOrganizationRoleUserRepository _orgRoleuserRepository;
        private readonly ICustomerCdContentTrackingModelFactory _customerCdContentTrackingModelFactory;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IBloodworksLabelViewModelFactory _bloodworksLabelViewModelFactory;
        private readonly ICdLabelViewModelFactory _cdLabelViewModelFactory;
        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;
        private readonly IBatchLabelViewModelFactory _batchLabelViewModelFactory;


        public OperationsReportingService(IEventCustomerRepository eventCustomerRepository, IUniqueItemRepository<Event> eventRepository, ICustomerRepository customerRepository,
            IOrderDetailRepository orderDetailRepository, ICdImageStatusModelFactory cdImageStatusModelFactory, IOrderRepository orderRepository, ICdContentGeneratorTrackingRepository cdContentGeneratorTrackingRepository,
            IOrganizationRoleUserRepository orgRoleuserRepository, ICustomerCdContentTrackingModelFactory customerCdContentTrackingModelFactory, IEventTestRepository eventTestRepository, IEventPackageRepository eventPackageRepository,
            IBloodworksLabelViewModelFactory bloodworksLabelViewModelFactory, ICdLabelViewModelFactory cdLabelViewModelFactory, IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService, IBatchLabelViewModelFactory batchLabelViewModelFactory)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
            _orderDetailRepository = orderDetailRepository;
            _cdImageStatusModelFactory = cdImageStatusModelFactory;
            _orderRepository = orderRepository;
            _cdContentGeneratorTrackingRepository = cdContentGeneratorTrackingRepository;
            _orgRoleuserRepository = orgRoleuserRepository;
            _customerCdContentTrackingModelFactory = customerCdContentTrackingModelFactory;
            _eventTestRepository = eventTestRepository;
            _eventPackageRepository = eventPackageRepository;
            _bloodworksLabelViewModelFactory = bloodworksLabelViewModelFactory;
            _cdLabelViewModelFactory = cdLabelViewModelFactory;
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;
            _batchLabelViewModelFactory = batchLabelViewModelFactory;
        }

        public ListModelBase<CdImageStatusModel, CdImageStatusModelFilter> GetCdImageStatusmodel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomerswithCdPurchase(pageNumber, pageSize, filter as CdImageStatusModelFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty())
            {
                return null;
            }

            var orderShippingStatus = _orderDetailRepository.GetCdImageShippingStatusfortheEventCustomers(eventCustomers.Select(ec => ec.Id).ToArray());
            var events = _eventRepository.GetByIds(eventCustomers.Select(ec => ec.EventId).ToArray());
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());
            return _cdImageStatusModelFactory.Create(eventCustomers, orderShippingStatus, customers, events);
        }

        public CustomerLabelListModel GetCustomerLabels(long eventId, int shippingStatus)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomersForShippingLabels(eventId, shippingStatus);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());
            return new CustomerLabelListModel()
            {
                CustomerLabelBasicModels = customers.Select(c => new CustomerLabelBasicModel() { Name = c.Name, Address = c.Address })
            };

        }

        public ListModelBase<CustomerCdContentTrackingModel, CustomerCdConentTrackingModelFilter> GetCustomerCdContentTrackingModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomersWithCdPurchase(pageNumber, pageSize, filter as CustomerCdConentTrackingModelFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty())
                return null;
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orderIds =
                _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(
                    eventCustomers.Select(ec => ec.Id).ToArray());

            var cdContentTrackingList =
                _cdContentGeneratorTrackingRepository.GetCdContentGeneratedforEventCustomerIds(
                    eventCustomers.Select(ec => ec.Id).ToArray());

            var orgRoleUserIds = (from cdContentGeneratorTracking in cdContentTrackingList
                                  where cdContentGeneratorTracking.DownloadedByOrgRoleUserId.HasValue
                                  select cdContentGeneratorTracking.DownloadedByOrgRoleUserId.Value).ToArray();

            var idNamePairs = _orgRoleuserRepository.GetNameIdPairofUsers(orgRoleUserIds);

            return _customerCdContentTrackingModelFactory.Create(eventCustomers, customers, orderIds, cdContentTrackingList,
                                                          idNamePairs);

        }

        public IEnumerable<BloodworksLabelViewModel> GetBloodworksLabel(long eventId)
        {
            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);
            eventCustomers = eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var orderIdEventCustomerIdPairs = _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray()).ToArray();

            var orderIdEventTestIdPairs = _eventTestRepository.GetEventTestIdForOrders(orderIdEventCustomerIdPairs.Select(pair => pair.FirstValue).ToArray()).ToArray();

            var eventTests = _eventTestRepository.GetbyIds(orderIdEventTestIdPairs.Select(pair => pair.SecondValue).ToArray());

            var eventTestIds = eventTests.Where(et => et.TestId == (long)TestType.Liver || et.TestId == (long)TestType.Lipid).Select(et => et.Id).ToArray();

            var eventCustomerIdsFromTest = (from oet in orderIdEventTestIdPairs
                                            join oec in orderIdEventCustomerIdPairs on oet.FirstValue equals oec.FirstValue
                                            where eventTestIds.Contains(oet.SecondValue)
                                            select oec.SecondValue).ToArray();

            var orderIdEventPackageIdPairs = _eventPackageRepository.GetEventPackageIdsForOrder(orderIdEventCustomerIdPairs.Select(pair => pair.FirstValue).ToArray());

            var eventPackages = _eventPackageRepository.GetByIds(orderIdEventPackageIdPairs.Select(pair => pair.SecondValue).ToArray()).ToArray();

            var eventPackageIds = eventPackages.Where(ep => ep.Tests.Where(t => t.TestId == (long)TestType.Liver || t.TestId == (long)TestType.Lipid
                                || t.TestId == (long)TestType.Crp || t.TestId == (long)TestType.Thyroid || t.TestId == (long)TestType.Psa || t.TestId == (long)TestType.Testosterone).Count() > 0).Select(ep => ep.Id).ToArray();

            var eventCustomerIdsFromPackage = (from oep in orderIdEventPackageIdPairs
                                               join oec in orderIdEventCustomerIdPairs on oep.FirstValue equals
                                                   oec.FirstValue
                                               where eventPackageIds.Contains(oep.SecondValue)
                                               select oec.SecondValue).ToArray();
            eventCustomers =
                eventCustomers.Where(
                    ec => eventCustomerIdsFromTest.Contains(ec.Id) || eventCustomerIdsFromPackage.Contains(ec.Id)).
                    Select(ec => ec).ToArray();

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var eventData = _eventRepository.GetById(eventId);
            return _bloodworksLabelViewModelFactory.Create(customers, eventData);
        }

        public BloodworksLabelViewModel GetBloodworksLabelForCustomer(long eventId, long customerId)
        {
            var eventData = _eventRepository.GetById(eventId);
            var customer = _customerRepository.GetCustomer(customerId);

            var tests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customerId);

            return GetBloodworksLabelForCustomer(eventData, customer, tests);
        }

        public BloodworksLabelViewModel GetBloodworksLabelForCustomer(Event eventData, Customer customer, List<Test> tests)
        {
            tests = tests.Where(t => TestGroup.BloodWorkTestIds.Contains(t.Id)).Select(t => t).ToList();

            return _bloodworksLabelViewModelFactory.Create(customer, eventData, tests);
        }

        public IEnumerable<CdLabelViewModel> GetCdLabelForEvent(long eventId)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomersForCdLabel(eventId);
            if (eventCustomers == null || eventCustomers.Count() < 1)
                return null;

            var customerIds = eventCustomers.Select(ec => ec.CustomerId).ToArray();

            var customers = _customerRepository.GetCustomers(customerIds);
            var eventData = _eventRepository.GetById(eventId);
            return _cdLabelViewModelFactory.Create(eventCustomers, customers, eventData);
        }

        public IEnumerable<BatchLabelViewModel> GetBatchLabelsForEvent(long eventId)
        {
            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);

            if (eventCustomers.IsNullOrEmpty())
                return null;

            eventCustomers = eventCustomers.Where(ec => ec.AppointmentId.HasValue).ToArray();
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            return _batchLabelViewModelFactory.Create(customers, eventCustomers);
        }
    }
}