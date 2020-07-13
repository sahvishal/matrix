using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Product = Falcon.App.Core.Enum.Product;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class DailyPatientRecapReportingService : IDailyPatientRecapReportingService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IUniqueItemRepository<ShippingDetail> _shippingDetailRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPodRepository _podRepository;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ITestRepository _testRepository;
        private readonly ITestNotPerformedRepository _testNotPerformedRepository;
        private readonly IDailyPatientRecapListModelFactory _dailyPatientRecapListModelFactory;

        public DailyPatientRecapReportingService(IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository,
            IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IUniqueItemRepository<ShippingDetail> shippingDetailRepository,
            IShippingOptionRepository shippingOptionRepository, IHospitalPartnerRepository hospitalPartnerRepository, IOrganizationRepository organizationRepository,
            ICorporateAccountRepository corporateAccountRepository, IAppointmentRepository appointmentRepository, IPodRepository podRepository, IEventPodRepository eventPodRepository, IEventRepository eventRepository,
            ITestRepository testRepository, ITestNotPerformedRepository testNotPerformedRepository, IDailyPatientRecapListModelFactory dailyPatientRecapListModelFactory)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRepository = organizationRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _appointmentRepository = appointmentRepository;
            _podRepository = podRepository;
            _eventPodRepository = eventPodRepository;
            _eventRepository = eventRepository;
            _testRepository = testRepository;
            _testNotPerformedRepository = testNotPerformedRepository;
            _dailyPatientRecapListModelFactory = dailyPatientRecapListModelFactory;
        }

        public ListModelBase<DailyPatientRecapModel, DailyPatientRecapModelFilter> GetDailyPatientReapModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetEventsCustomersForDailyPatientRecap(pageNumber, pageSize, filter as DailyPatientRecapModelFilter, out totalRecords);

            if (eventCustomers.IsNullOrEmpty()) return null;

            var eventIds = eventCustomers.Select(x => x.EventId).Distinct();
            var appointmentids = eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList();

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);

            var pods = _podRepository.GetPodsForEvents(eventIds);
            var eventPods = _eventPodRepository.GetByEventIds(eventIds);


            var customerIds = eventCustomers.Select(x => x.CustomerId).Distinct().ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var eventCustomerIds = eventCustomers.Select(x => x.Id).ToArray();

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds, true);

            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orders.Select(o => o.Id).ToList());
            //var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orders.Select(o => o.Id).ToList());

            var orderIdEventPackageTestIdPairs = _eventPackageRepository.GetOrderIdEventPackageTestIdPairsForOrder(orders.Select(o => o.Id).ToArray());
            var orderIdTestIdPairs = _eventTestRepository.GetOrderIdTestIdPairsForOrders(orders.Select(o => o.Id).ToArray());
            var testNotPerformedEventCustomerIdTestIdPairs = _testNotPerformedRepository.GetEventCusromerResultIdTestIdPairs(eventCustomerIds);

            var testIds = orderIdEventPackageTestIdPairs.Select(op => op.SecondValue).Distinct().ToList();
            testIds.AddRange(orderIdTestIdPairs.Select(op => op.SecondValue).Distinct().ToArray());
            var tests = _testRepository.GetTestNameValuePair(testIds);


            var shippingDetailIds = orders.SelectMany(o => o.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId))).ToArray();
            var shippingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds);

            var cdShippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);


            var eventHospitalPartners = _hospitalPartnerRepository.GetEventHospitalPartnersByEventIds(eventIds).ToArray();

            var organizationIds = eventHospitalPartners.Select(ehp => ehp.HospitalPartnerId).Distinct().ToArray();
            var hospitalFacilityIds = eventCustomers.Where(ec => ec.HospitalFacilityId.HasValue && ec.HospitalFacilityId.Value > 0).Select(ec => ec.HospitalFacilityId.Value).ToArray();

            organizationIds = organizationIds.Concat(hospitalFacilityIds).ToArray();

            var organizations = _organizationRepository.GetOrganizations(organizationIds);
            var eventIdHospitalPartnerNamePairs = (from ehp in eventHospitalPartners
                                                   join org in organizations on ehp.HospitalPartnerId equals org.Id
                                                   select new OrderedPair<long, string>(ehp.EventId, org.Name)).ToArray();

            var eventIdCorporateAccounrNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            var appointments = _appointmentRepository.GetByIds(appointmentids);

            return _dailyPatientRecapListModelFactory.CreateListModel(eventCustomers, customers, orders, shippingDetails, cdShippingOption, eventIdHospitalPartnerNamePairs, eventIdCorporateAccounrNamePairs, appointments,
                pods, eventPods, events, orderIdEventPackageTestIdPairs, orderIdTestIdPairs, testNotPerformedEventCustomerIdTestIdPairs, tests, orderPackageIdNamePair);

        }



        public ListModelBase<DailyPatientRecapCustomModel, DailyPatientRecapModelFilter> GetDailyPatientReapCustomModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetEventsCustomersForDailyPatientRecapCustom(pageNumber, pageSize, filter as DailyPatientRecapModelFilter, out totalRecords);

            if (eventCustomers.IsNullOrEmpty()) return null;

            var eventIds = eventCustomers.Select(x => x.EventId).Distinct();

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);

            var pods = _podRepository.GetPodsForEvents(eventIds);
            var eventPods = _eventPodRepository.GetByEventIds(eventIds);


            var customerIds = eventCustomers.Select(x => x.CustomerId).Distinct().ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var eventCustomerIds = eventCustomers.Select(x => x.Id).ToArray();

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds, true);

            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orders.Select(o => o.Id).ToList());
            //var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orders.Select(o => o.Id).ToList());

            var orderIdEventPackageTestIdPairs = _eventPackageRepository.GetOrderIdEventPackageTestIdPairsForOrder(orders.Select(o => o.Id).ToArray());
            var orderIdTestIdPairs = _eventTestRepository.GetOrderIdTestIdPairsForOrders(orders.Select(o => o.Id).ToArray());
            var testNotPerformedEventCustomerIdTestIdPairs = _testNotPerformedRepository.GetEventCusromerResultIdTestIdPairs(eventCustomerIds);

            var testIds = orderIdEventPackageTestIdPairs.Select(op => op.SecondValue).Distinct().ToList();
            testIds.AddRange(orderIdTestIdPairs.Select(op => op.SecondValue).Distinct().ToArray());
            var tests = _testRepository.GetTestNameValuePair(testIds);


            var eventIdCorporateAccounrNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            return _dailyPatientRecapListModelFactory.CreateCustomListModel(eventCustomers, customers, orders, eventIdCorporateAccounrNamePairs,
                pods, eventPods, events, orderIdEventPackageTestIdPairs, orderIdTestIdPairs, testNotPerformedEventCustomerIdTestIdPairs, tests, orderPackageIdNamePair);

        }
    }
}
