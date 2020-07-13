using System;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class MammoPatientRegistrationOnNonMammoEventNotificationViewModel
    {
        public MammoPatientRegistrationOnNonMammoEventNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime EventDate { get; set; }
        public long EventId { get; set; }
        public string Pod { get; set; }
        public string HealthPlan { get; set; }
        
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}