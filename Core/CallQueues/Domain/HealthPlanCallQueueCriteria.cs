using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class HealthPlanCallQueueCriteria : DomainObjectBase
    {
        public long CallQueueId { get; set; }
        public decimal Percentage { get; set; }
        public int NoOfDays { get; set; }
        public int RoundOfCalls { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? HealthPlanId { get; set; }
        public string CustomTags { get; set; }
        public bool IsDefault { get; set; }
        public string ZipCode { get; set; }
        public int? Radius { get; set; }
        public bool IsQueueGenerated { get; set; }
        public DateTime? LastQueueGeneratedDate { get; set; }
        public bool IsDeleted { get; set; }
        public long? CampaignId { get; set; }
        public string CriteriaName { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public long? LanguageId { get; set; }
    }
}