using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class HealthPlanGiftCertificateReportViewModel : ViewModelBase
    {
        public decimal DollarAmount { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("MI")]
        public string MiddleInitial { get; set; }

        public string ShipToLine1 { get; set; }
        public string ShipToLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DisplayName("Country Code")]
        public int CountryCode { get; set; }

        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }

        public string IsBulkShip { get; set; }
        public string BulkShipID { get; set; }
        public string BulkShipContactName { get; set; }
        public string BulkShipTelephone { get; set; }
        public string BulkShipCompanyName { get; set; }
        public string BulkShipAddress1 { get; set; }
        public string BulkShipAddress2 { get; set; }
        public string BulkShipCity { get; set; }
        public string BulkShipState { get; set; }
        public string BulkShipZip { get; set; }
        public string BulkShipCountryCode { get; set; }

        [DisplayName("4thLineEmbossing")]
        public string FourthLineEmbossing { get; set; }

        public string Expedite { get; set; }
        [DisplayName("Product_ID")]
        public long ProductId { get; set; }
        [DisplayName("Client_Id")]
        public long ClientId { get; set; }
        [DisplayName("Program_ID")]
        public string ProgramId { get; set; }
        [DisplayName("Card_Life")]
        public long CardLife { get; set; }
        [DisplayName("Expiration")]
        public string Expiration { get; set; }

        [DisplayName("Customer Number")]
        public string CustomerNumber { get; set; }

        public string Message4 { get; set; }

        public string CarrierMessage1 { get; set; }
        public string CarrierMessage2 { get; set; }
        public string CarrierMessage3 { get; set; }

        [DisplayName("IssuerID_Ovrd")]
        public string IssuerIdOvrd { get; set; }

        public string EmailAddress { get; set; }

        public string FundingComment { get; set; }

        public string PaymentRef { get; set; }

        public string BulkShipLocationID { get; set; }

        [DisplayName("Participant ID")]
        public string ParticipantId { get; set; }

        public string ClientData1 { get; set; }
        public string ClientData2 { get; set; }
        public string ClientData3 { get; set; }
        public string ClientData4 { get; set; }
        public string ClientData5 { get; set; }
        public string ClientData6 { get; set; }
        public string ClientData7 { get; set; }
        public string ClientData8 { get; set; }
        public string ClientData9 { get; set; }
        public string ClientData10 { get; set; }
    }
}
