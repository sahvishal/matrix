using System.ComponentModel;

namespace Falcon.App.Core.Finance.Enum
{
    public enum RefundRequestType
    {
        [Description("Customer Cancellation")]
        CustomerCancellation = 70,
        [Description("Downgrades or Discount")]
        DowngradesorDiscount = 71,
        [Description("Event Cancellation")]
        EventCancellation = 72,
        [Description("Forced Cancellation")]
        ForcedCancellation = 73,
        [Description("Field Issue")]
        FieldIssue = 74,
        [Description("Test not Performed")]
        TestNotPerformed = 75,
        [Description("Change Package")]
        ChangePackage = 83,
        [Description("Apply Source Code")]
        ApplySourceCode = 84,
        [Description("CD Removal")]
        CDRemoval = 85,
        [Description("Cancel Shipping")]
        CancelShipping = 86,
        [Description("Manual Refund")]
        ManualRefund = 87
    }

}