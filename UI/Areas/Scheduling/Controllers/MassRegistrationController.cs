using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Scheduling.Impl;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Medical.ViewModels;


namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [RoleBasedAuthorize]
    public class MassRegistrationController : Controller
    {
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ISessionContext _sessionContext;
        private readonly ICorporateTagService _corporateTagService;

        private readonly ILanguageRepository _languageRepository;
        private readonly ILabRepository _labRepository;

        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;
        private readonly ICorporateUploadRepository _corporateUploadRepository;
        private readonly IAccountAdditionalFieldRepository _accountAdditionalFieldRepository;

        private readonly ICorporateUploadHelper _corporateUploadHelper;
        private readonly IEligibilityUploadRepository _eligibilityUploadRepository;
        private readonly IEligibilityUploadService _eligibilityUploadService;
        private readonly ICorporateUploadService _corporateUploadService;
        private readonly ICustomerActivityTypeUploadRepository _customerActivityTypeUploadRepository;
        private readonly ICustomerActivityTypeUploadService _customerActivityTypeUploadService;
        private readonly IMemberUploadParseDetailRepository _memberUploadParseDetailRepository;
        private readonly IMemberUploadParseDetailFactory _memberUploadParseDetailFactory;
        private readonly ICustomerWithDuplicateAcesIdFileGenerator _customerWithDuplicateAcesIdFileGenerator;

        private readonly int _pageSize;

        public MassRegistrationController(ICustomerRegistrationService customerRegistrationService, IMediaRepository mediaRepository, IEventRepository eventRepository, ICorporateAccountRepository corporateAccountRepository,
            IOrganizationRepository organizationRepository, ISessionContext sessionContext, ICorporateTagService corporateTagService,
            ILanguageRepository languageRepository, ILabRepository labRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier,
            ILogManager logManager, IUniqueItemRepository<Core.Application.Domain.File> fileRepository, ICorporateUploadRepository corporateUploadRepository, IAccountAdditionalFieldRepository accountAdditionalFieldRepository,
             ICorporateUploadHelper corporateUploadHelper, IEligibilityUploadRepository eligibilityUploadRepository, IEligibilityUploadService eligibilityUploadService,
            ISettings settings, ICorporateUploadService corporateUploadService, ICustomerActivityTypeUploadRepository customerActivityTypeUploadRepository,
            ICustomerActivityTypeUploadService customerActivityTypeUploadService, IMemberUploadParseDetailRepository memberUploadParseDetailRepository,
            IMemberUploadParseDetailFactory memberUploadParseDetailFactory, ICustomerWithDuplicateAcesIdFileGenerator customerWithDuplicateAcesIdFileGenerator)
        {

            _customerRegistrationService = customerRegistrationService;
            _mediaRepository = mediaRepository;

            _eventRepository = eventRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _organizationRepository = organizationRepository;
            _sessionContext = sessionContext;
            _corporateTagService = corporateTagService;

            _languageRepository = languageRepository;
            _labRepository = labRepository;

            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _logger = logManager.GetLogger<MassRegistrationController>();
            _fileRepository = fileRepository;
            _corporateUploadRepository = corporateUploadRepository;
            _accountAdditionalFieldRepository = accountAdditionalFieldRepository;

            _corporateUploadHelper = corporateUploadHelper;
            _eligibilityUploadRepository = eligibilityUploadRepository;
            _eligibilityUploadService = eligibilityUploadService;
            _corporateUploadService = corporateUploadService;
            _customerActivityTypeUploadRepository = customerActivityTypeUploadRepository;
            _customerActivityTypeUploadService = customerActivityTypeUploadService;
            _memberUploadParseDetailRepository = memberUploadParseDetailRepository;
            _memberUploadParseDetailFactory = memberUploadParseDetailFactory;
            _customerWithDuplicateAcesIdFileGenerator = customerWithDuplicateAcesIdFileGenerator;
            _pageSize = settings.DefaultPageSizeForReports;
        }
        //
        // GET: /Scheduling/MassRegistration/

        public ActionResult Create(long eventId, string fileName = "")
        {
            var model = new MassRegistrationListModel { EventId = eventId };
            _corporateUploadHelper.SetEventDetails(model);
            _corporateUploadHelper.SetDropDownInfo(model);
            if (!string.IsNullOrEmpty(fileName))
                model.Registrations = _corporateUploadHelper.GetRegistraionModels(fileName);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MassRegistrationListModel model, bool saveAndContinue)
        {
            var registrationValidator = IoC.Resolve<MassRegistrationEditModelValidator>();
            var invalidRegistrationList = new List<MassRegistrationEditModel>();

            var eventData = _eventRepository.GetById(model.EventId);

            foreach (var registrationEditModel in model.Registrations)
            {
                if (registrationEditModel.HomeNumber != null && !string.IsNullOrEmpty(registrationEditModel.HomeNumber.ToString()))
                    registrationEditModel.HomeNumber = PhoneNumber.Create(registrationEditModel.HomeNumber.ToNumber().ToString(), PhoneNumberType.Home);
                var result = CorporateUploadHelper.ValidateModel(registrationValidator, registrationEditModel);
                if (string.IsNullOrEmpty(result))
                {
                    try
                    {
                        using (var scope = new TransactionScope())
                        {
                            if (!_customerRegistrationService.RegisterCustomer(registrationEditModel, model.EventId, eventData.EventType))
                                invalidRegistrationList.Add(registrationEditModel);
                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        registrationEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex.Message);
                        invalidRegistrationList.Add(registrationEditModel);
                    }
                }
                else
                {
                    registrationEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result);
                    invalidRegistrationList.Add(registrationEditModel);
                }
            }
            if (invalidRegistrationList.Count > 0)
            {
                model.Registrations = invalidRegistrationList;
                _corporateUploadHelper.SetEventDetails(model);
                _corporateUploadHelper.SetDropDownInfo(model);
                return View(model);
            }
            if (!saveAndContinue)
            {
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;
                if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.Technician))
                {
                    Response.RedirectUser("/Scheduling/EventCustomerList/Index?id=" + model.EventId);
                    return null;
                }


                if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.CorporateAccountCoordinator))
                {
                    Response.RedirectUser("/Users/Dashboard/CorporateAccountCoordinator");
                    return null;
                }
                Response.RedirectUser("/App/Common/EventDetails.aspx?EventId=" + model.EventId);
                return null;
            }

            var newModel = new MassRegistrationListModel { EventId = model.EventId };
            _corporateUploadHelper.SetEventDetails(newModel);
            _corporateUploadHelper.SetDropDownInfo(newModel);
            return View(newModel);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase massRegistrationFile)
        {
            if (Request.Files.Count < 1 || massRegistrationFile == null)
                return View();

            HttpPostedFileBase file = Request.Files[0];
            var physicalPath = _mediaRepository.GetTempMediaFileLocation().PhysicalPath;

            var fullPath = physicalPath + file.FileName;
            file.SaveAs(fullPath);

            var csvReader = IoC.Resolve<ICsvReader>();
            var customerTable = csvReader.ReadWithTextQualifier(fullPath);

            if (customerTable.Rows.Count > 0)
            {
                var eventId = Convert.ToInt64(customerTable.Rows[0]["EventId"].ToString());
                return RedirectToAction("Create", new { eventId, file.FileName });
            }
            return View();
        }


        public ActionResult CorporateUpload()
        {
            var uploadMediaLocation = _mediaRepository.GetSamplesLocation();
            var model = new CorporateUploadEditModel
            {
                UploadCsvMediaUrl = uploadMediaLocation.Url
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CorporateUpload(CorporateUploadEditModel model, HttpPostedFileBase corporateUploadFile)
        {
            if (Request.Files.Count < 1 || corporateUploadFile == null)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("No file has been uploaded. Please upload a csv file.");
                return View(model);
            }

            var uploadMediaLocation = _mediaRepository.GetUploadCsvMediaFileLocation();
            var account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(model.CorporateAccountId);
            var organization = _organizationRepository.GetOrganizationbyId(model.CorporateAccountId);
            model.Tag = account.Tag;
            model.Name = organization.Name;
            model.UploadCsvMediaUrl = _mediaRepository.GetSamplesLocation().Url;


            HttpPostedFileBase file = Request.Files[0];
            var physicalPath = uploadMediaLocation.PhysicalPath;
            var fileUploadedName = (Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName)).Replace("'", "").Replace("&", "");

            var fileName = (Path.GetFileNameWithoutExtension(fileUploadedName) + "_" + DateTime.Now.ToString("MMddyyyyhhmmss") + Path.GetExtension(fileUploadedName)).Replace("'", "").Replace("&", "");

            var fullPath = physicalPath + fileName;
            file.SaveAs(fullPath);

            var csvReader = IoC.Resolve<ICsvReader>();
            var customerTable = csvReader.ReadWithTextQualifier(fullPath);
            if (customerTable.Rows.Count == 0)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Uploaded file has no data.");
                return View(model);
            }

            var columns = customerTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName.ToLower()).ToArray();
            var missingColumnNames = _corporateUploadHelper.CheckAllColumnExist(columns);
            if (!string.IsNullOrEmpty(missingColumnNames))
            {
                model.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage("Missing Column Name(s) : " + missingColumnNames);

                return View(model);
            }

            var disabledTags = _corporateTagService.DisabledTagsInUsed(model.CustomTags, model.CorporateAccountId);

            if (disabledTags != null && disabledTags.Any())
            {
                model.CustomTags = model.CustomTags.Where(x => disabledTags.Contains(x)).ToList();

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Following tag(s) has been deactivated: " + string.Join(",", disabledTags));

                return View(model);
            }

            var files = new Core.Application.Domain.File
            {
                Path = fileName,
                FileSize = file.ContentLength,
                Type = FileType.Csv,
                UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                UploadedOn = DateTime.Now
            };

            files = _fileRepository.Save(files);

            var corporateUpload = new CorporateUpload
            {
                FileId = files.Id,
                UploadTime = DateTime.Now,
                UploadedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                AccountId = model.CorporateAccountId,
                SourceId = (long)MemberUploadSource.CorporateUplaod
            };

            corporateUpload = _corporateUploadRepository.Save(corporateUpload);

            model.TotalCustomers = customerTable.Rows.Count;
            model.IsUploadSucceded = true;
            model.IsParseSucceded = false;
            model.FileName = fileName;

            var failedFileName = Path.GetFileNameWithoutExtension(fileUploadedName).Replace("+", "_");

            model.FailedRecordsFile = failedFileName + "_Failure_" + DateTime.Now.ToString("MMddyyyyhhmmss") + ".csv";

            if (corporateUpload != null && corporateUpload.Id > 0)
                model.UploadCorporateId = corporateUpload.Id;

            var failureRecords = uploadMediaLocation.PhysicalPath + model.FailedRecordsFile;

            _corporateUploadHelper.CreateHeaderFileRecord(failureRecords, customerTable);


            model.AdjustOrderRecordsFile = failedFileName + "_AdjustOrder_" + DateTime.Now.ToString("MMddyyyyhhmmss") + ".csv";
            var adjustOrderRecordsFile = uploadMediaLocation.PhysicalPath + model.AdjustOrderRecordsFile;

            _corporateUploadHelper.CreateHeaderAdjustOrderForEventCustoerRecord(adjustOrderRecordsFile);

            return View(model);
        }

        [HttpPost]
        public JsonResult UploadCustomers(UploadCorporateCustomers model)
        {
            var fileName = model.FileName;
            var pageSize = model.PageSize;
            var tag = model.Tag;
            var failedRecordsFile = model.FailedRecordsFile;
            var adjustOrderFile = model.AdjustOrderRecordsFile;
            var pageNumber = model.PageNumber;
            var customTags = model.CustomTags;
            if (customTags != null)
                customTags = customTags.Where(s => !string.IsNullOrEmpty(s)).Select(s => s).ToList();
            var corporateModel = new CorporateUploadEditModel { Tag = tag, FileName = fileName, UploadCorporateId = model.UploadCorporateId };

            var mediaLocation = _mediaRepository.GetUploadCsvMediaFileLocation();
            var file = mediaLocation.PhysicalPath + corporateModel.FileName;

            var csvReader = IoC.Resolve<ICsvReader>();

            var languages = _languageRepository.GetAll();
            var labs = _labRepository.GetAll();

            var failureRecords = mediaLocation.PhysicalPath + failedRecordsFile;
            var adjustOrderRecordsFile = mediaLocation.PhysicalPath + model.AdjustOrderRecordsFile;

            var customerTable = csvReader.ReadWithTextQualifier(file);
            var createdByOrgRoleUser = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(_sessionContext.UserSession.CurrentOrganizationRole);

            var customerIdWithSameAcesId = new List<CustomerWithDuplicateAcesModel>();
            try
            {
                //var failedCustomers = new List<CorporateCustomerEditModel>();
                var adjustOrderForCustomerEditModel = new List<EventCusomerAdjustOrderViewModel>();

                var query = customerTable.AsEnumerable();

                var rows = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
                var customerToRender = rows.Count();
                var corporateAccount = _corporateAccountRepository.GetByTag(tag);
                var accountAdditionalFields = _accountAdditionalFieldRepository.GetAccountAdditionalFieldsEditModelByAccountId(corporateAccount.Id);
                var customerEditModel = new CorporateCustomerEditModel();

                foreach (DataRow row in rows)
                {
                    var sb = new StringBuilder();
                    try
                    {
                        customerEditModel = _corporateUploadHelper.GetCorporateCustomerEditModel(row);

                        var customerWithDuplicateAcesModel = new CustomerWithDuplicateAcesModel();
                        _corporateUploadService.CorporateUploadDataRow(customerEditModel, languages, labs, customTags, corporateModel,
                            accountAdditionalFields, adjustOrderForCustomerEditModel, createdByOrgRoleUser,
                            _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, null,
                            (long)MemberUploadSource.CorporateUplaod, sb, model.UploadCorporateId.Value, out customerWithDuplicateAcesModel);

                        if (customerWithDuplicateAcesModel != null && customerWithDuplicateAcesModel.CustomerId > 0)
                            customerIdWithSameAcesId.Add(customerWithDuplicateAcesModel);
                    }
                    catch (Exception ex)
                    {
                        customerEditModel.ErrorMessage = sb.ToString();
                        if (!string.IsNullOrEmpty(ex.Message))
                            customerEditModel.ErrorMessage += " Error Message: " + ex.Message;
                        //failedCustomers.Add(customerEditModel);
                    }

                    var memberUploadParseDetail = _memberUploadParseDetailFactory.GetDomain(customerEditModel, model.UploadCorporateId.Value);
                    _memberUploadParseDetailRepository.Save(memberUploadParseDetail);
                }

                if (!customerIdWithSameAcesId.IsNullOrEmpty())
                    _customerWithDuplicateAcesIdFileGenerator.GenerateCsvFile(model.UploadCorporateId.Value, customerIdWithSameAcesId);

                corporateModel.TotalCustomers = customerTable.Rows.Count;

                var totalPages = corporateModel.TotalCustomers / pageSize + (corporateModel.TotalCustomers % pageSize != 0 ? 1 : 0);
                var failedCustomers = _memberUploadParseDetailRepository.GetByCorporateUploadId(model.UploadCorporateId.Value, false);
                corporateModel.FailedCustomers = failedCustomers != null ? failedCustomers.Count() : 0;
                corporateModel.UploadedCustomers = customerToRender - corporateModel.FailedCustomers;
                corporateModel.IsParseSucceded = totalPages == pageNumber;

                if (corporateModel.IsParseSucceded)
                {
                    var corporateUploadedBy = _sessionContext.UserSession.FullName;

                    string corporateName = string.Empty;
                    if (corporateAccount != null)
                    {
                        var organization = _organizationRepository.GetOrganizationbyId(corporateAccount.Id);
                        if (organization != null)
                        {
                            corporateName = organization.Name;
                        }
                    }

                    var corporateUploadNotificationModel = _emailNotificationModelsFactory.GetCorporateUploadNotificationViewModel(corporateName, corporateUploadedBy, corporateModel.TotalCustomers, (corporateModel.TotalCustomers - corporateModel.FailedCustomers), corporateModel.FailedCustomers);

                    _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CorporateUploadNotification, EmailTemplateAlias.CorporateUploadNotification, corporateUploadNotificationModel, 0, 1, "System: Corporate Upload Notification");
                    _logger.Info("Corporate Upload Notification:Mail Send for upload corporate :" + tag + " UploadedBy:  " + corporateUploadedBy + " on : " + DateTime.Now);
                }

                corporateModel.FailedRecordsFile = failedRecordsFile;

                if (failedCustomers != null && failedCustomers.Any())
                {
                    var failedMember = _memberUploadParseDetailFactory.GetCorporateCustomerListModel(failedCustomers, model.UploadCorporateId.Value);
                    _corporateUploadHelper.UpdateFailedRecords(failureRecords, failedMember);

                    if (model.LogFileId < 1)
                    {
                        var fileInfo = new FileInfo(failureRecords);

                        var files = new Core.Application.Domain.File
                        {
                            Path = fileInfo.Name,
                            FileSize = fileInfo.Length,
                            Type = FileType.Csv,
                            UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                            UploadedOn = DateTime.Now
                        };

                        files = _fileRepository.Save(files);

                        model.LogFileId = files.Id;
                    }
                }

                if (adjustOrderForCustomerEditModel.Any())
                {
                    _corporateUploadHelper.UpdateAdjustOrderRecords(adjustOrderRecordsFile, adjustOrderForCustomerEditModel);
                    if (model.AdjustOrderLogFileId < 1)
                    {
                        var fileInfo = new FileInfo(adjustOrderRecordsFile);
                        var files = new Core.Application.Domain.File
                       {
                           Path = fileInfo.Name,
                           FileSize = fileInfo.Length,
                           Type = FileType.Csv,
                           UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                           UploadedOn = DateTime.Now
                       };

                        files = _fileRepository.Save(files);

                        model.AdjustOrderLogFileId = files.Id;
                    }
                }

                if (model.UploadCorporateId.HasValue && corporateModel.IsParseSucceded)
                {
                    var count = _corporateUploadHelper.FailedCustomerCount(failedRecordsFile, mediaLocation);

                    var uploadCorporate = _corporateUploadRepository.GetById(model.UploadCorporateId.Value);
                    uploadCorporate.SuccessfullUploadCount = (corporateModel.TotalCustomers - count);
                    uploadCorporate.FailedUploadCount = count;

                    if (model.LogFileId > 0)
                        uploadCorporate.LogFileId = model.LogFileId;

                    if (model.AdjustOrderLogFileId > 0)
                        uploadCorporate.AdjustOrderLogFileId = model.AdjustOrderLogFileId;

                    uploadCorporate.ParseStatus = (int)MemberUploadParseStatus.Start;
                    _corporateUploadRepository.Save(uploadCorporate);
                }

                corporateModel.FailedCustomersListPath = _corporateUploadHelper.CheckIsFileContainsRecord(corporateModel.IsParseSucceded, mediaLocation, failedRecordsFile);
                corporateModel.AdjustOrderRecordsFile = _corporateUploadHelper.CheckIsFileContainsRecord(corporateModel.IsParseSucceded, mediaLocation, adjustOrderFile);
            }
            catch (Exception ex)
            {
                corporateModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(ex.Message);
            }

            return Json(new
            {
                corporateModel.FileName,
                corporateModel.UploadedCustomers,
                corporateModel.Tag,
                corporateModel.FailedCustomers,
                corporateModel.IsParseSucceded,
                PageNumber = pageNumber + 1,
                corporateModel.FailedCustomersListPath,
                LogFileId = model.LogFileId,
                corporateModel.AdjustOrderRecordsFile,
                model.AdjustOrderLogFileId
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCorporateTag(long accountId)
        {
            return Json(_corporateTagService.GetTagViewModel(accountId));
        }

        public ActionResult EligibilityUpload(string message)
        {
            var model = new CustomerEligibilityUploadEditModel
            {
                SampleCsvMediaUrl = _mediaRepository.GetSamplesLocation().Url
            };
            if (message != null)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage(message);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EligibilityUpload(HttpPostedFileBase eligibilityUploadFile, CustomerEligibilityUploadEditModel model)
        {
            try
            {
                if (Request.Files.Count < 1 || eligibilityUploadFile == null)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("No file has been uploaded. Please upload a csv file.");
                    return View(model);
                }

                HttpPostedFileBase file = Request.Files[0];
                var fileExtension = file.FileName.Split('.');
                if ((fileExtension.Length >= 2 && fileExtension[fileExtension.Length - 1].ToLower() != "csv") || fileExtension.Length < 2)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("File uploaded is not a CSV");
                    return View(model);
                }

                try
                {
                    var organization = _organizationRepository.GetOrganizationbyId(model.CorporateAccountId);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("EligibilityUpload\nException occurred while retrieving account by accountId: {0}", model.CorporateAccountId));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Select valid corporate Account");
                    return View(model);
                }

                var uploadMediaLocation = _mediaRepository.GetEligibilityUploadMediaFileLocation();

                var physicalPath = uploadMediaLocation.PhysicalPath;
                var fileUploadedName = (Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName)).Replace("'", "").Replace("&", "");
                var fileName = (Path.GetFileNameWithoutExtension(fileUploadedName) + "_" + DateTime.Now.ToString("MMddyyyyhhmmss") + Path.GetExtension(fileUploadedName)).Replace("'", "").Replace("&", "");

                var fullPath = physicalPath + fileName;

                try
                {
                    file.SaveAs(fullPath);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("EligibilityUpload\nException occurred while saving file on server. FileName:{0} Path: {1}", fileUploadedName, fullPath));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                    return View(model);
                }

                var csvReader = IoC.Resolve<ICsvReader>();
                var customerTable = csvReader.ReadWithTextQualifier(fullPath);
                if (customerTable.Rows.Count == 0)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Uploaded file has no data.");

                    return View(model);
                }

                var columns = customerTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                var missingColumnNames = _corporateUploadHelper.CheckAllEligibilityColumnExist(columns);
                if (!string.IsNullOrEmpty(missingColumnNames))
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Missing Column Name(s) : " + missingColumnNames);

                    return View(model);
                }
                var files = new Core.Application.Domain.File
                {
                    Path = fileName,
                    FileSize = file.ContentLength,
                    Type = FileType.Csv,
                    UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                    UploadedOn = DateTime.Now
                };

                try
                {
                    files = _fileRepository.Save(files);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("EligibilityUpload\nException occurred while saving info in TblFile."));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                    return View(model);
                }

                var eligibilityUpload = new EligibilityUpload
                {
                    FileId = files.Id,
                    UploadTime = DateTime.Now,
                    UploadedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                    AccountId = model.CorporateAccountId,
                    StatusId = (long)EligibilityUploadStatus.Uploaded
                };

                try
                {
                    eligibilityUpload = _eligibilityUploadRepository.Save(eligibilityUpload);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("EligibilityUpload\nException occurred while saving info in EligibilityUpload."));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                    return View(model);
                }

                if (eligibilityUpload != null && eligibilityUpload.Id > 0)
                {
                    ModelState.Clear();
                    //const string message = "File uploaded successfully";
                    return RedirectToAction("EligibilityUpload", "MassRegistration", new { message = "File uploaded successfully" });
                }

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("File upload failed");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("EligibilityUpload\nException occurred"));
                _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                return View(model);
            }
        }

        public ActionResult EligibilityUploadDetails(EligibilityUploadListModelFilter filter = null, int pageNumber = 1)
        {
            try
            {
                int totalRecords;
                var model = _eligibilityUploadService.GetEligibilityUploadDetails(pageNumber, _pageSize, filter, out totalRecords) ??
                            new EligibilityUploadListModel();

                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                Func<int, string> urlFunc =
                    pn =>
                        Url.Action(currentAction,
                            new
                            {
                                pageNumber = pn,
                                filter.FromUploadDate,
                                filter.ToUploadDate,
                                filter.UploadedBy
                            });

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("EligibilityUpload Details\nException occurred"));
                _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                var model = new EligibilityUploadListModel { Filter = filter };
                return View(model);
            }
        }


        public ActionResult CustomerActivityTypeUpload(string message)
        {
            return View(new CustomerActivityTypeUploadViewModel()
            {
                FeedbackMessage = !string.IsNullOrWhiteSpace(message) ? FeedbackMessageModel.CreateSuccessMessage(message) : null
            });
        }

        [HttpPost]
        public ActionResult CustomerActivityTypeUpload(HttpPostedFileBase customerActivityTypeUploadFileUpload, CustomerActivityTypeUploadViewModel model)
        {
            try
            {
                if (Request.Files.Count < 1 || customerActivityTypeUploadFileUpload == null)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("No file has been uploaded. Please upload a csv file.");
                    return View(model);
                }

                HttpPostedFileBase file = Request.Files[0];
                var fileExtension = file.FileName.Split('.');
                if ((fileExtension.Length >= 2 && fileExtension[fileExtension.Length - 1].ToLower() != "csv") || fileExtension.Length < 2)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("File uploaded is not a CSV, please uplaod CSV file only");
                    return View(model);
                }

                var uploadMediaLocation = _mediaRepository.GetCustomerActivityTypeUploadMediaFileLocation();

                var physicalPath = uploadMediaLocation.PhysicalPath;
                var fileUploadedName = (Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName)).Replace("'", "").Replace("&", "");
                var fileName = (Path.GetFileNameWithoutExtension(fileUploadedName) + "_" + DateTime.Now.ToString("MMddyyyyhhmmss") + Path.GetExtension(fileUploadedName)).Replace("'", "").Replace("&", "");

                var fullPath = physicalPath + fileName;

                try
                {
                    file.SaveAs(fullPath);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("CustomerActivityTypeUpload \nException occurred while saving file on server. FileName:{0} Path: {1}", fileUploadedName, fullPath));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                    return View(model);
                }

                var csvReader = IoC.Resolve<ICsvReader>();
                var customerTable = csvReader.ReadWithTextQualifier(fullPath);
                if (customerTable.Rows.Count == 0)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Uploaded file has no data.");

                    return View(model);
                }

                var columns = customerTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName.ToLower()).ToArray();
                var missingColumnNames = _corporateUploadHelper.CheckForMissingColumnInCustomerActivityTypeUpload(columns);
                if (!string.IsNullOrEmpty(missingColumnNames))
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Missing Column Name(s) : " + missingColumnNames);

                    return View(model);
                }
                var files = new Core.Application.Domain.File
                {
                    Path = fileName,
                    FileSize = file.ContentLength,
                    Type = FileType.Csv,
                    UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                    UploadedOn = DateTime.Now
                };

                try
                {
                    files = _fileRepository.Save(files);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("CustomerActivityTypeUpload \nException occurred while saving info in TblFile."));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                    return View(model);
                }

                var customerActivityTypeUpload = new CustomerActivityTypeUpload
                {
                    FileId = files.Id,
                    UploadTime = DateTime.Now,
                    UploadedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                    StatusId = (long)EligibilityUploadStatus.Uploaded
                };

                try
                {
                    customerActivityTypeUpload = _customerActivityTypeUploadRepository.Save(customerActivityTypeUpload);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("CustomerActivityTypeUpload\nException occurred while saving info in CustomerActivityTypeUpload."));
                    _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                    return View(model);
                }

                if (customerActivityTypeUpload != null && customerActivityTypeUpload.Id > 0)
                {
                    ModelState.Clear();
                    return RedirectToAction("CustomerActivityTypeUpload", "MassRegistration", new { message = "File uploaded successfully" });
                }

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("File upload failed");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("CustomerActivityTypeUpload \nException occurred"));
                _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some internal error occurred");
                return View(model);
            }
        }

        public ActionResult CustomerActivityTypeUploadDetails(CustomerActivityTypeUploadListModelFilter filter = null, int pageNumber = 1)
        {
            try
            {
                int totalRecords;
                var model = _customerActivityTypeUploadService.GetCustomerActivityTypeUploadDetails(pageNumber, _pageSize, filter, out totalRecords) ??
                            new CustomerActivityTypeUploadListModel();

                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                Func<int, string> urlFunc =
                    pn =>
                        Url.Action(currentAction,
                            new
                            {
                                pageNumber = pn,
                                filter.FromUploadDate,
                                filter.ToUploadDate,
                                filter.UploadedBy
                            });

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("EligibilityUpload Details\nException occurred"));
                _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                var model = new CustomerActivityTypeUploadListModel { Filter = filter };
                return View(model);
            }
        }

        public ActionResult MemberUploadDetails(MemberUploadDetailsListModelFilter filter = null, int pageNumber = 1)
        {
            try
            {
                int totalRecords;
                var model = _corporateUploadService.GetMemberUploadDetails(pageNumber, _pageSize, filter, out totalRecords) ?? new MemberUploadDetailsListModel();
                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                Func<int, string> urlFunc =
                    pn =>
                        Url.Action(currentAction,
                            new
                            {
                                pageNumber = pn,
                                filter.FromUploadDate,
                                filter.ToUploadDate,
                                filter.SourceId
                            });

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format(" Member Upload Details\nException occurred"));
                _logger.Error(string.Format("Exception message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));

                var model = new MemberUploadDetailsListModel { Filter = filter };
                return View(model);
            }


        }
    }
}
