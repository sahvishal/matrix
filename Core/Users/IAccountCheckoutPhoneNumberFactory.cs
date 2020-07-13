using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Users
{
    public interface IAccountCheckoutPhoneNumberFactory
    {
        IEnumerable<AccountCheckoutPhoneNumberEditModel> CreateModel(IEnumerable<State> states, IEnumerable<AccountCheckoutPhoneNumber> accountCheckoutPhoneNumbers);
        IEnumerable<AccountCheckoutPhoneNumber> CreateDomain(IEnumerable<AccountCheckoutPhoneNumberEditModel> modelList, long accountId);
    }
}
