using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.UI.HtmlHelpers;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;
using Gma.QrCodeNet.Encoding.DataEncodation;

namespace Falcon.App.UI.Areas.CallCenter.Controllers
{
    [RoleBasedAuthorize]
    public class HealthPlanCallQueueCriteriaController : Controller
    {
        private readonly IHealthPlanCallQueueCriteriaService _healthPlanCallQueueCriteriaService;
        private readonly ISessionContext _sessionContext;
        private readonly int _pageSize;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly ICorporateUploadRepository _corporateUploadRepository;
        private readonly IHealthPlanCriteriaAssignmentRepository _healthPlanCriteriaAssignmentRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallCenterTeamRepository _callCenterTeamRepository;
        private readonly ICallCenterTeamService _callCenterTeamService;
        private readonly ICallCenterAgentTeamLogRepository _callCenterAgentTeamLogRepository;
        private readonly IHealthPlanCriteriaTeamAssignmentRepository _healthPlanCriteriaTeamAssignmentRepository;
        private readonly ICampaignActivityRepository _campaignActivityRepository;
        private readonly ILogger _logger;

        public HealthPlanCallQueueCriteriaController(IHealthPlanCallQueueCriteriaService healthPlanCallQueueCriteriaService, ISessionContext sessionContext, ISettings settings,
            IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, ICorporateUploadRepository corporateUploadRepository,
            IHealthPlanCriteriaAssignmentRepository healthPlanCriteriaAssignmentRepository, IUserRepository<User> userRepository, IMediaRepository mediaRepository,
            ICsvReader csvReader, ICallQueueRepository callQueueRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, ICallCenterTeamRepository callCenterTeamRepository,
            ICallCenterTeamService callCenterTeamService, ICallCenterAgentTeamLogRepository callCenterAgentTeamLogRepository,
            IHealthPlanCriteriaTeamAssignmentRepository healthPlanCriteriaTeamAssignmentRepository, ILogManager logManager, ICampaignActivityRepository campaignActivityRepository)
        {
            _healthPlanCallQueueCriteriaService = healthPlanCallQueueCriteriaService;
            _sessionContext = sessionContext;
            _pageSize = settings.DefaultPageSizeForReports;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _corporateUploadRepository = corporateUploadRepository;
            _healthPlanCriteriaAssignmentRepository = healthPlanCriteriaAssignmentRepository;
            _userRepository = userRepository;
            _mediaRepository = mediaRepository;
            _csvReader = csvReader;
            _callQueueRepository = callQueueRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callCenterTeamRepository = callCenterTeamRepository;
            _callCenterTeamService = callCenterTeamService;
            _callCenterAgentTeamLogRepository = callCenterAgentTeamLogRepository;
            _healthPlanCriteriaTeamAssignmentRepository = healthPlanCriteriaTeamAssignmentRepository;
            _campaignActivityRepository = campaignActivityRepository;
            _logger = logManager.GetLogger("HealthPlanCallQueueCriteriaController");
        }

        public ActionResult ManageCriteria(HealthPlanCallQueueListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            if (filter != null)
                filter.ShowAssignmentMetaData = true;
            var model = _healthPlanCallQueueCriteriaService.GetHealthPlanCallQueueList(pageNumber, _pageSize, filter, out totalRecords) ??
                        new HealthPlanCallQueueListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.HealthPlanId,
                               filter.CallQueueId,
                           });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult Create()
        {
            return View(_healthPlanCallQueueCriteriaService.GetCriteriaEditModel());
        }

