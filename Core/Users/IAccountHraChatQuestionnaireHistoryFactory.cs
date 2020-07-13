using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using System;
namespace Falcon.App.Core.Users
{
    public interface IAccountHraChatQuestionnaireHistoryFactory
    {
        AccountHraChatQuestionnaireHistory CreateDomain(long id, long questionnaireType, DateTime startDate, DateTime? endDate, long accountId, long createdBy, long? modifiedBy);
    }
}
