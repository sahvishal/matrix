using Falcon.App.Core.Users.Domain;
using System;
namespace Falcon.App.Core.Users
{
    public interface IAccountHraChatQuestionnaireFactory
    {
        AccountHraChatQuestionnaire CreateDomain(long id, long questionnaireType, DateTime startDate, DateTime? endDate, long accountId, long createdBy, long? modifiedBy);
    }
}
