using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class AnnualReminderNotificationViewModel
    {
        public AnnualReminderNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string CustomerName { get; set; }
        public string SourceCode { get; set; }
        public string CheckOutUrl { get; set; }
        public string AnnualReminderPhoneTollFree { get; set; }

        public IEnumerable<OnlineSchedulingEventViewModel> Events { get; set; }

        public AddressViewModel CustomerAddress { get; set; }

        public AddressViewModel LastScreeningLocation { get; set; }

        public DateTime LastScreeningDate { get; set; }
    }
}
