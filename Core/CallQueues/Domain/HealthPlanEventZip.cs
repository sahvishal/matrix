using System;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class HealthPlanEventZip
    {
        public long AccountID { get; set; }
        public string AccountTag { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsQueueGenerated { get; set; }
    }
}
