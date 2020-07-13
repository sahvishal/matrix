using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.OutboundReport.ViewModels
{
    public class CareCodingOutboundViewModel : ViewModelBase
    {
        [Description("Tenant_Id")]
        public string TenantId { get; set; }

        [Description("Campaign_Id")]
        public string CampaignId { get; set; }

        [Description("Individual_Id_Number")]
        public string IndividualIdNumber { get; set; }

        [Description("Client_Id")]
        public string ClientId { get; set; }

        [Description("Contract_Number")]
        public string ContractNumber { get; set; }

        [Description("Contract_Person_Number")]
        public string ContractPersonNumber { get; set; }

        [Description("Consumer_Id")]
        public string ConsumerId { get; set; }

        [Description("Campaign_Code")]
        public string CampaignCode { get; set; }

        [Description("Campaign_Member_Id")]
        public string CampaignMemberId { get; set; }

        [Description("Care_Code_Lab_Type")]
        public string CareCodeLabType { get; set; }

        [Description("Care_Code_Lab_Desc")]
        public string CareCodeLabDesc { get; set; }

        [Description("Status_of_Coding")]
        public string StatusOfCoding { get; set; }

        [Description("Medical_Code")]
        public string MedicalCode { get; set; }

        [Description("Medical_Code_Type")]
        public string MedicalCodeType { get; set; }

        [Description("Medical_Code_Service_Date")]
        public string MedicalCodeServiceDate { get; set; }
    }
}
