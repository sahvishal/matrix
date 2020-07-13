using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class SetupViewModel : ViewModelBase
    {
        public long UserLoginId { get; set; }
        public bool IsOtpVerified { get; set; }
        public bool UseSms { get; set; }
        public bool UseEmail { get; set; }
        public bool UseAuthenticator { get; set; }
        public bool IsPinRequired { get; set; }

        public string Pin { get; set; }
        public string PhoneCell { get; set; }
        public string Email { get; set; }

        public string EncodedSecret { get; set; }

        public bool IsOtpBySmsEnabled { get; set; }
        public bool IsOtpByEmailEnabled { get; set; }
        public bool IsOtpByAppEnabled { get; set; }
    }
}