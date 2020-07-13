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
    public class ConfirmationReportingService : IConfirmationReportingService
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallQueueCustomerCallRepository _callQueueCustomerCallRepository;

        private readonly IConfirmationReportingFactory _confirmationReportingFactory;
        private readonly IEventService _eventService;

        public ConfirmationReportingService(ICallQueueCustomerRepository callQueueCustomerRepository, ICallCenterCallRepository callCenterCallRepository, ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository,
            IConfirmationReportingFactory confirmationReportingFactory, IEventService eventService, ICorporateAccountRepository corporateAccountRepository, IAppointmentRepository appointmentRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, ICallQueueCustomerCallRepository callQueueCustomerCallRepository)
        {
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _confirmationReportingFactory = confirmationReportingFactory;
            _eventService = eventService;
            _corporateAccountRepository = corporateAccountRepository;
            _appointmentRepository = appointmentRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callQueueCustomerCallRepository = callQueueCustomerCallRepository;
        }

        public ListModelBase<ConfirmationReportViewModel, ConfirmationReportFilter> GetConfirmationReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var confirmationReportFilter = filter as ConfirmationReportFilter ?? new ConfirmationReportFilter();
            var confirmationQueueCustomers = _callQueueCustomerRepository.GetForConfirmationReport(confirmationReportFilter, pageNumber, pageSize, out totalRecords);

            var collection = new List<ConfirmationReportViewModel>();

            if (confirmationQueueCustomers.IsNullOrEmpty())
            {
                return new ConfirmationReportListModel
                {
                    Collection = new List<ConfirmationReportViewModel>(),
                    Filter = confirmationReportFilter
                };
            }

            var customerIds = confirmationQueueCustomers.Select(x => x.CustomerId.Value).ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var callQueueCustomerCalls = _callQueueCustomerCallRepository.GetByCallQueueCustomerIds(confirmationQueueCustomers.Select(x => x.Id));

            var calls = _callCenterCallRepository.GetCallByCustomerIdAndCallQueue(customerIds, HealthPlanCallQueueCategory.AppointmentConfirmation);

            var eventIds = confirmationQueueCustomers.Where(x => x.EventId.HasValue && x.EventId.Value > 0).Select(x => x.EventId.Value).ToArray();
            var events = _eventService.GetEventBasicInfoEventIds(eventIds);

            var eventCustomerIds = confirmationQueueCustomers.Where(x => x.EventCustomerId.HasValue).Select(x => x.EventCustomerId.Value).ToArray();
            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);

            var eventCustomersByEventIdsAndCustomerIds = _eventCustomerRepository.GetEventCustomersByEventIdsCustomerIds(eventIds, customerIds);

            if (!eventCustomersByEventIdsAndCustomerIds.IsNullOrEmpty())
            {
                eventCustomersByEventIdsAndCustomerIds = eventCustomersByEventIdsAndCustomerIds.Where(x => !eventCustomerIds.Contains(x.Id)).ToArray();
                eventCustomers = eventCustomers.Concat(eventCustomersByEventIdsAndCustomerIds);
            }

            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());

            var healthPlanIds = confirmationQueueCustomers.Where(x => x.HealthPlanId.HasValue).Select(x => x.HealthPlanId.Value).ToArray();
            var healthPlans = _corporateAccountRepository.GetByIds(healthPlanIds);
            var restrictionIdNamePairs = _corporateAccountRepository.GetRestrictionIdNamePairs(healthPlanIds);

            var calledByAgentIds = calls.Select(x => x.CreatedByOrgRoleUserId).Distinct().ToArray();
            var calledByAgentNameIdPairs = _organizationRoleUserRepository.GetNameIdPairofUsers(calledByAgentIds).ToArray();

            var confirmedByAgentIds = eventCustomers.Where(x => x.ConfirmedBy.HasValue).Select(x => x.ConfirmedBy.Value).ToArray();
            var confirmedByAgentNameIdPairs = _organizationRoleUserRepository.GetNameIdPairofUsers(confirmedByAgentIds).ToArray();

            collection = _confirmationReportingFactory.Create(confirmationQueueCustomers, customers, events, calls, eventCustomers, appointments, healthPlans, restrictionIdNamePairs,
                confirmedByAgentNameIdPairs, calledByAgentNameIdPairs, callQueueCustomerCalls).ToList();

            return new ConfirmationReportListModel
            {
                Collection = collection,
                Filter = confirmationReportFilter
            };
        }
    }
}
