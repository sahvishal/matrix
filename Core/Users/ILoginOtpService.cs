namespace Falcon.App.Core.Users
{
    public interface ILoginOtpService
    {
        bool VerifyOtp(string otp, long userLoginId, out bool isOtpExpired, out bool isAttemptExcceded);
        bool GenerateOtp(long userId, string sourceUrl);
        bool ResetOtp(long userId);
    }
}
