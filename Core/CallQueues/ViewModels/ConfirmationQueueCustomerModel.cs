using System;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class ConfirmationQueueCustomerModel
    {
        public long CustomerId { get; set; }

        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public string Tag { get; set; }

        public long EventCustomerId { get; set; }

        public DateTime AppointmentTime { get; set; }

        public string TimeZone { get; set; }

        public long StateId { get; set; }

        public string StateCode { get; set; }
    }
}
