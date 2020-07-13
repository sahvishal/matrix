using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class CustomerCheckListService : ICustomerCheckListService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventCustomerPreApprovedTestRepository _eventCustomerPreApprovedTestRepository;

        private readonly ICheckListQuestionRepository _checkListQuestionRepository;
        private readonly ICheckListAnswerRepository _checkListAnswerRepository;
        private readonly ICheckListQuestionAnswerEditModelFactory _checkListQuestionAnswerEditModelFactory;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICheckListTemplateRepository _checkListTemplateRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICheckListGroupRepository _checkListGroupRepository;
        private readonly IMedicareApiService _medicareApiService;
        private readonly ISettings _settings;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderController _orderController;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly ITestRepository _testRepository;
        private readonly IAccountNotReviewableTestRepository _accountNotReviewableTestRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly IEventPodRoomRepository _eventPodRoomRepository;

        private readonly ILogger _logger;

        private static readonly List<long> TestQuestionList = new List<long> { 11, 13, 17, 41, 47, 64, 77, 133, 151, 166, 183, 200, 281, 313, 324, 336, 344, 373, 397, 398, 406, 409, 418, 423, 441, 443, 448, 454, 475, 477, 479, 481, 485, 492, 505, 514, 515, 516, 537, 541, 561, 579, 590, 609, 622, 633, 640, 668 };
        public static long[] AbiGroup = { (long)TestType.FloChecABI, (long)TestType.AwvABI, (long)TestType.Lead };
        public static long[] DpnMonofilamentGroup = { (long)TestType.DPN, (long)TestType.Monofilament };

        public CustomerCheckListService(ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository, IEventCustomerPreApprovedTestRepository eventCustomerPreApprovedTestRepository,
            ICheckListQuestionRepository checkListQuestionRepository, ICheckListAnswerRepository checkListAnswerRepository, ICheckListQuestionAnswerEditModelFactory checkListQuestionAnswerEditModelFactory,
            IEventCustomerResultRepository eventCustomerResultRepository, ICheckListTemplateRepository checkListTemplateRepository, ICorporateAccountRepository corporateAccountRepository,
            ICheckListGroupRepository checkListGroupRepository, IMedicareApiService medicareApiService, ILogManager logManager, ISettings settings,
            IOrderRepository orderRepository, IOrderController orderController, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository,
            ITestRepository testRepository, IAccountNotReviewableTestRepository accountNotReviewableTestRepository, IEventRepository eventRepository, IEventPodRepository eventPodRepository, IEventPodRoomRepository eventPodRoomRepository)
        {
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventCustomerPreApprovedTestRepository = eventCustomerPreApprovedTestRepository;
            _checkListQuestionRepository = checkListQuestionRepository;
            _checkListAnswerRepository = checkListAnswerRepository;
            _checkListQuestionAnswerEditModelFactory = checkListQuestionAnswerEditModelFactory;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _checkListTemplateRepository = checkListTemplateRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _checkListGroupRepository = checkListGroupRepository;
            _medicareApiService = medicareApiService;
            _settings = settings;
            _orderRepository = orderRepository;
            _orderController = orderController;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _testRepository = testRepository;
            _accountNotReviewableTestRepository = accountNotReviewableTestRepository;
            _eventRepository = eventRepository;
            _eventPodRepository = eventPodRepository;
            _eventPodRoomRepository = eventPodRoomRepository;

            _logger = logManager.GetLogger<CustomerCheckListService>();
        }

        public CheckListFormEditModel GetCustomerCheckListEdtiModel(long customerId, long eventId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var account = _corporateAccountRepository.GetForEventIdWithOrganizationDetail(eventId);

            return GetCustomerCheckListEdtiModel(customer, account, eventCustomer);
        }

        public CheckListFormEditModel GetCustomerCheckListEdtiModel(Customer customer, CorporateAccount account, EventCustomer eventCustomer)
        {
            var preApporvedTestNames = _eventCustomerPreApprovedTestRepository.GetPreApprovedTestNameByEventCustomerId(eventCustomer.Id);
            var result = _eventCustomerResultRepository.GetById(eventCustomer.Id);

            var template = _checkListTemplateRepository.GetTemplateByEventId(eventCustomer.EventId);
            if (template == null && account.CheckListTemplateId.HasValue)
                template = _checkListTemplateRepository.GetById(account.CheckListTemplateId.Value);
            else if (template == null)
                template = _checkListTemplateRepository.GetDefaultTemplate();

            var templateGroup = _checkListGroupRepository.GetAllGroups();
            var checkListQuestion = _checkListQuestionRepository.GetAllQuestionsForTemplateId(template.Id);
            var checklistGroupQuestions = _checkListTemplateRepository.GetAllGroupQuestionsForTemplateId(template.Id);

            var version = _checkListAnswerRepository.GetLatestVersion(eventCustomer.Id);
            var answerList = new List<CheckListAnswer>();

            if (version > 0)
            {
                answerList = _checkListAnswerRepository.GetAllAnswerByEventCustomerId(eventCustomer.Id, version).ToList();
            }

            return new CheckListFormEditModel
            {
                CustomerId = customer.CustomerId,
                PreApporvedTestNames = preApporvedTestNames,
                EventId = eventCustomer.EventId,
                Name = customer.Name,
                DoB = customer.DateOfBirth,
                //HealthPlanName = (template.HealthPlanId.HasValue && account != null) ? account.Name : string.Empty,
                EventCustomerId = eventCustomer.Id,
                CheckListQuestion = _checkListQuestionAnswerEditModelFactory.CheckListQuestionAnswerEditModel(checkListQuestion, answerList, templateGroup, checklistGroupQuestions),
                IsEditable = result == null || result.ResultState < (long)TestResultStateNumber.PreAudit,
                Gender = customer.Gender
            };
        }

        private void UpdateCustomerOrder(long eventId, long customerId, IEnumerable<long> testIds, long orgUserId)
        {
            var order = _orderRepository.GetOrder(customerId, eventId);

            if (order != null && !order.OrderDetails.IsEmpty())
            {
                var orderDetail = _orderController.GetActiveOrderDetail(order);

                var eventTestOrderDetails = order.OrderDetails.Where(od => od.OrderItem.OrderItemType == OrderItemType.EventTestItem).Select(od => od).ToArray();

                var packageId = 0L;
                if (orderDetail.OrderItem.OrderItemType == OrderItemType.EventPackageItem)
                {
                    var eventPackage = _eventPackageRepository.GetById(orderDetail.OrderItem.ItemId);
                    packageId = eventPackage.PackageId;
                }

                var orderables = new List<IOrderable>();
                var selectedTestIds = testIds.ToList();



                if (packageId > 0)
                {
                    IEventPackageRepository eventPackageRepository = new EventPackageRepository();
                    var eventPackage = eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
                    orderables.Add(eventPackage);

                    RemoveTestsAlreadyInPackage(eventId, packageId, selectedTestIds);
                }

                if (!eventTestOrderDetails.IsNullOrEmpty())
                {
                    var eventTestIds = eventTestOrderDetails.Select(od => od.OrderItem.ItemId).ToArray();
                    var eventTestInOrder = _eventTestRepository.GetbyIds(eventTestIds);

                    var testAlreadyInOrders = eventTestInOrder.Select(et => et.TestId).ToArray();
                    selectedTestIds = selectedTestIds.Where(x => !testAlreadyInOrders.Contains(x)).ToList();

                    if (testAlreadyInOrders.Any(x => AbiGroup.Contains(x)))
                    {
                        selectedTestIds.RemoveAll(AbiGroup.Contains);
                    }

                    if (testAlreadyInOrders.Any(x => DpnMonofilamentGroup.Contains(x)))
                    {
                        selectedTestIds.RemoveAll(DpnMonofilamentGroup.Contains);
                    }

                    var activeEventTestOrderDetails = order.OrderDetails.Where(od => od.OrderItem.OrderItemType == OrderItemType.EventTestItem && od.IsCompleted).Select(od => od).ToArray();
                    if (!activeEventTestOrderDetails.IsNullOrEmpty())
                    {
                        var activEventTestIds = activeEventTestOrderDetails.Select(od => od.OrderItem.ItemId).ToArray();
                        var activeTestAlreadyInOrders = eventTestInOrder.Where(x => activEventTestIds.Contains(x.Id)).Select(et => et.TestId).ToArray();

                        selectedTestIds.AddRange(activeTestAlreadyInOrders);
                    }

                }

                if (!selectedTestIds.IsNullOrEmpty())
                {
                    var eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, selectedTestIds);
                    if (AddMissingTestToEvent(eventId, selectedTestIds, eventTests))
                    {
                        eventTests = _eventTestRepository.GetByEventAndTestIds(eventId, selectedTestIds);
                    }

                    if (packageId > 0)
                    {
                        foreach (var eventTest in eventTests)
                        {
                            eventTest.Price = eventTest.WithPackagePrice;
                        }
                    }

                    orderables.AddRange(eventTests);

                    bool indentedLineItemsAdded = false;

                    foreach (var orderable in orderables)
                    {
                        if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
                        {
                            _orderController.AddItem(orderable, 1, customerId, orgUserId, null, null, null, OrderStatusState.FinalSuccess, (long)OrderSource.Medicare);
                            indentedLineItemsAdded = true;
                        }
                        else
                            _orderController.AddItem(orderable, 1, customerId, orgUserId, OrderStatusState.FinalSuccess, (long)OrderSource.Medicare);
                    }

                    _orderController.PlaceOrder(order);
                }

            }
        }

        private void RemoveTestsAlreadyInPackage(long eventId, long packageId, List<long> selectedTestIds)
        {
            var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
            var package = eventPackage != null ? eventPackage.Package : null;

            if (package != null && !selectedTestIds.IsNullOrEmpty())
            {
                var packageTestIds = package.Tests.Select(t => t.Id);

                selectedTestIds.RemoveAll(packageTestIds.Contains);

                if (packageTestIds.Any(x => AbiGroup.Contains(x)))
                {
                    selectedTestIds.RemoveAll(AbiGroup.Contains);
                }

                if (packageTestIds.Any(x => DpnMonofilamentGroup.Contains(x)))
                {
                    selectedTestIds.RemoveAll(DpnMonofilamentGroup.Contains);
                }
            }
        }

        private IEnumerable<long> GetStandingOrderTest(IEnumerable<long> questionIds)
        {
            var selectedTestIds = new List<long>();

            foreach (var questionId in questionIds)
            {
                GetTestId(questionId, selectedTestIds);
            }

            return selectedTestIds;
        }

        private void GetTestId(long questionId, List<long> selectedTestIds)
        {
            switch (questionId)
            {
                case 11: selectedTestIds.Add((long)TestType.AwvHBA1C);
                    break;
                case 13: selectedTestIds.Add((long)TestType.DiabeticRetinopathy);
                    break;
                case 17:
                case 537:
                    selectedTestIds.Add((long)TestType.AwvLipid);
                    break;
                case 41: selectedTestIds.Add((long)TestType.UrineMicroalbumin);
                    break;
                case 47:
                case 454:
                case 418:
                case 541:
                    selectedTestIds.Add((long)TestType.IFOBT);
                    break;
                case 64: selectedTestIds.Add((long)TestType.AwvSpiro);
                    break;
                case 77:
                case 561:
                    selectedTestIds.Add((long)TestType.AwvEcho);
                    break;
                case 133:
                case 579:
                    selectedTestIds.Add((long)TestType.AwvEkg);
                    break;
                case 324: selectedTestIds.Add((long)TestType.Lead);
                    // selectedTestIds.Add((long)TestType.AwvABI);//need to check
                    break;
                case 151: //selectedTestIds.Add((long)TestType.AwvABI);
                // selectedTestIds.Add((long)TestType.FloChecABI);
                case 477:
                    selectedTestIds.Add((long)TestType.Lead);//need to check
                    break;
                case 166:
                case 609:
                    selectedTestIds.Add((long)TestType.AwvAAA);
                    break;
                case 183: selectedTestIds.Add((long)TestType.AwvAAA);
                    break;
                case 200: selectedTestIds.Add((long)TestType.AwvCarotid);
                    break;
                case 281: selectedTestIds.Add((long)TestType.AwvEcho);
                    break;
                case 313: selectedTestIds.Add((long)TestType.AwvEkg);
                    break;
                case 373: selectedTestIds.Add((long)TestType.AwvSpiro);
                    break;
                case 398: selectedTestIds.Add((long)TestType.AwvAAA);
                    break;
                case 406: selectedTestIds.Add((long)TestType.AwvAAA);
                    break;
                case 409: selectedTestIds.Add((long)TestType.Monofilament);
                    break;
                case 423:
                case 633:
                    selectedTestIds.Add((long)TestType.DPN);
                    // selectedTestIds.Add((long)TestType.Monofilament);//need to check
                    break;
                case 441: selectedTestIds.Add((long)TestType.AwvSpiro);
                    break;
                case 443: selectedTestIds.Add((long)TestType.AwvEcho);
                    break;
                case 448: selectedTestIds.Add((long)TestType.AAA);
                    break;
                case 475: selectedTestIds.Add((long)TestType.AwvEkg);
                    break;
                case 479: selectedTestIds.Add((long)TestType.AwvAAA);
                    break;
                case 481: selectedTestIds.Add((long)TestType.FluShot);
                    break;
                case 485:
                case 492:
                case 622:
                    selectedTestIds.Add((long)TestType.AwvBoneMass);
                    break;
                case 505:
                case 640:
                    selectedTestIds.Add((long)TestType.Mammogram);
                    break;
                case 514:
                case 515:
                case 516: selectedTestIds.Add((long)TestType.DiabeticRetinopathy);
                    break;
                case 590:
                    selectedTestIds.Add((long)TestType.QuantaFloABI);
                    selectedTestIds.Add((long)TestType.Lead);
                    break;
                case 668:
                    selectedTestIds.Add((long)TestType.QuantaFloABI);
                    break;
            }
        }

        private bool AddMissingTestToEvent(long eventId, IEnumerable<long> testIds, IEnumerable<EventTest> eventtests)
        {
            var existingtestIds = eventtests.Select(x => x.TestId).ToList();
            var toBeAddedTests = testIds.Where(testId => !existingtestIds.Contains(testId)).ToList();

            if (toBeAddedTests.Any())
            {
                var missingTest = _testRepository.GetTestByIds(toBeAddedTests);
                var account = _corporateAccountRepository.GetbyEventId(eventId);
                var testNotReviewableIds = new List<long>();

                if (account != null)
                {
                    var testNotReviewable = _accountNotReviewableTestRepository.GetByAccountId(account.Id);
                    if (!testNotReviewable.IsNullOrEmpty())
                        testNotReviewableIds.AddRange(testNotReviewable.Select(x => x.TestId));
                }

                foreach (var test in missingTest)
                {
                    var isTestNotReviewable = testNotReviewableIds.Any(x => x == test.Id);
                    _eventTestRepository.Save(new EventTest
                    {
                        TestId = test.Id,
                        EventId = eventId,
                        WithPackagePrice = 0,
                        Price = 0,
                        RefundPrice = 0,
                        ReimbursementRate = 0,
                        ShowInAlaCarte = true,
                        Gender = (long)Gender.Unspecified,
                        GroupId = (long)TestGroupType.None,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsTestReviewableByPhysician = isTestNotReviewable ? (bool?)true : null
                    });
                }

                var theEvent = _eventRepository.GetById(eventId);

                if (theEvent.IsDynamicScheduling)
                {
                    var podRoomTests = _eventPodRoomRepository.GetEventPodRoomTestsByEventId(eventId);
                    var eventPodRooms = podRoomTests.Select(x => x.EventPodRoomId).Distinct();

                    foreach (var eventPodRoom in eventPodRooms)
                    {
                        var testAlreadInRoom = podRoomTests.Where(x => x.EventPodRoomId == eventPodRoom).Select(x => x.TestId);
                        if (!testAlreadInRoom.IsNullOrEmpty())
                            toBeAddedTests.AddRange(testAlreadInRoom);

                        toBeAddedTests = toBeAddedTests.Distinct().ToList();

                        _eventPodRoomRepository.SaveEventPodRoomTests(toBeAddedTests, eventPodRoom);
                    }
                }

                return true;
            }

            return false;
        }

        public void SaveCheckListAnswer(CheckListAnswerEditModel model, long orgUserId, long userLoginLogId, string token)
        {
            if (model.Answers.IsNullOrEmpty()) return;

            var eventCustomer = ((IUniqueItemRepository<EventCustomer>)_eventCustomerRepository).GetById(model.EventCustomerId);

            var lastestVersion = model.Version;
            if (model.Version == 0)
                lastestVersion = _checkListAnswerRepository.GetLatestVersion(model.EventCustomerId);
            if (model.Answers.IsNullOrEmpty()) return;
            var checklistAnswer = new List<CheckListAnswer>();

            foreach (var answer in model.Answers)
            {
                checklistAnswer.Add(new CheckListAnswer
                {
                    Answer = answer.Answer,
                    QuestionId = answer.QuestionId,
                    Version = lastestVersion + 1,
                    Id = model.EventCustomerId,
                    IsActive = true,
                    DataRecorderMetaData = new DataRecorderMetaData(orgUserId, DateTime.Now, null),
                    Type=(long)CheckListType.CheckList
                });
            }

            _checkListAnswerRepository.SaveAnswer(checklistAnswer);

            try
            {
                var result = _eventCustomerResultRepository.GetById(model.EventCustomerId);

                if (token != "" && (result == null || result.ResultState < (long)TestResultStateNumber.PreAudit))
                {
                    var questionIds = model.Answers.Where(x => TestQuestionList.Contains(x.QuestionId)).Select(x => x.QuestionId);

                    if (!questionIds.IsNullOrEmpty())
                    {
                        var testIdsToBeUpdated = GetStandingOrderTest(questionIds);
                        if (!testIdsToBeUpdated.IsNullOrEmpty())
                        {
                            UpdateCustomerOrder(eventCustomer.EventId, eventCustomer.CustomerId, testIdsToBeUpdated, orgUserId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Some Error Occurred While Customer Updating Order. Exception Message {0} \t\n Stack Trace: {1}", ex.Message, ex.StackTrace));
            }
            
            if (_settings.SyncWithHra)
            {
                if (token != "")
                {
                    try
                    {
                        var visitId = _eventCustomerRepository.GetById(model.EventCustomerId).AwvVisitId;
                        if (visitId.HasValue)
                        {
                            var answers = new MedicareStandingOrderViewModel
                            {
                                PatientVisitId = visitId.Value,
                                Version = lastestVersion + 1,
                                IsSync = true,
                                Questions = model.Answers.Select(answer => new MedicareCheckListQuestionViewModel
                                {
                                    Answer = answer.Answer,
                                    QuestionId = answer.QuestionId
                                }).ToList()
                            };
                            try
                            {
                                _medicareApiService.Connect(userLoginLogId);
                            }
                            catch (Exception)
                            {
                                var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = _settings.OrganizationNameForHraQuestioner, Tag = _settings.OrganizationNameForHraQuestioner, IsForAdmin = false, RoleAlias = "CallCenterRep" };
                                _medicareApiService.PostAnonymous<string>(_settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                                _medicareApiService.Connect(userLoginLogId);
                            }

                            _medicareApiService.Post<bool>(MedicareApiUrl.SaveCheckList, answers);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Some Error Occured Whicle Saving Checklist Answer To MEDICARE\n Exception Message {0} \t\n Stack Trace: {1}", ex.Message, ex.StackTrace));
                    }
                }
            }
            else
            {
                _logger.Info("Syncing with HRA is off ");
            }
            

        }

    }
}
