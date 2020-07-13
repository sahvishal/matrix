using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Users.ViewModels
{
    public class RoleSelectItemModel
    {
        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public Roles ParentRole { get; set; }
    }
}