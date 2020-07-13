using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class UserLoginLog : DomainObjectBase
    {
        public long UserId { get; set; }
        public DateTime LogInDateTime { get; set; }
        public DateTime? LogOutDateTime { get; set; }
        public string BrowserSession { get; set; }
        public string BrowserName { get; set; }
        public string SessionIP { get; set; }
        public Uri RefferedUrl { get; set; }
        public string DeviceKey { get; set; }
        public string MedicareToken { get; set; }

        public UserLoginLog()
        { }

        public UserLoginLog(long userLoginLogId)
            : base(userLoginLogId)
        { }
    }
}
