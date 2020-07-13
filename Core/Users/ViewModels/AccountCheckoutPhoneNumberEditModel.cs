using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Users.ViewModels
{
    public class AccountCheckoutPhoneNumberEditModel : ViewModelBase
    {
        public int AccountCheckoutPhoneNumberID { get; set; }
        public long StateID { get; set; }
        public string StateName { get; set; }
        public string CheckoutPhoneNumber { get; set; }
    }
}
