using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class FillEventCallQueueModel
    {
        public IEnumerable<EventBasicInfoViewModel> Events { get; set; }
        public FillEventsCallQueueFilter Filter { get; set; }
        public HealthPlanCallQueueCriteria CallQueueCriteria { get; set; }
        public bool IsQueueGenerated { get; set; }
        public string HealthPlanName { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}