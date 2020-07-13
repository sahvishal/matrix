using System.ComponentModel;

namespace Falcon.App.Core.CallCenter.Enum
{
    public enum NotInterestedReason
    {
        [Description("Customer Refused")]
        CustomerRefused = 278,
        [Description("Don't have insurance")]
        DontHaveInsurance = 279
    }
}
