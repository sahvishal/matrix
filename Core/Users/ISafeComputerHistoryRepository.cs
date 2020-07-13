using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ILoginOtpRepository
    {
        LoginOtp Get(long userLoginId);
        bool Save(LoginOtp loginOtp);
    }
}
