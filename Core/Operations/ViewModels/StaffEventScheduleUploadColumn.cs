using System.ComponentModel;

namespace Falcon.App.Core.Operations.ViewModels
{
    public enum StaffEventScheduleUploadColumn
    {
        [Description("Staff Name")]
        StaffName,
        [Description("Employee ID")]
        EmployeeId,
        [Description("Pod")]
        Pod,
        [Description("Role")]
        Role,
        [Description("Event Date")]
        EventDate,
    }
}
