using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Users.ViewModels
{
    public class UserListModelFilter : ModelFilterBase
    {
        [DisplayName("Name/Email/UserName")]
        public string Keyword { get; set; }

        [DisplayName("Has Role Of")]
        public long Roles { get; set; }

        public bool ActiveUser { get; set; }

        public bool InActiveUser { get; set; }

        public UserType UserType { get; set; }
    }
}