using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class PhysicianQueueListItem
    {
        public long PhysicianId { get; set; }
        public long EventCustomerId { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool CriticalMarkedByTechnician { get; set; }
        public long ResultSummary { get; set; }
        public bool SentBackbyPrimaryEval { get; set; }
        public bool SentBackbyOverread { get; set; }
        public long? InQueuePriority { get; set; }
    }
}