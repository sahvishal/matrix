using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ILoginSettingRepository
    {
        LoginSettings Get(long userLoginId);
        bool Save(LoginSettings loginOtp);
    }
}
