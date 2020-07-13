using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IAccountAdditionalFieldRepository
    {
        IEnumerable<AccountAdditionalFields> GetByAccountId(long accountId);
        IEnumerable<AccountAdditionalFieldsEditModel> GetAccountAdditionalFieldsEditModelByAccountId(long accountId);
        IEnumerable<AccountAdditionalFields> GetAccountAdditionalFieldsByAccountIds(IEnumerable<long> accountIds);
    }
}
