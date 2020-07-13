using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class DirectMail : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public DateTime MailDate { get; set; }
        public long Mailedby { get; set; }
        public long CallUploadId { get; set; }
        public long? CampaignId { get; set; }
        public long? DirectMailTypeId { get; set; }
        public bool IsInvalidAddress { get; set; }
        public string Notes { get; set; }

    }
}
