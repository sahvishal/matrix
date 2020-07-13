using System.ComponentModel;

namespace Falcon.App.Core.Operations.ViewModels
{
    public enum PatientParsedDataColumn
    {
        [Description("HIPID")]
        CustomerId,

        [Description("ACESID")]
        AcesId
    }
}
