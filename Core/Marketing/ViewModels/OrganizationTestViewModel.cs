using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Marketing.ViewModels
{
    [NoValidationRequired]
    public class OrganizationTestViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
    }
}
