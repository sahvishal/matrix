using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.InboundReport.ViewModels
{
    public class BarrierInboundViewModel : ViewModelBase
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

        [DisplayName("Appointment_id")]
        public string AppointmentID { get; set; }

        [DisplayName("Barrier_Id")]
        public string BarrierId { get; set; }

        [DisplayName("Barrier_Category")]
        public string BarrierCategory { get; set; }

        [DisplayName("Barrier_Reason")]
        public string BarrierReason { get; set; }

        [DisplayName("Barrier_Resolution")]
        public string BarrierResolution { get; set; }
    }
}
