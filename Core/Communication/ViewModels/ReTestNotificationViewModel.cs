
namespace Falcon.App.Core.Communication.ViewModels
{
    public class ReTestNotificationViewModel
    {
        public ReTestNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public long PatientID { get; set; }
        public long EventID { get; set; }
        public string ReTests { get; set; }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}
