using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class CustomerClinicalQuestionAnswerService : ICustomerClinicalQuestionAnswerService
    {
        private readonly ICustomerClinicalQuestionAnswerRepository _clinicalQuestionAnswerRepository;
        private readonly IHealthAssessmentTemplateRepository _healthAssessmentTemplateRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IClinicalTestQualificationCriteriaRepository _clinicalTestQualificationCriteriaRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IClinicalQuestionsHealthAssessmentHelper _clinicalQuestionsHealthAssessmentHelper;

        public CustomerClinicalQuestionAnswerService(ICustomerClinicalQuestionAnswerRepository clinicalQuestionAnswerRepository, IHealthAssessmentTemplateRepository healthAssessmentTemplateRepository,
            IHealthAssessmentRepository healthAssessmentRepository, IClinicalTestQualificationCriteriaRepository clinicalTestQualificationCriteriaRepository, ICustomerRepository customerRepository, IEventTestRepository eventTestRepository, IClinicalQuestionsHealthAssessmentHelper clinicalQuestionsHealthAssessmentHelper)
        {
            _clinicalQuestionAnswerRepository = clinicalQuestionAnswerRepository;
            _healthAssessmentTemplateRepository = healthAssessmentTemplateRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _clinicalTestQualificationCriteriaRepository = clinicalTestQualificationCriteriaRepository;
            _customerRepository = customerRepository;
            _eventTestRepository = eventTestRepository;
            _clinicalQuestionsHealthAssessmentHelper = clinicalQuestionsHealthAssessmentHelper;
        }

        public CustomerClinicalQuestionEditModel Get(string guid, long customerId, long eventId, long clinicalQuestionTemplateId,long eventCustomerId = 0)
        {
            var template = _healthAssessmentTemplateRepository.GetById(clinicalQuestionTemplateId);

            var questions = _healthAssessmentRepository.GetByIds(template.QuestionIds);

            var questionModelCollection = Mapper.Map<IEnumerable<HealthAssessmentQuestion>, IEnumerable<HealthAssessmentQuestionEditModel>>(questions);

            var answers = _clinicalQuestionAnswerRepository.GetCustomerClinicalQuestionAnswers(guid, customerId);
            if (answers.IsNullOrEmpty() && eventCustomerId > 0)
            {  
				answers = null;
                var hafAnswers = _healthAssessmentRepository.GetAnswerByEventCustomerId(eventCustomerId);
                foreach (var answer in hafAnswers)
                {
                    var editModel = questionModelCollection.SingleOrDefault(q => q.QuestionId == answer.QuestionId);
                    if (editModel != null)
                        editModel.Answer = answer.Answer;
                }
            }

            if (answers != null)
            {
                foreach (var answer in answers)
                {
                    var editModel = questionModelCollection.SingleOrDefault(q => q.QuestionId == answer.ClinicalHealthQuestionId);
                    if (editModel != null)
                        editModel.Answer = answer.HealthQuestionAnswer;
                }
            }
            var healthAssessmentModel = new HealthAssessmentEditModel
            {
                CustomerId = customerId,
                EventId = eventId,
                QuestionEditModels = questionModelCollection
            };

            _clinicalQuestionsHealthAssessmentHelper.SetRecommendationLogic(clinicalQuestionTemplateId, healthAssessmentModel);
            var model = new CustomerClinicalQuestionEditModel
            {
                HealthAssessmentModel = healthAssessmentModel,
                ClinicalQuestionTemplateId = clinicalQuestionTemplateId,
                Guid = guid
            };

            return model;
        }

        public void Save(HealthAssessmentEditModel model, string guid, long clinicalQuestionTemplateId, long createdByOrgRoleUserId)
        {
            if (model.QuestionEditModels == null || !model.QuestionEditModels.Any())
                return;

            var answerCollection = model.QuestionEditModels.Select(
                m =>
                new CustomerClinicalQuestionAnswer
                {
                    Guid = guid,
                    ClinicalQuestionTemplateId = clinicalQuestionTemplateId,
                    EventId = model.EventId,
                    CustomerId = model.CustomerId,
                    ClinicalHealthQuestionId = m.QuestionId,
                    HealthQuestionAnswer = m.Answer,
                    DataRecorderMetaData = new DataRecorderMetaData(createdByOrgRoleUserId, DateTime.Now, null),
                }).ToArray();

            using (var scope = new TransactionScope())
            {
                Save(answerCollection, createdByOrgRoleUserId);
                scope.Complete();
            }
        }

        private void Save(IEnumerable<CustomerClinicalQuestionAnswer> answers, long createdByOrgRoleUserId)
        {
            var guid = answers.First().Guid;
            var customerId = answers.First().CustomerId;

            var answersInDb = _clinicalQuestionAnswerRepository.GetCustomerClinicalQuestionAnswers(guid, customerId);
            if (answersInDb != null && answersInDb.Any())
            {
                _clinicalQuestionAnswerRepository.DeleteCustomerClinicalQuestionAnswers(guid, customerId);

                foreach (var answer in answers)
                {
                    var answerInDb = answersInDb.SingleOrDefault(aid => aid.ClinicalHealthQuestionId == answer.ClinicalHealthQuestionId);
                    if (answerInDb != null)
                    {
                        answer.DataRecorderMetaData = answerInDb.DataRecorderMetaData;
                        answer.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(createdByOrgRoleUserId);
                        answer.DataRecorderMetaData.DateModified = DateTime.Now;
                    }
                }
            }

            _clinicalQuestionAnswerRepository.SaveCustomerClinicalQuestionAnswers(answers);
        }

        private List<long> GetTestIdsToRecommend(string guid, long customerId, Gender gender, DateTime? dob, List<long> disqualifiedTest)
        {
            var tests = new List<long>();

            var answers = _clinicalQuestionAnswerRepository.GetCustomerClinicalQuestionAnswers(guid, customerId);

            if (!answers.IsNullOrEmpty())
            {
                var clinicalQuestionTemplateId = answers.First().ClinicalQuestionTemplateId;
                var template = _healthAssessmentTemplateRepository.GetById(clinicalQuestionTemplateId);
                var criteria = _clinicalTestQualificationCriteriaRepository.GetbyTemplateId(clinicalQuestionTemplateId);
                if (criteria.IsNullOrEmpty())
                {
                    return tests;
                }

                var groups = _healthAssessmentRepository.GetQuestionWithGroupForTemplatId(clinicalQuestionTemplateId);
                var templateTestIds = criteria.Select(x => x.TestId);
                foreach (var templateTestId in templateTestIds)
                {
                    var selectedGroup = groups.Where(x => x.TestId.HasValue && x.TestId.Value == templateTestId).Select(x => x).First();
                    var questionsintheGroupForTemplate = selectedGroup.Questions.Where(x => template.QuestionIds.Contains(x.Id));

                    var selectedCriteria = criteria.Single(x => x.TestId == templateTestId);

                    var isTestSelected = true;

                    /*answer for the disqualifier question must be given other wise user can qualify. Case: if disqualifier question is child question and parent question is said no then
                    disqualifier question will be disable*/

                    if (selectedCriteria.DisqualifierQuestionId.HasValue)
                    {
                        questionsintheGroupForTemplate = questionsintheGroupForTemplate.Where(x => x.Id != selectedCriteria.DisqualifierQuestionId.Value);

                        var answerForTheQuestion = answers.SingleOrDefault(q => q.ClinicalHealthQuestionId == selectedCriteria.DisqualifierQuestionId.Value);
                        
                        if (answerForTheQuestion != null && answerForTheQuestion.HealthQuestionAnswer == selectedCriteria.DisqualifierQuestionAnswer)
                        {
                            isTestSelected = false;
                            disqualifiedTest.Add(templateTestId);
                        }
                    }


                    if (isTestSelected && selectedCriteria.AgeCondition.HasValue && dob.HasValue)
                    {
                        var age = dob.Value.GetAge();
                        if (selectedCriteria.AgeCondition == (long)ComparisonOperators.LessThan)
                            isTestSelected = age < selectedCriteria.AgeMax;

                        else if (selectedCriteria.AgeCondition == (long)ComparisonOperators.LessThanEqualTo)
                            isTestSelected = dob.Value.IsAgeLessThanEqualTo(selectedCriteria.AgeMax ?? 0);

                        else if (selectedCriteria.AgeCondition == (long)ComparisonOperators.GreaterThan)
                            isTestSelected = dob.Value.IsAgeGreaterThan(selectedCriteria.AgeMin ?? 0);

                        else if (selectedCriteria.AgeCondition == (long)ComparisonOperators.GreaterThanEqualTo)
                            isTestSelected = age >= selectedCriteria.AgeMin;

                        else if (selectedCriteria.AgeCondition == (long)ComparisonOperators.Between)
                            isTestSelected = age >= selectedCriteria.AgeMin && dob.Value.IsAgeLessThanEqualTo(selectedCriteria.AgeMax ?? 0);
                    }

                    if (isTestSelected && selectedCriteria.Gender != Gender.Unspecified)
                    {
                        isTestSelected = selectedCriteria.Gender == gender;
                    }

                    bool medicationCriteriaPassed = false;

                    if (isTestSelected && selectedCriteria.MedicationQuestionId.HasValue)
                    {
                        var answerForTheQuestion = answers.SingleOrDefault(q => q.ClinicalHealthQuestionId == selectedCriteria.MedicationQuestionId.Value);

                        isTestSelected = answerForTheQuestion == null || answerForTheQuestion.HealthQuestionAnswer == "No";

                        medicationCriteriaPassed = isTestSelected;
                    }

                    if (isTestSelected && !String.IsNullOrEmpty(selectedCriteria.Answer) && !questionsintheGroupForTemplate.IsNullOrEmpty())
                    {
                        var questionWithParent = questionsintheGroupForTemplate.Where(x => x.ParentQuestionId != null);
                        var parentQuestions = new List<HealthAssessmentQuestion>();
                        if (!questionWithParent.IsNullOrEmpty())
                        {
                            var parentQuestionIds = questionWithParent.Select(s => s.ParentQuestionId).Distinct();
                            parentQuestions = questionsintheGroupForTemplate.Where(x => parentQuestionIds.Contains(x.Id)).ToList();
                        }

                        if (parentQuestions.IsNullOrEmpty())
                        {
                            isTestSelected = IsUserPassNumberOfTestCriteria(selectedCriteria, medicationCriteriaPassed, questionsintheGroupForTemplate, answers);
                        }
                        else
                        {
                            foreach (var parentQuestion in parentQuestions)
                            {
                                var questionsInSection = questionsintheGroupForTemplate.Where(x => x.ParentQuestionId == parentQuestion.Id);
                                var parentAnswer = answers.Single(q => q.ClinicalHealthQuestionId == parentQuestion.Id);
                                if (isTestSelected && parentAnswer.HealthQuestionAnswer == "Yes")
                                    isTestSelected = IsUserPassNumberOfTestCriteria(selectedCriteria, medicationCriteriaPassed, questionsInSection, answers);
                                else
                                {
                                    isTestSelected = false;
                                }
                            }
                        }
                    }

                    if (isTestSelected)
                        tests.Add(templateTestId);

                }
            }
            return tests;
        }

        private bool IsUserPassNumberOfTestCriteria(ClinicalTestQualificationCriteria selectedCriteria, bool medicationCriteriaPassed,
            IEnumerable<HealthAssessmentQuestion> questionsintheGroupForTemplate, IEnumerable<CustomerClinicalQuestionAnswer> answers)
        {
            bool isTestSelected = true;
            int yesCount = 0, noCount = 0;
            var criteriaNumberOfQuestion = selectedCriteria.NumberOfQuestion;

            if (medicationCriteriaPassed)
            {
                questionsintheGroupForTemplate = questionsintheGroupForTemplate.Where(x => x.Id != selectedCriteria.MedicationQuestionId.Value);
            }

            foreach (var healthAssessmentQuestion in questionsintheGroupForTemplate)
            {
                var answerForTheQuestion = answers.Single(q => q.ClinicalHealthQuestionId == healthAssessmentQuestion.Id);
                if (answerForTheQuestion.HealthQuestionAnswer == "Yes")
                {
                    yesCount = yesCount + 1;
                }
                else
                {
                    noCount = noCount + 1;
                }
            }
            //
            if (selectedCriteria.Answer == "Yes")
            {
                isTestSelected = criteriaNumberOfQuestion <= yesCount;
            }
            else
            {
                isTestSelected = criteriaNumberOfQuestion <= noCount;
            }
            return isTestSelected;
        }

        public IEnumerable<ClinicalTestQualificationViewModel> RecommendTestToCustomer(string guid, long customerId, long eventId)
        {
            var customerProfile = _customerRepository.GetCustomer(customerId);
            var disqualifiedTestIds = new List<long>();
            var recommendedtestIds = GetTestIdsToRecommend(guid, customerId, customerProfile.Gender, customerProfile.DateOfBirth, disqualifiedTestIds);
            var recommendedTestNames = new List<ClinicalTestQualificationViewModel>();
            var eventTests = _eventTestRepository.GetTestsForEvent(eventId);

            if (!recommendedtestIds.IsNullOrEmpty())
            {
                var recommendedtests = eventTests.Where(x => recommendedtestIds.Contains(x.TestId));

                if (recommendedtests.Any())
                {
                    recommendedTestNames = recommendedtests.Select(x => new ClinicalTestQualificationViewModel(x.Test.Id, x.Test.Name, false)).ToList();
                }
            }

            if (!disqualifiedTestIds.IsNullOrEmpty())
            {
                var disqualifiedTest = eventTests.Where(x => disqualifiedTestIds.Contains(x.TestId));

                if (disqualifiedTest.Any())
                {
                    recommendedTestNames.AddRange(disqualifiedTest.Select(x => new ClinicalTestQualificationViewModel(x.Test.Id, x.Test.Name, true))); ;
                }
            }

            return recommendedTestNames;
        }
    }
}
