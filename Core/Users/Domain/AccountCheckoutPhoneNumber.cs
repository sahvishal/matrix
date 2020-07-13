using Falcon.App.Core.Domain;
namespace Falcon.App.Core.Users.Domain
{
    public class AccountCheckoutPhoneNumber : DomainObjectBase
    {
        public long AccountID { get; set; }
        public long StateID { get; set; }
        public string CheckoutPhoneNumber { get; set; }
    }
}
