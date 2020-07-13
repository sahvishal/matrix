using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IAccountNotReviewableTestRepository
    {
        void Save(AccountNotReviewableTest domainObject);
        void DeleteByAccountId(long accountId);
        void Save(IEnumerable<AccountNotReviewableTest> accountTests, long accountId);
        IEnumerable<AccountNotReviewableTest> GetByAccountId(long accountId);
    }
}