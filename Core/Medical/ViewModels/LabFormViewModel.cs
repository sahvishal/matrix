
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using System;
namespace Falcon.App.Core.Medical.ViewModels
{
    public class LabFormViewModel
    {                    
        public Name PatientName { get; set; }
        public string Gender { get; set; }

        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }
        
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }
        public long PatientId { get; set; }

        public Address PatientAddress { get; set; }
        public PhoneNumber PatientPhone { get; set; }

        public Name PolicyHolderName { get; set; }
        public Address PolicyHolderAddress { get; set; }

        public Name PhysicianName { get; set; }
        public string PhysicianAccountNumber { get; set; }
        public string Npi { get; set; }
    }
}
