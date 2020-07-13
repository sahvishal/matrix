using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerViewModel
    {
        public long EventCustomerId { get; set; }

        public long CustomerId { get; set; }

        public long OrderId { get; set; } // Needed for Cancel Shipping

        public string CustomerName { get; set; }

        public AddressViewModel Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsNoShow { get; set; }

        public bool IsProductPurchased { get; set; }

        public bool IsHealthAssessmentFormFilled { get; set; }

        public bool IsUndeliveredShippinginOrder { get; set; }

        public bool IsShippingPurchased { get; set; }

        public bool IsAuthorized { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal TotalAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal AmountPaid { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal AmountDue { get; set; }

        public string OrderPurchased { get; set; }

        public AssignedPhysicianViewModel AssignedPhysicians { get; set; }

        public string SourceCode { get; set; }

        public RegulatoryState HipaaStatus { get; set; }

        public RegulatoryState PartnerRelease { get; set; }

        public IEnumerable<CustomerCallNotes> CustomerNotes { get; set; }

        public int TestResultStateNumber { get; set; }

        public string EmployeeId { get; set; }
        public string InsuranceId { get; set; }

        public bool IsCancelProductRequestPending { get; set; }
        public bool IsCancelShippingRequestPending { get; set; }
        public bool IsMammoPurchased { get; set; }

        public long? HospitalFacilityId { get; set; }

        public bool ShowLipidPrint { get; set; }

        public bool ShowKynPrint { get; set; }

        public RegulatoryState AbnStatus { get; set; }

        public bool ShowAwvPcpForm { get; set; }

        public RegulatoryState PcpConsentStatus { get; set; }

        public bool ShowMedicareForm { get; set; }

        public RegulatoryState InsuranceReleaseStatus { get; set; }

        public bool IsMedicareQuestionAnswered { get; set; }

        public bool IsFluShotTestPurchased { get; set; }

        public long? LeftWithoutScreeningReasonId { get; set; }

        public string LeftWithoutScreeningNotes { get; set; }

        public long? AwvVisitId { get; set; }

        public string MedicareToken { get; set; }

        public IEnumerable<string> PreApprovedTests { get; set; }

        public bool? IsGiftCertificateDelivered { get; set; }

        public string GiftCode { get; set; }

        public long? GiftCodeNotGivenReasonId { get; set; }

        public bool IsIfobtTestPurchased { get; set; }

        public bool IsUrineMicroalbumineTestPurchased { get; set; }

        public bool IsForRetest { get; set; }

        public string AcesId { get; set; }

        public bool IsEawvPurchased { get; set; }

        public bool IsEawvMarkedAsTestNotPerformed { get; set; }

        public bool ShowMyBioCheckAssessmentPrint { get; set; }

        public bool ShowGiftCard { get; set; }

        public bool ShowParticipationConsent { get; set; }
    }
}