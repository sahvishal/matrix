using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class Event : DomainObjectBase
    {
        public long HostId { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public string TimeZone { get; set; }
        public RegistrationMode RegistrationMode { get; set; }
        public EventType EventType { get; set; }
        public EventStatus Status { get; set; }
        public string EventNotes { get; set; }
        public string InvitationCode { get; set; }
        public long[] PodIds { get; set; }
        public long AssignedtoOrgRoleUserId { get; set; }

        public string TechnicianNotes { get; set; }
        public string CallCenterNotes { get; set; }


        public bool IsSignOff { get; set; }
        public DateTime? SignOffDate { get; set; }
        public long? SignOffOrgRoleUserId { get; set; }
        public long? AccountId { get; set; }
        public bool EnableAlaCarteOnline { get; set; }
        public bool EnableAlaCarteCallCenter { get; set; }
        public bool EnableAlaCarteTechnician { get; set; }
        public bool IsDynamicScheduling { get; set; }
        public int? SlotInterval { get; set; }
        public int? ServerRooms { get; set; }
        public DateTime? LunchStartTime { get; set; }
        public int? LunchDuration { get; set; }
        public long? HealthAssessmentTemplateId { get; set; }
        public bool NotifyResultReady { get; set; }
        public bool CaptureInsuranceId { get; set; }
        public bool InsuranceIdRequired { get; set; }
        public bool IsFemaleOnly { get; set; }

        public long? GenerateKynXml { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public bool RecommendPackage { get; set; }

        public bool AskPreQualifierQuestion { get; set; }

        public int? FixedGroupScreeningTime { get; set; }

        public string BloodPackageTracking { get; set; }
        public string RecordsPackageTracking { get; set; }
        public long? EventCancellationReasonId { get; set; }
        public bool EnableForCallCenter { get; set; }
        public bool EnableForTechnician { get; set; }
        public bool IsPackageTimeOnly { get; set; }
        public long? GenerateHKynXml { get; set; }

        public long? UpdatedByAdmin { get; set; }
        public bool IsManual { get; set; }

        public bool GenerateHealthAssesmentForm { get; set; }
        public long? GenerateHealthAssesmentFormStatus { get; set; }

        public bool IsLocked { get; set; }

        public bool AllowNonMammoPatients { get; set; }

        public Event()
        { }

        public Event(long eventId)
            : base(eventId)
        { }
    }
}
