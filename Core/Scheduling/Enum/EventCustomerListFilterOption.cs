namespace Falcon.App.Core.Scheduling.Enum
{
    public enum EventCustomerListFilterOption
    {
        All = 1,
        Attended,
        NoShow,
        Paid,
        Unpaid,
        UnpaidExcludingNoShow,
        PaidviaCard,
        PaidviaCash,
        PaidviaCheck,
        PaidviaeCheck,
        PaidviaGiftCertificate,
        MetricsOnsite,
        MetricsUpgrades,
        MetricsDowngrades,
        LeftWithoutScreening
    }
}