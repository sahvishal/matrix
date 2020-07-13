using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;
using Falcon.App.Core.CallQueues.Domain;

namespace API.Areas.CallCenter.Controllers
{
    public class HealthPlanContactCustomerController : BaseController
    {
        private readonly ITagRepository _tagRepository;
        private readonly IOutboundCallQueueService _outboundCallQueueService;
        private readonly ICustomerCallQueueCallAttemptService _customerCallQueueCallAttemptService;
        private readonly ICallCenterRepository _callCenterRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ISessionContext _sessionContext;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICustomerAccountGlocomNumberService _accountCheckoutPhoneNumberService;
        private readonly ICallQueueCustomerCallRepository _callQueueCustomerCallRepository;
        private readonly ICustomerAccountGlocomNumberRepository _customerAccountGlocomNumberRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IPreQualificationTestTemplateRepository _preQualificationTestTemplateRepository;
        private readonly IPreQualifiedQuestionTemplateService _preQualifiedQuestionTemplateService;
        private readonly IEventCustomerQuestionAnswerService _eventCustomerQuestionAnswerService;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        public HealthPlanContactCustomerController(ITagRepository tagRepository, IOutboundCallQueueService outboundCallQueueService, ICustomerCallQueueCallAttemptService customerCallQueueCallAttemptService, ICallCenterRepository callCenterRepository,
                    IProspectCustomerRepository prospectCustomerRepository, ISessionContext sessionContext, ICallQueueCustomerRepository callQueueCustomerRepository, ICustomerAccountGlocomNumberService accountCheckoutPhoneNumberService,
                    ICallQueueCustomerCallRepository callQueueCustomerCallRepository, ICustomerAccountGlocomNumberRepository customerAccountGlocomNumberRepository, ICallCenterCallRepository callCenterCallRepository,
                    IPreApprovedTestRepository preApprovedTestRepository, IEventTestRepository eventTestRepository, IPreQualificationTestTemplateRepository preQualificationTestTemplateRepository,
                    IPreQualifiedQuestionTemplateService preQualifiedQuestionTemplateService, IEventCustomerQuestionAnswerService eventCustomerQuestionAnswerService, ILogManager logManager,ICustomerRepository customerRepository)
        {
            _tagRepository = tagRepository;
            _customerCallQueueCallAttemptService = customerCallQueueCallAttemptService;
            _callCenterRepository = callCenterRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _sessionContext = sessionContext;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _outboundCallQueueService = outboundCallQueueService;
            _accountCheckoutPhoneNumberService = accountCheckoutPhoneNumberService;
            _callQueueCustomerCallRepository = callQueueCustomerCallRepository;
            _customerAccountGlocomNumberRepository = customerAccountGlocomNumberRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _eventTestRepository = eventTestRepository;
            _preQualificationTestTemplateRepository = preQualificationTestTemplateRepository;
            _preQualifiedQuestionTemplateService = preQualifiedQuestionTemplateService;
            _eventCustomerQuestionAnswerService = eventCustomerQuestionAnswerService;
            _customerRepository = customerRepository;
            _logger = logManager.GetLogger("HealthPlanContactCustomerController");
        }

        [HttpGet]
        public IEnumerable<Tag> GetCallDispositionTags()
        {
            var lookups = _tagRepository.GetTags(ProspectCustomerSource.CallCenter, true);
            return lookups;
        }

        [HttpGet]
        public CallQueueCustomerNotesViewModel GetNotes(long callId, long callQueueCustomerId)
        {
            return _outboundCallQueueService.GetCustomerNotes(callId, callQueueCustomerId);
        }

        [HttpGet]
        public bool SetReadAndUnderstoodNotes(long callAttemptId)
        {
            _customerCallQueueCallAttemptService.SetReadAndUnderstoodNotes(callAttemptId);
            return true;
        }

