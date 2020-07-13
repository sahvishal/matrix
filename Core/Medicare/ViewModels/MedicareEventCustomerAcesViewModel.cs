using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicareEventCustomerAcesViewModel
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public string MemberId { get; set; }
        public string AcesId { get; set; }
    }
}
