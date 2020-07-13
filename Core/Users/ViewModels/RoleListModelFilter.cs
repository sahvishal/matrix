using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Users.ViewModels
{
    [NoValidationRequired]
    public class RoleListModelFilter
    {
        public string Name { get; set; }
    }
}