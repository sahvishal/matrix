namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerCallStatusViewModel
    {
        public long NotCalledStatus { get; set; }
        public long TalkedToPersonStatus { get; set; }
        public long LeftVoiceMailStatus { get; set; }
        public long LeftVoiceMail2Status { get; set; }
        public long LeftVoiceMail3Status { get; set; }
        public long LeftVoiceMail4Status { get; set; }
        public long VoiceMail5Status { get; set; }
        public long VoiceMail6Status { get; set; }
        public long MailedEmailedStatus { get; set; }
        public long UnReachableStatus { get; set; }
        public long TotalCount { get; set; }
    }
}
