using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class MemberUploadParseDetail : DomainObjectBase
    {
        public long CorporateUploadId { get; set; }
        public long CustomerId { get; set; }
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string Email { get; set; }
        public string AlternateEmail { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneHome { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Hicn { get; set; }
        public string PcpFirstName { get; set; }
        public string PcpLastName { get; set; }
        public string PcpPhone { get; set; }
        public string PcpFax { get; set; }
        public string PcpEmail { get; set; }
        public string PcpAddress1 { get; set; }
        public string PcpAddress2 { get; set; }
        public string PcpCity { get; set; }
        public string PcpState { get; set; }
        public string PcpZip { get; set; }
        public string PcpNpi { get; set; }
        public string PreApprovedTest { get; set; }
        public string IsEligible { get; set; }
        public string TargetYear { get; set; }
        public string Language { get; set; }
        public string Lab { get; set; }
        public string Copay { get; set; }
        public string MedicareAdvantagePlanName { get; set; }
        public string Lpi { get; set; }
        public string Market { get; set; }
        public string Mrn { get; set; }
        public string GroupName { get; set; }
        public string IcdCodes { get; set; }
        public string PreApprovedPackage { get; set; }
        public long? PreApprovedPackageId { get; set; }
        public string PCPMailingAddress1 { get; set; }
        public string PCPMailingAddress2 { get; set; }
        public string PCPMailingCity { get; set; }
        public string PCPMailingState { get; set; }
        public string PCPMailingZip { get; set; }
        public string CurrentMedication { get; set; }
        public string CurrentMedicationSource { get; set; }
        public string AdditionalField1 { get; set; }
        public string AdditionalField2 { get; set; }
        public string AdditionalField3 { get; set; }
        public string AdditionalField4 { get; set; }
        public string Activity { get; set; }
        public string PredictedZip { get; set; }
        public string Mbi { get; set; }
        public string BillingMemberId { get; set; }
        public string BillingMemberPlan { get; set; }
        public string BillingMemberPlanYear { get; set; }
        public string WarmTransferAllowed { get; set; }
        public string WarmTransferYear { get; set; }
        public string AcesId { get; set; }
        public string EligibilityYear { get; set; }
        public string DNC { get; set; }
        public string ProductType { get; set; }

        public string AcesClientId { get; set; }
        
        public string ErrorMessage { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
