namespace Falcon.App.Core.Communication.ViewModels
{
    public class HourlyAppointmentBookedReportNotificationViewModel
    {
        public HourlyAppointmentBookedReportNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public string ReportName { get; set; }
        public string ExportPath { get; set; }
        
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}