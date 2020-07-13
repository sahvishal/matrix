namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareCanUnsignViewModel
    {
        public long HfCustomerId { get; set; }
        public long EventId { get; set; }
        public bool CanUnsign { get; set; }
        public string Message { get; set; }
    }
}
