using Falcon.App.Core.Application.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HouseCallHafResultExportModel
    {
        [DisplayName("HealthFair ID")]
        public long CustomerId { get; set; }

        [DisplayName("Member ID")]
        public string MemberId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        [Format("MM/dd/yyyy")]
        public DateTime? Dob { get; set; }

        public string Gender { get; set; }

        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [DisplayName("Street Address")]
        public string Address1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        [DisplayName("PCP Name")]
        public string PCPName { get; set; }

        [DisplayName("PCP Address")]
        public string PCPAddress { get; set; }

        [DisplayName("PCP City")]
        public string PCPCity { get; set; }

        [DisplayName("PCP State")]
        public string PCPState { get; set; }

        [DisplayName("PCP Zip")]
        public string PCPZip { get; set; }

        [DisplayName("Registration Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? RegistrationDate { get; set; }

        [DisplayName("Appointment Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? AppointmentDate { get; set; }

        [DisplayName("Appointment Time")]
        [Format("hh:mm tt")]
        public DateTime? AppointmentTime { get; set; }

        [DisplayName("Event ID")]
        public long EventId { get; set; }

        [DisplayName("Event Loaction")]
        public string EventLocation { get; set; }

        [DisplayName("Event Address")]
        public string EventAddress { get; set; }

        public IEnumerable<OrderedPair<long, string>> HealthAssesmentAnswer { get; set; }
    }
}
