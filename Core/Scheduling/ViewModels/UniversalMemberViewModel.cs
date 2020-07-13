using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class UniversalMemberViewModel : ViewModelBase
    {
        [DisplayName("ClientID")]
        public string ClientID { get; set; }

        [DisplayName("ClientMemberId")]
        public string ClientMemberId { get; set; }

        [DisplayName("AltClientMemberId")]
        public string AltClientMemberId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DisplayName("MiddleName")]
        public string MiddleName { get; set; }

        [DisplayName("LastName")]
        public string LastName { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("DateOfBirth")]
        [Format("yyyyMMdd")]
        public DateTime? DoB { get; set; }

        [DisplayName("HICNumber")]
        public string HicNumber { get; set; }

        [DisplayName("MediCaidNumber")]
        public string MediCaidNumber { get; set; }

        [DisplayName("HomeStreet1")]
        public string HomeStreet1 { get; set; }

        [DisplayName("HomeStreet2")]
        public string HomeStreet2 { get; set; }

        [DisplayName("HomeCity")]
        public string HomeCity { get; set; }

        [DisplayName("HomeCounty")]
        public string HomeCounty { get; set; }

        [DisplayName("HomeState")]
        public string HomeState { get; set; }

        [DisplayName("HomeZip")]
        public string HomeZip { get; set; }

        [DisplayName("MailingStreet1")]
        public string MailingStreet1 { get; set; }

        [DisplayName("MailingStreet2")]
        public string MailingStreet2 { get; set; }

        [DisplayName("MailingCity")]
        public string MailingCity { get; set; }

        [DisplayName("MailingCounty")]
        public string MailingCounty { get; set; }

        [DisplayName("MailingState")]
        public string MailingState { get; set; }

        [DisplayName("MailingZip")]
        public string MailingZip { get; set; }

        [DisplayName("TelephoneNumber1")]
        public string TelephoneNumber1 { get; set; }

        [DisplayName("TelephoneNumber2")]
        public string TelephoneNumber2 { get; set; }

        [DisplayName("TelephoneNumber3")]
        public string TelephoneNumber3 { get; set; }

        [DisplayName("EmailAddress")]
        public string EmailAddress { get; set; }

        [DisplayName("SubscriberId")]
        public string SubscriberId { get; set; }

        [DisplayName("MarketingPlan")]
        public string MarketingPlan { get; set; }

        [DisplayName("Language")]
        public string Language { get; set; }

        [DisplayName("Race")]
        public string Race { get; set; }

        [DisplayName("PlanID")]
        public string PlanID { get; set; }

        [DisplayName("OtherPlanID")]
        public string OtherPlanID { get; set; }

        [DisplayName("MetalLevel")]
        public string MetalLevel { get; set; }

        [DisplayName("CMSNumber")]
        public string CmsNumber { get; set; }

        [DisplayName("PBPNumber")]
        public string PbpNumber { get; set; }

        [DisplayName("EligibilityStartDate")]
        [Format("yyyyMMdd")]
        public DateTime? EligibilityStartDate { get; set; }

        [DisplayName("EligibilityEndDate")]
        [Format("yyyyMMdd")]
        public DateTime? EligibilityEndDate { get; set; }

        [DisplayName("TerminationReason")]
        public string TerminationReason { get; set; }

        [DisplayName("EligibilityGroup")]
        public string EligibilityGroup { get; set; }

        [DisplayName("ClientProviderId")]
        public string ClientProviderId { get; set; }

        [DisplayName("NetworkProvider")]
        public string NetworkProvider { get; set; }

        [DisplayName("PCPStartDate")]
        [Format("yyyyMMdd")]
        public DateTime? PcpStartDate { get; set; }

        [DisplayName("PCPEndDate")]
        [Format("yyyyMMdd")]
        public DateTime? PcpEndDate { get; set; }

        [DisplayName("Custom1")]
        public string Custom1 { get; set; }

        [DisplayName("Custom2")]
        public string Custom2 { get; set; }

        [DisplayName("Custom3")]
        public string Custom3 { get; set; }

        [DisplayName("PreferredPlanName")]
        public string PreferredPlanName { get; set; }

        [DisplayName("MBI")]
        public string Mbi { get; set; }
    }
}