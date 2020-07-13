using System;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class EventLockedNotificationViewModel
    {
        public EventLockedNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string Name { get; set; }
        public long EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Pods { get; set; }
        public AddressViewModel AddressOfVenue { get; set; }

    }
}