using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class CallUploadLog : DomainObjectBase
    {
        public long CallUploadId { get; set; }
        public long CustomerId { get; set; }
        public string OutreachType { get; set; }
        public DateTime? OutreachDateTime { get; set; }
        public string Outcome { get; set; }
        public string Disposition { get; set; }
        public string Reason { get; set; }

        public string CampaignName { get; set; }
        public string DirectMailType { get; set; }

        public long EventId { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        public string Notes { get; set; }

        public bool IsSuccessfull { get; set; }
        public string ErrorMessage { get; set; }

        public bool IsRuleApplied { get; set; }

        public string CustomerIdForCsv { get; set; }

        public long? OutcomeEnum { get; set; }
        public long? DispositionEnum { get; set; }

        public long? ReasonEnum { get; set; }
        public string EventIdForCsv { get; set; }
        public string OutreachDate { get; set; }
        public string OutreachTime { get; set; }
        public bool IsDirectMail { get; set; }
        public string IsInvalidAddress { get; set; }
    }
}