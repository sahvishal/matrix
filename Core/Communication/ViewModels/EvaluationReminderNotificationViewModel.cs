namespace Falcon.App.Core.Communication.ViewModels
{
    public class EvaluationReminderNotificationViewModel
    {
        public EvaluationReminderNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public long PrimaryEvaluationQueueCount { get; set; }

        public long OverReadEvaluationQueueCount { get; set; }

        public long CriticalEvaluationQueueCount { get; set; }

        public string PhysicianName { get; set; }
    }
}
