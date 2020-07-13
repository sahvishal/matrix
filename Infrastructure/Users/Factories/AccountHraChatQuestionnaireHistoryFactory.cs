using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using System;

namespace Falcon.App.Infrastructure.Users.Factories
{
    [DefaultImplementation]
    public class AccountHraChatQuestionnaireHistoryFactory : IAccountHraChatQuestionnaireHistoryFactory
    {
        public AccountHraChatQuestionnaireHistory CreateDomain(long id, long questionnaireType, DateTime startDate, DateTime? endDate, long accountId, long createdBy, long? modifiedBy)
        {
            var inpersistence = new AccountHraChatQuestionnaireHistory();
            inpersistence.Id = id;
            inpersistence.AccountId = accountId;
            inpersistence.QuestionnaireType = questionnaireType;
            inpersistence.StartDate = startDate;
            inpersistence.EndDate = endDate;
            inpersistence.CreatedBy = createdBy;
            inpersistence.ModifiedBy = modifiedBy;
            inpersistence.CreatedOn = DateTime.Now;
            inpersistence.ModifiedOn = DateTime.Now;
            return inpersistence;
        }
    }
}
