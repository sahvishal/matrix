using System.ComponentModel;

namespace Falcon.App.Core.Sales.Enum
{
    public enum HospitalPartnerCustomerDateTypeFilter
    {
        [Description("Event Date")]
        EventDate = 1,
        [Description("Last Modified Date")]
        LastModifiedDate = 2,
        ResultStatusUpdatedDate = 3,
        [Description("Date of Birth")]
        DateOfBirth=4
    }
}
