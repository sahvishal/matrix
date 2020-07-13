using Type = System.Type;

namespace Falcon.App.Core.ACL
{
    public interface IAuthorizeEntity
    {
        bool AuthorizeAccount(long entityId, Type repositoryType, long accountId);
        bool AuthorizeSelf(long entityId, Type repositoryType, long organizationRoleUserId);
    }
}