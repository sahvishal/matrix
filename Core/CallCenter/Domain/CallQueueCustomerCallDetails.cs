using System;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class CallQueueCustomerCallDetails
    {
        public long CallId { get; set; }
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
        
        public long EventId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Disposition { get; set; }
        public bool? ReadAndUnderstood { get; set; }

        public bool IsUploaded { get; set; }
        public long? CampaignId { get; set; }

        public long? NotInterestedReasonId { get; set; }

        public long CallQueueCustomerId { get; set; }
        public long CallQueueId { get; set; }
        public long HealthPlanId { get; set; }
    }
}
