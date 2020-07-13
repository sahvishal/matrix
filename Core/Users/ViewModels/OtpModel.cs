using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class OtpModel : ViewModelBase
    {
        public string Otp { get; set; }
        public bool IsOtpVerified { get; set; }
        public bool IsAccountLocked { get; set; }
        [UIHint("CheckBox")]
        [DisplayName("Don't ask again on this computer")]
        public bool MarkAsSafe { get; set; }
        public bool IsAllowSafeComputerEnabled { get; set; }
        public long UserId { get; set; }
    }
}