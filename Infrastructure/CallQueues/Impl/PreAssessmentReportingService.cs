using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;


namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class PreAssessmentReportingService : IPreAssessmentReportingService
    {

        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallQueueCustomerCallRepository _callQueueCustomerCallRepository;

        private readonly IPreAssessmentReportingFactory _preAssessmentReportingFactory;
        private readonly IPreAssessmentCustomerCallQueueCallAttemptRepository _preAssessmentCustomerCallQueueCallAttemptRepository;
        private readonly IEventService _eventService;

        public PreAssessmentReportingService(IPreAssessmentCustomerCallQueueCallAttemptRepository preAssessmentCustomerCallQueueCallAttemptRepository, ICallCenterCallRepository callCenterCallRepository, ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository,
           IPreAssessmentReportingFactory preAssessmentReportingFactory, IEventService eventService, ICorporateAccountRepository corporateAccountRepository, IAppointmentRepository appointmentRepository,
           IOrganizationRoleUserRepository organizationRoleUserRepository, ICallQueueCustomerCallRepository callQueueCustomerCallRepository)
        {
            _preAssessmentCustomerCallQueueCallAttemptRepository = preAssessmentCustomerCallQueueCallAttemptRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _preAssessmentReportingFactory = preAssessmentReportingFactory;
            _eventService = eventService;
            _corporateAccountRepository = corporateAccountRepository;
            _appointmentRepository = appointmentRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callQueueCustomerCallRepository = callQueueCustomerCallRepository;

        }

        public ListModelBase<PreAssessmentReportViewModel, PreAssessmentReportFilter> GetPreAssessmentReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var PreAssessmentReportFilter = filter as PreAssessmentReportFilter ?? new PreAssessmentReportFilter();
            var PreAsessmentQueueCustomers = _preAssessmentCustomerCallQueueCallAttemptRepository.GetForPreAssessmentReport(PreAssessmentReportFilter, pageNumber, pageSize, out totalRecords);

            var collection = new List<PreAssessmentReportViewModel>();

            if (PreAsessmentQueueCustomers.IsNullOrEmpty())
            {
                return new PreAssessmentReportListModel
                {
                    Collection = new List<PreAssessmentReportViewModel>(),
                    Filter = PreAssessmentReportFilter
                };
            }

            var customerIds = PreAsessmentQueueCustomers.Select(x => x.CustomerId.Value).ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);


            var calls = _callCenterCallRepository.GetCallByCustomerIdAndCallQueuePreAssessment(customerIds, HealthPlanCallQueueCategory.PreAssessmentCallQueue);

            var eventIds = PreAsessmentQueueCustomers.Where(x => x.EventId.HasValue && x.EventId.Value > 0).Select(x => x.EventId.Value).ToArray();
            var events = _eventService.GetEventBasicInfoEventIds(eventIds);

            var eventCustomerIds = PreAsessmentQueueCustomers.Where(x => x.EventCustomerID.HasValue).Select(x => x.EventCustomerID.Value).ToArray();
            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);

            var eventCustomersByEventIdsAndCustomerIds = _eventCustomerRepository.GetEventCustomersByEventIdsCustomerIds(eventIds, customerIds);

            if (!eventCustomersByEventIdsAndCustomerIds.IsNullOrEmpty())
            {
                eventCustomersByEventIdsAndCustomerIds = eventCustomersByEventIdsAndCustomerIds.Where(x => !eventCustomerIds.Contains(x.Id)).ToArray();
                eventCustomers = eventCustomers.Concat(eventCustomersByEventIdsAndCustomerIds);
            }

            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());

            var healthPlanIds = PreAsessmentQueueCustomers.Where(x => x.HealthPlanId.HasValue).Select(x => x.HealthPlanId.Value).ToArray();
            var healthPlans = _corporateAccountRepository.GetByIds(healthPlanIds);
            var restrictionIdNamePairs = _corporateAccountRepository.GetRestrictionIdNamePairs(healthPlanIds);

            var calledByAgentIds = calls.Select(x => x.CreatedByOrgRoleUserId).Distinct().ToArray();
            var calledByAgentNameIdPairs = _organizationRoleUserRepository.GetNameIdPairofUsers(calledByAgentIds).ToArray();

            var confirmedByAgentIds = eventCustomers.Where(x => x.ConfirmedBy.HasValue).Select(x => x.ConfirmedBy.Value).ToArray();
            var confirmedByAgentNameIdPairs = _organizationRoleUserRepository.GetNameIdPairofUsers(confirmedByAgentIds).ToArray();

            collection = _preAssessmentReportingFactory.Create(PreAsessmentQueueCustomers, customers, events, calls, eventCustomers, appointments, healthPlans, restrictionIdNamePairs,
                confirmedByAgentNameIdPairs, calledByAgentNameIdPairs).ToList();

            return new PreAssessmentReportListModel
            {
                Collection = collection,
                Filter = PreAssessmentReportFilter
            };

        }
    }
}
