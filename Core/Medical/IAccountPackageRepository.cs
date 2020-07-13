using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
   public interface IAccountPackageRepository
    {
        void Save(AccountPackage domainObject);
        void DeleteByAccountId(long accountId);
        void Save(IEnumerable<AccountPackage> accountPackages, long accountId);
        IEnumerable<AccountPackage> GetByAccountId(long accountId);
    }
}