        [HttpPost]
        public ActionResult Create(HealthPlanCallQueueCriteriaEditModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    //if ((model.Assignments == null && model.CallCenterTeamAssignments == null)
                    //    ||
                    //    ((model.Assignments != null && !model.Assignments.Any()) && (model.CallCenterTeamAssignments != null && !model.CallCenterTeamAssignments.Any())))
                    //{
                    //    model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Assignment must exist");
                    //    return View(model);
                    //}

                    var healthPlanCriteria = _healthPlanCallQueueCriteriaRepository.GetCriteriaByHealthPlanCallQueue(model.HealthPlanId, model.CallQueue);

                    if (!string.IsNullOrWhiteSpace(model.CriteriaName))
                    {
                        model.CriteriaName = model.CriteriaName.Trim();
                        var criteriaNameList = _healthPlanCallQueueCriteriaRepository.GetAllHealthPlanCallQueueCriteriaNames();

                        if (criteriaNameList.Any(x => x.ToLower() == model.CriteriaName.ToLower()))
                        {
                            model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Name already exists");
                            return View(model);
                        }
                    }
                    if (model.CallQueue == HealthPlanCallQueueCategory.AppointmentConfirmation)
                    {
                        var healthPlanCallQueueCriteria = _healthPlanCallQueueCriteriaRepository.GetQueueCriteriaForQueueByLanguage(model.CallQueue, model.HealthPlanId, model.LanguageId);
                        if (healthPlanCallQueueCriteria != null)
                        {
                            model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Criteria already exists for selected language.");
                            return View(model);
                        }
                    }

                    bool isCriteriaExist = CheckHealthPlanCallQueueCriteriaAlreadyExists(model, healthPlanCriteria);

                    if (isCriteriaExist)
                    {
                        model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Criteria for same healthplan and call queue exist");
                        return View(model);
                    }
                    else
                    {
                        //if (model.Id > 0)
                        //{
                        //    //check if user has changed mode of assignment (agent assignment or team assignment)
                        //    var isTeamAssignmentOld =
                        //        _healthPlanCriteriaTeamAssignmentRepository.GetTeamAssignments(model.Id).Any();
                        //    var isAgentAssignmentOld =
                        //        _healthPlanCriteriaAssignmentRepository.GetByCriteriaId(model.Id).Any();

                        //    if (model.IsTeamAssignment && isAgentAssignmentOld) //delete old agent assignments
                        //    {
                        //        _healthPlanCriteriaAssignmentRepository.DeleteByCriteriaId(model.Id);
                        //    }
                        //    else if (!model.IsTeamAssignment && isTeamAssignmentOld) //delete old team assignments
                        //    {
                        //        _healthPlanCriteriaTeamAssignmentRepository.DeleteAssignmentsForCriteria(model.Id);
                        //    }
                        //}
                        _healthPlanCallQueueCriteriaService.SaveHealthPlanCallQueueCriteria(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, false);

                        ModelState.Clear();

                        model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Criteria for healthplan and call queue created successfully");
                    }
                }
                return RedirectToAction("ManageCriteria");
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(long criteriaId, bool isSuccessfull = false)
        {
            var model = _healthPlanCallQueueCriteriaService.GetCriteriaEditModel(criteriaId);
            if (isSuccessfull)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Criteria updated and queue will be regenerated");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(HealthPlanCallQueueCriteriaEditModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    //if ((model.Assignments == null && model.CallCenterTeamAssignments == null)
                    //    ||
                    //    ((model.Assignments != null && !model.Assignments.Any()) && (model.CallCenterTeamAssignments != null && !model.CallCenterTeamAssignments.Any())))
                    //{
                    //    model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Assignment must exist");
                    //    return View(model);
                    //}

                    var healthPlanCriteria = _healthPlanCallQueueCriteriaRepository.GetCriteriaByHealthPlanCallQueue(model.HealthPlanId, model.CallQueue);

                    if (!string.IsNullOrWhiteSpace(model.CriteriaName))
                    {
                        model.CriteriaName = model.CriteriaName.Trim();
                        var currentCriteria = healthPlanCriteria.FirstOrDefault(x => x.Id == model.Id);

                        //if we are Modifying Criteria Name then check for Uniqueness
                        if (currentCriteria.CriteriaName.ToLower() != model.CriteriaName.ToLower())
                        {
                            var criteriaNameList = _healthPlanCallQueueCriteriaRepository.GetAllHealthPlanCallQueueCriteriaNames();
                            if (criteriaNameList.Any(x => x.ToLower() == model.CriteriaName.ToLower()))
                            {
                                model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Name already exists");
                                return View(model);
                            }
                        }
                        if (model.CallQueue == HealthPlanCallQueueCategory.AppointmentConfirmation && currentCriteria.LanguageId != model.LanguageId)
                        {
                            var healthPlanCallQueueCriteria = _healthPlanCallQueueCriteriaRepository.GetQueueCriteriaForQueueByLanguage(model.CallQueue, model.HealthPlanId, model.LanguageId);
                            if (healthPlanCallQueueCriteria != null)
                            {
                                model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Criteria already exists for selected language.");
                                return View(model);
                            }
                        }
                    }
                    bool isCriteriaExist = CheckHealthPlanCallQueueCriteriaAlreadyExists(model, healthPlanCriteria);

                    if (isCriteriaExist)
                    {
                        model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("Criteria for same healthplan and call queue exist");
                        return View(model);
                    }
                    else
                    {
                        var criteria = healthPlanCriteria.First(x => x.Id == model.Id);
                        var isCriteriaSameAsPervious = IsCriteriaIsSameAsPerious(model, criteria);

                        if (isCriteriaSameAsPervious)
                        {
                            isCriteriaSameAsPervious = CheckCustomerDataHasBeenUploaded(criteria);
                        }

                        //check if user has changed mode of assignment (agent assignment or team assignment)
                        var isTeamAssignmentOld = _healthPlanCriteriaTeamAssignmentRepository.GetTeamAssignments(criteria.Id).Any();
                        var isAgentAssignmentOld = _healthPlanCriteriaAssignmentRepository.GetByCriteriaId(criteria.Id).Any();

                        if (model.IsTeamAssignment && isAgentAssignmentOld) //delete old agent assignments
                        {
                            _healthPlanCriteriaAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                        }
                        else if (!model.IsTeamAssignment && isTeamAssignmentOld)     //delete old team assignments
                        {
                            _healthPlanCriteriaTeamAssignmentRepository.DeleteAssignmentsForCriteria(criteria.Id);
                        }
                        else if (model.IsTeamAssignment && isTeamAssignmentOld && model.CallCenterTeamAssignments.IsNullOrEmpty())
                        {
                            _healthPlanCriteriaTeamAssignmentRepository.DeleteAssignmentsForCriteria(criteria.Id);
                        }
                        else if (!model.IsTeamAssignment && isAgentAssignmentOld && model.Assignments.IsNullOrEmpty())
                        {
                            _healthPlanCriteriaAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                        }

                        _healthPlanCallQueueCriteriaService.SaveHealthPlanCallQueueCriteria(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, isCriteriaSameAsPervious);
                        if (model.IsCriteriaSameAsPervious)
                        {
                            model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Criteria Updated");
                            return View(model);
                        }
                        else
                        {
                            return RedirectToAction("Edit", new { criteriaId = model.Id, isSuccessfull = true });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex.Message);
                return View(model);
            }
        }

