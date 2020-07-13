
namespace Falcon.App.Core.Communication.ViewModels
{
    public class ListWithoutCustomTagsNotificationViewModel
    {
        public ListWithoutCustomTagsNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public string PatientwithoutCustomTagFileLocation { get; set; }
        public string FailedCustomerRecordFileLocation { get; set; }
        public string AdjustOrderFileLocation { get; set; }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}
