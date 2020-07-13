using System;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class CustomerTagChangeNotificationViewModel
    {
        public CustomerTagChangeNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PreviousEventId { get; set; }
        public string PreviousSponser { get; set; }
        public String PreviousEventDate { get; set; }
        public string PreviousTag { get; set; }
        public string NewEventId { get; set; }
        public string NewSponser { get; set; }
        public DateTime NewEventDate { get; set; }
        public string NewTag { get; set; } 
    }
}
