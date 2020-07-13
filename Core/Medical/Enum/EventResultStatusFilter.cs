using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum EventResultStatusFilter
    {
        [Description("Upload Pending")]
        UploadPending=91,
        [Description("Parse Pending")]
        ParsePending=94,
        [Description("Missing Results")]
        MissingResults=1,
        [Description("UnStable State ")]
        UnStableState = 2,//TODO:value is set to 2 so that it does not get selected by default
        [Description("Pre-Audit Pending")]
        PreAuditPending=4,
        [Description("Review Pending")]
        ReviewPending=5,
        [Description("Post Audit Pending")]
        PostAuditPending=6,
        [Description("Result Delivered")]
        ResultDelivered=7
    }
}
