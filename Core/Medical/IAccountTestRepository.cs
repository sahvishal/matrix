using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
   public interface IAccountTestRepository
    {
       void Save(AccountTest domainObject);
        void DeleteByAccountId(long accountId);
        void Save(IEnumerable<AccountTest> accountTests, long accountId);
        IEnumerable<AccountTest> GetByAccountId(long accountId);
    }
}
