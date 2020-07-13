using System.ComponentModel;

namespace Falcon.App.Core.Finance.Enum
{
    public enum HealthPlanRevenueType
    {
        [Description("Per Customer")]
        PerCustomer = 299,

        [Description("Per Package")]
        PerPackage = 300,

        [Description("Per Test")]
        PerTest =301
    }
}