        public ActionResult EditCallQueueAssignment(long criteriaId)
        {
            var model = _healthPlanCallQueueCriteriaService.GetCallQueueAssignment(criteriaId);

            return PartialView(model.ToList());
        }

        [HttpPost]
        public ActionResult EditCallQueueAssignment(IEnumerable<CallQueueAssignmentEditModel> model)
        {
            if (ModelState.IsValid)
            {
                _healthPlanCriteriaAssignmentRepository.UpdateHealthPlanCriteriaAssignment(model);
            }
            return PartialView(model);
        }

        private bool CheckHealthPlanCallQueueCriteriaAlreadyExists(HealthPlanCallQueueCriteriaEditModel model, IEnumerable<HealthPlanCallQueueCriteria> healthPlanCriterias)
        {
            bool isCriteriaExist = false;

            if (healthPlanCriterias != null && healthPlanCriterias.Any())
            {
                healthPlanCriterias = healthPlanCriterias.Where(x => x.Id != model.Id);

                if (model.CallQueue == HealthPlanCallQueueCategory.CallRound)
                {
                    isCriteriaExist = healthPlanCriterias.Any(x => x.NoOfDays == model.NoOfDays && x.RoundOfCalls == model.RoundOfCalls);
                }
                else if (model.CallQueue == HealthPlanCallQueueCategory.NoShows)
                {
                    isCriteriaExist = healthPlanCriterias.Any(x => x.StartDate == model.StartDate && x.EndDate == model.EndDate);
                }
                else if (model.CallQueue == HealthPlanCallQueueCategory.FillEventsHealthPlan)
                {
                    isCriteriaExist = healthPlanCriterias.Any(x => x.Percentage == model.Percentage && x.NoOfDays == model.NoOfDaysOfEvents);
                }
                else if (model.CallQueue == HealthPlanCallQueueCategory.ZipRadius)
                {
                    isCriteriaExist = healthPlanCriterias.Any(x => x.ZipCode == model.Zipcode && x.Radius == model.Radius);
                }
            }

            return isCriteriaExist;
        }

        private bool IsCriteriaIsSameAsPerious(HealthPlanCallQueueCriteriaEditModel model, HealthPlanCallQueueCriteria domain)
        {
            switch (model.CallQueue)
            {
                case HealthPlanCallQueueCategory.CallRound:
                    return domain.NoOfDays == model.NoOfDays && domain.RoundOfCalls == model.RoundOfCalls;

                case HealthPlanCallQueueCategory.ZipRadius:
                    return domain.Radius.HasValue && domain.ZipCode == model.Zipcode && domain.Radius.Value == model.Radius;

                case HealthPlanCallQueueCategory.FillEventsHealthPlan:
                    return domain.NoOfDays == model.NoOfDaysOfEvents && domain.Percentage == model.Percentage;

                case HealthPlanCallQueueCategory.NoShows:
                    return domain.StartDate == model.StartDate && domain.EndDate == model.EndDate;

                case HealthPlanCallQueueCategory.AppointmentConfirmation:
                    return domain.StartDate == model.StartDate && domain.EndDate == model.EndDate;

                case HealthPlanCallQueueCategory.LanguageBarrier:
                    return true;
            }

            return false;
        }

