using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.InboundReport
{
    public interface IConditionInboundReportFactory
    {
        ListModelBase<ConditionInboundViewModel, ConditionInboundFilter> Create(IEnumerable<EventCustomerDiagnosis> diagnosisRecords, IEnumerable<EventCustomer> eventCustomers, IEnumerable<ChaseOutbound> chaseOutbounds,
            IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns);
    }
}
