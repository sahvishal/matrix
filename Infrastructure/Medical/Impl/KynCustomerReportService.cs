using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class KynCustomerReportService : IKynCustomerReportService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IKynCustomerReportingFactory _kynCustomerReportingFactory;
        private readonly IEventRepository _eventRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPodRepository _podRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICorporateCustomerCustomTagRepository _customTagRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;

        public KynCustomerReportService(IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IKynCustomerReportingFactory kynCustomerReportingFactory, IEventRepository eventRepository,
            IAppointmentRepository appointmentRepository, IPodRepository podRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IRoleRepository roleRepository, ICorporateCustomerCustomTagRepository customTagRepository,
            ICorporateAccountRepository corporateAccountRepository, IHospitalPartnerRepository hospitalPartnerRepository, IHealthAssessmentRepository healthAssessmentRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _kynCustomerReportingFactory = kynCustomerReportingFactory;
            _eventRepository = eventRepository;
            _appointmentRepository = appointmentRepository;
            _podRepository = podRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _roleRepository = roleRepository;
            _customTagRepository = customTagRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
        }

        public ListModelBase<KynCustomerModel, KynCustomerModelFilter> GetKynCustomerReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var kynfilter = filter as KynCustomerModelFilter;
            var eventCustomers = _eventCustomerRepository.GetKynEventCustomers(pageNumber, pageSize, kynfilter, out totalRecords);

            if (eventCustomers.IsNullOrEmpty()) return new KynCustomerListModel();
            var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();
            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).Distinct().ToArray();
            var healthAssessments = _healthAssessmentRepository.GetCustomerHealthInfoByEventCustomerIds(eventCustomerIds);

            var healthAssessmentsOrgRoleUserIds = healthAssessments.Where(ha => ha.DataRecorderMetaData != null && ha.DataRecorderMetaData.DataRecorderCreator != null).Select(ha => ha.DataRecorderMetaData.DataRecorderCreator.Id).ToList();
            var healthAssessmentsbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(healthAssessmentsOrgRoleUserIds.ToArray()).ToArray();
            var healthAssessmentModifiedByAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(healthAssessmentsOrgRoleUserIds.ToArray()).ToArray();
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);
            var appointments = _appointmentRepository.GetAppointmentsForEvents(eventIds);
            var showKyn = kynfilter != null && kynfilter.ShowOnlyKyn;

            var orgRoleUserIds = eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToList();
            var registeredbyAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(orgRoleUserIds);
            var roles = _roleRepository.GetAll();

            var registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray()).ToArray();
            var customerIds = customers.Select(c => c.CustomerId).ToArray();
            var customTags = _customTagRepository.GetByCustomerIds(customerIds);
            var corporateAccountNames = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);
            var hospitalPartnerNames = _hospitalPartnerRepository.GetEventIdHospitalPartnerNamePair(eventIds);
            return _kynCustomerReportingFactory.Create(eventCustomers, events, customers, appointments, pods, showKyn, registeredbyAgent, roles, registeredbyAgentNameIdPair, customTags, corporateAccountNames, hospitalPartnerNames,
                healthAssessments, healthAssessmentsbyAgentNameIdPair,healthAssessmentModifiedByAgent);
        }
    }
}
