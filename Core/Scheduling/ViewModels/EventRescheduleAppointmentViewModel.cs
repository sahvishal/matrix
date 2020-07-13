namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventRescheduleAppointmentViewModel
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long EventCustomerId { get; set; }
        public long EventId { get; set; }
    }
}
