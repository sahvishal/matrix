namespace Falcon.App.Core.Medical.Domain
{
    public class PhysicianEvaluationQueueSummary
    {
        public long ItemsDone { get; set; }
        public long ItemsAvailable { get; set; }
        public long CriticalsInQueue { get; set; }
        public long FirstItemInTheQueue { get; set; }
        public long PriorityInQueueCount { get; set; }
    }
}