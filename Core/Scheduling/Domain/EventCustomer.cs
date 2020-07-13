using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventCustomer : DomainObjectBase
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public long? AppointmentId { get; set; }
        public long? AffiliateCampaignId { get; set; }
        public long? ClickId { get; set; }

        public bool OnlinePayment { get; set; }

        public bool TestConducted { get; set; }
        public bool NoShow { get; set; }

        public string MarketingSource { get; set; }
        public RegulatoryState HIPAAStatus { get; set; }
        public RegulatoryState PartnerRelease { get; set; }
        public long? HospitalFacilityId { get; set; }

        public RegulatoryState AbnStatus { get; set; }

        public RegulatoryState PcpConsentStatus { get; set; }
        public RegulatoryState InsuranceReleaseStatus { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public long? CampaignId { get; set; }
        public long? AwvVisitId { get; set; }

        public long? LeftWithoutScreeningReasonId { get; set; }
        public long? LeftWithoutScreeningNotesId { get; set; }

        public bool EnableTexting { get; set; }

        public bool? IsGiftCertificateDelivered { get; set; }
        public string GiftCode { get; set; }

        public long? PatientDetailId { get; set; }

        public long? CustomerProfileHistoryId { get; set; }

        public bool IsAppointmentConfirmed { get; set; }
        public long? ConfirmedBy { get; set; }

        public bool IsForRetest { get; set; }
        public long? PreferredContactType { get; set; }
        public long? GcNotGivenReasonId { get; set; }

        public DateTime? NoShowDate { get; set; }

        public bool SingleTestOverride { get; set; }

        public bool IsParticipationConsentSigned { get; set; }
        public bool IsPhysicianRecordRequestSigned { get; set; }
        public bool IsFluVaccineConsentSigned { get; set; }

        public EventCustomer()
        { }


        public EventCustomer(long eventCustomerId)
            : base(eventCustomerId)
        { }
    }
}
