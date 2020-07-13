namespace Falcon.App.Core.Communication.ViewModels
{
    public class SentBackForCorrectionNotificationViewModel
    {
        public SentBackForCorrectionNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string CustomerName { get; set; }
        public long CustomerId { get; set; }

        public string EventName { get; set; }
        public long EventId { get; set; }

        public string PhysicianComments { get; set; }
    }
}