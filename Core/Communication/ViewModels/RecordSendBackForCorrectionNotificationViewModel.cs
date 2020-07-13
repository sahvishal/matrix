namespace Falcon.App.Core.Communication.ViewModels
{
    public class RecordSendBackForCorrectionNotificationViewModel
    {
        public RecordSendBackForCorrectionNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public string PhysicianName { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public string ReasonEntered { get; set; }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}
