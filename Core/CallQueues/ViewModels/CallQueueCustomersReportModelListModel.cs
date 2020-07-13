using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueCustomersReportModelListModel : ListModelBase<CallQueueCustomersReportModel, OutboundCallQueueFilter>
    {
        public override IEnumerable<CallQueueCustomersReportModel> Collection { get; set; }

        public override OutboundCallQueueFilter Filter { get; set; }

        public CallQueueCustomersStatsViewModel RejectedCustomersStats { get; set; }

        public bool IsQueueGenerated { get; set; }

        public HealthPlanCallQueueCriteria CallQueueCriteria { get; set; }
        public string HealthPlanName { get; set; }
        public string CallQueueName { get; set; }
        public string CallQueueCategory { get; set; }
    }
}