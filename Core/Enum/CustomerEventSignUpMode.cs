using System.ComponentModel;

namespace Falcon.App.Core.Enum
{
    public enum CustomerEventSignUpMode
    {
        WalkIn = 8,
        Online = 9,
        [Description("Call Center")]
        CallCenter = 10,
        Administrator = 1,
        Coordinator = 7,
        [Description("Call Center")]
        CallCenterManager=3
    }
}