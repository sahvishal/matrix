using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class AccountCheckoutPhoneNumberFactory : IAccountCheckoutPhoneNumberFactory
    {
        public IEnumerable<AccountCheckoutPhoneNumberEditModel> CreateModel(IEnumerable<State> states, IEnumerable<AccountCheckoutPhoneNumber> accountCheckoutPhoneNumbers)
        {
            if (accountCheckoutPhoneNumbers.IsNullOrEmpty()) return null;

            var list = accountCheckoutPhoneNumbers.Select((acpn, index) => new AccountCheckoutPhoneNumberEditModel
                 {
                     CheckoutPhoneNumber = acpn.CheckoutPhoneNumber,
                     StateID = acpn.StateID,
                     StateName = states.First(x => x.Id == acpn.StateID).Name,
                     AccountCheckoutPhoneNumberID = index++
                 }).OrderBy(x => x.StateName).ToList();

            return list;
        }


        public IEnumerable<AccountCheckoutPhoneNumber> CreateDomain(IEnumerable<AccountCheckoutPhoneNumberEditModel> modelList, long accountId)
        {
            if (modelList.IsNullOrEmpty()) return null;

            var list = modelList.Select(model => new AccountCheckoutPhoneNumber
            {
                AccountID = accountId,
                StateID = model.StateID,
                CheckoutPhoneNumber = PhoneNumber.ToNumber(model.CheckoutPhoneNumber)
            }).ToList();

            return list;
        }
    }
}
