using System;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerAppointmentViewModel
    {
        public long EventCustomerId { get; set; }

        public long CustomerId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public AddressViewModel Address { get; set; }

        public string HomePhone { get; set; }

        public string MobileNumber { get; set; }

        public string MemberId { get; set; }

        public DateTime? Dob { get; set; }

        public string Gender { get; set; }

        public string HealthPlan { get; set; }

        public long EventId { get; set; }

        public long? AppointmentId { get; set; }

        public DateTime? AppointmentTime { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public string Packages { get; set; }

        public string Tests { get; set; }

        public PcpInfoViewModel PrimaryCarePhysician { get; set; }

        public RegulatoryState HipaaConsent { get; set; }
        public RegulatoryState PcpConsent { get; set; }

        public bool MatrixConsent { get; set; }
        public bool PhysicianRecordRequest { get; set; }
        public bool GiftCard { get; set; }
        public bool FluVaccine { get; set; }
        public bool ExitInterview { get; set; }
        public bool Survey { get; set; }
        public bool NoShow { get; set; }
        public bool LeftWithoutScreening { get; set; }

        public bool ChaperoneConsent { get; set; }
    }
}
