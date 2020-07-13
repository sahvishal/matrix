using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Call = Falcon.App.Core.CallCenter.Domain.Call;

namespace Falcon.App.Core.InboundReport
{
    public interface IResponseVendorReportFactory
    {
        ResponseVendorReportListModel Create(IEnumerable<Customer> customers, IEnumerable<Language> languages, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Event> events, IEnumerable<Call> calls,
            IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<PcpDisposition> pcpDispositions, IEnumerable<EventCustomerBarrier> eventCustomerBarriers, IEnumerable<Barrier> barriers, IEnumerable<ChaseOutbound> chaseOutbounds,
            IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns, IEnumerable<ChaseCampaignType> chaseCampaignTypes, IEnumerable<EventAppointmentCancellationLog> eventAppointmentCancellationLogs,
            IEnumerable<CustomerInfo> resultPostedCustomers, IEnumerable<CustomerEligibility> customerEligibilities);
    }
}
