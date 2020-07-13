using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class MemberStatusModel : ViewModelBase
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

        public string Email { get; set; }
        public string Package { get; set; }

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

        [DisplayName("Registration Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? RegistrationDate { get; set; }

        [DisplayName("Scheduled Status")]
        public string ScheduledStatus { get; set; }

        [DisplayName("Completion Status")]
        public string CompletionStatus { get; set; }

        [DisplayName("Current Status")]
        public string CurrentStatus { get; set; }

        [DisplayName("Current Outbound Call Category")]
        public string CurrentOutboundCallCategory { get; set; }

        [DisplayName("Current Outbound Call Outcome")]
        public string CurrentOutboundCallOutcome { get; set; }

        [DisplayName("Current Outbound Call Disposition")]
        public string CurrentOutboundCallDisposition { get; set; }

        [DisplayName("Pod Name")]
        public string Pod { get; set; }

        public string Tag { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        public string IsEligible { get; set; }

        [DisplayName("Is Targeted Member")]
        public string IsTargetedMember { get; set; }

        public string Activity { get; set; }

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

        [DisplayName("Medicare Plan Name")]
        public string MedicarePlanName { get; set; }

        [DisplayName("HICN")]
        public string Hicn { get; set; }

        [DisplayName("MBI")]
        public string Mbi { get; set; }

        [DisplayName("Market")]
        public string Market { get; set; }

        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [DisplayName("Restriction Status")]
        public string RestrictionStatus { get; set; }

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

        [DisplayName("Customer Result Shipped Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? CustomerResultShipedDate { get; set; }

        [DisplayName("PCP Result Shipped Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? PCPResultShipedDate { get; set; }

        [DisplayName("Additional Fields")]
        public IEnumerable<OrderedPair<string, string>> AdditionalFields { get; set; }

        [DisplayName("Total Direct Mail Count")]
        public int TotalDirectMailCount { get; set; }

        [DisplayName("Total Inbound Call Count")]
        public int TotalInboundCallCount { get; set; }

        [DisplayName("Total Outbound Call Count")]
        public int TotalOutboundCallCount { get; set; }

        [DisplayName("Direct Mail Date 1")]
        [Format("MM/dd/yyyy")]
        public DateTime? DirectMailDate1 { get; set; }

        [DisplayName("Direct Mail Date 2")]
        [Format("MM/dd/yyyy")]
        public DateTime? DirectMailDate2 { get; set; }

        [DisplayName("Direct Mail Date 3")]
        [Format("MM/dd/yyyy")]
        public DateTime? DirectMailDate3 { get; set; }

        [DisplayName("Direct Mail Date 4")]
        [Format("MM/dd/yyyy")]
        public DateTime? DirectMailDate4 { get; set; }

        [DisplayName("Direct Mail Date 5")]
        [Format("MM/dd/yyyy")]
        public DateTime? DirectMailDate5 { get; set; }

        [DisplayName("Outreach Call Date 1")]
        [Format("MM/dd/yyyy")]
        public DateTime? OutreachCallDate1 { get; set; }

        [DisplayName("Outreach Call Date 2")]
        [Format("MM/dd/yyyy")]
        public DateTime? OutreachCallDate2 { get; set; }

        [DisplayName("Outreach Call Date 3")]
        [Format("MM/dd/yyyy")]
        public DateTime? OutreachCallDate3 { get; set; }

        [DisplayName("Outreach Call Date 4")]
        [Format("MM/dd/yyyy")]
        public DateTime? OutreachCallDate4 { get; set; }

        [DisplayName("Outreach Call Date 5")]
        [Format("MM/dd/yyyy")]
        public DateTime? OutreachCallDate5 { get; set; }

        [DisplayName("Product")]
        public string Product { get; set; }
    }
}