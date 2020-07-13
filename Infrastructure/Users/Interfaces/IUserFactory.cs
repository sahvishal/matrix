using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IUserFactory<UserType>
        where UserType : User
    {
        UserType CreateUser(UserEntity userEntity, Address address, bool useUserLoginInfo = true);
        List<UserType> CreateUsers(List<UserEntity> userEntities, List<Address> addresses);
        List<UserType> CreateOnlyUsers(List<UserEntity> userEntities, List<Address> addresses);
        UserEntity CreateUserEntity(UserType userType);
        List<UserType> CreateWithoutAddrss(List<UserEntity> userEntities);
    }

    public interface IUserFactory : IUserFactory<User>
    { }
}