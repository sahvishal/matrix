using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class KynHealthAssessmentHelper : IKynHealthAssessmentHelper
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IHealthAssessmentService _healthAssessmentService;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly ICustomerHafQuestionService _customerHafQuestionService;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        private readonly long[] _personalHealthQuestionIds = { 145, 146, 147, 148, 149, 150, 151, 152 };
        private long[] _womenOnlyQuestionIds = { 153, 154, 155, 156, 157, 158 };
        private readonly long[] _smokingQuestionIds = { 159, 160, 161, 162, 163, 164 };
        private readonly long[] _medicationQuestionIds = { 165, 166, 167 };
        private readonly long[] _lifeStyleQuestionIds = { 168, 169, 170, 171 };
        private readonly long[] _insuranceQuestoin = { 65, 70, 229, 1008 };
        private readonly long[] _excludeQuestion = { 579, 1177, 1221, 1248, 1249 };
        private readonly long[] _yesNoDependencyQuestion = { 1106, 1109, 1112, 1115, 1118, 1121, 1126, 1131, 1136, 1141, 1146, 1151 };

        public KynHealthAssessmentHelper(ICustomerRepository customerRepository, IHealthAssessmentService healthAssessmentService, IHealthAssessmentRepository healthAssessmentRepository, ICustomerHafQuestionService customerHafQuestionService,
                                            IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _customerRepository = customerRepository;
            _healthAssessmentService = healthAssessmentService;
            _healthAssessmentRepository = healthAssessmentRepository;
            _customerHafQuestionService = customerHafQuestionService;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }

        public bool IsKynHafFilled(long eventId, long customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            return IsKynHafFilled(eventId, customer);
        }

        public bool IsKynHafFilled(long eventId, Customer customer)
        {
            var model = _healthAssessmentService.GetHealthAssessmentEditModel(customer.CustomerId, eventId);
            if (model == null || !model.QuestionEditModels.Any())
                return false;

            if (!model.IsKynPurchased)
                return true;

            if (!CheckKynHaf(customer, model)) return false;

            return true;
        }

        private bool CheckKynHaf(Customer customer, HealthAssessmentEditModel model)
        {
            if (model.QuestionEditModels.Any(x => _personalHealthQuestionIds.Contains(x.QuestionId) && string.IsNullOrEmpty(x.Answer)))
                return false;

            if (customer.Gender == Gender.Female)
            {
                _womenOnlyQuestionIds = _womenOnlyQuestionIds.Where(x => x != 156).ToArray();
                if (model.QuestionEditModels.Any(x => _womenOnlyQuestionIds.Contains(x.QuestionId) && string.IsNullOrEmpty(x.Answer)))
                    return false;

                //var birthQuestion = model.QuestionEditModels.SingleOrDefault(x => x.QuestionId == 154);
                //if (birthQuestion != null && string.IsNullOrEmpty(birthQuestion.Answer))
                //    return false;

                var diabetesQuestion = model.QuestionEditModels.SingleOrDefault(x => x.QuestionId == 155);
                if (diabetesQuestion != null && !string.IsNullOrEmpty(diabetesQuestion.Answer) && diabetesQuestion.Answer.ToLower() == "yes")
                {
                    var lastDiagnosedQuestion = model.QuestionEditModels.SingleOrDefault(x => x.QuestionId == 156);
                    if (lastDiagnosedQuestion != null && string.IsNullOrEmpty(lastDiagnosedQuestion.Answer))
                        return false;
                }
            }

            if (model.QuestionEditModels.Any(x => _medicationQuestionIds.Contains(x.QuestionId) && string.IsNullOrEmpty(x.Answer)))
                return false;

            if (model.QuestionEditModels.Any(x => _lifeStyleQuestionIds.Contains(x.QuestionId) && string.IsNullOrEmpty(x.Answer)))
                return false;

            var currentlySmokeQuestion = model.QuestionEditModels.SingleOrDefault(x => x.QuestionId == 168);
            if (currentlySmokeQuestion != null && !string.IsNullOrEmpty(currentlySmokeQuestion.Answer) && currentlySmokeQuestion.Answer.ToLower() == "yes")
            {
                if (model.QuestionEditModels.Any(x => _smokingQuestionIds.Contains(x.QuestionId) && string.IsNullOrEmpty(x.Answer)))
                    return false;

                //var smokedYearQuestion = model.QuestionEditModels.SingleOrDefault(x => x.QuestionId == 163);
                //if (smokedYearQuestion != null && string.IsNullOrEmpty(smokedYearQuestion.Answer))
                //    return false;

                //var smokedDailyQuestion = model.QuestionEditModels.SingleOrDefault(x => x.QuestionId == 164);
                //if (smokedDailyQuestion != null && string.IsNullOrEmpty(smokedDailyQuestion.Answer))
                //    return false;
            }
            return true;
        }

        public bool CheckHafPrefilled(long eventId, long customerId, int versionNumber = 0)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            return CheckHafPrefilled(customer, eventId, versionNumber);
        }

        private bool CheckHafPrefilled(Customer customer, long eventid, int versionNumber = 0)
        {
            var model = _customerHafQuestionService.Get(new HafFilter { CustomerId = customer.CustomerId, EventId = eventid, SetChildQuestion = false, VersionNumber = versionNumber });
            if (model == null) return false;
            var questions = _healthAssessmentService.GetQuestions(eventid, customer.CustomerId);

            if (questions == null || !questions.Any()) return false;

            var questionIds = questions.Select(x => x.Id).Distinct();

            var hafQuestions = new List<HafQuestion>();

            if (model.HafGroup != null)
                hafQuestions.AddRange(model.HafGroup.Questions.ToList());

            if (model.HafTests.Any())
                hafQuestions.AddRange(model.HafTests.SelectMany(x => x.HafQuestionGroups.SelectMany(q => q.Questions)).ToList());

            if (!hafQuestions.Any()) return false;

            if (customer.Gender != Gender.Female)
                hafQuestions = hafQuestions.Where(x => !_womenOnlyQuestionIds.Contains(x.QuestoinId) && x.QuestoinId != 100).ToList();

            var hafNotDependent = hafQuestions.Where(x => x.DependentQuestionId == 0).ToList();

            var isPrefilled = !hafNotDependent.Any(x => questionIds.Contains(x.QuestoinId) && !_insuranceQuestoin.Contains(x.QuestoinId) && !_excludeQuestion.Contains(x.QuestoinId) && string.IsNullOrEmpty(x.Answer) && x.ControlType == (long)DisplayControlType.Radio);

            //var temp = hafNotDependent.Where(x => questionIds.Contains(x.QuestoinId) && !_insuranceQuestoin.Contains(x.QuestoinId) && string.IsNullOrEmpty(x.Answer) && x.ControlType == (long)DisplayControlType.Radio).Select(x => x).ToArray();

            if (isPrefilled)
            {
                var hafDependent = hafQuestions.Where(x => questionIds.Contains(x.QuestoinId) && x.DependentQuestionId > 0 && !_insuranceQuestoin.Contains(x.DependentQuestionId) && !_excludeQuestion.Contains(x.QuestoinId)).ToList();

                foreach (var hafQuestion in hafDependent)
                {
                    var dependentAnswer = hafQuestions.FirstOrDefault(h => h.QuestoinId == hafQuestion.DependentQuestionId && h.Answer.ToLower() == hafQuestion.DependencyRule.ToLower());

                    if (dependentAnswer != null)
                    {
                        if (_yesNoDependencyQuestion.Contains(dependentAnswer.QuestoinId))
                        {
                            var allDependentQuestions = hafQuestions.Where(h => h.DependentQuestionId == hafQuestion.DependentQuestionId);

                            allDependentQuestions = allDependentQuestions.Where(h => !string.IsNullOrEmpty(h.Answer));
                            if (!allDependentQuestions.Any())
                            {
                                isPrefilled = false;
                                break;
                            }
                        }
                        else if (string.IsNullOrEmpty(hafQuestion.Answer) && hafQuestion.ControlType == (long)DisplayControlType.Radio)
                        {
                            isPrefilled = false;
                            break;
                        }
                        else if (hafQuestion.ControlType == (long)DisplayControlType.CheckBox)
                        {
                            var allDependentQuestions = hafQuestions.Where(h => h.DependentQuestionId == hafQuestion.DependentQuestionId && hafQuestion.ControlType == (long)DisplayControlType.CheckBox);

                            allDependentQuestions = allDependentQuestions.Where(h => !string.IsNullOrEmpty(h.Answer));
                            if (!allDependentQuestions.Any())
                            {
                                isPrefilled = false;
                                break;
                            }
                        }
                    }
                }
            }

            return isPrefilled;
        }

        public bool? IsKynHafPrefilled(long eventId, long customerId, DateTime appointmentTime, bool checkKynOnly = true)
        {
            var model = _healthAssessmentService.GetHealthAssessmentEditModel(customerId, eventId);
            if (model == null || !model.QuestionEditModels.Any())
                return false;

            if (!model.IsKynPurchased && checkKynOnly)
                return null;

            var customer = _customerRepository.GetCustomer(customerId);

            var isFilled = checkKynOnly ? CheckKynHaf(customer, model) : CheckHafPrefilled(customer, eventId);

            if (isFilled)
            {
                var answers = _healthAssessmentRepository.Get(customerId, eventId);

                if (answers.Any())
                {
                    var answer = answers.First();
                    if (answer.DataRecorderMetaData == null || answer.DataRecorderMetaData.DataRecorderCreator == null) return false;

                    var technicianIds = _organizationRoleUserRepository.GetOrganizationRoleUserIdsForRole((long)Roles.Technician);

                    technicianIds.AddRange(_organizationRoleUserRepository.GetOrganizationRoleUserIdsByParentRole((long)Roles.Technician));

                    var dataRecorderMetaData = answer.DataRecorderMetaData;
                    var updatedByCustomerOrOtherThanTechnician = dataRecorderMetaData.DataRecorderCreator.Id == customerId || !technicianIds.Contains(dataRecorderMetaData.DataRecorderCreator.Id);

                    if (updatedByCustomerOrOtherThanTechnician)
                    {
                        return dataRecorderMetaData.DateCreated.AddHours(2) <= appointmentTime;
                    }

                    var latestVersion = _healthAssessmentRepository.GetLastVersionNumberUpdatedByCustomerOrOtherThanTechnician(answer.EventCustomerId, customerId);

                    if (latestVersion > 0)
                    {
                        var archiveAnswers = _healthAssessmentRepository.GetArchive(customerId, eventId, latestVersion);

                        model = _healthAssessmentService.GetHealthAssessmentEditModel(customerId, eventId, latestVersion);

                        isFilled = checkKynOnly ? CheckKynHaf(customer, model) : CheckHafPrefilled(customer, eventId, latestVersion);

                        if (isFilled)
                        {
                            if (archiveAnswers != null && archiveAnswers.Any())
                            {
                                answer = archiveAnswers.First().HealthAssessmentAnswer;
                                dataRecorderMetaData = answer.DataRecorderMetaData;
                                return dataRecorderMetaData.DateCreated.AddHours(2) <= appointmentTime;
                            }
                        }
                    }

                }
            }

            return false;
        }
    }
}
