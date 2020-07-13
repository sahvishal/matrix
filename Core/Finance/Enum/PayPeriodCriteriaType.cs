using System.ComponentModel;

namespace Falcon.App.Core.Finance.Enum
{
    public enum PayPeriodCriteriaType
    {
        [Description("Less than equal to")]
        LessThanEqualTo = 334,
        Between = 335,
        [Description("Greater than equal to")]
        GreaterThanEqualTo = 336
    }
}
