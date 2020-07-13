using System.ComponentModel;

namespace Falcon.App.Core.Users.Enum
{
    public enum DoNotContactReason
    {
        [Description("Dead/Passed Away")]
        PassedAway = 109,

        [Description("Invalid Address")]
        InvalidAddress = 110,

        [Description("Customer Request")]
        CustomerRequest = 111,

        [Description("Health Plan Request")]
        HealthPlanRequest = 343,

        [Description("Other")]
        Other = 112
    }
}
