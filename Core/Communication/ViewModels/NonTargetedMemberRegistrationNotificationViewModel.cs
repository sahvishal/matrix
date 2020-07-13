
namespace Falcon.App.Core.Communication.ViewModels
{
    public class NonTargetedMemberRegistrationNotificationViewModel
    {
        public NonTargetedMemberRegistrationNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public long PatientID { get; set; }
        public string PatientName { get; set; }
        public long EventID { get; set; }
        public string Healthplan { get; set; }
        public string Pod { get; set; }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}
