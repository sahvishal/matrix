using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class InterviewInboundViewModel : ViewModelBase
    {
        [DisplayName("Tenant_Id")]
        public string TenantId { get; set; }

        [DisplayName("Client_Id")]
        public string ClientId { get; set; }

        [DisplayName("Campaign_Id")]
        public string CampaignId { get; set; }

        [DisplayName("Individual_ID_Number")]
        public string IndividualIDNumber { get; set; }

        [DisplayName("Contract_Number")]
        public string ContractNumber { get; set; }

        [DisplayName("Contract_Person_Number")]
        public string ContractPersonNumber { get; set; }

        [DisplayName("Consumer_Id")]
        public string ConsumerId { get; set; }

        [DisplayName("Vendor_Person_Id")]
        public string VendorPersonId { get; set; }

        [DisplayName("Chart_Number")]
        public string ChartNumber { get; set; }

        [DisplayName("Requirement_Code")]
        public string RequirementCode { get; set; }

        [DisplayName("Requirement_Status")]
        public string RequirementStatus { get; set; }

        [DisplayName("Requirement_Status_Description")]
        public string RequirementStatusDescription { get; set; }

        [DisplayName("Requirement_Status_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? RequirementStatusDate { get; set; }

        [DisplayName("Requirement_Status_Time")]
        [Format("HH:mm:ss")]
        public DateTime? RequirementStatusTime { get; set; }

        [DisplayName("Requirement_User_Code")]
        public string RequirementUserCode { get; set; }
    }
}
