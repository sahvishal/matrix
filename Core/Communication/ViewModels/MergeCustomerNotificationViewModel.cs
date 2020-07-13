using System;

namespace Falcon.App.Core.Communication.ViewModels
{
   public  class MergeCustomerNotificationViewModel
    {
       public MergeCustomerNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
       {
           EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
       }

       public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

       public long UploadId { get; set; }

       public DateTime UploadDate { get; set; }

       public string FileName { get; set; }
    }
}
