using System;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class CallQueueCustomer : DomainObjectBase
    {
        public long CallQueueId { get; set; }
        public long? CustomerId { get; set; }
        public long? ProspectCustomerId { get; set; }
        public CallQueueStatus Status { get; set; }
        public int Attempts { get; set; }
        public bool IsActive { get; set; }
        public long? NotesId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public long? CreatedByOrgRoleUserId { get; set; }
        public long? ModifiedByOrgRoleUserId { get; set; }
        public long? AssignedToOrgRoleUserId { get; set; }
        public long? CallQueueCriteriaId { get; set; }
        public DateTime CallDate { get; set; }
        public long? EventId { get; set; }
        public long? HealthPlanId { get; set; }
        public long? CampaignId { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public PhoneNumber PhoneHome { get; set; }
        public PhoneNumber PhoneOffice { get; set; }
        public PhoneNumber PhoneCell { get; set; }

        public long ZipId { get; set; }
        public string ZipCode { get; set; }
        public string Tag { get; set; }
        public bool? IsEligble { get; set; }
        public bool? IsIncorrectPhoneNumber { get; set; }
        public bool? IsLanguageBarrier { get; set; }
        public long? ActivityId { get; set; }
        public long? DoNotContactTypeId { get; set; }
        public long? DoNotContactReasonId { get; set; }
        public DateTime? DoNotContactUpdateDate { get; set; }
        public long CallCount { get; set; }

        public DateTime? AppointmentDate { get; set; }
        public long? CallStatus { get; set; }
        public DateTime? ContactedDate { get; set; }
        public string Disposition { get; set; }
        public DateTime? CallBackRequestedDate { get; set; }

        public DateTime? AppointmentCancellationDate { get; set; }

        public long? EventCustomerId { get; set; }
        public DateTime? AppointmentDateTimeWithTimeZone { get; set; }

        public long? DoNotContactUpdateSource { get; set; }

        public DateTime? LanguageBarrierMarkedDate { get; set; }
        public DateTime? IncorrectPhoneNumberMarkedDate { get; set; }

        public long? LanguageId { get; set; }
        public DateTime? NoShowDate { get; set; }
        public int? TargetedYear { get; set; }
        public bool? IsTargeted { get; set; }

        public long? ProductTypeId { get; set; }

        public CallQueueCustomer()
        { }

        public CallQueueCustomer(long id)
            : base(id)
        { }
    }
}
