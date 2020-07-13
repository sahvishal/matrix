namespace Falcon.App.Core.Communication.ViewModels
{
    public class AmountRefundNotificationViewModel
    {
        public AmountRefundNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string FullName { get; set; }
        public decimal AmountRefunded { get; set; }
    }
}