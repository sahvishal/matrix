namespace Falcon.App.Core.Communication.ViewModels
{
    public class DirectMailActivityNotificationViewModel
    {
        public DirectMailActivityNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string UserName { get; set; }
        public string CampaignName { get; set; }
        public string HealthPlan { get; set; }
        public string CustomTags { get; set; }

    }
}