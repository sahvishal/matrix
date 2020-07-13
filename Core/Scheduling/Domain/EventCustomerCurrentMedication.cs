namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventCustomerCurrentMedication
    {
        public long EventCustomerId { get; set; }
        public long NdcId { get; set; }
        public bool IsPrescribed { get; set; }
        public bool IsOtc { get; set; }
    }
}