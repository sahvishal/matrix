namespace Falcon.App.Core.Communication.ViewModels
{
    public class ResetPasswordNotificationModel
    {
        public ResetPasswordNotificationModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
        public long UserId { get; set; }
        public string ResetPasswordQueryString { get; set; }
        public string FullName { get; set; }
    }
}