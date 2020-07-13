
namespace Falcon.App.Core.Communication.ViewModels
{
    public class SingleTestOverrideNotificationViewModel
    {
        public SingleTestOverrideNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public long PatientID { get; set; }
        public long EventID { get; set; }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}
