using System;

namespace Falcon.App.Core.Application.ViewModels
{
    public class UserLoginSessionInfo
    {
        public string UserName { get; set; }
        public string SessionToken { get; set; }
        public DateTime LastAccessTime { get; set; }
    }
}