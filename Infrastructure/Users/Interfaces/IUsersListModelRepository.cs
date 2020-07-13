using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IUsersListModelRepository
    {

        UserListModel GetUserListModelPaged(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);     

        UserListModel GetUserListModelByRole(Roles type);
        
        UserListModel GetUserListModelByRole(Roles type, long organizationId);

        UserListModel GetUserListModelByRolePaged(Roles type,int pageSize, int pageNumber);

        UserListModel GetUserListModelByRole(Roles type, string searchCondition);
        UserListModel GetUserListModelByRolePaged(Roles type, string searchCondition, int pageSize, int pageNumber);

    }
}