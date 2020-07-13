using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class MassRegistrationEditModel:ViewModelBase
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public PhoneNumber HomeNumber { get; set; }

        [DisplayName("Email")]
        [UIHint("ExtendedTextBox")]
        public string Email { get; set; }

        public AddressEditModel Address { get; set; }

        [DisplayName("Package")]
        public long PackageId { get; set; }

        [DisplayName("Appointment Time")]
        public long AppointmentId { get; set; }

        [DisplayName("Send Email Notification")]
        public bool SendNotification { get; set; }
        
        [DisplayName("Date Of birth")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Employee Id")]
        public string EmployeeId { get; set; }

        [DisplayName("Insurance Id")]
        public string InsuranceId { get; set; }

        [DisplayName("Feet")]
        public int HeightInFeet { get; set; }

        [DisplayName("Inch")]
        public int HeightInInch { get; set; }

        [DisplayName("Weight")]
        public double Weight { get; set; }

        [DisplayName("Race")]
        public string Race { get; set; }

        public int Gender { get; set; }

        [DisplayName("SSN")]
        public string Ssn { get; set; }

        [DisplayName("Free Shipping")]
        public bool AddFreeShipping { get; set; }
        public string Copay { get; set; }
        public string MedicareAdvantagePlanName { get; set; }

        public MassRegistrationEditModel()
        {
            Address = new AddressEditModel();
        }
    }
}
