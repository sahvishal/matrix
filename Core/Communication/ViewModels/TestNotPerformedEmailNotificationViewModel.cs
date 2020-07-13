using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class TestNotPerformedEmailNotificationViewModel
    {
        public TestNotPerformedEmailNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime EventDate { get; set; }
        public long EventId { get; set; }
        public string Pod { get; set; }
        public string Reason { get; set; }

        public IEnumerable<TestNotPerformedNotificationTestViewModel> TestData { get; set; }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}