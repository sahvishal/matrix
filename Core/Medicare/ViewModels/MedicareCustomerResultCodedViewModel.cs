using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicareCustomerResultCodedViewModel
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public string UserName { get; set; }
        public string RoleAlias { get; set; }
        public bool IsCoded { get; set; }
        public string EmployeeId { get; set; }
    }
}
