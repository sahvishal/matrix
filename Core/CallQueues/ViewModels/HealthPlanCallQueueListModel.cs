using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues.ViewModels
{   
    public class HealthPlanCallQueueListModel : ListModelBase<HealthPlanCallQueueViewModel, HealthPlanCallQueueListModelFilter>
    {
        public override IEnumerable<HealthPlanCallQueueViewModel> Collection { get; set; }

        public override HealthPlanCallQueueListModelFilter Filter { get; set; }
    }
}
