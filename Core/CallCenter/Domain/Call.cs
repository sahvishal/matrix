using System;
using Falcon.App.Core.Domain;


namespace Falcon.App.Core.CallCenter.Domain
{
    public class Call : DomainObjectBase
    {
        public DateTime CallDateTime { get; set; }
        public DateTime? StartTime { get; set; }//TimeCreated
        public DateTime? EndTime { get; set; }//TimeEnd

        public string CallStatus { get; set; }

        public string CalledInNumber { get; set; }//IncomingPhoneLine

        public string CallerNumber { get; set; }

        public string CallBackNumber { get; set; }

        public bool IsIncoming { get; set; }//OutBound

        public long CalledCustomerId { get; set; }

        public long Status { get; set; }
        public long CreatedByOrgRoleUserId { get; set; }
        public bool IsNewCustomer { get; set; }
        public long EventId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Disposition { get; set; }
        public bool? ReadAndUnderstood { get; set; }

        public bool IsUploaded { get; set; }
        public long? CampaignId { get; set; }

        public long? NotInterestedReasonId { get; set; }
        public long? HealthPlanId { get; set; }
        public long? CallQueueId { get; set; }

        public string CustomTags { get; set; }
        public bool? IsContacted { get; set; }

        public long? DialerType { get; set; }
        public byte InvalidNumberCount { get; set; }

        public long? ProductTypeId { get; set; }
    }
}