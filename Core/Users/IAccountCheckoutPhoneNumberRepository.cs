using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Users
{
    public interface IAccountCheckoutPhoneNumberRepository
    {
        IEnumerable<AccountCheckoutPhoneNumber> GetByAccountId(long accountId);
        void Save(IEnumerable<AccountCheckoutPhoneNumber> accountCheckoutPhoneNumbers, long accountId);
        IEnumerable<AccountCheckoutPhoneNumber> GetAccountCheckoutPhoneNumberByStateID(long accouontId, long stateId);
        IEnumerable<AccountCheckoutPhoneNumber> GetAccountCheckoutPhoneNumberByStateIDs(long accountId, IEnumerable<long> stateIds);
    }
}
