using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;

namespace Falcon.App.Infrastructure.Users.Factories
{
    [DefaultImplementation]
    public class AccountHraChatQuestionnaireFactory : IAccountHraChatQuestionnaireFactory
    {
        public AccountHraChatQuestionnaire CreateDomain(long id, long questionnaireType, DateTime startDate, DateTime? endDate, long accountId, long createdBy, long? modifiedBy)
        {
            var inpersistence = new AccountHraChatQuestionnaire
            {
                Id = id,
                AccountId = accountId,
                QuestionnaireType = questionnaireType,
                StartDate = startDate,
                EndDate = endDate,
                CreatedBy = createdBy,
                ModifiedBy = modifiedBy,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            return inpersistence;
        }
    }
}
