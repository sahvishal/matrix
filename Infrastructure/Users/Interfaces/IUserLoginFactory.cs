using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IUserLoginFactory
    {
        UserLoginEntity CreateUserLoginEntity(UserLogin userLogin, long userId);
        UserLogin CreateUserLogin(UserLoginEntity userLoginEntity);
    }
}
