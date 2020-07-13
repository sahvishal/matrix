using System;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class KynNotificationViewModel
    {
        public KynNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string CustomerName { get; set; }

        public long UserId { get; set; }

        public long CustomerId { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime AppointmentTime { get; set; }

        public string EventName { get; set; }

        public AddressViewModel AddressOfVenue { get; set; }

        public bool IsDemographicInfoFilled { get; set; }

        public bool IsHafFilled { get; set; }
    }
}
