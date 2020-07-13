using System;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class WelcomeWithUserNameNotificationModel
    {
        public WelcomeWithUserNameNotificationModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DateTime SingupDate { get; set; }
    }
}