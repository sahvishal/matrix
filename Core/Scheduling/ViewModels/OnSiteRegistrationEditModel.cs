using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OnSiteRegistrationEditModel : ViewModelBase
    {
        public long EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [UIHint("ExtendedTextBox")]
        public string Email { get; set; }

        [DisplayName("Primary Phone")]
        public PhoneNumber HomeNumber { get; set; }

        public int Gender { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime? DateofBirth { get; set; }

        public AddressEditModel Address { get; set; }

        public long SelectedPackageId { get; set; }

        public IEnumerable<long> SelectedTestIds { get; set; }

        public long SelectedAppointmentId { get; set; }

        public IEnumerable<EventPackageOrderItemViewModel> AllEventPackages { get; set; }
        public IEnumerable<EventTestOrderItemViewModel> AllEventTests { get; set; }
        public IEnumerable<EventSchedulingSlot> Appointments { get; set; }

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

        public OnSiteRegistrationEditModel()
        {
            Address = new AddressEditModel();
        }

        
    }
}
