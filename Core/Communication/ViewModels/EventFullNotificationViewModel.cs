﻿using System;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class EventFullNotificationViewModel
    {
        public EventFullNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public AddressViewModel AddressOfVenue { get; set; }
        public string Pods { get; set; }
        public int TotalSlots { get; set; }
    }
}