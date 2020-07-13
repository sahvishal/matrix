using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IAccountHraChatQuestionnaireRepository
    {
        IEnumerable<AccountHraChatQuestionnaire> GetByAccountId(long accountId);
        AccountHraChatQuestionnaire GetCurrentQuestionnaireTypeByAccountId(long accountId);
        void Save(long accountId, long questionnaireType, DateTime? startDate, long orgUserId);
        void Save(AccountHraChatQuestionnaire domain);
        void DeactivateLast(long accountId, DateTime endDate, long orgUserId);
    }
}
