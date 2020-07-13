using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerEventCriticalTestDataEditModel:ViewModelBase
    {
        [UIHint("Hidden")]
        public long CustomerEventScreeningTestId { get; set; }

        [DisplayName("Best Contact Number for Patient")]
        public PhoneNumber ContactNumber { get; set; }

        [DisplayName("Critical Care Criteria")]
        [DataType(DataType.MultilineText)]
        public string TechnicianNotes { get; set; }

        [DisplayName("Physician Recommendation for Customer")]
        [DataType(DataType.MultilineText)]
        public string TechnicianNotesForPhysician { get; set; }

        public bool IsCustomerSigned { get; set; }

        public bool IsTechnicianSigned { get; set; }

        [DisplayName("Today's Date")]
        [Format("MM/dd/yyyy")]
        public DateTime DateOfSubmission { get; set; }

        [DisplayName("Technician")]
        public long TechnicianId { get; set; }

        [DisplayName("Validating Technician")]
        public long ValidatingTechnicianId { get; set; }

        [DisplayName("Contacting Physician")]
        public string PrimaryPhysician { get; set; }

        public bool HasPcp { get; set; }
        
        public string PrimaryCarePhysicianName { get; set; }

        [DisplayName("Primary Care Physician Phone Number")]
        public PhoneNumber PrimaryCarePhysicianPhoneNumber { get; set; }

        public string CustomerName { get; set; }

        public Gender Gender { get; set; }

        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [UIHint("Hidden")]
        public long CustomerId { get; set; }
        
        [UIHint("Hidden")]
        public long EventId { get; set; }
        
        [UIHint("Hidden")]
        public long TestId { get; set; }
        
        [UIHint("Hidden")]
        public long EventCustomerId { get; set; }

        [UIHint("Hidden")]
        public int ResultState { get; set; }

        public bool IsDefaultFollowup { get; set; }
        public bool IsPatientReceivedImages { get; set; }
        public string Symptoms { get; set; }

    }
}
