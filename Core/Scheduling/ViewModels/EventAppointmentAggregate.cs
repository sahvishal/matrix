using System;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventAppointmentAggregate
    {
        public Appointment Appointment{ get; set;}

        public Customer AppointmentBookedFor{ get; set;}

        public Event Event{ get; set;}

        public string PackageAndTests { get; set; }

        public TimeSpan SlotTime { get; set; }

        public AppointmentSlotType SlotType { get; set; }
    }
}
