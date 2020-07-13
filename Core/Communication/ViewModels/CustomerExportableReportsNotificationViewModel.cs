using System;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class CustomerExportableReportsNotificationViewModel
    {
        public CustomerExportableReportsNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string Name { get; set; }
        public string ExportableReport { get; set; }     
        public string Url { get; set; }
    }
}
