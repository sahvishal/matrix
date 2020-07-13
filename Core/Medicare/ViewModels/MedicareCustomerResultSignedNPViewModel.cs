using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicareCustomerResultSignedNPViewModel
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public string UserName { get; set; }
        public string RoleAlias { get; set; }
        public bool IsSigned { get; set; }
        public long UserId { get; set; }
    }
}
