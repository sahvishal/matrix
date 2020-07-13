using System;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Users.ViewModels
{
    public class PatientEventDetailViewModel
    {
        public long CustomerId { get; set; }

        public long EventId { get; set; }
        
        public long EventCustomerId { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime AppointmentTime { get; set; }

        public Address EventLocation { get; set; }
    }
}
