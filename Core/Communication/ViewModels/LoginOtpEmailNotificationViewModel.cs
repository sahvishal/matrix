namespace Falcon.App.Core.Communication.ViewModels
{
    public class LoginOtpEmailNotificationViewModel
    {
        public LoginOtpEmailNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
        public string UserName { get; set; }
        public string Otp { get; set; }
        public string ExpirationMinutes { get; set; } 
    }
}