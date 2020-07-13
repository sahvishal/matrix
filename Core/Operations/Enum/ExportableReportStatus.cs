
using System.ComponentModel;

namespace Falcon.App.Core.Operations.Enum
{
    public enum ExportableReportStatus
    {
        Pending = 274,
        [Description("In Progress")]
        InProgress = 275,
        Completed = 276,
        Failed = 277
    }
}
