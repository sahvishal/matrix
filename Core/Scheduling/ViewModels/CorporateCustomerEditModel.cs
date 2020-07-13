using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CorporateCustomerEditModel
    {
        [Hidden]
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


        public IEnumerable<string> PreApprovedTest { get; set; }

        public string IsEligible { get; set; }
        public string Activity { get; set; }
        public string TargetYear { get; set; }
        public string Language { get; set; }
        public string Lab { get; set; }
        public string Copay { get; set; }
        public string MedicareAdvantagePlanName { get; set; }
        public string Lpi { get; set; }
        public string Market { get; set; }
        public string Mrn { get; set; }
        public string GroupName { get; set; }

        public IEnumerable<string> IcdCodes { get; set; }
        public string PreApprovedPackage { get; set; }

        [Hidden]
        public long PreApprovedPackageId { get; set; }

        public string PCPMailingAddress1 { get; set; }
        public string PCPMailingAddress2 { get; set; }
        public string PCPMailingCity { get; set; }
        public string PCPMailingState { get; set; }
        public string PCPMailingZip { get; set; }
        public IEnumerable<string> CurrentMedication { get; set; }
        public IEnumerable<string> CurrentMedicationSource { get; set; }
        public string AdditionalField1 { get; set; }
        public string AdditionalField2 { get; set; }
        public string AdditionalField3 { get; set; }
        public string AdditionalField4 { get; set; }
        public string PredictedZip { get; set; }

        public string Mbi { get; set; }

        public string BillingMemberId { get; set; }
        public string BillingMemberPlan { get; set; }
        public int? BillingMemberPlanYear { get; set; }

        public string WarmTransferAllowed { get; set; }
        public string WarmTransferYear { get; set; }

        public string AcesId { get; set; }

        [DisplayName("Eligibility Year")]
        public string EligibilityYear { get; set; }

        public string DNCFlag { get; set; }

        public string Product { get; set; }

        [Hidden]
        public long? MemberUploadSourceId { get; set; }
        [Hidden]
        public bool IsCustomerZipInvalid { get; set; }
        [Hidden]
        public bool IsPCPZipInvalid { get; set; }
        [Hidden]
        public bool IsPCPMailingZipInvalid { get; set; }
        [Hidden]
        public long CustomerAddressId { get; set; }
        [Hidden]
        public long PCPAddressId { get; set; }
        [Hidden]
        public long PCPMailingAddressId { get; set; }

        [Hidden]
        public string NewInsertedZipIds { get; set; }

        [Hidden]
        public string NewInsertedCityIds { get; set; }

        public string ACESClientID { get; set; }

        //public IEnumerable<string> RequiredTest { get; set; }
        //public string ForYear { get; set; }

        //Error Message property should always be last.
        public string ErrorMessage { get; set; }


    }
}
