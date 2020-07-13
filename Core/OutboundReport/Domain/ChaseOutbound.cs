using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class ChaseOutbound : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public string TenantId { get; set; }
        public string IndividualId { get; set; }
        public string ClientId { get; set; }
        public string VendorCd { get; set; }
        public string ContractNumber { get; set; }
        public string ContractPersonNumber { get; set; }
        public string ConsumerId { get; set; }
        public string CampaignMemberId { get; set; }
        public string DistributionId { get; set; }
        public bool SubscriberIndicator { get; set; }
        public long? RelationshipId { get; set; }
        public bool IdentifiedIndicator { get; set; }
        public bool OutboundCallIndicator { get; set; }
        public bool WirelessIndicator { get; set; }
        public string PriorityCode { get; set; }
        public string BusinessCaseId { get; set; }
        public bool MedicareIndicator { get; set; }
        public long? ChaseGroupId { get; set; }
        public bool HmoLobIndicator { get; set; }
        public string ReferMemberTo { get; set; }
        public string ClosestRetailCenter { get; set; }
        public long? ConfidenceScoreId { get; set; }
        public string LocationCode { get; set; }
        public DateTime? ForecastedOutreachDate { get; set; }
        public DateTime? RecordProcessDate { get; set; }
        public string AgentContextNameValueSet { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
