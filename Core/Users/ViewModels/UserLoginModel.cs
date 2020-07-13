using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class UserLoginModel : ViewModelBase
    {
        [DisplayName("Username")]
        public string UserName { get; set; }
        [IgnoreAudit]
        public string Password { get; set; } 
    }
}