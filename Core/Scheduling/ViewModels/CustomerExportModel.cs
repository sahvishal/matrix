using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerExportModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneHome { get; set; }

        public string Gender { get; set; }

        [DisplayName("DOB")]
        [Format("MM/dd/yyyy")]
        public DateTime? DateofBirth { get; set; }

        [DisplayName("Address 1")]
        public string Address1 { get; set; }

        [DisplayName("Address 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        [DisplayName("Predicted Zip")]
        public string PredictedZip { get; set; }

        [DisplayName("Signup Date")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Source")]
        public string MarketingSource { get; set; }

        [DisplayName("Mode")]
        public string SignUpMode { get; set; }

        public string Email { get; set; }

        public string Race { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        [DisplayName("IsPaid?")]
        public bool IsPaid { get; set; }

        [Format("00.00")]
        public decimal Amount { get; set; }

        public string Package { get; set; }

        [DisplayName("Cost")]
        [Format("00.00")]
        public decimal ScreeningCost { get; set; }

        [DisplayName("Coupon Code")]
        public string SourceCode { get; set; }

        [DisplayName("Discount")]
        [Format("00.00")]
        public decimal SourceCodeAmount { get; set; }

        public long EventId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? EventDate { get; set; }

        [DisplayName("Event Address 1")]
        public string EventAddress1 { get; set; }

        [DisplayName("Event Address 2")]
        public string EventAddress2 { get; set; }

        [DisplayName("Event City")]
        public string EventCity { get; set; }

        [DisplayName("Event State")]
        public string EventState { get; set; }

        [DisplayName("Event Zip")]
        public string EventZip { get; set; }

        [DisplayName("Pod Name")]
        public string Pod { get; set; }

        [DisplayName("Appointment Status")]
        public string Status { get; set; }

        [DisplayName("Incoming Phone Line")]
        public string IncomingPhoneLine { get; set; }

        [DisplayName("Last Screening Date")]
        public string LastScreeningDate { get; set; }

        public string Tag { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        public string IsEligible { get; set; }

        public string Activity { get; set; }

        public string Language { get; set; }

        public string Lab { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string CustomTag { get; set; }

        [DisplayName("PCP First Name")]
        public string PcpFirstName { get; set; }

        [DisplayName("PCP Last Name")]
        public string PcpLastName { get; set; }

        [DisplayName("PCP Address 1")]
        public string PcpAddress1 { get; set; }

        [DisplayName("PCP Address 2")]
        public string PcpAddress2 { get; set; }

        [DisplayName("PCP City")]
        public string PcpCity { get; set; }

        [DisplayName("PCP State")]
        public string PcpState { get; set; }

        [DisplayName("PCP Zip")]
        public string PcpZip { get; set; }

        [DisplayName("PCP Fax")]
        public string PcpFax { get; set; }

        [DisplayName("PCP Phone")]
        public string PcpPhone { get; set; }

        [DisplayName("PCP NPI")]
        public string PcpNpi { get; set; }

        [DisplayName("Copay Amount")]
        public string Copay { get; set; }

        [DisplayName("Medicare Plan Name")]
        public string MedicarePlanName { get; set; }

        [DisplayName("HICN")]
        public string Hicn { get; set; }

        [DisplayName("MBI")]
        public string Mbi { get; set; }

        [DisplayName("LPI")]
        public string Lpi { get; set; }

        [DisplayName("Market")]
        public string Market { get; set; }

        [DisplayName("MRN")]
        public string Mrn { get; set; }

        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [DisplayName("Do Not Contact Reason")]
        public string DoNotContactReason { get; set; }

        [DisplayName("Do Not Contact Reason Notes")]
        public string DoNotContactReasonNote { get; set; }

        [DisplayName("Pre-Approved Test")]
        public string PreApprovedTest { get; set; }

        [DisplayName("Pre-Approved Package")]
        public string PreApprovedPackage { get; set; }

        [DisplayName("ACES Id")]
        public string AcesId { get; set; }

        [DisplayName("Additional Fields")]
        public IEnumerable<OrderedPair<string, string>> AdditionalFields { get; set; }

        [DisplayName("Relationship Code")]
        [Hidden]
        public string RelationshipCode { get; set; }

        [DisplayName("Relationship Name")]
        [Hidden]
        public string RelationshipName { get; set; }

        [DisplayName("Product")]
        public string Product { get; set; }
    }
}
