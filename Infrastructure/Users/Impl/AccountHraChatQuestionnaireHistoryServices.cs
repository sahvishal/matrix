using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class AccountHraChatQuestionnaireHistoryServices : IAccountHraChatQuestionnaireHistoryServices
    {
        private readonly IAccountHraChatQuestionnaireRepository _accountHraChatQuestionnaireHistoryRepository;

        public AccountHraChatQuestionnaireHistoryServices()
        {
            _accountHraChatQuestionnaireHistoryRepository = new AccountHraChatQuestionnaireRepository();
        }
      
        public QuestionnaireType QuestionnaireTypeByAccountIdandEventDate(long accountId, DateTime eventDate)
        {
            var questionnaireTypeByAccountId = _accountHraChatQuestionnaireHistoryRepository.GetByAccountId(accountId);
            var result = questionnaireTypeByAccountId.Where(q => q.StartDate <= eventDate && (q.EndDate == null || q.EndDate >= eventDate)).FirstOrDefault();

            QuestionnaireType questionnaireType = QuestionnaireType.None;
            if (result == null)
                return questionnaireType;

            return ((QuestionnaireType)result.QuestionnaireType);
        }

        public AccountHraChatQuestionnaire GetCurrentQuestionnaireTypeByAccountId(long accountId)
        {
            var questionnaireTypeByAccountId = _accountHraChatQuestionnaireHistoryRepository.GetCurrentQuestionnaireTypeByAccountId(accountId);
            return questionnaireTypeByAccountId;
        }

        public IEnumerable<AccountHraChatQuestionnaire> GetByAccountId(long accountId)
        {
            return _accountHraChatQuestionnaireHistoryRepository.GetByAccountId(accountId);
        }

    }
}
