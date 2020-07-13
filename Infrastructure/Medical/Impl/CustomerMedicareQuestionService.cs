using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class CustomerMedicareQuestionService : ICustomerMedicareQuestionService
    {
        private readonly IMedicareQuestionRepository _medicareQuestionRepository;
        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;
        private readonly ISessionContext _sessionContext;


        public CustomerMedicareQuestionService(IMedicareQuestionRepository medicareQuestionRepository, IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService, ISessionContext sessionContext)
        {
            _medicareQuestionRepository = medicareQuestionRepository;
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;
            _sessionContext = sessionContext;

        }

        public IEnumerable<MedicareQuestionGroupEditModel> GetEditModel(long eventCustomerId)
        {
            var questions = _medicareQuestionRepository.GetAllQuestions();
            var groups = _medicareQuestionRepository.GetAllGroups();
            var answers = GetAnswersByEventCustomerId(eventCustomerId);
            var questionsRemarks = _medicareQuestionRepository.GetQuestionRemarks();

            questionsRemarks = questionsRemarks.Where(x => x.CombinedQuestionId.HasValue && x.CombinedQuestionId.Value > 0);

            return groups.Select(domain => new MedicareQuestionGroupEditModel
            {
                Id = domain.Id,
                IsAcitve = domain.IsActive,
                IsDefault = domain.IsDefault,
                GroupName = domain.GroupName,
                GroupAlias = domain.GroupAlias,
                MedicareQuestions =
                    questions.Where(x => x.GroupId == domain.Id)
                        .Select(x => CreateQuestionEditModel(x, answers, questionsRemarks.Where(dq => dq.CombinedQuestionId == x.Id)))
                        .ToList()
            }).ToList();
        }

        private MedicareQuestionEditModel CreateQuestionEditModel(MedicareQuestion medicareQuestion, IEnumerable<MedicareQuestionAnswer> answers, IEnumerable<MedicareQuestionsRemark> questionsRemarks)
        {
            var answer = answers.FirstOrDefault(x => x.QuestionId == medicareQuestion.Id);
            var remarks = medicareQuestion.MedicareQuestionsRemarks != null && medicareQuestion.MedicareQuestionsRemarks.Any() ? medicareQuestion.MedicareQuestionsRemarks.ToList() : null;

            if (questionsRemarks != null && questionsRemarks.Any())
            {
                if (remarks != null && remarks.Any())
                {
                    remarks.AddRange(questionsRemarks.ToList());
                }
                else
                {
                    remarks = questionsRemarks.ToList();
                }
            }

            return new MedicareQuestionEditModel
            {
                MedicareGroupDependencyRules = medicareQuestion.MedicareGroupDependencyRules,
                MedicareQuestionsRemarks = remarks,
                DependencyRules = medicareQuestion.DependencyRules,
                Id = medicareQuestion.Id,
                ControlType = medicareQuestion.ControlType,
                ControlValues = medicareQuestion.ControlValues,
                ParentQuestionId = medicareQuestion.ParentQuestionId,
                Question = medicareQuestion.Question,
                IsDefault = medicareQuestion.IsDefault,
                DefaultValue = medicareQuestion.DefaultValue,
                Answer = answer != null ? answer.Answer : string.Empty
            };
        }

        public void SaveCustomerMedicareAnswer(CustomerMedicareQuestionAnswerEditModel customerMedicareQuestionAnswer)
        {

            if (customerMedicareQuestionAnswer.Question != null && customerMedicareQuestionAnswer.Question.Any())
            {
                var medicareQuestionAnswerList = customerMedicareQuestionAnswer.Question.Select(x => GetDomain(x, customerMedicareQuestionAnswer.CustomerEventId)).ToList();
                var createdBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                _medicareQuestionRepository.SaveCustomerAnswer(medicareQuestionAnswerList, customerMedicareQuestionAnswer.CustomerEventId, createdBy);
            }
        }

        private MedicareQuestionAnswer GetDomain(CustomerMedicareAnswer customerMedicareAnswer, long eventCustomerId)
        {
            return new MedicareQuestionAnswer
            {
                QuestionId = customerMedicareAnswer.Id,
                Answer = customerMedicareAnswer.Answer,
                EventCustomerId = eventCustomerId
            };
        }

        public bool IsTestPurchased(long eventId, long customerId, long[] testId)
        {
            var tests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customerId);
            return tests != null && tests.Any(t => testId.Contains(t.Id));

        }

        public IEnumerable<MedicareQuestionAnswer> GetAnswersByEventCustomerId(long eventCustomerId)
        {
            return _medicareQuestionRepository.GetAnswersByEventCustomerId(eventCustomerId);
        }

        public IEnumerable<OrderedPair<long, DateTime>> GetEvenetCustomerMedicareSavedDatePair(long eventId)
        {
            return _medicareQuestionRepository.GetEvenetCustomerMedicareSavedDatePair(eventId);
        }
    }
}
