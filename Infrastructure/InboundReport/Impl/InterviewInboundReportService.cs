using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class InterviewInboundReportService : IInterviewInboundReportService
    {
        private readonly IInterviewInboundReportFactory _interviewInboundReportFactory;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly IChaseCampaignRepository _chaseCampaignRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventAppointmentCancellationLogRepository _eventAppointmentCancellationLogRepository;
        private readonly IUniqueItemRepository<CustomerCallNotes> _customerCallNotesRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly ICallCenterCallRepository _callRepository;

        public InterviewInboundReportService(IInterviewInboundReportFactory interviewInboundReportFactory, IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IEventRepository eventRepository,
            IChaseOutboundRepository chaseOutboundRepository, IChaseCampaignRepository chaseCampaignRepository, IAppointmentRepository appointmentRepository, IEventAppointmentCancellationLogRepository eventAppointmentCancellationLogRepository,
            IUniqueItemRepository<CustomerCallNotes> customerCallNotesRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IUserRepository<User> userRepository, ICallCenterCallRepository callRepository)
        {
            _interviewInboundReportFactory = interviewInboundReportFactory;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _chaseOutboundRepository = chaseOutboundRepository;
            _chaseCampaignRepository = chaseCampaignRepository;
            _appointmentRepository = appointmentRepository;
            _eventAppointmentCancellationLogRepository = eventAppointmentCancellationLogRepository;
            _customerCallNotesRepository = customerCallNotesRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _userRepository = userRepository;
            _callRepository = callRepository;
        }

        public ListModelBase<InterviewInboundViewModel, InterviewInboundFilter> GetInterviewInboundReportList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            filter = filter ?? new InterviewInboundFilter();
            var interviewInboundFilter = filter as InterviewInboundFilter ?? new InterviewInboundFilter();

            var responseVendorReportFilter = new ResponseVendorReportFilter
            {
                StartDate = interviewInboundFilter.StartDate,
                EndDate = interviewInboundFilter.EndDate,
                AccountId = interviewInboundFilter.AccountId,
                CustomTags = interviewInboundFilter.CustomTags
            };

            var customerIds = _customerRepository.GetCustomersByCustomTag(responseVendorReportFilter, pageNumber, pageSize, out totalRecords);
            //var customerIds = _callRepository.GetForInterviewReport(filter as InterviewInboundFilter, pageNumber, pageSize, out totalRecords);
            if (customerIds.IsNullOrEmpty()) return null;

            var calls = _callRepository.GetCallsForInterviewReport(filter as InterviewInboundFilter, customerIds);

            var customers = customerIds.Any() ? _customerRepository.GetCustomers(customerIds.ToArray()) : new List<Customer>();

            //var eventCustomers = _eventCustomerRepository.GetEventCustomersByEventIdsCustomerIds(eventIds, customerIds) ?? new List<EventCustomer>();
            var eventCustomers = _eventCustomerRepository.GetByEventIdsOrCustomerIds(interviewInboundFilter.StartDate, customerIds) ?? new List<EventCustomer>();
            var eventCustomerIds = eventCustomers.Select(x => x.Id);

            var eventIds = eventCustomers.Select(x => x.EventId).ToArray();
            var events = _eventRepository.GetEvents(eventIds);

            var chaseOutbounds = _chaseOutboundRepository.GetByCustomerIds(customerIds);

            var customerChaseCampaigns = _chaseCampaignRepository.GetCustomerChaseCampaignsByCustomerIds(customerIds.ToArray());
            var chaseCampaignIds = customerChaseCampaigns.Select(x => x.ChaseCampaignId).Distinct();
            var chaseCampaigns = _chaseCampaignRepository.GetByIds(chaseCampaignIds);

            var appointmentIds = eventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.AppointmentId.Value);
            var appointments = _appointmentRepository.GetByIds(appointmentIds);

            var eventAppointmentCancellatonLogs = _eventAppointmentCancellationLogRepository.GetByEventCustomerIds(eventCustomerIds);

            var noteIds = eventAppointmentCancellatonLogs.Where(x => x.NoteId.HasValue).Select(x => x.NoteId.Value);
            var customerCallNotes = _customerCallNotesRepository.GetByIds(noteIds);

            var eventIdStaffIdPairs = _eventRepository.GetEventStaffPairs(eventIds);

            var orgRoleUserIds = eventIdStaffIdPairs.Select(x => x.SecondValue).Distinct().ToArray();
            var organizationRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsers(orgRoleUserIds);

            var userIds = organizationRoleUsers.Select(x => x.UserId).Distinct().ToList();
            var users = _userRepository.GetUsers(userIds);

            return _interviewInboundReportFactory.Create(eventCustomers, customers, chaseOutbounds, customerChaseCampaigns, chaseCampaigns, calls, appointments, events, eventAppointmentCancellatonLogs, customerCallNotes, eventIdStaffIdPairs,
                                                                      organizationRoleUsers, users);
        }
    }
}
