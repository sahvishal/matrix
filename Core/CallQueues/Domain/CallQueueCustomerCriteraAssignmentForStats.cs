using System;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class CallQueueCustomerCriteraAssignmentForStats
    {
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; }
        public long CustomerId { get; set; }
        public long Status { get; set; }
        public long Attempts { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime CallDate { get; set; }
        public int CallCount { get; set; }
        public int ZipId { get; set; }
        public DateTime DateModified { get; set; }
        public long HealthPlanId { get; set; }
        public long CampaignId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public bool IsLanguageBarrier { get; set; }
        public long CallStatus { get; set; }
        public DateTime ContactedDate { get; set; }
        public string Disposition { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentCancellationDate { get; set; }
        public bool IsEligble { get; set; }
        public bool ActivityId { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneOffice { get; set; }
        public bool IsIncorrectPhoneNumber { get; set; }
        public long DoNotContactTypeId { get; set; }
        public DateTime CallBackRequestedDate { get; set; }
        public DateTime DoNotContactUpdateDate { get; set; }
        public long DoNotContactUpdateSource { get; set; }
        public DateTime LanguageBarrierMarkedDate { get; set; }
        public DateTime IncorrectPhoneNumberMarkedDate { get; set; }
        public int TargetedYear { get; set; }
        public bool IsTargeted { get; set; }
    }
}