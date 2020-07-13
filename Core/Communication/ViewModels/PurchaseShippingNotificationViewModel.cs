using System;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class PurchaseShippingNotificationViewModel
    {
        public PurchaseShippingNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public AddressViewModel AddressOfVenue { get; set; }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
