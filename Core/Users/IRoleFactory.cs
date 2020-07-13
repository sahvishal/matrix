using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IRoleFactory
    {
            RoleEditModel CreateModel(Role domain);
            Role CreateDomain(RoleEditModel model);
    }
}