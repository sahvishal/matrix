using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface IUserRepository<UserType>
        where UserType : User
    {
        bool UniqueEmail(string emailAddress);
        bool UniqueEmail(long excludedUserId, string emailAddress);
        bool UserNameExists(string userName);
        bool UserNameExists(long excludedUserId, string userName);
        UserType GetUser(long userId);
        List<UserType> GetUsers(List<long> userIds);
        List<UserType> GetOnlyUserAndAddressInfo(IEnumerable<long> userIds);
        List<UserType> GetActiveSystemUsers(List<long> userIds);
        UserType SaveUser(UserType user); // Might not be the right place to do so
        void SetUserDefaultRole(long userId, Roles role);

        IEnumerable<OrderedPair<long, string>> GetUsersWithDefaultRole(Roles defaultRole);
        IEnumerable<OrderedPair<long, string>> GetUsersByRole(Roles role, bool activeUsersOnly = false);

        bool UpdateUserIsActiveStatus(long userId, bool isActive);
        List<KeyValuePair<long, string>> SearchUsersByName(string prefix, bool onlyCustomer);
        bool UpdateUsePhoneAndEmail(long userId, string phoneCell, string email);
        List<KeyValuePair<long, string>> SearchUsersByNameAndRole(string prefix, Roles role);
        long? SearchUserByEmailAndRole(string emailId, long roleId = (long) Roles.CallCenterRep);
        IEnumerable<OrderedPair<long, string>> GetUsersByRoles(IEnumerable<long> roleIds, bool activeUsersOnly = false);
        List<UserType> GetUserWithoutAddressInfo(IEnumerable<long> userIds);
    }
}