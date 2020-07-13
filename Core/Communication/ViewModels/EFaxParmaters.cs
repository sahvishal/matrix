namespace Falcon.App.Core.Communication.ViewModels
{
    public class EFaxParmaters
    {
        public string Message { get; set; }
        public string CustomerId { get; set; }
        public string TransmissionId { get; set; }
        public string RecipientFax { get; set; }
        public bool SendDuplicate { get; set; }
        public bool IsHighPriority { get; set; }
    }
}
