using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class MemberUploadbyAcesFailedCustomerModel
    {
        [Hidden]
        public long CustomerId { get; set; }

        [DisplayName("Member ID")]
        public string MemberId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [DisplayName("DOB")]
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

        [DisplayName("HICNumber")]
        public string Hicn { get; set; }


        [DisplayName("PCP FirstName")]
        public string PcpFirstName { get; set; }

        [DisplayName("PCP LastName")]
        public string PcpLastName { get; set; }

        [DisplayName("PCP Phone")]
        public string PcpPhone { get; set; }

        [DisplayName("PCP Fax")]
        public string PcpFax { get; set; }

        [DisplayName("PCP Email")]
        public string PcpEmail { get; set; }

        [DisplayName("PCP Address1")]
        public string PcpAddress1 { get; set; }

        [DisplayName("PCP Address2")]
        public string PcpAddress2 { get; set; }

        [DisplayName("PCP City")]
        public string PcpCity { get; set; }

        [DisplayName("PCP State")]
        public string PcpState { get; set; }

        [DisplayName("PCP Zip")]
        public string PcpZip { get; set; }

        [DisplayName("PCP NPI")]
        public string PcpNpi { get; set; }

        [DisplayName("PreApproved Tests")]
        public string PreApprovedTest { get; set; }

        [DisplayName("Is Eligible")]
        public string IsEligible { get; set; }

        [DisplayName("Target Year")]
        public string TargetYear { get; set; }

        public string Activity { get; set; }

        public string Language { get; set; }

        public string Lab { get; set; }

        [DisplayName("Copay Amount")]
        public string Copay { get; set; }

        [DisplayName("Medicare Plan Name")]
        public string MedicareAdvantagePlanName { get; set; }

        [DisplayName("LPI")]
        public string Lpi { get; set; }

        public string Market { get; set; }

        [DisplayName("MRN")]
        public string Mrn { get; set; }

        public string GroupName { get; set; }

        [DisplayName("ICD Codes")]
        public string IcdCodes { get; set; }

        [DisplayName("PreApprovedPackages")]
        public string PreApprovedPackage { get; set; }

        [Hidden]
        public long PreApprovedPackageId { get; set; }

        public string PCPMailingAddress1 { get; set; }

        public string PCPMailingAddress2 { get; set; }

        public string PCPMailingCity { get; set; }

        public string PCPMailingState { get; set; }

        public string PCPMailingZip { get; set; }

        public string CurrentMedication { get; set; }

        public string CurrentMedicationSource { get; set; }

        [DisplayName("Field 1")]
        public string AdditionalField1 { get; set; }

        [DisplayName("Field 2")]
        public string AdditionalField2 { get; set; }

        [DisplayName("Field 3")]
        public string AdditionalField3 { get; set; }

        [DisplayName("Field 4")]
        public string AdditionalField4 { get; set; }

        public string PredictedZip { get; set; }


        [DisplayName("Mbi Number")]
        public string Mbi { get; set; }

        //public string BillingMemberId { get; set; }
        //public string BillingMemberPlan { get; set; }
        //public int? BillingMemberPlanYear { get; set; }
        //public string WarmTransferAllowed { get; set; }
        //public string WarmTransferYear { get; set; }

        [DisplayName("ACESId")]
        public string AcesId { get; set; }

        [DisplayName("Eligibility Year")]
        public string EligibilityYear { get; set; }

        [DisplayName("ProductNames")]
        public string ProductType { get; set; }

        [DisplayName("DNO")]
        public string DNC { get; set; }

        [Hidden]
        public long? MemberUploadSourceId { get; set; }

        public string ACESClientID { get; set; }

        //Error Message property should always be last.
        public string ErrorMessage { get; set; }


    }
}
