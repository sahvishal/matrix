namespace Falcon.App.Core.Enum
{
    // TODO: This is put here because it is used only in parallel to EventCustomerService.
    public enum EventCustomerFilterMode
    {
        Filled,
        All,
        Open,
        Blocked,
        Registered,
        Actual,
        Paid,
        UnPaid,
        NoShow,
        CreditCard,
        Cash,
        Check,
        ECheck,
        Cancelled,
        UnPaidNoShowExcluded,
        LeftWithoutScreening
    } ;
}