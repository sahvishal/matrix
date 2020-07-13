using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class StaffEventSchedulingModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Pod")]
        public string Pod { get; set; }

        [DisplayName("Event Address")]
        public string EventAddressStreet12 { get; set; }

        [DisplayName("Event State")]
        public string EventStateName { get; set; }

        [DisplayName("Event City")]
        public string EventCity { get; set; }

        [DisplayName("Event ZipCode")]
        public string EventZipCode { get; set; }

        [DisplayName("Sponsor")]
        public string Sponsor { get; set; }

        [DisplayName("Staff Name")]
        public string StaffFullName { get; set; }

        [DisplayName("Staff Role")]
        public string StaffEventRole { get; set; }

        [DisplayName("Staff EmployeeId")]
        public string EmployeeId { get; set; }
    }
}
