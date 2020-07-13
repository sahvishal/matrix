using System.ComponentModel;

namespace Falcon.App.Core.Finance.Enum
{
    public enum RequestResultType
    {
        [Description("Adjust Order")]
        AdjustOrder = 76,
        [Description("Reschedule Appointment")]
        RescheduleAppointment = 77,
        [Description("Offer Free Add ons and Discount")]
        OfferFreeAddonsAndDiscounts = 78,
        [Description("Issue Gift Certificate")]
        IssueGiftCertificate = 79,
        [Description("Issue Refund")]
        IssueRefund = 80
    }
}