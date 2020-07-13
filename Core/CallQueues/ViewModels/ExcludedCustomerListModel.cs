using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class ExcludedCustomerListModel : ListModelBase<GmsExcludedCustomerViewModel, OutboundCallQueueFilter>
    {
        public override IEnumerable<GmsExcludedCustomerViewModel> Collection { get; set; }

        public override OutboundCallQueueFilter Filter { get; set; }

        public string HealthPlanName { get; set; }
        public string SuppressionType { get; set; }
        public string CallQueueType { get; set; }
        public string CriteriaName { get; set; }
    }
}