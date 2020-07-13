using System;
using System.IO;
using System.Linq;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using File = Falcon.App.Core.Application.Domain.File;
using System.Collections.Generic;
using AutoMapper;
using Falcon.App.Core.Geo;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class CorporateAccountService : ICorporateAccountService
    {
        private readonly IOrganizationService _organizationService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHostService _hostService;

        private readonly IPackageRepository _packageRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IAccountPackageRepository _accountPackageRepository;
        private readonly IAccountPackageFactory _accountPackageFactory;
        private readonly IRegistrationConfigFactory _registrationConfigFactory;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;

        private readonly ITestRepository _testRepository;
        private readonly IAccountTestRepository _accountTestRepository;
        private readonly IAccountTestFactory _accountTestFactory;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IAccountNotReviewableTestRepository _accountNotReviewableTestRepository;
        private readonly IAccountNotReviewableTestFactory _accountNotReviewableTestFactory;
        private readonly IAccountAdditionalFieldRepository _accountAdditionalFieldRepository;
        private readonly IHcpcsCodeRepository _hcpcsCodeRepository;
        private readonly ITestHcpcsCodeRepository _testHcpcsCodeRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;

        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICorporateAccountCustomerFactory _corporateAccountCustomerFactory;
        private readonly IEventRepository _eventRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IPodRepository _podRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IAccountCheckoutPhoneNumberRepository _accountCheckoutPhoneNumberRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IAccountCheckoutPhoneNumberFactory _accountCheckoutPhoneNumberFactory;
        private readonly IAccountCallQueueSettingRepository _accountCallQueueSettingRepository;
        private readonly IAccountCallQueueSettingFactory _accountCallQueueSettingFactory;
        private readonly ISettings _settings;
        private readonly IAccountCallCenterOrganizationService _accountCallCenterOrganizationService;
        private readonly IAccountCallCenterOrganizationRepository _accountCallCenterOrganizationRepository;
        private readonly IAccountHraChatQuestionnaireHistoryServices _accountHraChatQuestionnaireHistoryServices;
        private readonly IAccountHraChatQuestionnaireRepository _accountHraChatQuestionnaireRepository;


        public CorporateAccountService(IOrganizationService organizationService, ICorporateAccountRepository corporateAccountRepository, IHostService hostService,
            IPackageRepository packageRepository, IShippingOptionRepository shippingOptionRepository, IUniqueItemRepository<File> fileRepository,
            ICustomerRepository customerRepository, IMediaRepository mediaRepository, IAccountPackageRepository accountPackageRepository, IAccountPackageFactory accountPackageFactory,
            IRegistrationConfigFactory registrationConfigFactory, IConfigurationSettingRepository configurationSettingRepository, ITestRepository testRepository,
            IAccountTestRepository accountTestRepository, IAccountTestFactory accountTestFactory, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository,
            ICallQueueRepository callQueueRepository, IAccountNotReviewableTestRepository accountNotReviewableTestRepository, IAccountNotReviewableTestFactory accountNotReviewableTestFactory,
            IAccountAdditionalFieldRepository accountAdditionalFieldRepository, IHcpcsCodeRepository hcpcsCodeRepository, ITestHcpcsCodeRepository testHcpcsCodeRepository,
            IEventCustomerRepository eventCustomerRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository,
            IEventCustomerResultRepository eventCustomerResultRepository, ICorporateAccountCustomerFactory corporateAccountCustomerFactory,
            IEventRepository eventRepository, IShippingDetailRepository shippingDetailRepository, IPodRepository podRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
            IHealthAssessmentRepository healthAssessmentRepository, ILanguageRepository languageRepository, IEventCustomerNotificationRepository eventCustomerNotificationRepository,
            IHospitalPartnerRepository hospitalPartnerRepository, IHostRepository hostRepository, IAccountCheckoutPhoneNumberRepository accountCheckoutPhoneNumberRepository,
            IStateRepository stateRepository, IAccountCheckoutPhoneNumberFactory accountCheckoutPhoneNumberFactory, IAccountCallQueueSettingRepository accountCallQueueSettingRepository,
            IAccountCallQueueSettingFactory accountCallQueueSettingFactory, ISettings settings, IAccountCallCenterOrganizationService accountCallCenterOrganizationService,
            IAccountCallCenterOrganizationRepository accountCallCenterOrganizationRepository, IAccountHraChatQuestionnaireHistoryServices accountHraChatQuestionnaireHistoryServices, IAccountHraChatQuestionnaireRepository accountHraChatQuestionnaireHistoryRepository)
        {
            _organizationService = organizationService;
            _corporateAccountRepository = corporateAccountRepository;
            _hostService = hostService;
            _packageRepository = packageRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _fileRepository = fileRepository;
            _customerRepository = customerRepository;
            _mediaRepository = mediaRepository;
            _accountPackageRepository = accountPackageRepository;
            _accountPackageFactory = accountPackageFactory;
            _registrationConfigFactory = registrationConfigFactory;
            _configurationSettingRepository = configurationSettingRepository;
            _accountTestRepository = accountTestRepository;
            _testRepository = testRepository;
            _accountTestFactory = accountTestFactory;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _callQueueRepository = callQueueRepository;
            _accountNotReviewableTestRepository = accountNotReviewableTestRepository;
            _accountNotReviewableTestFactory = accountNotReviewableTestFactory;
            _accountAdditionalFieldRepository = accountAdditionalFieldRepository;
            _hcpcsCodeRepository = hcpcsCodeRepository;
            _testHcpcsCodeRepository = testHcpcsCodeRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;

            _eventCustomerResultRepository = eventCustomerResultRepository;
            _corporateAccountCustomerFactory = corporateAccountCustomerFactory;
            _eventRepository = eventRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _podRepository = podRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _languageRepository = languageRepository;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _hostRepository = hostRepository;
            _accountCheckoutPhoneNumberRepository = accountCheckoutPhoneNumberRepository;
            _stateRepository = stateRepository;
            _accountCheckoutPhoneNumberFactory = accountCheckoutPhoneNumberFactory;
            _accountCallQueueSettingRepository = accountCallQueueSettingRepository;
            _accountCallQueueSettingFactory = accountCallQueueSettingFactory;
            _settings = settings;
            _accountCallCenterOrganizationService = accountCallCenterOrganizationService;
            _accountCallCenterOrganizationRepository = accountCallCenterOrganizationRepository;
            _accountHraChatQuestionnaireHistoryServices = accountHraChatQuestionnaireHistoryServices;
            _accountHraChatQuestionnaireRepository = accountHraChatQuestionnaireHistoryRepository;
        }

        public CorporateAccountBasicInfoEditModel GetBasicInfoEditModel(long id)
        {
            var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(id);
            var organizationEditmodel = _organizationService.GetOrganizationCreateModel(id);

            var model = new CorporateAccountBasicInfoEditModel
            {
                OrganizationEditModel = organizationEditmodel,
                ContractNotes = account.ContractNotes,
                Content = account.Content,
                CorpCode = account.AccountCode,

            };

            if (account.ConvertedHostId.HasValue && account.ConvertedHostId.Value > 0)
            {
                model.ConvertedHostId = account.ConvertedHostId;
                model.CreateHost = true;
            }

            return model;
        }
        public CorporateAccountBasicInfoEditModel SaveAccountInfo(CorporateAccountBasicInfoEditModel model)
        {
            OrganizationEditModel existingOrganizationEditModel = null;
            if (model.OrganizationEditModel.Id > 0)
                existingOrganizationEditModel = _organizationService.GetOrganizationCreateModel(model.OrganizationEditModel.Id);


            CorporateAccount account = null;
            model.OrganizationEditModel.OrganizationType = OrganizationType.CooperateAccount;
            if (existingOrganizationEditModel != null)
            {
                model.OrganizationEditModel.LogoImage = existingOrganizationEditModel.LogoImage;
            }
            var accountId = _organizationService.Create(model.OrganizationEditModel);

            var shippingOptionIds = _corporateAccountRepository.GetAccountShippingOptionIds(accountId);
            var customerResultTestDependency = _corporateAccountRepository.GetAccountCustomerResultTestDependency(accountId);
            var pcpResultTestDependency = _corporateAccountRepository.GetAccountPcpResultTestDependency(accountId);
            var healthPlanResultTestDependency = _corporateAccountRepository.GetAccountHealthPlanResultTestDependency(accountId);

            model.OrganizationEditModel.Id = accountId;
            if (!model.IsNew)
                account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(accountId);

            account = CreateCorporateAccountDomain(model, account);
            if (model.IsNew)
                account.Id = accountId;
            _corporateAccountRepository.SaveAccount(account, shippingOptionIds, customerResultTestDependency, pcpResultTestDependency, healthPlanResultTestDependency);

            if (model.CreateHost)
            {
                var hostId = _hostService.CreateHostFromBasicInfo(model);

                if (model.OrganizationEditModel.Id > 0)
                    model.ConvertedHostId = hostId;
                _corporateAccountRepository.UpdateConvertedHost(accountId, hostId);
            }
            else if (!model.CreateHost && model.ConvertedHostId.HasValue && model.ConvertedHostId.Value > 0)
            {
                _corporateAccountRepository.UpdateConvertedHost(accountId, null);
                _hostService.DeleteHost(model.ConvertedHostId.Value);
            }

            return model;
        }

        private CorporateAccount CreateCorporateAccountDomain(CorporateAccountBasicInfoEditModel model, CorporateAccount inpersistence)
        {
            inpersistence = inpersistence ?? new CorporateAccount();

            inpersistence.AccountCode = model.CorpCode;
            inpersistence.ContractNotes = model.ContractNotes;
            inpersistence.Content = model.Content;

            return inpersistence;
        }

        public RegistrationConfigEditModel GetRegistrationConfig(long id)
        {
            var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(id);
            var accountPackages = _accountPackageRepository.GetByAccountId(id);
            var accountTests = _accountTestRepository.GetByAccountId(id);
            var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AskPreQualificationQuestion);
            var askPreQualificationQuestion = value.ToLower() == bool.TrueString.ToLower();
            var organizationEditmodel = _organizationService.GetOrganizationCreateModel(id);
            var logo = organizationEditmodel.LogoImage;
            var accountNotReviewableTests = _accountNotReviewableTestRepository.GetByAccountId(id);
            var tests = _testRepository.GetAll();
            var accountCheckoutPhoneNumbers = _accountCheckoutPhoneNumberRepository.GetByAccountId(id);
            var accountCallQueueSettings = _accountCallQueueSettingRepository.GetByAccountId(id);
            var registrationModel = _registrationConfigFactory.CreateModel(account);

            registrationModel.LogoImageId = logo != null ? logo.Id : 0;
            registrationModel.LogoImagePath = logo != null ? logo.Path : string.Empty;
            registrationModel.OrganizationName = organizationEditmodel.Name;
            registrationModel.LogoImage = GetFileModelFromFile(logo, _mediaRepository.GetOrganizationLogoImageFolderLocation());
            registrationModel.IsCustomerTagInUse = !string.IsNullOrEmpty(account.Tag) && _customerRepository.IsCustomerTagInUse(account.Tag);
            registrationModel.ShowAskPreQualificationQuestionSetting = askPreQualificationQuestion;
            registrationModel.AskPreQualificationQuestion = askPreQualificationQuestion && account.AskPreQualificationQuestion;
            registrationModel.AttachGiftCard = account.AttachGiftCard;
            registrationModel.GiftCardAmount = account.GiftCardAmount;

            if (!accountCheckoutPhoneNumbers.IsNullOrEmpty())
            {
                var states = _stateRepository.GetAllStates();

                registrationModel.AccountCheckoutPhoneNumbers = _accountCheckoutPhoneNumberFactory.CreateModel(states, accountCheckoutPhoneNumbers);
            }

            if (!accountCallQueueSettings.IsNullOrEmpty())
            {
                var callQueues = _callQueueRepository.GetByIds(accountCallQueueSettings.Select(x => x.CallQueueId).Distinct(), false, true);
                registrationModel.AccountCallQueueSettings = _accountCallQueueSettingFactory.CreateModel(accountCallQueueSettings, callQueues);
            }
            else
            {
                registrationModel.AccountCallQueueSettings = GetDefaultAccountCallQueueSettings(id);
            }

            if (registrationModel.CaptureSurvey)
            {
                File surveyPdf = null;
                if (account.SurveyPdfFileId > 0)
                    surveyPdf = _fileRepository.GetById(account.SurveyPdfFileId);

                registrationModel.SurveyPdf = GetFileModelFromFile(surveyPdf, _mediaRepository.GetCorporateSurveyPdfFolderLocation());
            }
            else
            {
                registrationModel.SurveyPdf = new FileModel();
            }

            if (registrationModel.ShowCallCenterScript)
            {
                File callCenterPdf = null;
                File confirmationPdf = null;

                //File inboundCallScriptPdf = null;

                if (account.CallCenterScriptFileId > 0)
                    callCenterPdf = _fileRepository.GetById(account.CallCenterScriptFileId);

                registrationModel.CallCenterScriptPdf = GetFileModelFromFile(callCenterPdf, _mediaRepository.GetCallCenterScriptPdfFolderLocation());

                if (account.ConfirmationScriptFileId > 0)
                    confirmationPdf = _fileRepository.GetById(account.ConfirmationScriptFileId);

                registrationModel.ConfirmationScriptPdf = GetFileModelFromFile(confirmationPdf, _mediaRepository.GetCallCenterScriptPdfFolderLocation());

                /*if (account.InboundCallScriptFileId > 0)
                    inboundCallScriptPdf = _fileRepository.GetById(account.InboundCallScriptFileId);

                registrationModel.InboundCallScriptPdf = GetFileModelFromFile(inboundCallScriptPdf, _mediaRepository.GetCallCenterScriptPdfFolderLocation());*/


            }
            else
            {
                registrationModel.CallCenterScriptPdf = new FileModel();
                registrationModel.ConfirmationScriptPdf = new FileModel();
                //registrationModel.InboundCallScriptPdf = new FileModel();
            }

            if (registrationModel.PrintCheckList)
            {
                File checkListPdf = null;
                if (account.CheckListFileId > 0)
                    checkListPdf = _fileRepository.GetById(account.CheckListFileId);

                registrationModel.CheckListPdf = GetFileModelFromFile(checkListPdf, _mediaRepository.GetCorporateCheckListPdfFolderLocation());
            }
            else
            {
                registrationModel.CheckListPdf = new FileModel();
            }

            var packages = _packageRepository.GetAll();
            registrationModel.OrganizationPackageList = packages.Select(x => new OrganizationPackageViewModel { Gender = ((Gender)x.Gender), Id = x.Id, Name = x.Name }).ToList();

            if (accountPackages != null && accountPackages.Any())
            {
                var activePackageIds = packages.Select(p => p.Id);
                var deactivatedPackageIds = accountPackages.Where(ap => !activePackageIds.Contains(ap.PackageId)).Select(ap => ap.PackageId);
                accountPackages = accountPackages.Where(ap => !deactivatedPackageIds.Contains(ap.PackageId));
                registrationModel.DefaultPackages = _accountPackageFactory.CreateModel(packages, accountPackages);

                if (deactivatedPackageIds.Any())
                {
                    var deactivatedPackages = _packageRepository.GetByIds(deactivatedPackageIds).Select(p => p.Name).ToArray();
                    registrationModel.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage(string.Format("Package(s) {0} attached with the account has been deactived. If you save then it will be removed.", string.Join(",", deactivatedPackages)));
                }
            }

            registrationModel.ShippingOptions = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess();
            registrationModel.ShippingOptionIds = _corporateAccountRepository.GetAccountShippingOptionIds(id);
            registrationModel.OrganizationTestList = tests.Select(x => new OrganizationTestViewModel { Gender = ((Gender)x.Gender), Id = x.Id, Name = x.Name }).ToList();

            if (accountTests != null && accountTests.Any())
            {
                var activeTestIds = tests.Select(p => p.Id);
                var deactivatedTestIds = accountTests.Where(ap => !activeTestIds.Contains(ap.TestId)).Select(ap => ap.TestId);

                accountTests = accountTests.Where(ap => !deactivatedTestIds.Contains(ap.TestId));
                registrationModel.DefaultTests = _accountTestFactory.CreateModel(tests, accountTests);

                if (deactivatedTestIds.Any())
                {
                    var deactivatedTests = ((IUniqueItemRepository<Test>)_testRepository).GetByIds(deactivatedTestIds).Select(p => p.Name).ToArray();
                    registrationModel.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage(string.Format("Test(s) {0} attached with the account has been deactivated. If you save then it will be removed.", string.Join(",", deactivatedTests)));
                }
            }

            var reviewableTests = _testRepository.GetReviewableTests();
            registrationModel.TestReviewableByPhysicianMasterList = reviewableTests.Select(x => new OrganizationTestViewModel { Gender = ((Gender)x.Gender), Id = x.Id, Name = x.Name });
            registrationModel.AccountAdditionalFields = _accountAdditionalFieldRepository.GetAccountAdditionalFieldsEditModelByAccountId(id);

            if (accountNotReviewableTests != null && accountNotReviewableTests.Any())
            {
                var accountNotReviewableTestsTemp = accountNotReviewableTests;
                var reviewableTestIds = reviewableTests.Select(p => p.Id);
                var notReviewableTestIds = accountNotReviewableTests.Where(ap => !reviewableTestIds.Contains(ap.TestId)).Select(ap => ap.TestId);

                accountNotReviewableTests = accountNotReviewableTests.Where(ap => !notReviewableTestIds.Contains(ap.TestId));
                registrationModel.TestNotReviewableByPhysician = _accountNotReviewableTestFactory.CreateModel(tests, accountNotReviewableTests);

                var activeTestIds = tests.Select(p => p.Id);
                var deactivatedTestIds = accountNotReviewableTestsTemp.Where(ap => !activeTestIds.Contains(ap.TestId)).Select(ap => ap.TestId);
                var deactivatedMessage = string.Empty;
                var notReviewableMessage = string.Empty;

                if (deactivatedTestIds.Any())
                {
                    notReviewableTestIds = notReviewableTestIds.Where(x => !deactivatedTestIds.Contains(x));
                    var deactivatedTests = ((IUniqueItemRepository<Test>)_testRepository).GetByIds(deactivatedTestIds).Select(p => p.Name).ToArray();
                    deactivatedMessage = string.Format(" Test(s) {0} attached with the account has been deactivated. If you save then it will be removed.", string.Join(",", deactivatedTests));
                }

                if (notReviewableTestIds.Any())
                {
                    var notReviewableTests = ((IUniqueItemRepository<Test>)_testRepository).GetByIds(notReviewableTestIds).Select(p => p.Name).ToArray();
                    notReviewableMessage = string.Format(" Test(s) {0} attached with the account has been marked not reviewable. If you save then it will be removed.", string.Join(",", notReviewableTests));
                }

                if (!string.IsNullOrEmpty(deactivatedMessage) && !string.IsNullOrEmpty(notReviewableMessage))
                {
                    var sb = new StringBuilder();
                    sb.Append("<ul><li>");
                    sb.Append(deactivatedMessage);
                    sb.Append("</li><li>");
                    sb.Append(notReviewableMessage);
                    sb.Append("</li></ul>");
                    registrationModel.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage(sb.ToString());
                }
                else if (!string.IsNullOrEmpty(notReviewableMessage))
                {
                    registrationModel.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage(notReviewableMessage);
                }
                else if (!string.IsNullOrEmpty(deactivatedMessage))
                    registrationModel.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage(deactivatedMessage);

            }

            var accountCallCenterOrganization = _accountCallCenterOrganizationRepository.GetByAccountId(id);
            if (!accountCallCenterOrganization.IsNullOrEmpty())
            {
                registrationModel.AccountCallCenterOrganization = _accountCallCenterOrganizationService.GetEditModel(accountCallCenterOrganization);
            }

            var questionnaireTypes = _accountHraChatQuestionnaireHistoryServices.GetByAccountId(account.Id);

            if (questionnaireTypes.IsNullOrEmpty() || questionnaireTypes.Any(x => !x.EndDate.HasValue && x.QuestionnaireType == (long)QuestionnaireType.None))
            {
                registrationModel.QuestionnaireType = QuestionnaireType.None;
                registrationModel.CurrentQuestionnaireType = QuestionnaireType.None;
                registrationModel.IsShowHraQuestionnaire = true;
            }
            else
            {
                var questionnaireType = questionnaireTypes.OrderByDescending(x => x.CreatedOn).First();

                registrationModel.QuestionnaireType = (QuestionnaireType)questionnaireType.QuestionnaireType;
                registrationModel.CurrentQuestionnaireType = (QuestionnaireType)questionnaireType.QuestionnaireType;
                registrationModel.ChatStartDate = (questionnaireType.QuestionnaireType == (long)QuestionnaireType.ChatQuestionnaire) ? (DateTime?)questionnaireType.StartDate : null;
                registrationModel.HasChatStartDate = registrationModel.ChatStartDate.HasValue;

            }

            var disableHralink = questionnaireTypes.IsNullOrEmpty() ? false : questionnaireTypes.Any(x => x.QuestionnaireType == (long)QuestionnaireType.ChatQuestionnaire);
            registrationModel.IsShowHraQuestionnaire = !disableHralink;
            return registrationModel;
        }

        private FileModel GetFileModelFromFile(File file, MediaLocation location)
        {
            return file == null ? new FileModel() : new FileModel
            {
                Id = file.Id,
                Caption = Path.GetFileNameWithoutExtension(file.Path),
                FileName = file.Path,
                FileSize = file.FileSize,
                FileType = (long)file.Type,
                PhisicalPath = file.Path,
                UploadedBy = file.UploadedBy.Id,
                Url = location.Url
            };
        }

        private File GetFileFromFileModel(FileModel model, MediaLocation location, FileType mediaType)
        {
            model.Caption = model.Caption.Replace("+", "_").Replace(" ", "_");
            var fileLocation = location.PhysicalPath + model.Caption + "_" + DateTime.Now.ToFileTimeUtc() + Path.GetExtension(model.FileName);
            var file = new File
            {
                Id = model.Id,
                FileSize = model.FileSize,
                Path = model.IsTemporaryLocated ? model.Caption + "_" + DateTime.Now.ToFileTimeUtc() + Path.GetExtension(model.FileName) : model.PhisicalPath,
                Type = mediaType,
                UploadedOn = DateTime.Now,
                UploadedBy = new OrganizationRoleUser(model.UploadedBy)
            };

            if (model.IsTemporaryLocated)
            {
                DirectoryOperationsHelper.Copy(model.FolderPath + model.FileName, fileLocation);
            }

            return file;
        }

        private File GetPgpPbulicFile(FileModel model, MediaLocation location, FileType mediaType, CorporateAccount account)
        {
            var fileName = account.Id + "_" + model.Caption + "_" + DateTime.Now.ToFileTimeUtc() + Path.GetExtension(model.FileName);
            var fileLocation = location.PhysicalPath + fileName;
            var file = new File
            {
                Id = model.Id,
                FileSize = model.FileSize,
                Path = model.IsTemporaryLocated ? fileName : model.PhisicalPath,
                Type = mediaType,
                UploadedOn = DateTime.Now,
                UploadedBy = new OrganizationRoleUser(model.UploadedBy)
            };

            if (model.IsTemporaryLocated)
            {
                DirectoryOperationsHelper.Copy(model.FolderPath + model.FileName, fileLocation);
            }

            return file;
        }

        public void SaveAccountRegistrationInfo(RegistrationConfigEditModel model, long orgRoleId)
        {
            var accountId = model.AccountId;
            var organization = _organizationService.GetOrganizationCreateModel(accountId);
            var customerResultTestDependency = _corporateAccountRepository.GetAccountCustomerResultTestDependency(accountId);
            var pcpResultTestDependency = _corporateAccountRepository.GetAccountPcpResultTestDependency(accountId);
            var healthPlanResultTestDependency = _corporateAccountRepository.GetAccountHealthPlanResultTestDependency(accountId);

            var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AskPreQualificationQuestion);
            var askPreQualificationQuestion = value.ToLower() == bool.TrueString.ToLower();

            var logoImageFolder = _mediaRepository.GetOrganizationLogoImageFolderLocation();
            organization.LogoImage = model.LogoImage != null && !string.IsNullOrEmpty(model.LogoImage.Caption) ? GetFileFromFileModel(model.LogoImage, logoImageFolder, FileType.Image) : null;

            _organizationService.Create(organization);

            var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(accountId);

            var isHealthPlan = account.IsHealthPlan;

            account = _registrationConfigFactory.CreateDomain(account, model);

            if (!model.IsHealthPlan && isHealthPlan)
            {
                _healthPlanCallQueueCriteriaRepository.MarkForDeleteByHealthPlanId(model.AccountId);
            }

            if (model.IsHealthPlan && !isHealthPlan)
            {
                CreateCriteriaForHealthPlan(model.AccountId, orgRoleId, HealthPlanCallQueueCategory.LanguageBarrier);
                CreateCriteriaForHealthPlan(model.AccountId, orgRoleId, HealthPlanCallQueueCategory.AppointmentConfirmation, model.OrganizationName + " Confirmation");
            }

            account.AskPreQualificationQuestion = askPreQualificationQuestion && model.AskPreQualificationQuestion;
            if (model.SurveyPdf != null && !string.IsNullOrEmpty(model.SurveyPdf.Caption))
            {
                if (model.SurveyPdf.Id <= 0)
                {
                    var surveyPdf = _fileRepository.Save(GetFileFromFileModel(model.SurveyPdf, _mediaRepository.GetCorporateSurveyPdfFolderLocation(), FileType.Pdf));
                    model.SurveyPdf.Id = surveyPdf.Id;
                }
                account.SurveyPdfFileId = model.SurveyPdf.Id;
            }
            else
            {
                account.SurveyPdfFileId = 0;
            }

            if (model.ShowCallCenterScript && model.CallCenterScriptPdf != null && !string.IsNullOrEmpty(model.CallCenterScriptPdf.Caption))
            {
                if (model.CallCenterScriptPdf.Id <= 0)
                {
                    var callCenterPdf = _fileRepository.Save(GetFileFromFileModel(model.CallCenterScriptPdf, _mediaRepository.GetCallCenterScriptPdfFolderLocation(), FileType.Pdf));
                    model.CallCenterScriptPdf.Id = callCenterPdf.Id;
                }
                account.CallCenterScriptFileId = model.CallCenterScriptPdf.Id;
            }
            else
            {
                account.CallCenterScriptFileId = 0;
            }

            if (model.ShowCallCenterScript && model.ConfirmationScriptPdf != null && !string.IsNullOrEmpty(model.ConfirmationScriptPdf.Caption))
            {
                if (model.ConfirmationScriptPdf.Id <= 0)
                {
                    var confirmationPdf = _fileRepository.Save(GetFileFromFileModel(model.ConfirmationScriptPdf, _mediaRepository.GetCallCenterScriptPdfFolderLocation(), FileType.Pdf));
                    model.ConfirmationScriptPdf.Id = confirmationPdf.Id;
                }
                account.ConfirmationScriptFileId = model.ConfirmationScriptPdf.Id;
            }
            else
            {
                account.ConfirmationScriptFileId = 0;
            }

            /*if (model.ShowCallCenterScript && model.InboundCallScriptPdf != null && !string.IsNullOrEmpty(model.InboundCallScriptPdf.Caption))
            {
                if (model.InboundCallScriptPdf.Id <= 0)
                {
                    var inboundCallScriptPdf = _fileRepository.Save(GetFileFromFileModel(model.InboundCallScriptPdf, _mediaRepository.GetCallCenterScriptPdfFolderLocation(), FileType.Pdf));
                    model.InboundCallScriptPdf.Id = inboundCallScriptPdf.Id;
                }
                account.InboundCallScriptFileId = model.InboundCallScriptPdf.Id;
            }
            else
            {
                account.InboundCallScriptFileId = 0;
            }*/



            if (model.PrintCheckList && model.CheckListPdf != null && !string.IsNullOrEmpty(model.CheckListPdf.Caption))
            {
                if (model.CheckListPdf.Id <= 0)
                {
                    var checkListPdf = _fileRepository.Save(GetFileFromFileModel(model.CheckListPdf, _mediaRepository.GetCorporateCheckListPdfFolderLocation(), FileType.Pdf));
                    model.CheckListPdf.Id = checkListPdf.Id;
                }
                account.CheckListFileId = model.CheckListPdf.Id;
            }
            else
            {
                account.CheckListFileId = 0;
            }

            var accountPackages = _accountPackageFactory.CreateDomain(model.DefaultPackages, model.AccountId);
            _accountPackageRepository.Save(accountPackages, accountId);

            var accountTests = _accountTestFactory.CreateDomain(model.DefaultTests, model.AccountId);
            _accountTestRepository.Save(accountTests, accountId);

            var testNotReviewable = _accountNotReviewableTestFactory.CreateDomain(model.TestNotReviewableByPhysician, model.AccountId);
            _accountNotReviewableTestRepository.Save(testNotReviewable, accountId);

            account.AccountAdditionalFields = model.IsAdditionalField ? GetAccountAdditionalField(model.AccountAdditionalFields) : null;
            _corporateAccountRepository.SaveAccountAddtionalFieldDependency(model.AccountId, account.AccountAdditionalFields);

            _corporateAccountRepository.SaveAccount(account, model.ShippingOptionIds, customerResultTestDependency, pcpResultTestDependency, healthPlanResultTestDependency);

            var previousQuestionnaireType = _accountHraChatQuestionnaireRepository.GetByAccountId(account.Id).OrderByDescending(q => q.CreatedOn).FirstOrDefault();

            model.QuestionnaireType = account.IsHealthPlan ? model.QuestionnaireType : QuestionnaireType.None;

            if ((!account.IsHealthPlan && previousQuestionnaireType != null && previousQuestionnaireType.QuestionnaireType != (long)QuestionnaireType.None) || (account.IsHealthPlan && (previousQuestionnaireType == null || (previousQuestionnaireType.EndDate.HasValue) || model.QuestionnaireType != (QuestionnaireType)previousQuestionnaireType.QuestionnaireType)))
            {

                var domain = new AccountHraChatQuestionnaire
                 {
                     AccountId = accountId,
                     QuestionnaireType = (long)model.QuestionnaireType,
                     StartDate = model.ChatStartDate ?? DateTime.Today.AddDays(1),
                     CreatedBy = orgRoleId,
                     CreatedOn = DateTime.Now
                 };

                _accountHraChatQuestionnaireRepository.Save(domain);
            }

            var accountCheckoutPhoneNumbers = _accountCheckoutPhoneNumberFactory.CreateDomain(model.AccountCheckoutPhoneNumbers, model.AccountId);

            _accountCheckoutPhoneNumberRepository.Save(accountCheckoutPhoneNumbers, model.AccountId);

            var accountCallQueueSetting = _accountCallQueueSettingFactory.CreateDomain(model.AccountCallQueueSettings, model.AccountId);

            _accountCallQueueSettingRepository.Save(accountCallQueueSetting, model.AccountId, model.IsHealthPlan);

            _accountCallCenterOrganizationService.Save(model.AccountCallCenterOrganization, model.AccountId, orgRoleId, model.RestrictHealthPlanData);
        }

        private IEnumerable<AccountAdditionalFields> GetAccountAdditionalField(IEnumerable<AccountAdditionalFieldsEditModel> accountAddtionalModel)
        {

            return Mapper.Map<IEnumerable<AccountAdditionalFieldsEditModel>, IEnumerable<AccountAdditionalFields>>(accountAddtionalModel);

        }

        public ResultConfigEditModel GetResultConfigEditModel(long id)
        {
            var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(id);
            var customerResultTestDependency = _corporateAccountRepository.GetAccountCustomerResultTestDependency(account.Id);
            var pcpResultTestDependency = _corporateAccountRepository.GetAccountPcpResultTestDependency(account.Id);
            var healthPlanResultTestDependency = _corporateAccountRepository.GetAccountHealthPlanResultTestDependency(account.Id);

            var model = new ResultConfigEditModel
            {
                AccountId = account.Id,
                AllowCobranding = account.AllowCobranding,
                AllowCustomerPortalLogin = account.AllowCustomerPortalLogin,
                CorporateWhiteLabeling = account.CorporateWhiteLabeling,
                GeneratePcpLetterWithDiagnosisCode = account.GeneratePcpLetterWithDiagnosisCode,
                ResultReadyMailTemplateId = account.ResultReadyMailTemplateId,
                SendResultReadyMail = account.SendResultReadyMail,
                SendSurveyMail = account.SendSurveyMail,
                ShowBasicBiometricPage = account.ShowBasicBiometricPage,
                SurveyMailTemplateId = account.SurveyMailTemplateId,
                SendResultReadyMailWithFax = account.SendResultReadyMailWithFax,
                CapturePcpConsent = account.CapturePcpConsent,
                CaptureAbnStatus = account.CaptureAbnStatus,
                GeneratePcpResult = account.GeneratePcpResult,
                GenerateCustomerResult = account.GenerateCustomerResult,
                IsCustomerResultsTestDependent = account.IsCustomerResultsTestDependent,
                CustomerResultTestDependency = (customerResultTestDependency != null && customerResultTestDependency.Any()) ? customerResultTestDependency.ToArray() : null,
                PcpResultTestDependency = (pcpResultTestDependency != null && pcpResultTestDependency.Any()) ? pcpResultTestDependency.ToArray() : null,
                HealthPlanResultTestDependency = (healthPlanResultTestDependency != null && healthPlanResultTestDependency.Any()) ? healthPlanResultTestDependency.ToArray() : null,
                RemoveLongDescription = account.RemoveLongDescription,

                GeneratePcpLetter = account.GeneratePcpLetter,
                AddImagesForAbnormal = account.AddImagesForAbnormal,
                UseHeaderImage = account.UseHeaderImage,
                AttachScannedDoc = account.AttachScannedDoc,
                ResultFormatTypeId = account.ResultFormatTypeId,
                AttachUnreadableTest = account.AttachUnreadableTest,
                AttachEawvPreventionPlan = account.AttachEawvPreventionPlan,
                GenerateEawvPreventionPlanReport = account.GenerateEawvPreventionPlanReport,
                GenerateBmiReport = account.GenerateBmiReport,
                EnablePgpEncryption = account.EnablePgpEncryption,
                GenerateHealthPlanReport = account.GenerateHealthPlanReport,
                AttachAttestationForm = account.AttachAttestationForm,
                SendEventResultReadyNotification = account.SendEventResultReadyNotification,
                PrintPcpAppointmentForResult = account.PrintPcpAppointmentForResult,
                MarkPennedBack = account.MarkPennedBack,
                PennedBackText = account.PennedBackText,
                PcpCoverLetterTemplateId = account.PcpCoverLetterTemplateId.HasValue ? account.PcpCoverLetterTemplateId.Value : -1,
                MemberCoverLetterTemplateId = account.MemberCoverLetterTemplateId.HasValue ? account.MemberCoverLetterTemplateId.Value : -1,
                IsPcpCoverLetterSelected = account.GeneratePcpLetter && account.PcpCoverLetterTemplateId.HasValue && account.PcpCoverLetterTemplateId > 0,
                IsMemberCoverLetterSelected = account.IncludeMemberLetter && account.MemberCoverLetterTemplateId.HasValue && account.MemberCoverLetterTemplateId > 0,
            };

            File fluffLetter = null;
            if (account.FluffLetterFileId > 0)
                fluffLetter = _fileRepository.GetById(account.FluffLetterFileId);

            model.FluffLetter = GetFileModelFromFile(fluffLetter, _mediaRepository.GetCorporateFluffLetterFolderLocation());

            File pcpPdf = null;
            if (account.PcpLetterPdfFileId > 0)
                pcpPdf = _fileRepository.GetById(account.PcpLetterPdfFileId);

            model.PcpLetterPdf = GetFileModelFromFile(pcpPdf, _mediaRepository.GetCorporatePcpLetterPdfFolderLocation());

            File pgpPublicKey = null;

            if (account.EnablePgpEncryption && account.PublicKeyFileId > 0)
            {
                pgpPublicKey = _fileRepository.GetById(account.PublicKeyFileId);
            }
            model.PublicKeyFile = GetFileModelFromFile(pgpPublicKey, _mediaRepository.GetPublicKeyFolderLocation());

            //Participant Letter
            File participantLetter = null;
            if (account.ParticipantLetterId > 0)
                participantLetter = _fileRepository.GetById(account.ParticipantLetterId);

            model.ParticipantLetter = GetFileModelFromFile(participantLetter, _mediaRepository.GetCorporateParticipantLetterFolderLocation());

            //Member Letter
            File memberLetter = null;
            model.IncludeMemberLetter = account.IncludeMemberLetter;
            if (account.MemberLetterFileId > 0)
                memberLetter = _fileRepository.GetById(account.MemberLetterFileId);

            model.MemberLetter = GetFileModelFromFile(memberLetter, _mediaRepository.GetCorporateMemberLetterPdfFolderLocation());

            return model;
        }

        public void SaveAccountResultConfig(ResultConfigEditModel model)
        {
            var accountId = model.AccountId;

            var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(accountId);
            var shippingOptionIds = _corporateAccountRepository.GetAccountShippingOptionIds(accountId);

            account.AllowCobranding = model.AllowCobranding;
            account.AllowCustomerPortalLogin = model.AllowCustomerPortalLogin;
            account.CorporateWhiteLabeling = model.CorporateWhiteLabeling;

            account.GeneratePcpLetterWithDiagnosisCode = model.GeneratePcpLetterWithDiagnosisCode;
            account.ShowBasicBiometricPage = model.ShowBasicBiometricPage;

            account.SendResultReadyMail = model.SendResultReadyMail;
            account.ResultReadyMailTemplateId = model.ResultReadyMailTemplateId;
            account.SendSurveyMail = model.SendSurveyMail;
            account.SurveyMailTemplateId = model.SurveyMailTemplateId;
            account.SendResultReadyMailWithFax = model.SendResultReadyMailWithFax;

            account.CaptureAbnStatus = model.CaptureAbnStatus;
            account.CapturePcpConsent = model.CapturePcpConsent;

            account.IsCustomerResultsTestDependent = model.IsCustomerResultsTestDependent;
            account.GenerateCustomerResult = model.GenerateCustomerResult;
            account.GeneratePcpResult = model.GeneratePcpResult;
            account.RemoveLongDescription = model.RemoveLongDescription;

            account.ResultFormatTypeId = model.ResultFormatTypeId;
            account.AttachUnreadableTest = model.AttachUnreadableTest;
            account.GenerateBmiReport = model.GenerateBmiReport;
            account.EnablePgpEncryption = model.EnablePgpEncryption;
            account.GenerateHealthPlanReport = model.GenerateHealthPlanReport;
            account.AttachAttestationForm = model.AttachAttestationForm;
            account.SendEventResultReadyNotification = model.SendEventResultReadyNotification;
            account.PrintPcpAppointmentForResult = model.PrintPcpAppointmentForResult;
            account.MarkPennedBack = model.MarkPennedBack;
            account.PennedBackText = model.PennedBackText;

            if (model.FluffLetter != null && !string.IsNullOrEmpty(model.FluffLetter.Caption))
            {
                if (model.FluffLetter.Id <= 0)
                {
                    var fluffLetter = _fileRepository.Save(GetFileFromFileModel(model.FluffLetter, _mediaRepository.GetCorporateFluffLetterFolderLocation(), FileType.Document));
                    model.FluffLetter.Id = fluffLetter.Id;
                }

                account.FluffLetterFileId = model.FluffLetter.Id;
            }
            else
            {
                account.FluffLetterFileId = 0;
            }

            account.GeneratePcpLetter = model.GeneratePcpLetter;
            if (model.GeneratePcpLetter && !model.IsPcpCoverLetterSelected && model.PcpLetterPdf != null && !string.IsNullOrEmpty(model.PcpLetterPdf.Caption))
            {
                if (model.PcpLetterPdf.Id <= 0)
                {
                    var pcpLetter = _fileRepository.Save(GetFileFromFileModel(model.PcpLetterPdf, _mediaRepository.GetCorporatePcpLetterPdfFolderLocation(), FileType.Document));
                    model.PcpLetterPdf.Id = pcpLetter.Id;
                }

                account.PcpLetterPdfFileId = model.PcpLetterPdf.Id;
            }
            else
            {
                account.PcpLetterPdfFileId = 0;
            }

            if (model.GeneratePcpLetter && model.IsPcpCoverLetterSelected && model.PcpCoverLetterTemplateId > 0)
                account.PcpCoverLetterTemplateId = model.PcpCoverLetterTemplateId;
            else
                account.PcpCoverLetterTemplateId = null;

            if (model.PublicKeyFile != null && !string.IsNullOrEmpty(model.PublicKeyFile.Caption))
            {
                if (model.PublicKeyFile.Id <= 0)
                {
                    var publicKeyFile = _fileRepository.Save(GetPgpPbulicFile(model.PublicKeyFile, _mediaRepository.GetPublicKeyFolderLocation(), FileType.Document, account));
                    model.PublicKeyFile.Id = publicKeyFile.Id;
                }

                account.PublicKeyFileId = model.PublicKeyFile.Id;
            }
            else
            {
                account.PublicKeyFileId = 0;
            }

            if (model.ParticipantLetter != null && !string.IsNullOrEmpty(model.ParticipantLetter.Caption) && model.GenerateCustomerResult)
            {
                if (model.ParticipantLetter.Id <= 0)
                {
                    var participantLetter = _fileRepository.Save(GetPgpPbulicFile(model.ParticipantLetter, _mediaRepository.GetCorporateParticipantLetterFolderLocation(), FileType.Pdf, account));
                    model.ParticipantLetter.Id = participantLetter.Id;
                }

                account.ParticipantLetterId = model.ParticipantLetter.Id;
            }
            else
            {
                account.ParticipantLetterId = 0;
            }

            account.AddImagesForAbnormal = model.AddImagesForAbnormal;
            account.UseHeaderImage = model.UseHeaderImage;
            account.AttachScannedDoc = model.AttachScannedDoc;

            account.AttachEawvPreventionPlan = model.AttachEawvPreventionPlan;
            account.GenerateEawvPreventionPlanReport = model.GenerateEawvPreventionPlanReport;

            account.IncludeMemberLetter = model.IncludeMemberLetter;
            if (model.IncludeMemberLetter && !model.IsMemberCoverLetterSelected && model.MemberLetter != null && !string.IsNullOrEmpty(model.MemberLetter.Caption))
            {
                if (model.MemberLetter.Id <= 0)
                {
                    var memberLetterFile = _fileRepository.Save(GetFileFromFileModel(model.MemberLetter, _mediaRepository.GetCorporateMemberLetterPdfFolderLocation(), FileType.Pdf));
                    model.MemberLetter.Id = memberLetterFile.Id;
                }
                account.MemberLetterFileId = model.MemberLetter.Id;
            }
            else
            {
                account.MemberLetterFileId = 0;
            }

            if (model.IncludeMemberLetter && model.IsMemberCoverLetterSelected && model.MemberCoverLetterTemplateId > 0)
                account.MemberCoverLetterTemplateId = model.MemberCoverLetterTemplateId;
            else
                account.MemberCoverLetterTemplateId = null;

            _corporateAccountRepository.SaveAccount(account, shippingOptionIds, model.CustomerResultTestDependency, model.PcpResultTestDependency, model.HealthPlanResultTestDependency);
        }

        public bool CheckCanChangeClinicalTemplate(long accountId)
        {
            return _corporateAccountRepository.CheckCanChangeClinicalTemplate(accountId);
        }

        private void CreateCriteriaForHealthPlan(long healthPlanId, long orgRoleId, string category, string criteriaName = "")
        {
            var criteria = _healthPlanCallQueueCriteriaRepository.GetCriteriaByHealthPlanCallQueue(healthPlanId, category);

            if (criteria.IsNullOrEmpty())
            {
                var callqueue = _callQueueRepository.GetCallQueueByCategory(category);

                var callQueueCriteria = new HealthPlanCallQueueCriteria
                {
                    CallQueueId = callqueue.Id,
                    DataRecorderMetaData = new DataRecorderMetaData(orgRoleId, DateTime.Now, null),
                    HealthPlanId = healthPlanId,
                    IsDefault = false,
                    IsDeleted = false,
                    IsQueueGenerated = false,
                    CriteriaName = criteriaName
                };

                _healthPlanCallQueueCriteriaRepository.Save(callQueueCriteria);
            }
        }

        public void BindDefaultRegistrationData(RegistrationConfigEditModel model)
        {
            model.OrganizationPackageList = _packageRepository.GetAll()
                    .Select(x => new OrganizationPackageViewModel { Gender = ((Gender)x.Gender), Id = x.Id, Name = x.Name })
                    .OrderBy(x => x.Name)
                    .ToList();
            model.ShippingOptions = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess();
            model.ShippingOptionIds = _corporateAccountRepository.GetAccountShippingOptionIds(model.AccountId);
            model.OrganizationTestList = _testRepository.GetAll().Select(CreateOrganizationTestViewModeModel).OrderBy(x => x.Name).ToList();
            if (model.DefaultPackages != null && model.DefaultPackages.Any())
            {
                var defaultpackages = model.DefaultPackages;
                model.DefaultPackages = _packageRepository.GetByIds(model.DefaultPackages.Select(x => x.PackageId))
                    .Select(x => new OrganizationPackageEditModel
                    {
                        Gender = ((Gender)x.Gender),
                        PackageId = x.Id,
                        PackageName = x.Name,
                        IsRecommended = defaultpackages.First(p => p.PackageId == x.Id).IsRecommended
                    });
            }

            if (model.DefaultTests != null && model.DefaultTests.Any())
            {
                var testIds = model.DefaultTests.Select(x => x.TestId);
                model.DefaultTests = _testRepository.GetAll()
                        .Where(t => testIds.Contains(t.Id))
                        .Select(x => new OrganizationTestEditModel { Gender = ((Gender)x.Gender), TestId = x.Id, TestName = x.Name });
            }

            var reviewableTests = _testRepository.GetReviewableTests();

            model.TestReviewableByPhysicianMasterList = reviewableTests.Select(CreateOrganizationTestViewModeModel);

            if (model.TestNotReviewableByPhysician != null && model.TestNotReviewableByPhysician.Any())
            {
                var testIds = model.TestNotReviewableByPhysician.Select(x => x.Id);
                model.TestNotReviewableByPhysician = reviewableTests.Where(t => testIds.Contains(t.Id)).Select(CreateOrganizationTestViewModeModel);
            }
            var account = GetRegistrationConfig(model.AccountId);
            if (account != null)
                model.CurrentQuestionnaireType = account.CurrentQuestionnaireType;
        }

        public TestCptSelectionViewModel GetCptTestMappingModel(long id)
        {
            var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(id);
            var model = new TestCptSelectionViewModel();
            var tests = new List<OrderedPair<string, long>>();
            var alltest = _testRepository.GetAll();
            tests.Add(new OrderedPair<string, long>("--Select--", -1));
            alltest.ForEach(x => tests.Add(new OrderedPair<string, long>(x.Name, x.Id)));
            model.Tests = new List<OrderedPair<string, long>>();
            model.Tests = model.Tests.Concat(tests);

            var hcpcsCodes = _hcpcsCodeRepository.GetAll();
            var mappings = _testHcpcsCodeRepository.GetAll();


            model.Id = account.Id;
            model.Name = account.Name;
            var testMappings = (from p in mappings
                                group p by p.TestId
                                    into grp
                                    select new { TestId = grp.Key, Hcpcs = grp.ToArray() }).ToArray();
            model.ExistingMappings = new List<TestHcpcsViewModel>();
            foreach (var testHcpcsCode in testMappings)
            {
                var test = alltest.First(x => x.Id == testHcpcsCode.TestId);

                var map = new TestHcpcsViewModel
                {
                    TestId = test.Id,
                    TestName = test.Name
                };
                map.HcpcsList = new List<HcpcsViewModel>();
                foreach (var hcpcsCode in testHcpcsCode.Hcpcs)
                {
                    var hcp = hcpcsCodes.First(x => x.Id == hcpcsCode.HcpcsCodeId);
                    map.HcpcsList.Add(new HcpcsViewModel { Id = hcp.Id, Code = hcp.Code, Description = hcp.Description });
                }


                model.ExistingMappings.Add(map);
            }


            model.HcpcsViewModels = new List<HcpcsViewModel>();
            hcpcsCodes.ForEach(x => model.HcpcsViewModels.Add(new HcpcsViewModel() { Id = x.Id, Code = x.Code, Description = x.Description }));

            return model;
        }

        private OrganizationTestViewModel CreateOrganizationTestViewModeModel(Test test)
        {
            return new OrganizationTestViewModel { Gender = ((Gender)test.Gender), Id = test.Id, Name = test.Name };
        }

        public ListModelBase<CorporateAccountCustomerViewModel, CorporateAccountCustomerListModelFilter> GetMemberResultSummary(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var customerFilter = filter as CorporateAccountCustomerListModelFilter;
            var eventCustomers = _eventCustomerRepository.GetEventCustomersForMemberResultSummary(pageNumber, pageSize, customerFilter, out totalRecords);

            var model = eventCustomers.IsNullOrEmpty() ? new CorporateAccountCustomerListModel() : GetCustomers(eventCustomers);

            var eventData = _eventRepository.GetById(customerFilter.EventId);
            var host = _hostRepository.GetHostForEvent(customerFilter.EventId);
            var eventIds = new[] { eventData.Id };
            var totalCustomers = _eventRepository.GetTotalRegistration(eventIds);
            var screenedCustomers = _eventRepository.GetAttendedCustomers(eventIds);
            var noShowCustomers = _eventRepository.GetNoShowCustomers(eventIds);
            var cancelledCustomers = _eventRepository.GetCancelledCustomers(eventIds);

            model.EventId = eventData.Id;
            model.EventDate = eventData.EventDate;
            model.HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
            model.TotalCustomers = totalCustomers.First().SecondValue;
            model.ScreenedCustomers = screenedCustomers.First().SecondValue;
            model.NoShowCustomers = noShowCustomers.First().SecondValue;
            model.CancelledCustomers = cancelledCustomers.First().SecondValue;

            return model;
        }

        private CorporateAccountCustomerListModel GetCustomers(IEnumerable<EventCustomer> eventCustomers)
        {
            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();
            var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());
            var pods = _podRepository.GetPodsForEvents(eventIds);

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds, true);
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orders.Select(o => o.Id).ToList());
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orders.Select(o => o.Id).ToList());

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var shippingDetailIds = orders.SelectMany(o => o.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId))).ToArray();

            var resultStatuses = _eventCustomerResultRepository.GetTestResultStatus(eventCustomerIds);

            var shippingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds);
            var cdShippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);

            var eventCustomerResults = _eventCustomerResultRepository.GetByIds(eventCustomerIds);
            eventCustomerResults = eventCustomerResults.Where(ecr => ecr.ResultState >= (long)TestResultStateNumber.Evaluated).ToArray();

            var eventIdCorporateAccountNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var healthAssessmentQuestions = _healthAssessmentRepository.GetAllQuestions();

            var healthAssessmentAnswers = _healthAssessmentRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var languages = _languageRepository.GetAll();

            var eventCustomerNotifications = _eventCustomerNotificationRepository.GetByEventCustomerIds(eventCustomerIds, NotificationTypeAlias.CannedMessageNotification);

            var eventHospitalPartners = _hospitalPartnerRepository.GetEventHospitalPartnersByEventIds(eventIds).ToArray();

            return _corporateAccountCustomerFactory.Create(eventCustomers, customers, orders, orderPackageIdNamePair, orderTestIdNamePair, shippingDetails, cdShippingOption, eventCustomerResults, events, pods, eventIdCorporateAccountNamePairs,
                                                            resultStatuses, primaryCarePhysicians, healthAssessmentAnswers, healthAssessmentQuestions, languages, eventCustomerNotifications, eventHospitalPartners);
        }

        private IEnumerable<AccountCallQueueSettingEditModel> GetDefaultAccountCallQueueSettings(long accountId)
        {
            var mailRoundLeftVoiceMail = _settings.MailRoundLeftVoiceMailDefault;
            var mailRoundAllCallDefault = _settings.MailRoundAllCallDefault;
            var refusedCustomer = _settings.RefusedCustomerReturnInCallQueue;
            var defaultNoOfDays = _settings.CustomerReturnInCallQueue;
            var fillEventAllCallDefault = _settings.FillEventAllCallDefault;
            var fillEventRefusedCustomerDefault = _settings.FillEventRefusedCustomerDefault;
            var maxAttemptsDefault = _settings.CallQueueMaxAttemptDefault;
            var callQueues = _callQueueRepository.GetAll(false, true);

            var accountCallQueueSettings = new List<AccountCallQueueSettingEditModel>();

            foreach (var callQueue in callQueues)
            {
                if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                    continue;

                foreach (CallQueueSuppressionType suppressionType in Enum.GetValues(typeof(CallQueueSuppressionType)))
                {
                    var obj = new AccountCallQueueSettingEditModel();
                    obj.AccountId = accountId;
                    obj.CallQueueId = callQueue.Id;
                    obj.CallQueueName = callQueue.Name;
                    obj.IsActive = true;
                    obj.SuppressionDescription = suppressionType.GetDescription();
                    obj.SuppressionTypeId = (long)suppressionType;

                    if (callQueue.Category == HealthPlanCallQueueCategory.MailRound)
                    {
                        if (suppressionType == CallQueueSuppressionType.LeftVoiceMail)
                            obj.NoOfDays = mailRoundLeftVoiceMail;

                        else if (suppressionType == CallQueueSuppressionType.Others)
                            obj.NoOfDays = mailRoundAllCallDefault;

                        else
                            obj.NoOfDays = refusedCustomer;
                    }
                    else if (callQueue.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan)
                    {
                        if (suppressionType == CallQueueSuppressionType.LeftVoiceMail || suppressionType == CallQueueSuppressionType.Others)
                            obj.NoOfDays = fillEventAllCallDefault;
                        else
                            obj.NoOfDays = fillEventRefusedCustomerDefault;
                    }
                    else
                    {
                        if (suppressionType == CallQueueSuppressionType.LeftVoiceMail || suppressionType == CallQueueSuppressionType.Others)
                            obj.NoOfDays = defaultNoOfDays;
                        else
                            obj.NoOfDays = refusedCustomer;
                    }

                    if (suppressionType == CallQueueSuppressionType.MaxAttempts)
                        obj.NoOfDays = maxAttemptsDefault;

                    accountCallQueueSettings.Add(obj);
                }
            }

            return accountCallQueueSettings;
        }
    }
}
