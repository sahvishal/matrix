using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class LabsInboundViewModel : ViewModelBase
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

        [DisplayName("Lab_Type")]
        public string LabType { get; set; }

        [DisplayName("Lab_Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? LabDate { get; set; }

        [DisplayName("Lab_Result")]
        public string LabResult { get; set; }

        [DisplayName("Lab_Action")]
        public string LabAction { get; set; }
    }
}