        private bool UpdateContactedInfo(long prospectCustomerId, long callId)
        {
            _callCenterRepository.BindCallToProspectCustomerForCallQueue(callId, prospectCustomerId);
            return _prospectCustomerRepository.UpdateContactedStatus(prospectCustomerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpGet]
        public long StartCallAndUpdateCallAttemptTable(long callQueueCustomerId, long callAttemptId, string calledGlocomNumber, string patientPhoneNumber, string callQueueCategory)
        {

            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(callQueueCustomer.CustomerId.Value);

            var oldCustomerGlocomNumber = _customerAccountGlocomNumberRepository.GetByCustomerIdAndGlocomNumber(callQueueCustomer.CustomerId.Value, calledGlocomNumber.Replace("-", ""));

            var incomingPhoneLine = calledGlocomNumber.Replace("-", "");
            var callersPhoneNumber = patientPhoneNumber.Replace("-", "");
            var customer = _customerRepository.GetCustomer((long)callQueueCustomer.CustomerId);

            using (var scope = new TransactionScope())
            {
                var organizationRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                var callStatus = CallType.Existing_Customer.ToString().Replace("_", " ");

                var eventId = callQueueCustomer.EventId.HasValue && callQueueCustomer.EventCustomerId.HasValue ? callQueueCustomer.EventId.Value : 0;
                
                var callId = _outboundCallQueueService.SetCallDetail(organizationRoleUserId, callQueueCustomer.CustomerId.Value, incomingPhoneLine, callersPhoneNumber, callStatus, callQueueCustomer.CampaignId, callQueueCustomer.HealthPlanId, null,
                    callQueueCustomer.CallQueueId, eventId: eventId, callQueueCategory: callQueueCategory, ProductTypeId: customer.ProductTypeId);

                UpdateContactedInfo(prospectCustomer.Id, callId);

                _customerCallQueueCallAttemptService.SetCallIdCallAttempt(callAttemptId, callId);

                var callQueueCustomerCallModel = new CallQueueCustomerCall();
                callQueueCustomerCallModel.CallId = callId;
                callQueueCustomerCallModel.CallQueueCustomerId = callQueueCustomerId;
                _callQueueCustomerCallRepository.Save(callQueueCustomerCallModel);

                var customerAccountGlocomNumber = new CustomerAccountGlocomNumber
                {
                    CallId = callId,
                    CustomerId = callQueueCustomer.CustomerId.Value,
                    GlocomNumber = calledGlocomNumber,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                var editmodel = new CallQueueCustomerCallDetailsEditModel
                {
                    CallQueueCustomerId = callQueueCustomerId,
                    Disposition = string.Empty,
                    CallStatusId = (long)CallStatus.Initiated,
                    IsCallSkipped = false,
                    ModifiedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                    Attempt = 0,
                    CallQueueStatus = (long)CallQueueStatus.Initial,
                    CallDate = DateTime.Today.AddDays(30),
                    CallQueueId = callQueueCustomer.CallQueueId
                };

                _callQueueCustomerRepository.UpdateCallqueueCustomerByCustomerId(editmodel, callQueueCustomer.CustomerId.Value);

                if (oldCustomerGlocomNumber != null)
                {
                    oldCustomerGlocomNumber.IsActive = false;
                    _customerAccountGlocomNumberRepository.Update(oldCustomerGlocomNumber);
                }

                _accountCheckoutPhoneNumberService.SaveAccountCheckoutPhoneNumber(customerAccountGlocomNumber);
                scope.Complete();
                return callId;
            }
        }

        [HttpGet]
        public bool UpdateCallersPhoneNumber(long callId, string patientPhoneNumber)
        {
            return _callCenterCallRepository.UpdateCallersPhoneNumber(callId, patientPhoneNumber.Replace("-", ""));
        }

        [HttpGet]
        [AllowAnonymous]
        public string GetPreQualificationTemplateIds(long customerId, long eventId)
        {
            var eventTests = _eventTestRepository.GetEventTestsByEventIds(new[] { eventId });
            var preQualificationTemplateIds = eventTests.Where(x => x.PreQualificationQuestionTemplateId.HasValue).Select(x => x.PreQualificationQuestionTemplateId.Value).ToArray();

            var preQualificationTestTemplates = _preQualificationTestTemplateRepository.GetByIds(preQualificationTemplateIds);

            var selectedTemplateIds = new List<long>(); //preQualificationTestTemplates.Select(x => x.TestId).ToArray();
            foreach (var preQualificationTestTemplate in preQualificationTestTemplates)
            {
                if (CheckPreApprovedTest(customerId, new[] { preQualificationTestTemplate.TestId }))
                {
                    selectedTemplateIds.Add(preQualificationTestTemplate.Id);
                }
            }

            return string.Join(",", selectedTemplateIds);
        }

        private bool CheckPreApprovedTest(long customerId, IEnumerable<long> testIdsToCheck)
        {
            return _preApprovedTestRepository.CheckPreApprovedTestForCustomer(customerId, testIdsToCheck);
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<PreQualificationTemplateQuestionListModel> GetPreQualificationQuestion(long customerId, string templateIds)
        {
            if (string.IsNullOrWhiteSpace(templateIds)) return null;
            var templateIdsArray = new List<long>();
            foreach (var templateIdString in templateIds.Split(','))
            {
                if (!string.IsNullOrWhiteSpace(templateIdString))
                {
                    var templateId = Convert.ToInt64(templateIdString);
                    templateIdsArray.Add(templateId);
                }
            }

            var list = _preQualifiedQuestionTemplateService.GetPreQualificationQuestionsbyTemplateIds(templateIdsArray);

            var answers = _eventCustomerQuestionAnswerService.GetEventCustomerQuestionAnswer(customerId);

            var preQualificationTemplateList = new List<PreQualificationTemplateQuestionListModel>();
            foreach (var preQualificationQuestionViewModel in list)
            {
                var model = new PreQualificationTemplateQuestionListModel
                {
                    TestId = preQualificationQuestionViewModel.TestId,
                    TemplateId = preQualificationQuestionViewModel.TemplateId,
                    TestName = preQualificationQuestionViewModel.TestName,
                    DependencyRule = preQualificationQuestionViewModel.QuestionRule.Select(x =>
                        new PreQualificationQuestionRuleViewModel
                        {
                            DependencyValue = x.DependencyValue,
                            DependentQuestionId = x.DependentQuestionId,
                            QuestionId = x.QuestionId
                        }).ToList(),
                    Questions = preQualificationQuestionViewModel.Questions.Select(x =>
                    new QuestionViewModel
                    {
                        Id = x.Id,
                        TestId = x.TestId,
                        Question = x.Question,
                        Options = x.ControlValues.Split(!string.IsNullOrWhiteSpace(x.ControlValueDelimiter) ? x.ControlValueDelimiter[0] : ','),
                        Answer = answers.Any(a => a.QuestionId == x.Id) ? answers.First(a => a.QuestionId == x.Id).Answer : "",
                        ParentId = x.ParentId,
                        TypeId = x.TypeId,
                    }).ToList()
                };

                preQualificationTemplateList.Add(model);
            }

            return preQualificationTemplateList;
        }

        [HttpPost]
        [AllowAnonymous]
        public bool SavePreQualificationAnswers(EventCustomerQuestionAnswerPostModel model)
        {
            try
            {
                _eventCustomerQuestionAnswerService.SavePreQualifiedTestAnswers(model.QuestionAnswerTestIds, model.DisqualifiedTests, null, model.CustomerId, model.EventId,
                _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(" Exception at SavePreQualificationAnswers");
                _logger.Error("exception Message: " + ex.Message);
                _logger.Error("exception Stack Trace: " + ex.StackTrace);
                return false;
            }
        }
    }
}
