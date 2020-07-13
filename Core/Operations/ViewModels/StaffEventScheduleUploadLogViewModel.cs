using System.ComponentModel;
using System.Runtime.Serialization;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class StaffEventScheduleUploadLogViewModel : ViewModelBase
    {
        [Description("Staff Name")]
        public string Name { get; set; }

        [Description("Employee ID")]
        public string EmployeeId { get; set; }

        [Description("Pod")]
        public string Pod { get; set; }

        [Description("Role")]
        public string Role { get; set; }

        [Description("Event Date")]
        [Format("MM/dd/yyyy")]
        public string EventDate { get; set; }

        [Description("Error Message")]
        public string ErrorMessage { get; set; }
    }
}
