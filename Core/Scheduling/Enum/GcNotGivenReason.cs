using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum GcNotGivenReason
    {
        [Description("Out of Gift Cards")]
        OutofGiftCards=1,

        [Description("Member Left Without Card")]
        MemberLeftWithoutCard=2
    }
}
