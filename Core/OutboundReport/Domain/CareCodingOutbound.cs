using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class CareCodingOutbound : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public string TenantId { get; set; }
        public string CampaignId { get; set; }
        public string IndividualId { get; set; }
        public string ClientId { get; set; }
        public string ContractNumber { get; set; }
        public string ContractPersonNumber { get; set; }
        public string ConsumerId { get; set; }
        public string CampaignCode { get; set; }
        public string CampaignMemberId { get; set; }
        public string CareCodeLabType { get; set; }
        public string CareCodeLabDescription { get; set; }
        public string StatusOfCoding { get; set; }
        public string MedicalCode { get; set; }
        public string MedicalCodeType { get; set; }
        public DateTime? MedicalCodeServiceDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