        private bool CheckCustomerDataHasBeenUploaded(HealthPlanCallQueueCriteria criteria)
        {
            return _corporateUploadRepository.IsFileUpladedBetweenDateTime(criteria.LastQueueGeneratedDate.HasValue ? criteria.LastQueueGeneratedDate.Value : criteria.DataRecorderMetaData.DateCreated, DateTime.Now);
        }

        public JsonResult IsAlreadyAssignedToHealthPlanCallQueue(long healthPlan, string callQueueCategory, long criteriaId, long assignmentTo, DateTime startDate, DateTime? endDate)
        {
            var isExist = _healthPlanCallQueueCriteriaRepository.CheckHealthPlanAssignment(healthPlan, callQueueCategory, criteriaId, assignmentTo, startDate, endDate);

            return Json(new { isExist }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RegenerateHealthPlanCriteria(long criteriaId)
        {
            _healthPlanCallQueueCriteriaRepository.RegenerateHealthPlanCriteria(criteriaId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            var feedback = FeedbackMessageModel.CreateSuccessMessage("Health Plan Criteria Regenerated.");

            return Json(feedback, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCampaignByAccountId(long healthPlanId)
        {
            var campaigns = _healthPlanCallQueueCriteriaRepository.GetCampaignsByHealthPlanId(healthPlanId);
            campaigns = campaigns.Where(x => x.EndDate >= DateTime.Today);
            return Json(campaigns, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAgentsList(string searchText)
        {
            return Json(_userRepository.SearchUsersByNameAndRole(searchText, Roles.CallCenterRep).ToList().Select(x => new { id = x.Key, label = x.Value }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MassAssignment(MassAgentAssignmentEditModel data)
        {
            var model = new MassAgentAssignmentViewModel();
            var healthPlanId = data.HealthPlanId;
            var callQueueCategory = data.CallQueueCategory;
            var criteriaId = data.CriteriaId;
            var callQueue = new CallQueue();

            if (healthPlanId == null || (healthPlanId.HasValue && healthPlanId.Value == 0))
            {
                return Json(model.ErrorMessage = "Select healthplan first", JsonRequestBehavior.AllowGet);
            }
            if (!(callQueueCategory == HealthPlanCallQueueCategory.FillEventsHealthPlan
                || callQueueCategory == HealthPlanCallQueueCategory.MailRound
                || callQueueCategory == HealthPlanCallQueueCategory.LanguageBarrier
                || callQueueCategory == HealthPlanCallQueueCategory.AppointmentConfirmation))
            {
                return Json(model.ErrorMessage = "Select call queue first", JsonRequestBehavior.AllowGet);
            }

            if (Request != null && Request.Files != null && Request.Files.Count > 0 && data.MassAssignmentFile != null)
            {
                HttpPostedFileBase file = Request.Files[0];
                var uploadDateTime = DateTime.Now;
                var fileUploadName = @"MassAgentAssignment_" + uploadDateTime.ToString("yyyyMMddHHmmss") + "_" + _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId + ".csv";
                var tempMediaFileLocation = _mediaRepository.GetTempMediaFileLocation();
                var tempPhysicalPath = tempMediaFileLocation.PhysicalPath;
                var tempFullpath = tempPhysicalPath + fileUploadName;

                var logFileName = "Failure_" + fileUploadName;
                var logFilePath = tempPhysicalPath + logFileName;

                var fileExtension = file.FileName.Split('.');
                if ((fileExtension.Length >= 2 && fileExtension[fileExtension.Length - 1].ToLower() != "csv") || fileExtension.Length < 2)
                {
                    return Json(model.ErrorMessage = "File format is not CSV", JsonRequestBehavior.AllowGet);
                }

                try
                {
                    file.SaveAs(tempFullpath);          //save in Temp
                    model.UploadedCsvFileName = fileUploadName;
                }
                catch (Exception)
                {
                    return Json(model.ErrorMessage = "Internal error occurred", JsonRequestBehavior.AllowGet);
                }

                var massAssignmentTable = _csvReader.ReadWithTextQualifier(tempFullpath);

                if (massAssignmentTable.Rows.Count == 0)
                {
                    return Json(model.ErrorMessage = "File contains no data", JsonRequestBehavior.AllowGet);
                }

                var columns = massAssignmentTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                var missingColumnNames = CheckAllColumnExist(columns);
                if (!string.IsNullOrEmpty(missingColumnNames))
                {
                    var customString = missingColumnNames
                         .Replace(MassAgentAssignmentColumns.AgentName, "Agent name")
                         .Replace(MassAgentAssignmentColumns.EmailId, "Email id")
                         .Replace(MassAgentAssignmentColumns.StartDate, "Start date")
                         .Replace(MassAgentAssignmentColumns.EndDate, "End date");

                    return Json(model.ErrorMessage = "Missing Column Name(s):" + customString, JsonRequestBehavior.AllowGet);
                }

                //parsing HealthPlanId and CallQueueCategory
                if (healthPlanId == null || string.IsNullOrEmpty(callQueueCategory))
                {
                    return Json(model.ErrorMessage = "Please select healthplan/call queue first", JsonRequestBehavior.AllowGet);
                }

                callQueue = _callQueueRepository.GetCallQueueByCategory(data.CallQueueCategory);

                if (callQueue == null)
                {
                    return Json(model.ErrorMessage = "Invalid call queue selected", JsonRequestBehavior.AllowGet);
                }

                var agentDataCollection = new List<CallQueueAssignmentEditModel>();
                DataTable table = _csvReader.CsvToDataTable(tempMediaFileLocation.PhysicalPath + fileUploadName, true);
                if (table.Rows.Count <= 0)
                {
                    return Json(model.ErrorMessage = "File contains no data", JsonRequestBehavior.AllowGet);
                }

                var failedToParseRecords = new StringBuilder();
                failedToParseRecords.Append(MassAgentAssignmentColumns.AgentName + "," +
                                       MassAgentAssignmentColumns.EmailId + "," +
                                       MassAgentAssignmentColumns.StartDate + "," +
                                       MassAgentAssignmentColumns.EndDate + "," +
                                       "Error Message" + Environment.NewLine);

                foreach (DataRow row in table.Rows)
                {
                    var agentData = new CallQueueAssignmentEditModel();
                    var rowData = GetMassAssignmentCsvRow(row);
                    var errorRow = rowData.AgentName + "," +
                                   rowData.EmailId + "," +
                                   rowData.StartDate + "," +
                                   rowData.EndDate;

                    //Email Id
                    if (string.IsNullOrEmpty(rowData.EmailId))
                    {
                        failedToParseRecords.Append(errorRow + "," + "No Email Provided" + Environment.NewLine);
                        continue;
                    }
                    //StartDate empty
                    if (string.IsNullOrEmpty(rowData.StartDate))
                    {
                        failedToParseRecords.Append(errorRow + "," + "Start date not provided" + Environment.NewLine);
                        continue;
                    }
                    //Start Date Convert
                    try
                    {
                        var startDate = Convert.ToDateTime(rowData.StartDate);

                        if (!(startDate >= DateTime.Today))
                        {
                            failedToParseRecords.Append(errorRow + "," + "Start date must be greater than or equal to current date" + Environment.NewLine);
                            continue;
                        }

                        agentData.StartDate = startDate;
                    }
                    catch (Exception)
                    {
                        failedToParseRecords.Append(errorRow + "," + "Start date invalid format" + Environment.NewLine);
                        continue;
                    }
                    //EndDate
                    if (!string.IsNullOrEmpty(rowData.EndDate))
                    {
                        try
                        {
                            var endDate = Convert.ToDateTime(rowData.EndDate);

                            if (!(endDate >= agentData.StartDate))
                            {
                                failedToParseRecords.Append(errorRow + "," + "End date should be greater than or equal to start date." + Environment.NewLine);
                                continue;
                            }
                            agentData.EndDate = endDate;
                        }
                        catch (Exception)
                        {
                            failedToParseRecords.Append(errorRow + "," + "End date invalid format" + Environment.NewLine);
                            continue;
                        }
                    }
                    else
                    {
                        agentData.EndDate = null;
                    }

                    var oruId = _userRepository.SearchUserByEmailAndRole(rowData.EmailId);
                    if (oruId == null)
                    {
                        failedToParseRecords.Append(errorRow + "," + "Agent not found in our records" + Environment.NewLine);
                        continue;
                    }

                    if (!data.AssignmentsfromUi.IsNullOrEmpty())
                    {
                        if (data.AssignmentsfromUi.Any(x => x.AssignedOrgRoleUserId == oruId))
                        {
                            failedToParseRecords.Append(errorRow + "," + "Agent already added manually" + Environment.NewLine);
                            continue;
                        }
                    }

                    if (agentDataCollection.Any(x => x.AssignedOrgRoleUserId == oruId))
                    {
                        failedToParseRecords.Append(errorRow + "," + "Failed, as record is already present in CSV" + Environment.NewLine);
                        continue;
                    }

                    agentData.AssignedOrgRoleUserId = oruId.Value;
                    agentData.Name = rowData.AgentName;

                    if (criteriaId == null)
                    {
                        criteriaId = 0;
                    }

                    if (callQueueCategory == HealthPlanCallQueueCategory.FillEventsHealthPlan)
                    {
                        agentData.IsExistInOtherCriteria = _healthPlanCallQueueCriteriaRepository.CheckHealthPlanAssignment(healthPlanId.Value,
                            callQueueCategory, criteriaId.Value, agentData.AssignedOrgRoleUserId, agentData.StartDate.Value, agentData.EndDate);

                        if (agentData.IsExistInOtherCriteria)
                        {
                            failedToParseRecords.Append(errorRow + "," + "Start date is overlapping with already assigned date for same health plan and same call queue." + Environment.NewLine);
                            continue;
                        }
                    }
                    else
                    {
                        agentData.IsExistInOtherCriteria = false;
                    }
                    agentData.IsEdited = true;
                    agentDataCollection.Add(agentData);
                }

                if (agentDataCollection.Count < table.Rows.Count) //Some records have failed
                {
                    System.IO.File.AppendAllText(logFilePath, failedToParseRecords.ToString());
                    model.IsRecordsFailed = true;
                    model.LogFileName = logFileName;
                }
                else
                {
                    model.LogFileName = null;
                }

                model.SuccessAssignments = agentDataCollection;
                model.ErrorMessage = "";
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(model.ErrorMessage = "No file has been uploaded. Please upload a csv file.", JsonRequestBehavior.AllowGet);
            }
        }

        private string CheckAllColumnExist(string[] givenList)
        {
            //var columns = "CUSTOMERID,FIRSTNAME,LASTNAME,DOB,MEMBERID,NEWPHONENUMBER,PHONETYPE";
            const string columns = MassAgentAssignmentColumns.AgentName + "," +
                                   MassAgentAssignmentColumns.EmailId + "," +
                                   MassAgentAssignmentColumns.StartDate + "," +
                                   MassAgentAssignmentColumns.EndDate;
            string[] checkList = columns.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            var list = checkList.Except(givenList, StringComparer.CurrentCultureIgnoreCase);
            if (list.Any())
                return string.Join(",", list);
            return string.Empty;
        }

        private MassAgentAssignmentUploadCsv GetMassAssignmentCsvRow(DataRow row)
        {
            var model = new MassAgentAssignmentUploadCsv
            {
                AgentName = GetRowValue(row, MassAgentAssignmentColumns.AgentName),
                EmailId = GetRowValue(row, MassAgentAssignmentColumns.EmailId),
                StartDate = GetRowValue(row, MassAgentAssignmentColumns.StartDate),
                EndDate = GetRowValue(row, MassAgentAssignmentColumns.EndDate)
            };
            return model;
        }

        private static string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        //Agent Team CreateManage
        public ActionResult CreateTeam()
        {
            var model = new CallCenterTeamEditModel
            {
                AgentsMasterList = _organizationRoleUserRepository.GetIdNamePairofUsersByRole(Roles.CallCenterRep).Sort(OrderByDirection.Ascending, x => x.SecondValue)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateTeam(CallCenterTeamEditModel model)
        {
            try
            {
                model.AgentsMasterList = _organizationRoleUserRepository.GetIdNamePairofUsersByRole(Roles.CallCenterRep).Sort(OrderByDirection.Ascending, x => x.SecondValue);
                if (!model.Assignments.IsNullOrEmpty())
                    model.AgentsMasterList = model.AgentsMasterList.Where(x => !model.Assignments.Select(y => y.FirstValue).Contains(x.FirstValue)).Select(x => x);


                #region Validations
                model.FeedbackMessage = new FeedbackMessageModel();
                model.FeedbackMessage.MessageType = UserInterfaceMessageType.Error;

                model.Name = model.Name.Trim();
                if (string.IsNullOrEmpty(model.Name))
                {
                    model.FeedbackMessage.MessageType = UserInterfaceMessageType.Warning;
                    model.FeedbackMessage.Message = "Team name cannot be empty.";
                    return View(model);
                }
                if (model.Name.Trim().Length < 5)
                {
                    model.FeedbackMessage.MessageType = UserInterfaceMessageType.Warning;
                    model.FeedbackMessage.Message = "Team name must be at least 5 characters long.";
                    return View(model);
                }

                if (!_callCenterTeamRepository.IsTeamNameUnique(model.Name))
                {
                    model.FeedbackMessage.Message = "Team name already in use.";
                    return View(model);
                }

                if (model.Assignments == null || (model.Assignments != null && !model.Assignments.Any()))
                {
                    model.FeedbackMessage.Message = "Select some agents to be in team.";
                    return View(model);
                }

                if (model.TypeId <= 0)
                {
                    model.FeedbackMessage.Message = "Select valid team type.";
                    return View(model);
                }
                #endregion

                var domain = _callCenterTeamRepository.Save(new CallCenterTeam
                {
                    Name = model.Name,
                    Description = model.Description,
                    TypeId = model.TypeId,
                    DataRecorderMetaData = new DataRecorderMetaData
                    {
                        DataRecorderCreator = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId),
                        DataRecorderModifier = null,
                        DateCreated = DateTime.Now,
                        DateModified = null
                    },
                    IsActive = true
                });

                _callCenterTeamRepository.SaveAgentTeamAssignment(domain.Id, model.Assignments.Select(x => x.FirstValue).ToList());

                var callCenterAgentTeamLogList = model.Assignments.Select(assignment => new CallCenterAgentTeamLog
                {
                    TeamId = domain.Id,
                    AgentId = assignment.FirstValue,
                    AssignedByOrgRoleUserId = domain.DataRecorderMetaData.DataRecorderCreator.Id,
                    DateAssigned = DateTime.Now,
                    DateRemoved = null,
                    IsActive = true,
                    RemovedByOrgRoleUserId = null
                }).ToList();
                _callCenterAgentTeamLogRepository.SaveAll(callCenterAgentTeamLogList);

                model.FeedbackMessage.MessageType = UserInterfaceMessageType.Success;
                model.FeedbackMessage.Message = "Team Created Successfully";

                return View(model);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error(ex.Message);
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Call Center Team CreateTeam[Post] Stack Trace :" + ex.StackTrace);
                model.FeedbackMessage = new FeedbackMessageModel();
                model.FeedbackMessage.MessageType = UserInterfaceMessageType.Error;
                model.FeedbackMessage.Message = ex.Message;

                return View(model);
            }
        }

        public ActionResult EditTeam(long teamId)
        {
            var model = _callCenterTeamService.GetCallCenterTeamEditModel(teamId);
            if (model == null)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error(string.Format("Error occurred while fetching team details. No Data Present for TeamId:{0} ", teamId));
                model = new CallCenterTeamEditModel();
                model.FeedbackMessage = new FeedbackMessageModel();
                model.FeedbackMessage.MessageType = UserInterfaceMessageType.Error;
                model.FeedbackMessage.Message = "Invalid Team Id provided";
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTeam(CallCenterTeamEditModel model)
        {
            try
            {
                model.AgentsMasterList = _organizationRoleUserRepository.GetIdNamePairofUsersByRole(Roles.CallCenterRep).Sort(OrderByDirection.Ascending, x => x.SecondValue);
                if (!model.Assignments.IsNullOrEmpty())
                    model.AgentsMasterList = model.AgentsMasterList.Where(x => !model.Assignments.Select(y => y.FirstValue).Contains(x.FirstValue)).Select(x => x);

                #region Validations
                model.Name = model.Name.Trim();
                model.FeedbackMessage = new FeedbackMessageModel();
                model.FeedbackMessage.MessageType = UserInterfaceMessageType.Error;

                if (string.IsNullOrEmpty(model.Name))
                {
                    model.FeedbackMessage.MessageType = UserInterfaceMessageType.Warning;
                    model.FeedbackMessage.Message = "Team name cannot be empty.";
                    return View(model);
                }
                if (model.Name.Trim().Length < 5)
                {
                    model.FeedbackMessage.MessageType = UserInterfaceMessageType.Warning;
                    model.FeedbackMessage.Message = "Team name must be at least 5 characters long.";
                    return View(model);
                }

                var domain = _callCenterTeamRepository.GetById(model.Id);
                if (domain == null)
                {
                    model.FeedbackMessage.Message = "No such team present in our records";
                    return View(model);
                }


                if (!string.Equals(domain.Name.ToLower(), model.Name.ToLower()))
                {
                    if (!_callCenterTeamRepository.IsTeamNameUnique(model.Name))
                    {
                        model.FeedbackMessage.Message = "Team name already in use";
                        return View(model);
                    }
                }

                if (model.Assignments == null || (model.Assignments != null && !model.Assignments.Any()))
                {
                    model.FeedbackMessage.Message = "Add some agents to be in team";
                    return View(model);
                }

                if (model.TypeId <= 0)
                {
                    model.FeedbackMessage.Message = "Invalid team type";
                    return View(model);
                }
                #endregion

                #region Save Team Data
                domain.Name = model.Name;
                domain.Description = model.Description;
                domain.TypeId = model.TypeId;
                domain.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                domain.DataRecorderMetaData.DateModified = DateTime.Now;
                _callCenterTeamRepository.Save(domain);
                #endregion

                #region Updating CallCenterAgentTeamLog
                var previousAgentsAssigned = _organizationRoleUserRepository.GetNameIdPairofUsers(_callCenterTeamRepository.GetTeamAgents(model.Id).ToArray());
                if (previousAgentsAssigned != null)
                {
                    var removedAgents = previousAgentsAssigned.Select(x => x.FirstValue).Except(model.Assignments.Select(x => x.FirstValue));
                    var newAgents = model.Assignments.Select(x => x.FirstValue).Except(previousAgentsAssigned.Select(x => x.FirstValue));

                    if (removedAgents.Any())
                    {
                        var removedAgentslog = _callCenterAgentTeamLogRepository.GetAgentTeamLogForTeam(model.Id, removedAgents.ToArray());
                        foreach (var agent in removedAgentslog)
                        {
                            agent.DateRemoved = DateTime.Now;
                            agent.RemovedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                            agent.IsActive = false;
                        }
                        _callCenterAgentTeamLogRepository.SaveAll(removedAgentslog);
                    }

                    if (newAgents.Any())
                    {
                        var callCenterAgentTeamLogList = newAgents.Select(newAgent => new CallCenterAgentTeamLog
                        {
                            TeamId = domain.Id,
                            AgentId = newAgent,
                            AssignedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                            DateAssigned = DateTime.Now,
                            DateRemoved = null,
                            IsActive = true,
                            RemovedByOrgRoleUserId = null
                        }).ToList();
                        _callCenterAgentTeamLogRepository.SaveAll(callCenterAgentTeamLogList);
                    }
                }
                #endregion

                //Save current team and agent mapping
                _callCenterTeamRepository.SaveAgentTeamAssignment(domain.Id, model.Assignments.Select(x => x.FirstValue).ToList());

                model.FeedbackMessage.MessageType = UserInterfaceMessageType.Success;
                model.FeedbackMessage.Message = "Team updated successfully";
                return View(model);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error(ex.Message);
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Call Center Team EditTeam[Post] Stack Trace :" + ex.StackTrace);
                model.FeedbackMessage = new FeedbackMessageModel();
                model.FeedbackMessage.MessageType = UserInterfaceMessageType.Error;
                model.FeedbackMessage.Message = ex.Message;
                return View(model);
            }
        }

        public JsonResult IsTeamAlreadyAssignedToHealthPlanCallQueue(long healthPlan, string callQueueCategory, long criteriaId, long teamId, DateTime startDate, DateTime? endDate)
        {
            var isExist = _healthPlanCallQueueCriteriaRepository.CheckAgentTeamHealthPlanAssignment(healthPlan, callQueueCategory, criteriaId, teamId, startDate, endDate);
            return Json(new { isExist }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ManageCallCenterTeam(CallCenterTeamListModelFilter filter = null, int pageNumber = 1)
        {
            try
            {
                int totalRecords;
                var model = _callCenterTeamService.GetCallCenterTeams(pageNumber, _pageSize, filter, out totalRecords) ??
                            new CallCenterTeamListModel();

                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                Func<int, string> urlFunc =
                    pn =>
                        Url.Action(currentAction,
                            new
                            {
                                pageNumber = pn,
                                filter.Name
                            });

                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                IoC.Resolve<ILogManager>().GetLogger<Global>().Info("Call Upload going to return view @" + DateTime.Now);

                return View(model);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error(ex.Message);
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Call Center Team Detail Stack Trace :" + ex.StackTrace);
                var model = new CallCenterTeamListModel();
                model.Filter = filter;
                return View(model);
            }
        }


        public ActionResult EditTeamAssignment(long criteriaId)
        {
            var model = new HealthPlanCriteriaTeamListEditModel
            {
                Collection = _healthPlanCallQueueCriteriaService.GetTeamAssignementEditModel(criteriaId)
            };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditTeamAssignment(HealthPlanCriteriaTeamListEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _healthPlanCallQueueCriteriaService.UpdateTeamAssignment(model);

                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Team Assignment edit successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some error occurred while assigning Team");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace:" + ex.StackTrace);

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some error occurred. Please try after some time");
            }

            return PartialView(model);
        }

        [AllowAnonymous]
        public JsonResult GetDirectMailActivityDates(long campaignId)
        {
            var directMailDates = _campaignActivityRepository.GetDirectMailActivitiesByCampaignId(campaignId);

            var collection = directMailDates.Select(dmd => new OrderedPair<long, string>
            {
                FirstValue = dmd.Id,
                SecondValue = dmd.ActivityDate.ToString("MM/dd/yyyy")
            });

            return Json(collection, JsonRequestBehavior.AllowGet);
        }
    }
}