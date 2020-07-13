using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class EventCustomerQuestionAnswerService : IEventCustomerQuestionAnswerService
    {
        private readonly ITestRepository _testRepository;
        private readonly IDisqualifiedTestRepository _disqualifiedTestRepository;
        private readonly IEventCustomerQuestionAnswerRepository _eventCustomerQuestionAnswerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventCustomerQuestionAnswerFactory _eventCustomerQuestionAnswerFactory;
        private readonly IPreQualificationQuestionRepository _preQualificationQuestionRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IPreQualificationTemplateDependentTestRepository _preQualificationTemplateDependentTestRepository;
        private readonly IDependentDisqualifiedTestRepository _dependentDisqualifiedTestRepository;

        public EventCustomerQuestionAnswerService(ITestRepository testRepository, IDisqualifiedTestRepository disqualifiedTestRepository, IEventCustomerQuestionAnswerRepository eventCustomerQuestionAnswerRepository,
            ICustomerRepository customerRepository, ICorporateAccountRepository corporateAccountRepository, IEventCustomerQuestionAnswerFactory eventCustomerQuestionAnswerFactory,
            IPreQualificationQuestionRepository preQualificationQuestionRepository, IEventTestRepository eventTestRepository, IPreQualificationTemplateDependentTestRepository preQualificationTemplateDependentTestRepository,
            IDependentDisqualifiedTestRepository dependentDisqualifiedTestRepository)
        {
            _testRepository = testRepository;
            _disqualifiedTestRepository = disqualifiedTestRepository;
            _eventCustomerQuestionAnswerRepository = eventCustomerQuestionAnswerRepository;
            _customerRepository = customerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _eventCustomerQuestionAnswerFactory = eventCustomerQuestionAnswerFactory;
            _preQualificationQuestionRepository = preQualificationQuestionRepository;
            _eventTestRepository = eventTestRepository;
            _preQualificationTemplateDependentTestRepository = preQualificationTemplateDependentTestRepository;
            _dependentDisqualifiedTestRepository = dependentDisqualifiedTestRepository;
        }

        public void SavePreQualifiedTestAnswers(string questionAnsTestId, string disqualified, long? eventCustomerId, long customerId, long eventId, long orgUserId)
        {
            if (!string.IsNullOrEmpty(questionAnsTestId))
            {
                long version = _eventCustomerQuestionAnswerRepository.GetLatestVersion(customerId, eventId);
                long disqualifiedVersion = _disqualifiedTestRepository.GetLatestVersion(customerId, eventId);
                using (var scope = new TransactionScope())
                {
                    var model = _eventCustomerQuestionAnswerFactory.GetEventCustomerQuestionAnswerListModel(questionAnsTestId, customerId, eventId, version, orgUserId);
                    _eventCustomerQuestionAnswerRepository.DeleteEventCustomerQuestionAnswers(customerId, eventId, orgUserId);
                    _eventCustomerQuestionAnswerRepository.SaveAnswer(model);

                    _disqualifiedTestRepository.DeleteDisqualifiedTests(customerId, eventId, orgUserId);
                    _dependentDisqualifiedTestRepository.DeleteDependentDisqualifiedTests(customerId, eventId, orgUserId);

                    if (!string.IsNullOrEmpty(disqualified))
                    {
                        var disqualifiedTests = disqualified.Split('|');

                        var disqualifiedTestIds = new List<long>();
                        foreach (var disqualifiedTest in disqualifiedTests)
                        {
                            var dtArray = disqualifiedTest.Split(',');
                            var disqualifiedTestId = Convert.ToInt64(dtArray[0]);
                            disqualifiedTestIds.Add(disqualifiedTestId);
                        }

                        var disqualifiedEventTests = _eventTestRepository.GetByEventAndTestIds(eventId, disqualifiedTestIds);
                        var disqualifiedTestTemplateIds = disqualifiedEventTests.Where(x => x.PreQualificationQuestionTemplateId.HasValue).Select(x => x.PreQualificationQuestionTemplateId.Value);
                        var dependentDisqualifiedTestIds = _preQualificationTemplateDependentTestRepository.GetByTemplateIds(disqualifiedTestTemplateIds.ToArray())
                            .Where(x => disqualifiedTestTemplateIds.Contains(x.TemplateId)).Select(x => x.TestId);

                        var disqualifiedModel = _eventCustomerQuestionAnswerFactory.GetDisqualifiedTestListModel(disqualified, customerId, eventId, disqualifiedVersion, orgUserId);
                        _disqualifiedTestRepository.SaveAnswer(disqualifiedModel);

                        if (!dependentDisqualifiedTestIds.IsNullOrEmpty())
                        {
                            var dependentDisqualifiedVersion = _dependentDisqualifiedTestRepository.GetLatestVersion(customerId, eventId);
                            var dependentDisqualifiedTests = _eventCustomerQuestionAnswerFactory.GetDependentDisqualifiedTestDomains(customerId, eventId, dependentDisqualifiedTestIds, dependentDisqualifiedVersion, orgUserId, eventCustomerId);
                            _dependentDisqualifiedTestRepository.Save(dependentDisqualifiedTests);
                        }
                        
                    }
                    scope.Complete();
                }
            }
        }

        public ListModelBase<DisqualifiedTestReportViewModel, DisqualifiedTestReportFilter> GetDisqualifiedTestReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var modelFilter = filter as DisqualifiedTestReportFilter;
            var disqualifiedTests = _disqualifiedTestRepository.GetByFilter(modelFilter, pageNumber, pageSize, out totalRecords);
            if (disqualifiedTests.IsNullOrEmpty()) return new DisqualifiedTestReportListModel { Collection = new List<DisqualifiedTestReportViewModel>() };

            var customerIds = disqualifiedTests.Select(x => x.CustomerId).Distinct().ToArray();
            var customers = _customerRepository.GetCustomersWoithoutLoginAndAddressDetails(customerIds);

            var eventIds = disqualifiedTests.Select(x => x.EventId).Distinct().ToArray();

            var pagedDisqualifiedTestList = _disqualifiedTestRepository.GetAllByEventIdCustomerId(customerIds, eventIds);

            var testIds = disqualifiedTests.Select(x => x.TestId).Distinct().ToArray();
            var tests = _testRepository.GetTestByIds(testIds);

            var tags = customers.Where(x => !string.IsNullOrEmpty(x.Tag)).Select(x => x.Tag).Distinct().ToArray();
            var tagHealthPlanNamePairs = _corporateAccountRepository.HealthPlanNamesCorrepondingToTag(tags);

            var questionIds = pagedDisqualifiedTestList.Select(x => x.QuestionId).ToArray();
            var questions = _preQualificationQuestionRepository.GetByQuestionIds(questionIds);

            var listModel = _eventCustomerQuestionAnswerFactory.Create(disqualifiedTests, customers, tests, tagHealthPlanNamePairs, questions, pagedDisqualifiedTestList);
            return listModel;
        }

        public IEnumerable<EventCustomerQuestionAnswerEditModel> GetEventCustomerQuestionAnswer(long customerId)
        {
            var questions = _preQualificationQuestionRepository.GetAllQuestions();
            var eventCustomerQuestionAnswer = _eventCustomerQuestionAnswerRepository.GetEventCustomerQuestionAnswer(customerId);
            return _eventCustomerQuestionAnswerFactory.GetEventCustomerQuestionAnswer(questions, eventCustomerQuestionAnswer);
        }

        public string GetQuestionAnswerTestIdString(long customerId, long eventId)
        {
            var eventCustomerQuestionAnswer = _eventCustomerQuestionAnswerRepository.GetEventCustomerQuestionAnswer(customerId);
            if (eventCustomerQuestionAnswer.IsNullOrEmpty()) return string.Empty;

            var questionIds = eventCustomerQuestionAnswer.Select(x => x.QuestionId).ToArray();
            var preQualificationQuestions = _preQualificationQuestionRepository.GetByQuestionIds(questionIds);

            var questionAnswerTestIdArray = new List<string>();
            foreach (var customerQuestionAnswer in eventCustomerQuestionAnswer)
            {
                var question = preQualificationQuestions.First(x => x.Id == customerQuestionAnswer.QuestionId);
                questionAnswerTestIdArray.Add(customerQuestionAnswer.QuestionId + "," + customerQuestionAnswer.Answer + "," + question.TestId);
            }

            return string.Join("|", questionAnswerTestIdArray);
        }

        public void UpdatePreQualifiedTestAnswers(long customerId, long eventId, long oldEventId, long orgUserId)
        {
            var isMammoEvent = _eventTestRepository.EventHasMammoTests(eventId);
            if (!isMammoEvent)
                return;

            long version = _eventCustomerQuestionAnswerRepository.GetLatestVersion(customerId, eventId);
            var disqualifiedVersion = _disqualifiedTestRepository.GetLatestVersion(customerId, oldEventId);

            var eventQuestionAnswer = _eventCustomerQuestionAnswerRepository.GetAllByCustomerIdEventId(customerId, oldEventId);
            var eventQuestionAnswerModel = _eventCustomerQuestionAnswerFactory.CreateEventCustomerQuestionAnswerListModel(eventQuestionAnswer, customerId, eventId, orgUserId, version);

            var disqualifiedQuestion = _disqualifiedTestRepository.GetAllByEventCustomerId(customerId, oldEventId, Convert.ToInt32(disqualifiedVersion));
            var disqualifiedQuestionModel = _eventCustomerQuestionAnswerFactory.CreateDisqualifiedTestListModel(disqualifiedQuestion, customerId, eventId, orgUserId, Convert.ToInt32(version));

            var dependentDisqualifiedTest = _dependentDisqualifiedTestRepository.GetAllByEventCustomerId(customerId, oldEventId, Convert.ToInt32(disqualifiedVersion));

            var eventIds = new long[] { oldEventId, eventId };

            using (var scope = new TransactionScope())
            {

                _eventCustomerQuestionAnswerRepository.DeleteEventCustomerQuestionAnswers(customerId, eventIds, orgUserId);

                _eventCustomerQuestionAnswerRepository.SaveAnswer(eventQuestionAnswerModel);

                _disqualifiedTestRepository.DeleteDisqualifiedTests(customerId, eventIds, orgUserId);

                _dependentDisqualifiedTestRepository.DeleteDependentDisqualifiedTests(customerId, eventIds, orgUserId);

                if (!disqualifiedQuestionModel.IsNullOrEmpty())
                {
                    var disqualifiedEventTests = _eventTestRepository.GetByEventAndTestIds(eventId, disqualifiedQuestion.Select(x => x.TestId).ToArray());

                    var disqualifiedTestTemplateIds = disqualifiedEventTests.Where(x => x.PreQualificationQuestionTemplateId.HasValue).Select(x => x.PreQualificationQuestionTemplateId.Value);

                    var dependentDisqualifiedTestIds = _preQualificationTemplateDependentTestRepository.GetByTemplateIds(disqualifiedTestTemplateIds.ToArray())
                        .Where(x => disqualifiedTestTemplateIds.Contains(x.TemplateId)).Select(x => x.TestId);

                    //var disqualifiedModel = _eventCustomerQuestionAnswerFactory.GetDisqualifiedTestListModel(disqualified, customerId, eventId, disqualifiedVersion, orgUserId);
                    _disqualifiedTestRepository.SaveAnswer(disqualifiedQuestionModel);

                    var dependentDisqualifiedTests = _eventCustomerQuestionAnswerFactory.GetDependentDisqualifiedTestDomains(customerId, eventId, dependentDisqualifiedTestIds, Convert.ToInt32(version), orgUserId, null);

                    _dependentDisqualifiedTestRepository.Save(dependentDisqualifiedTests);
                }
                scope.Complete();
            }

        }

    }
}
