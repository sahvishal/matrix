namespace Falcon.App.Core.Communication.ViewModels
{
    public class GiftCertificateNotificationModel
    {
        public GiftCertificateNotificationModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
        public string ToName { get; set; }
        public string ClaimCode { get; set; }
        public string Message { get; set; }
        public decimal Value { get; set; }
        public string FromName { get; set; }

    }
}