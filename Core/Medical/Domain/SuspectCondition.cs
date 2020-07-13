using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class SuspectCondition : DomainObjectBase
    {
        public long SuspectConditionUploadId { get; set; }
        public long CustomerId { get; set; }
        public string GMPI { get; set; }
        public string MemberID { get; set; }
        public string SubscriberID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string ICDCode { get; set; }
        public string ICDDesc { get; set; }
        public string ICDCodeVersion { get; set; }
        public string HCC { get; set; }
        public string HCCDesc { get; set; }
        public string CaptureAction { get; set; }
        public string CaptureLocation { get; set; }
        public string CaptureReasonDescription { get; set; }
        public DateTime? CaptureReferenceDate { get; set; }
        public string SectionName { get; set; }
        public bool IsSynced { get; set; }
    }
}
