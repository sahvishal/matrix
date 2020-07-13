using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerEventCriticalTestDataViewModel
    {
        [Format("MM/dd/yyyy")]
        public DateTime? DateOfSubmission { get; set; }

        public string CustomerName { get; set; }

        public PhoneNumber ContactNumber { get; set; }

        public string TechnicianName { get; set; }

        public string ValidatingTechnicianName { get; set; }

        public string PrimaryCarePhysician { get; set; }

        public string PrimaryPhysicianName { get; set; }

        public bool HasPcp { get; set; }

        public string TestName { get; set; }

        public string TechnicianNotes { get; set; }

        [DisplayName("Physician notes for Customer")]
        public string TechnicianNotesForPhysician { get; set; }

        [Hidden]
        public long TestId { get; set; }

        [Hidden]
        public bool IsCritical { get; set; }
        
        [Hidden]
        public bool IsUrgent { get; set; }

        public bool IsDefaultFollowup { get; set; }
        public bool IsPatientReceivedImages { get; set; }
        public string Symptoms { get; set; }
    }
}
