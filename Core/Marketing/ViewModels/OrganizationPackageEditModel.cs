using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Marketing.ViewModels
{
    [NoValidationRequired]
    public class OrganizationPackageEditModel
    {
        public long PackageId { get; set; }
        public string PackageName { get; set; }
        public bool IsRecommended { get; set; }
        public Gender Gender { get; set; }
    }
}
