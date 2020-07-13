using System;

namespace Falcon.App.Core.Users.Domain
{
    public class SafeComputerHistory
    {
        public long UserLoginId { get; set; }
        public string BrowserType { get; set; }
        public string ComputerIp { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }
    }
}
