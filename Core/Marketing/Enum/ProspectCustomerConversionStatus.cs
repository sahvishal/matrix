using System.ComponentModel;

namespace Falcon.App.Core.Marketing.Enum
{
    public enum ProspectCustomerConversionStatus
    {
        Converted = 29,

        [Description("Not converted")]
        NotConverted = 30,

        [Description("Do not call")]
        Declined = 31
    }
}