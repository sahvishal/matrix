using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class CustomAppointmentBookedReportingService : ICustomAppointmentBookedReportingService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUniqueItemRepository<Appointment> _appointmentRepository;
        private readonly IEventReportingService _eventReportingService;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventAppointmentChangeLogRepository _eventAppointmentChangeLogRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICustomAppointmentsBookedModelFactory _customAppointmentsBookedModelFactory;
        private readonly IAddressRepository _addressRepository;
        private readonly IEventRepository _eventRepository;



        public CustomAppointmentBookedReportingService(IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IUniqueItemRepository<Appointment> appointmentRepository,
            IEventReportingService eventReportingService, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository,
           IEventAppointmentChangeLogRepository eventAppointmentChangeLogRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IRoleRepository roleRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ILanguageRepository languageRepository,
            ICustomAppointmentsBookedModelFactory customAppointmentsBookedModelFactory, IAddressRepository addressRepository, IEventRepository eventRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _appointmentRepository = appointmentRepository;
            _eventReportingService = eventReportingService;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _eventAppointmentChangeLogRepository = eventAppointmentChangeLogRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _roleRepository = roleRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _languageRepository = languageRepository;
            _customAppointmentsBookedModelFactory = customAppointmentsBookedModelFactory;
            _addressRepository = addressRepository;
            _eventRepository = eventRepository;
        }

        public ListModelBase<CustomAppointmentsBookedModel, CustomAppointmentsBookedListModelFilter> GetCustomAppointmentsBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {

            var customFilter = filter as CustomAppointmentsBookedListModelFilter;
            customFilter = customFilter ?? new CustomAppointmentsBookedListModelFilter();

            var appFilter = new AppointmentsBookedListModelFilter
            {
                AccountId = customFilter.AccountId,
                FromDate = customFilter.FromDate,
                ToDate = customFilter.ToDate,
                Tag = customFilter.Tag
            };
            var eventCustomers = _eventCustomerRepository.GetEventCustomersbyRegisterationDate(pageNumber, pageSize, appFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());
            var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();
            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).Distinct().ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());
            var customerIds = customers.Select(x => x.CustomerId);
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray(), true);

            var eventPackages = _eventPackageRepository.GetbyEventIds(eventIds);
            var eventTests = _eventTestRepository.GetByEventIds(eventIds);


            var orgRoleUserIds = eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToList();

            var eventAppointmentChangeLogs = _eventAppointmentChangeLogRepository.GetByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray()).ToArray();

            orgRoleUserIds.AddRange(eventAppointmentChangeLogs.Select(eacl => eacl.CreatedByOrgRoleUserId));

            var registeredbyAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(orgRoleUserIds);

            var roles = _roleRepository.GetAll();

            var registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray()).ToArray();

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());
            var languages = _languageRepository.GetAll();

            return _customAppointmentsBookedModelFactory.Create(eventCustomers, appointments, orders, model, customers, registeredbyAgent,
                roles, registeredbyAgentNameIdPair, eventAppointmentChangeLogs, primaryCarePhysicians, eventPackages, eventTests, languages);
        }

        public IEnumerable<Address> SetCustomerSearchDetails(IEnumerable<long> billingAddressIds)
        {
            var collection = new List<Address>();
            if (!billingAddressIds.IsNullOrEmpty())
            {
                collection = _addressRepository.GetAddresses(billingAddressIds.ToList());
            }

            return collection;
        }

        public IEnumerable<OffCallEventDetail> GetOffCallEventDetails(IEnumerable<long> customerIds)
        {
            var collection = new List<OffCallEventDetail>();

            var eventCustomers = _eventCustomerRepository.GetLatestEventCustomersByCustomerId(customerIds);

            if (eventCustomers.IsNullOrEmpty())
                return collection;

            var events = _eventRepository.GetEvents(eventCustomers.Select(x => x.EventId).ToArray());

            foreach (var eventCustomer in eventCustomers)
            {
                var eventData = events.First(x => x.Id == eventCustomer.EventId);
                var model = new OffCallEventDetail
                {
                    CustomerId = eventCustomer.CustomerId,
                    EventId = eventCustomer.EventId,
                    EventDate = eventData.EventDate,
                    EventName = eventData.Name,
                };
                collection.Add(model);
            }
            return collection;
        }
    }
}