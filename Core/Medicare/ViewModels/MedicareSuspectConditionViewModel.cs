using System;

namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareSuspectConditionViewModel
    {
        public long CustomerId { get; set; }
        public string GMPI { get; set; }
        public string MemberID { get; set; }
        public string SubscriberID { get; set; }
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
    }
}
