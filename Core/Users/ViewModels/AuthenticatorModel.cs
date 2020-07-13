using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class AuthenticatorModel : ViewModelBase
    {
        
        public bool UseSms { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}