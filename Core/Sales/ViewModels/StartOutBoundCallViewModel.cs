namespace Falcon.App.Core.Sales.ViewModels
{
    public class StartOutBoundCallViewModel
    {
        public long CallId { get; set; }
        public long AttemptId { get; set; }
        public long CallQueueCustomerId { get; set; }
        public bool IsDoNotCall { get; set; }
        public bool IsRemovedFromQueue { get; set; }
        public bool NoMoreCustomerInList { get; set; }

        public bool IsAlreadyLocked { get; set; }
        public bool IsAlreadyCalledToday { get; set; }

        public bool TryAgain { get; set; }

        public bool AssignmentChanged { get; set; }
    }
}
