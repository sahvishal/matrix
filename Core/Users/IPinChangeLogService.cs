
namespace Falcon.App.Core.Users
{
    public interface IPinChangeLogService
    {
        bool IsPinRepeated(long technicianId, string pin);
        bool Update(string password, long technicianId, long createdByOrgRoleUserId);
    }
}
