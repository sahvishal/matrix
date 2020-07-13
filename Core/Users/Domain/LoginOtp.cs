using System;

namespace Falcon.App.Core.Users.Domain
{
    public class LoginOtp
    {
        public long UserLoginId { get; set; }
        public string Otp { get; set; }
        public DateTime DateCreated { get; set; }
        public int AttemptCount { get; set; }
    }
}
