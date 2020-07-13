using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class WelcomeWithPasswordNotificationModel
    {
        public WelcomeWithPasswordNotificationModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase )
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
        [IgnoreAudit]
        public string Password { get; set; }
        [IgnoreAudit]
        public string ResetPasswordQueryString { get; set; }
        public string FullName { get; set; }
        public long UserId { get; set; }
    }
}