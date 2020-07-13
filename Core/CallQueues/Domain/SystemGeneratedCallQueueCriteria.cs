using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class SystemGeneratedCallQueueCriteria : DomainObjectBase
    {
        public long CallQueueId { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
        public int NoOfDays { get; set; }
        public bool IsDefault { get; set; }
        public bool IsQueueGenerated { get; set; }
        public long? AssignedToOrgRoleUserId { get; set; }
        public DateTime? LastQueueGeneratedDate { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}