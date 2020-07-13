using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class HealthPlanCallQueueViewModel : ViewModelBase
    {
        public long Id { get; set; }

        public long CallQueueId { get; set; }

        public string HealthPlan { get; set; }

        public string HealthPlanCallQueue { get; set; }

        public HealthPlanCallQueueCriteriaViewModel Criterias { get; set; }
        public bool IsDefault { get; set; }
        public string[] Assignments { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public string[] TeamAssignment { get; set; }

        public long CustomerCount { get; set; }
    }
}
