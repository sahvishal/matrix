using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class Campaign :DomainObjectBase
    {
        public string Name { get; set; }
        public string CampaignCode { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long TypeId { get; set; }
        public long ModeId { get; set; }
        public long AccountId { get; set; }

        public string CustomTags { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}