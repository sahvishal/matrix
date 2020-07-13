using System;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class AccountCallQueueSetting
    {
        public long AccountId { get; set; }
        public long CallQueueId { get; set; }
        public long SuppressionTypeId { get; set; }
        public int NoOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
