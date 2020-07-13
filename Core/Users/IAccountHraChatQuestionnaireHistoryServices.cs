using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IAccountHraChatQuestionnaireHistoryServices
    {
        QuestionnaireType QuestionnaireTypeByAccountIdandEventDate(long accountId, DateTime eventDate);
        AccountHraChatQuestionnaire GetCurrentQuestionnaireTypeByAccountId(long accountId);
        IEnumerable<AccountHraChatQuestionnaire> GetByAccountId(long accountId);
    }
}
