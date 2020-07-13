
namespace Falcon.App.Core.Communication.ViewModels
{
    public class NPfordiagnosingwithlinkNotificationViewModel
    {
        public NPfordiagnosingwithlinkNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public long PatientID { get; set; }
        public long EventID { get; set; }
        public string UrlTestDocumentation { get; set; }
        public string UrlUnlockAssessment { get; set; }
        public string UrlTriggersReadyForCodingStatus { get; set; }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}
