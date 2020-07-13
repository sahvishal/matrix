using System;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class CorporateUploadNotificationViewModel
    {
        public CorporateUploadNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
        
        public string CorporateName { get; set; }
        public DateTime DateOfUpload { get; set; }
        public string UploadedBy { get; set; }
        public long TotalCustomers { get; set; }
        public long UploadedCustomers { get; set; }
        public long FailedCustomers { get; set; }
    }
}
