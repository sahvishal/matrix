using System.Collections.Generic;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class ProspectCustomerFollowupNotificationViewModel
    {
        public ProspectCustomerFollowupNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string CustomerName { get; set; }
        
        public string CheckOutUrl { get; set; }

        public string SourceCode { get; set; }

        public IEnumerable<OnlineSchedulingEventViewModel> Events { get; set; }
    }
}
