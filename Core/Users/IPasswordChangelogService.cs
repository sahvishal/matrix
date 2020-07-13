using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IPasswordChangelogService
    {
        bool IsPasswordRepeated(long userLoginId, string password);
        bool Update(long userLoginId, SecureHash usedSecureHash, long createdByOrgRoleUserId);
    }
}
