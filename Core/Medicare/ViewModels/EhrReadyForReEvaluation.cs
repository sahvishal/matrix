namespace Falcon.App.Core.Medicare.ViewModels
{
    public class EhrReadyForReEvaluation
    {
        public long HfCustomerId { get; set; }
        public long EventId { get; set; }
        public bool ReadyForReEvaluation { get; set; }
        public string Message { get; set; }
    }
}