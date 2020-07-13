using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IAccountHraChatQuestionnaireHistoryRepository
    {
        IEnumerable<AccountHraChatQuestionnaireHistory> GetByAccountId(long accountId);
        AccountHraChatQuestionnaireHistory GetCurrentQuestionnaireTypeByAccountId(long accountId);
        void Save(long accountId, long questionnaireType, DateTime? startDate, long orgUserId);
        void UpdateIfnotHealthPlan(long accountId, long orgUserId);
    }
}
