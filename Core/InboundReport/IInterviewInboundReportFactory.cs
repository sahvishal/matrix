using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.InboundReport
{
    public interface IInterviewInboundReportFactory
    {
        ListModelBase<InterviewInboundViewModel, InterviewInboundFilter> Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<ChaseOutbound> chaseOutbounds,
            IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns, IEnumerable<Call> calls, IEnumerable<Appointment> appointments, IEnumerable<Event> events,
            IEnumerable<EventAppointmentCancellationLog> eventAppointmentCancellationLogs, IEnumerable<CustomerCallNotes> customerCallNotes, IEnumerable<OrderedPair<long, long>> eventIdStaffIdPair,
            IEnumerable<OrganizationRoleUser> organizationRoleUsers, IEnumerable<User> users);
    }
}
