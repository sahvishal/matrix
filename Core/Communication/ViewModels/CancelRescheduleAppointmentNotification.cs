using System;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class CancelRescheduleAppointmentNotification
    {
        public CancelRescheduleAppointmentNotification(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string CustomerName { get; set; }
        public long EventId { get; set; }

        public long NewEventId { get; set; }

        public DateTime? NewEventDate { get; set; }
        public bool IsCancelAppointment { get; set; }
        public string Reason { get; set; }
        public string SubReason { get; set; }
    }
}