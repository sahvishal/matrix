using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class UserNameEditModel : ViewModelBase
    {
        [Hidden]
        public long UserId { get; set; }

        [Description("6-20 characters")]
        [DisplayName("User Name")]
        public string UserName { get; set; }
    }
}
