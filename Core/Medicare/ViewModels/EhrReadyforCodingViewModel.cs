namespace Falcon.App.Core.Medicare.ViewModels
{
    public class EhrReadyforCodingViewModel
    {
        public long HfCustomerId { get; set; }
        public long EventId { get; set; }
        public bool ReadyForCoding { get; set; }
        public string Message { get; set; }
    }
}