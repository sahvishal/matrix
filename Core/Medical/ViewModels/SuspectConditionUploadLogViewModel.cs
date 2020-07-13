using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class SuspectConditionUploadLogViewModel : ViewModelBase
    {
        public string GMPI { get; set; }
        public string MemberId { get; set; }
        public string SubscriberID { get; set; }
        public string MemberName { get; set; }
        public string DOB { get; set; }
        public string ICDCode { get; set; }
        public string ICDDesc { get; set; }
        public string ICDCodeVersion { get; set; }
        public string HCC { get; set; }
        public string HCCDesc { get; set; }
        public string CaptureAction { get; set; }
        public string CaptureLocation { get; set; }
        public string CaptureReasonDescription { get; set; }
        public string CaptureReferenceDate { get; set; }
        public string SectionName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
