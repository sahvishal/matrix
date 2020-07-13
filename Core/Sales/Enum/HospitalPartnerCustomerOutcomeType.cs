using System.ComponentModel;

namespace Falcon.App.Core.Sales.Enum
{
    public enum HospitalPartnerCustomerOutcomeType
    {
        [Description("Scheduled")]
        HospitalPartnerCustomerScheduledOutcome,

        [Description("Not Scheduled")]
        HospitalPartnerCustomerNotScheduledOutcome
    }
}
