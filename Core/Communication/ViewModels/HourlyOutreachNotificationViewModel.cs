namespace Falcon.App.Core.Communication.ViewModels
{
    public class HourlyOutreachNotificationViewModel
    {
        public HourlyOutreachNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public string ReportName { get; set; }
        public string ExportPath { get; set; }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}