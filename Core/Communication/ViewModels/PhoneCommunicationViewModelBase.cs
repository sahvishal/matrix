using System;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class PhoneCommunicationViewModelBase
    {
        public long NotificationId { get; set; }

        public NotificationMedium NotificationMediumId { get; set; }

        public DateTime NotificationDateTime { get; set; }
    }
}
