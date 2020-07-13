namespace Falcon.App.Core.Communication.ViewModels
{
    public class ResultReadyNotificationViewModel
    {
        public ResultReadyNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }


        public string CustomerName { get; set; }

        public string UserName { get; set; }

        public bool IsPaperCopyPurchased { get; set; }

        public string HospitalPartnerLogoFilePathUrl { get; set; }

    }
}