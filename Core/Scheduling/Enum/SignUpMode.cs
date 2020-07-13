using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    //Note: Created while New Online Scheduling. This is to replace the Old/Obselete ESignUpMode
    public enum SignUpMode
    {
        [Description("Call Center")]
        CallCenter = 1,
        [Description("Walk In")]
        Walkin,
        [Description("Online")]
        Online,
        [Description("Customer Portal")]
        CustomerPortal
    }
}