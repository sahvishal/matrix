using System;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HealthAssessmentHeaderEditModel
    {
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }
        public int Gender { get; set; }
        public DateTime? DateofBirth { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }

        public AddressEditModel Address { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public long EventId { get; set; }

        public DateTime EventDate { get; set; }

        public AddressViewModel EventAddress { get; set; }

        public bool AttendedPreviousScreening { get; set; }
        public DateTime? DateofPreviousScreening { get; set; }

        public int Race { get; set; }

        public string Laguage { get; set; }

        public string Ssn { get; set; }

        public bool CaptureSsn { get; set; }

        public string MemberId { get; set; }

        public string PhysicianName { get; set; }

        public ParticipationConsentModel ParticipationConsent { get; set; }
    }
}
