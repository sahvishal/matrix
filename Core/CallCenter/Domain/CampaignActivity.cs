using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class CampaignActivity : DomainObjectBase
    {
        public long CampaignId { get; set; }
        public DateTime ActivityDate { get; set; }
        public long TypeId { get; set; }
        public int Sequence { get; set; }

        public long? DirectMailTypeId { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }



    }
}