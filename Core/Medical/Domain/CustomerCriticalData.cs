using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.Domain
{
    public class CustomerCriticalData : DomainObjectBase
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public long TestId { get; set; }

        public PhoneNumber ContactNumber { get; set; }
        public string TechnicianNotes { get; set; }
        public string TechnicianNotesforPhysician { get; set; }

        public bool IsCustomerSigned { get; set; }
        public bool IsTechnicianSigned { get; set; }
        public DateTime DateofSubmission { get; set; }

        public long TechnicianId { get; set; }
        public long ValidatingTechnicianId { get; set; }
        public string Physician { get; set; }
        public bool HasPcp { get; set; }

        public bool IsDefaultFollowup { get; set; }
        public bool IsPatientReceivedImages { get; set; }
        public string Symptoms { get; set; }

    }
}
