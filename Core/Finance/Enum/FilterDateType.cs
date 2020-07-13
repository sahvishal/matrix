using System.ComponentModel;

namespace Falcon.App.Core.Finance.Enum
{
    public enum FilterDateType
    {
        [Description("Transaction Date")]
        TransactionDate = 1,
        [Description("Event Date")]
        EventDate,
        [Description("Request Date")]
        RequestDate,
        [Description("Resolved Date")]
        ResolvedDate
    }
}