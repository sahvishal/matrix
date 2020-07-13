using System;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OnlineSchedulingProcessAndCartViewModel
    {
        public string CartGuid { get; set; }
        public long? PackageId { get; set; }
        public string Tests { get; set; }
        public string Products { get; set; }
        public long? AppointmentId { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public string ScreenResolution { get; set; }

        public string SponsoredBy { get; set; }

        public long? CustomerId { get; set; }
        public bool IsExistingCustomer { get; set; }
        public string CustomerName { get; set; }
        public long? ProspectCustomerId { get; set; }

        public decimal OrderAmount { get; set; }
        public long? EventId { get; set; }
        public string CheckoutPhoneNumber { get; set; }
        public bool? IsUsedAppointmentSlotExpiryExtension { get; set; }

        public OnlineSchedulingProcessStep CurrentStep { get; set; }
    }
}