using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.OutboundReport.ViewModels
{
    public class ChaseOutboundViewModel : ViewModelBase
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Tenant Id")]
        public string TenantId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleInitial { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Date Of Birth")]
        public string DateOfBirth { get; set; }
        [DisplayName("SSN")]
        public string Ssn { get; set; }
        [DisplayName("Gender Code")]
        public string GenderCode { get; set; }
        [DisplayName("Hicn")]
        public string Hicn { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressCountyName { get; set; }
        public string AddressCountyCode { get; set; }
        [DisplayName("Language Preference Code")]
        public string LanguagePreferenceCode { get; set; }

        [DisplayName("Campaign Id")]
        public string CampaignId { get; set; }
        [DisplayName("Campaign File Id")]
        public string CampaignFileId { get; set; }
        [DisplayName("Campaign Name")]
        public string CampaignName { get; set; }
        [DisplayName("Campaign Code")]
        public string CampaignCode { get; set; }
        [DisplayName("Campaign Household Id")]
        public string CampaignHouseholdId { get; set; }
        [DisplayName("Campaign Type")]
        public string CampaignType { get; set; }
        [DisplayName("Campaign Member Id")]
        public string CampaignMemberId { get; set; }

        [DisplayName("Individual Id Number")]
        public string IndividualId { get; set; }

        [DisplayName("Client Id")]
        public string ClientId { get; set; }

        [DisplayName("Vendor CD")]
        public string VendorCD { get; set; }

        [DisplayName("Contract Number")]
        public string ContractNumber { get; set; }
        [DisplayName("Contract Person Number")]
        public string ContractPersonNumber { get; set; }

        [DisplayName("Consumer Id")]
        public string ConsumerId { get; set; }

        [DisplayName("Distribution Id")]
        public string DistributionId { get; set; }

        [DisplayName("Subscriber Indicator")]
        public bool SubscriberIndicator { get; set; }

        [DisplayName("Relationship Code")]
        public string RelationshipCode { get; set; }

        [DisplayName("Relationship Description")]
        public string RelationshipDescription { get; set; }

        [DisplayName("Identified Indicator")]
        public bool IdentifiedIndicator { get; set; }

        [DisplayName("Work Phone Number")]
        public string WorkPhoneNumber { get; set; }

        [DisplayName("Outbound Call Indicator")]
        public bool OutboundCallIndicator { get; set; }

        [DisplayName("Wireless Indicator")]
        public bool WirelessIndicator { get; set; }

        [DisplayName("Priority Code")]
        public string PriorityCode { get; set; }

        [DisplayName("Key Code")]
        public string KeyCode { get; set; }

        [DisplayName("Business Case Id")]
        public string BusinessCaseId { get; set; }

        [DisplayName("Medicare Indicator")]
        public bool MedicareIndicator { get; set; }

        [DisplayName("Group Number")]
        public string GroupNumber { get; set; }
        [DisplayName("Group Division")]
        public string GroupDivision { get; set; }
        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        [DisplayName("HMO LOB Indicator")]
        public bool HmoLobIndicator { get; set; }

        [DisplayName("Product Level 1")]
        public string ProductLevel1 { get; set; }
        [DisplayName("Product Level 2")]
        public string ProductLevel2 { get; set; }
        [DisplayName("Product Level 3")]
        public string ProductLevel3 { get; set; }
        [DisplayName("Product Level 4")]
        public string ProductLevel4 { get; set; }
        [DisplayName("Product Level 5")]
        public string ProductLevel5 { get; set; }

        [DisplayName("Refer Member To")]
        public string ReferMemberTo { get; set; }

        [DisplayName("Provider Of Record Full Name")]
        public string ProviderOfRecordFullName { get; set; }
        [DisplayName("Provider Of Record Phone Number")]
        public string ProviderOfRecordPhoneNumber { get; set; }
        [DisplayName("Provider Of Record Group Name")]
        public string ProviderOfRecordGroupName { get; set; }
        [DisplayName("Provider Of Record Group Number")]
        public string ProviderOfRecordGroupNumber { get; set; }
        [DisplayName("Provider Of Record Address Line 1")]
        public string ProviderOfRecordAddressLine1 { get; set; }
        [DisplayName("Provider Of Record Address Line 2")]
        public string ProviderOfRecordAddressLine2 { get; set; }
        [DisplayName("Provider Of Record City")]
        public string ProviderOfRecordAddressCity { get; set; }
        [DisplayName("Provider Of Record State")]
        public string ProviderOfRecordAddressState { get; set; }
        [DisplayName("Provider Of Record Zip Code")]
        public string ProviderOfRecordAddressZipCode { get; set; }

        [DisplayName("Channel Level 2")]
        public string ChannelLevel2 { get; set; }
        [DisplayName("Channel Level 3")]
        public string ChannelLevel3 { get; set; }

        [DisplayName("Closest Retail Center")]
        public string ClosestRetailCenter { get; set; }

        [DisplayName("Confidence Score")]
        public string ConfidenceScore { get; set; }

        [DisplayName("Location Code")]
        public string LocationCode { get; set; }

        [DisplayName("Forecasted Outreach Date")]
        public string ForecastedOutreachDate { get; set; }

        [DisplayName("Record Process Date")]
        public string RecordProcessDate { get; set; }

        [DisplayName("Agent Context Name Value Set")]
        public string AgentContextNameValueSet { get; set; }

        public string HomeAddressLine1 { get; set; }
        public string HomeAddressLine2 { get; set; }
        public string HomeAddressCity { get; set; }
        public string HomeAddressState { get; set; }
        public string HomeAddressZipCode { get; set; }
        public string HomeAddressCountyName { get; set; }
        public string HomeAddressCountyCode { get; set; }

        public string CustomTags { get; set; }
    }
}
