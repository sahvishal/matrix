using System;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class OutboundCall
    {
        public long CallID { get; set; }
        public bool IsNewCustomer { get; set; }
        public long CalledCustomerID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeEnd { get; set; }
        public string CallStatus { get; set; }
        public long EventID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CallBackNumber { get; set; }
        public string IncomingPhoneLine { get; set; }
        public string CallersPhoneNumber { get; set; }
        public string CallerName { get; set; }
        public long? PromoCodeID { get; set; }
        public long? AffiliateID { get; set; }
        public bool OutBound { get; set; }
        public long Status { get; set; }
        public long CreatedByOrgRoleUserId { get; set; }
        public string Disposition { get; set; }
        public bool? ReadAndUnderstoodNotes { get; set; }
        public bool IsUploaded { get; set; }
        public long? CampaignId { get; set; }
        public long? NotInterestedReasonId { get; set; }
        public long HealthPlanId { get; set; }
        public long CallQueueId { get; set; }
    }
}
