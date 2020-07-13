using System;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class IneligibleCustomerAppointmentNotificationViewModel
    {
        public IneligibleCustomerAppointmentNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }       
        public string Tag { get; set; }
    }
}
