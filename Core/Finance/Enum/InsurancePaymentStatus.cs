using System.ComponentModel;

namespace Falcon.App.Core.Finance.Enum
{
    public enum InsurancePaymentStatus
    {
        [Description("Not Settled")]
        NotSettled = 1,
        Settled = 2
    }
}
