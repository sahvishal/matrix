using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class HourlyAppointmentBookedReportingService : IHourlyAppointmentBookedReportingService
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
        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly ICorporateCustomerCustomTagRepository _customTagRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        private readonly IPcpAppointmentRepository _pcpAppointmentRepository;
        private readonly IAccountAdditionalFieldRepository _accountAdditionalFieldRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;


        public HourlyAppointmentBookedReportingService(IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository,
            IUniqueItemRepository<Appointment> appointmentRepository, IEventReportingService eventReportingService, IOrderRepository orderRepository,
            IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IEventAppointmentChangeLogRepository eventAppointmentChangeLogRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IRoleRepository roleRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
            ILanguageRepository languageRepository, ICustomAppointmentsBookedModelFactory customAppointmentsBookedModelFactory,
            ISourceCodeRepository sourceCodeRepository, ICallCenterCallRepository callCenterCallRepository, IShippingOptionRepository shippingOptionRepository,
            IShippingDetailRepository shippingDetailRepository, ICorporateCustomerCustomTagRepository customTagRepository,
            ICorporateAccountRepository corporateAccountRepository, IPcpAppointmentRepository pcpAppointmentRepository, IAccountAdditionalFieldRepository accountAdditionalFieldRepository,
            ICustomerEligibilityRepository customerEligibilityRepository)
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
            _sourceCodeRepository = sourceCodeRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _customTagRepository = customTagRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _pcpAppointmentRepository = pcpAppointmentRepository;
            _accountAdditionalFieldRepository = accountAdditionalFieldRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
        }

        public ListModelBase<HourlyAppointmentBookedModel, HourlyAppointmentsBookedListModelFilter> GetHourlyAppointmentsBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var customFilter = filter as HourlyAppointmentsBookedListModelFilter;
            customFilter = customFilter ?? new HourlyAppointmentsBookedListModelFilter();

            var appFilter = new AppointmentsBookedListModelFilter
            {
                AccountId = customFilter.AccountId,
                FromDate = customFilter.FromDate,
                ToDate = customFilter.ToDate,
                ShowCustomersWithAppointment = customFilter.ShowCustomersWithAppointment,
                IsHealthPlanEvent = true
            };

            var eventCustomers = _eventCustomerRepository.GetEventCustomersbyRegisterationDate(pageNumber, pageSize, appFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());
            var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();
            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).Distinct().ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());
            var customerIds = customers.Select(x => x.CustomerId);
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray(), true);
            var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, DateTime.Today.Year);

            if (customerEligibilities.IsNullOrEmpty())
                customerEligibilities = new List<CustomerEligibility>();

            var eventPackages = _eventPackageRepository.GetbyEventIds(eventIds);
            var eventTests = _eventTestRepository.GetByEventIds(eventIds);

            var sourceCodes = _sourceCodeRepository.GetSourceCodeByIds(orders.SelectMany(o => o.OrderDetails.Where(od => od.SourceCodeOrderDetail != null && od.SourceCodeOrderDetail.IsActive)
                .Select(od => od.SourceCodeOrderDetail.SourceCodeId)).Distinct().ToArray());

            var orgRoleUserIds = eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToList();

            var eventAppointmentChangeLogs = _eventAppointmentChangeLogRepository.GetByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray()).ToArray();

            orgRoleUserIds.AddRange(eventAppointmentChangeLogs.Select(eacl => eacl.CreatedByOrgRoleUserId));

            var registeredbyAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(orgRoleUserIds);

            var roles = _roleRepository.GetAll();

            var registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray()).ToArray();

            var callDetails = _callCenterCallRepository.GetCallDetails(customers);

            var shippingDetailIds = orders.SelectMany(o => o.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId))).ToArray();
            var shippingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds);
            var cdShippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);
            var shippingOptions = _shippingOptionRepository.GetAllShippingOptions();

            var customTags = _customTagRepository.GetByCustomerIds(customerIds);

            var tagNames = customers.Where(x => !string.IsNullOrEmpty(x.Tag)).Select(x => x.Tag).ToArray();
            var corporateAccount = _corporateAccountRepository.GetByTags(tagNames);
            var corporateAccountIds = corporateAccount.Select(x => x.Id).ToArray();
            var accountAdditionalField = _accountAdditionalFieldRepository.GetAccountAdditionalFieldsByAccountIds(corporateAccountIds);

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());
            var languages = _languageRepository.GetAll();
            var pcpAppointments = _pcpAppointmentRepository.GetByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());

            return _customAppointmentsBookedModelFactory.CreateHourlyModel(eventCustomers, appointments, orders, model, customers, registeredbyAgent, roles, registeredbyAgentNameIdPair, sourceCodes, callDetails,
               shippingDetails, cdShippingOption, shippingOptions, eventAppointmentChangeLogs, primaryCarePhysicians, eventPackages, eventTests, languages, customTags, corporateAccount,
               accountAdditionalField, pcpAppointments, customerEligibilities);
        }
    }
}