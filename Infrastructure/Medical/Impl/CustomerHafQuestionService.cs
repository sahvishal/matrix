using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public sealed class HafTestDisplayNames
    {
        public long TestId { get; set; }
        public string TestDisplayName { get; set; }
    }

    public static class HafDisplayNames
    {
        public static List<HafTestDisplayNames> TestDisplay { get; set; }

        static HafDisplayNames()
        {
            TestDisplay = new List<HafTestDisplayNames>
            {
                new HafTestDisplayNames
                {
                    TestId = (long) TestType.Kyn,
                    TestDisplayName = "KYN HEALTH QUESTIONNAIRE"
                },
                new HafTestDisplayNames
                {
                    TestId = (long) TestType.HKYN,
                    TestDisplayName = "KYN HEALTH QUESTIONNAIRE"
                },
                new HafTestDisplayNames
                {
                    TestId = (long) TestType.Mammogram,
                    TestDisplayName = "MAMMOGRAPHY HEALTH QUESTIONNAIRE"
                }
            };
        }
    }

    [DefaultImplementation]
    public class CustomerHafQuestionService : ICustomerHafQuestionService
    {
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IHealthAssessmentTemplateRepository _healthAssessmentTemplateRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IHealthAssessmentQuestionDependencyRuleRepository _haqDependencyRuleRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerHafQuestionService(IHealthAssessmentRepository healthAssessmentRepository, IOrderRepository orderRepository, IHealthAssessmentTemplateRepository healthAssessmentTemplateRepository, IEventRepository eventRepository, IEventPodRepository eventPodRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IHealthAssessmentQuestionDependencyRuleRepository haqDependencyRuleRepository, ICustomerRepository customerRepository)
        {
            _healthAssessmentRepository = healthAssessmentRepository;
            _orderRepository = orderRepository;
            _healthAssessmentTemplateRepository = healthAssessmentTemplateRepository;
            _eventRepository = eventRepository;
            _eventPodRepository = eventPodRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _haqDependencyRuleRepository = haqDependencyRuleRepository;
            _customerRepository = customerRepository;
        }

        public bool IsFemale { get; set; }

        static readonly long[] NoControlValue = { 70, 1008 };

        public HafModel Get(HafFilter filter)
        {
            var theEvent = _eventRepository.GetById(filter.EventId);

            if (!theEvent.HealthAssessmentTemplateId.HasValue || theEvent.HealthAssessmentTemplateId.Value <= 0)
                return null;

            var customer = _customerRepository.GetCustomer(filter.CustomerId);

            var template = _healthAssessmentTemplateRepository.GetById(theEvent.HealthAssessmentTemplateId.Value);
            var genericQuestionIds = new List<long>();
            var list = new List<KeyValuePair<long, List<long>>>();

            IsFemale = customer.Gender == Gender.Female;

            //Get Generic Question from Event Templates
            genericQuestionIds.AddRange(template.QuestionIds);

            var order = _orderRepository.GetOrder(filter.CustomerId, filter.EventId);
            var eventpackageId = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventPackageItem).Select(od => od.OrderItem.ItemId).FirstOrDefault();

            var isKynIntegrationEnabled = _eventPodRepository.IsKynIntegrationEnabled(filter.EventId);
            var eventTestIds = new List<long>();

            if (eventpackageId > 0)
            {
                var eventPackage = _eventPackageRepository.GetById(eventpackageId);

                if (eventPackage.HealthAssessmentTemplateId.HasValue && eventPackage.HealthAssessmentTemplateId.Value > 0)
                {
                    var packageTemplate = _healthAssessmentTemplateRepository.GetById(eventPackage.HealthAssessmentTemplateId.Value);
                    genericQuestionIds.AddRange(packageTemplate.QuestionIds);
                }

                eventTestIds.AddRange(eventPackage.Tests.Select(t => t.Id));
            }
            list.Add(new KeyValuePair<long, List<long>>(0, genericQuestionIds));

            eventTestIds.AddRange(order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId));
            var eventTests = _eventTestRepository.GetbyIds(eventTestIds);

            var testWiseQuestion = GetTestQuestionKeyValuePairs(eventTestIds, isKynIntegrationEnabled, eventTests);
            if (testWiseQuestion != null)
                list.AddRange(testWiseQuestion);

            var hafModel = GetHafModel(list, eventTests, filter.EventId, filter.CustomerId, filter.SetChildQuestion, filter.VersionNumber) ?? new HafModel();

            hafModel.EventId = filter.EventId;
            hafModel.CustomerId = filter.CustomerId;
            return hafModel;
        }

        private IEnumerable<KeyValuePair<long, List<long>>> GetTestQuestionKeyValuePairs(IEnumerable<long> eventTestIds, bool isKynIntegrationEnabled, IEnumerable<EventTest> eventTests)
        {
            if (eventTestIds.IsNullOrEmpty()) return null;


            eventTests = eventTests.Where(et => et.HealthAssessmentTemplateId.HasValue && et.HealthAssessmentTemplateId.Value > 0 && (et.TestId != (long)TestType.Kyn || et.TestId != (long)TestType.HKYN || isKynIntegrationEnabled)).Select(et => et);

            if (eventTests.IsNullOrEmpty()) return null;

            if (!isKynIntegrationEnabled)
                eventTests.ToList().RemoveAll(et => et.TestId == (long)TestType.Kyn || et.TestId == (long)TestType.HKYN);

            var testTemplates = _healthAssessmentTemplateRepository.GetByIds(eventTests.Select(et => et.HealthAssessmentTemplateId.Value));

            var testList = eventTests.Where(x => x.HealthAssessmentTemplateId.HasValue).Select(et => new { et.TestId, et.HealthAssessmentTemplateId });

            return (from healthAssessmentTemplate in testTemplates
                    let test = testList.First(x => x.HealthAssessmentTemplateId == healthAssessmentTemplate.Id)
                    select
                        new KeyValuePair<long, List<long>>(test.TestId,
                            new List<long>(healthAssessmentTemplate.QuestionIds))).ToList();
        }

        private HafModel GetHafModel(IEnumerable<KeyValuePair<long, List<long>>> keyValuePairs, IEnumerable<EventTest> eventTests, long eventId, long customerId, bool setChildQuestion, int versionNumber)
        {
            var questionsGroupByGroupName = _healthAssessmentRepository.GetAllQuestionGroupWithQuestion();
            var dependencyRules = _haqDependencyRuleRepository.Get();
            var genericQuestionIds = keyValuePairs.First(x => x.Key == 0).Value;
            IEnumerable<HealthAssessmentAnswer> answers = null;

            if (versionNumber > 0)
            {
                var archiveanswers = _healthAssessmentRepository.GetArchive(customerId, eventId, versionNumber);
                answers = archiveanswers.Select(aa => aa.HealthAssessmentAnswer).ToArray();
            }
            else
            {
                answers = _healthAssessmentRepository.Get(customerId, eventId);
            }


            keyValuePairs = keyValuePairs.Where(x => x.Key > 0);

            var questions = questionsGroupByGroupName.Where(x => x.Questions != null).SelectMany(x => x.Questions);

            var questionHafModel = questions.Where(
                 x =>
                     genericQuestionIds.Contains(x.Id) &&
                     (x.IsForFemale == null || x.IsForFemale == IsFemale))
                 .OrderBy(x => x.DisplaySequence)
                 .ThenBy(x => x.Id)
                 .Select(
                     x => GetQuestion(x, dependencyRules.FirstOrDefault(d => d.QuestionId == x.Id), answers))
                 .ToList();

            var genericModel = questionHafModel.Where(x => x.ParentQuestionId <= 0).ToArray();

            var model = new HafModel
            {
                Name = string.Empty,
                Description = string.Empty,
                HafGroup = new HafQuestionGroup
                {
                    Questions = setChildQuestion ? genericModel.Select(x => SetChildQuestions(x, questionHafModel.Where(c => c.ParentQuestionId == x.QuestoinId).ToArray(), questionHafModel.ToArray())) : questionHafModel
                },
                HafTests = CreateTestLevelHafQuestion(keyValuePairs, eventTests, questionsGroupByGroupName.Where(x => x.Questions != null).ToArray(), dependencyRules, answers, setChildQuestion)
            };

            long parentQuestionId = 0;
            var index = 0;

            foreach (var item in model.HafGroup.Questions.Where(x => x.ParentQuestionId > 0))
            {
                if (parentQuestionId != item.ParentQuestionId)
                {
                    index = 1;
                    parentQuestionId = item.ParentQuestionId;
                }
                item.RelativeOrder = index++;
            }

            return model;
        }

        private HafQuestion SetChildQuestions(HafQuestion question, IEnumerable<HafQuestion> childQuestionList, IEnumerable<HafQuestion> questionList)
        {
            question.ChildQuestion = childQuestionList;

            if (childQuestionList != null && childQuestionList.Any())
            {
                foreach (var hafQuestion in childQuestionList)
                {
                    SetChildQuestions(hafQuestion, questionList.Where(c => c.ParentQuestionId == hafQuestion.QuestoinId), questionList);
                }
            }

            return question;
        }

        private IEnumerable<HafTest> CreateTestLevelHafQuestion(IEnumerable<KeyValuePair<long, List<long>>> keyValuePairs, IEnumerable<EventTest> eventTests, IEnumerable<HealthAssessmentQuestionGroup> questionsGroupByGroupName, IEnumerable<HealthAssessmentQuestionDependencyRule> dependencyRules, IEnumerable<HealthAssessmentAnswer> answers, bool setChildQuestion)
        {
            if (questionsGroupByGroupName == null || !questionsGroupByGroupName.Any()) return null;

            return (from keyValuePair in keyValuePairs
                    let eventtest = eventTests.First(x => x.TestId == keyValuePair.Key)
                    let groupIds = questionsGroupByGroupName.Where(x => x.Questions.Any(q => keyValuePair.Value.Contains(q.Id))).Select(g => g.Id).Distinct()
                    let displayName = HafDisplayNames.TestDisplay.FirstOrDefault(t => t.TestId == eventtest.TestId)
                    select new HafTest
                    {
                        Name = displayName == null ? string.Empty : displayName.TestDisplayName,
                        HafQuestionGroups = GetGroups(groupIds, questionsGroupByGroupName, keyValuePair.Value, dependencyRules, answers, setChildQuestion)
                    }).ToList();
        }

        private IEnumerable<HafQuestionGroup> GetGroups(IEnumerable<long> groupIds, IEnumerable<HealthAssessmentQuestionGroup> questionsGroupByGroupName, IEnumerable<long> questionIds, IEnumerable<HealthAssessmentQuestionDependencyRule> dependencyRules, IEnumerable<HealthAssessmentAnswer> answers, bool setChildQuestion)
        {
            var groups = new List<HafQuestionGroup>();
            long parentQuestionId = 0;
            var index = 0;

            foreach (var groupId in groupIds)
            {
                var group = questionsGroupByGroupName.First(x => x.Id == groupId);
                var hafGroup = new HafQuestionGroup
                {
                    Name = group.Id > 1 ? group.Name : string.Empty,
                    GroupId = groupId,
                    Description = group.Id > 1 ? group.Description : string.Empty,
                };

                var list = new List<HafQuestion>();
                foreach (
                    var item in
                        @group.Questions.Where(q => questionIds.Contains(q.Id) && (q.IsForFemale == null || q.IsForFemale == IsFemale)).OrderBy(x => x.DisplaySequence)
                            .ThenBy(x => x.Id).Select(source => GetQuestion(source, dependencyRules.FirstOrDefault(d => d.QuestionId == source.Id), answers)))
                {
                    if (parentQuestionId != item.ParentQuestionId && item.ParentQuestionId > 0)
                    {
                        index = 1;
                        parentQuestionId = item.ParentQuestionId;
                    }
                    item.RelativeOrder = index++;
                    list.Add(item);
                }
                if (list == null || !list.Any()) continue;

                var parentQuestions = list.Where(x => x.ParentQuestionId == 0);

                hafGroup.Questions = setChildQuestion ? parentQuestions.Select(x => SetChildQuestions(x, list.Where(c => c.ParentQuestionId == x.QuestoinId), list)) : list;
                groups.Add(hafGroup);
            }

            return groups;
        }

        private HafQuestion GetQuestion(HealthAssessmentQuestion question, HealthAssessmentQuestionDependencyRule dependencyRules, IEnumerable<HealthAssessmentAnswer> answers)
        {
            HealthAssessmentAnswer answer = null;
            if (answers != null && answers.Any())
            {
                answer = answers.FirstOrDefault(x => x.QuestionId == question.Id);
            }
            var isNoControlValue = NoControlValue.Contains(question.Id);
            return new HafQuestion
            {
                ControlType = (long)question.ControlType,
                ControlValues = isNoControlValue ? null : question.ControlValues,
                DefaultValue = answer == null ? question.DefaultValue : answer.Answer,
                QuestoinId = question.Id,
                Answer = answer == null ? string.Empty : answer.Answer,
                DisplaySequence = question.DisplaySequence,
                Label = question.Label,
                Question = question.Question,
                ParentQuestionId = question.ParentQuestionId ?? 0,
                DependentQuestionId = dependencyRules == null ? 0 : dependencyRules.DependantQuestionId,
                DependencyRule = dependencyRules == null ? string.Empty : dependencyRules.DependencyRule,
                QuestionGroupId = question.QuestionGroupId
            };
        }
    }
}
