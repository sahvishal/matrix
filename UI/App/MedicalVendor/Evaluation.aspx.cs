using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Users;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.UI.App.MedicalVendor
{
    public partial class Evaluation : System.Web.UI.Page
    {

        protected long EventId { get; set; }
        protected long CustomerId { get; set; }

        protected const string ConstForSaveAndNext = "SaveAndNext";
        protected const string ConstForSaveAndClose = "SaveAndClose";
        protected const string ConstForClose = "Close";
        protected string VersionNumber { get; set; }

        protected bool ShowBasicBiometric
        {
            get
            {
                var configRepository = IoC.Resolve<IConfigurationSettingRepository>();
                var val = configRepository.GetConfigurationValue(ConfigurationSettingName.ShowBasicBiometric);

                bool showBasicBiometric = true;

                Boolean.TryParse(val, out showBasicBiometric);

                return showBasicBiometric;
            }
        }

        protected long EventCustomerId
        {
            get
            {
                long s = 0;
                if (Request.QueryString["EventCustomerId"] != null && long.TryParse(Request.QueryString["EventCustomerId"], out s))
                {
                    return s;
                }
                return 0;
            }
        }

        protected bool IsforOveread
        {
            get { return Convert.ToBoolean(ViewState["IsforOveread"]); }
            set { ViewState["IsforOveread"] = value; }
        }

        protected bool CaptureHaf
        {
            get;
            set;
        }

        protected bool ShowCheckListForm { get; set; }
        protected bool ShowHideFastingStatus { get; set; }

        protected bool CanPhysicianUpdateResultEntery { get; set; }

        public DateTime EventDate { get; set; }

        public bool ShowCriticalPatientData { get; set; }
        protected string HraQuestionerAppUrl { get; set; }
        protected string OrganizationNameForHraQuestioner { get; set; }
        protected string HraToken { get; set; }
        protected string Tag { get; set; }
        protected long MedicareVisitId { get; set; }
        protected string ShowHraLink { get; set; }

        protected bool IsNewResultFlow { get; set; }

        protected string ShowChatLink { get; set; }
        protected string ChatQuestionerAppUrl { get; set; }
        protected bool ShowChatAssesmentLink { get; set; }
        private EventCustomerResult EventCustomerResult { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var settings = IoC.Resolve<ISettings>();

            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            if (!IsPostBack)
            {
                if (EventCustomerId > 0)
                {
                    var eventRepository = new EventCustomerResultRepository();
                    EventCustomerResult = eventRepository.GetById(EventCustomerId);
                    if (EventCustomerResult != null)
                    {
                        EventId = EventCustomerResult.EventId;
                        CustomerId = EventCustomerResult.CustomerId;
                        SetEventBasicInfo(EventCustomerResult.EventId);
                        TestSection.CustomerId = EventCustomerResult.CustomerId;
                        TestSection.EventId = EventCustomerResult.EventId;
                    }

                    var priorityInQueue = IoC.Resolve<IPriorityInQueueRepository>().GetByEventCustomerResultId(EventCustomerId);
                    if (priorityInQueue != null && priorityInQueue.InQueuePriority > 0 && priorityInQueue.NoteId != null)
                    {
                        var noteText = IoC.Resolve<INotesRepository>().Get(priorityInQueue.NoteId.Value);
                        if (noteText != null && !string.IsNullOrEmpty(noteText.Text))
                        {
                            PriorityInQueueMessage.ShowSuccessMessage("<b><u>Priority In Queue Reason:</u> </b>" +
                                                                         noteText.Text);
                            PriorityInQueueMessage.Visible = true;
                        }
                    }

                    var customerEventTestStateRepository = IoC.Resolve<ICustomerEventTestStateRepository>();
                    var isCriticalPatient = customerEventTestStateRepository.IsPatientCritical(EventCustomerId);

                    var eventCustomerCriticalQuestionRepository = IoC.Resolve<IEventCustomerCriticalQuestionRepository>();
                    var criticalData = eventCustomerCriticalQuestionRepository.GetByEventCustomerId(EventCustomerId);

                    if ((priorityInQueue != null && priorityInQueue.InQueuePriority > 0) || (isCriticalPatient && !criticalData.IsNullOrEmpty()))
                    {
                        ShowCriticalPatientData = true;
                    }
                }

                Page.Title = "Evaluation : " + CustomerId;

                var physicianId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                var physicianRepository = IoC.Resolve<IPhysicianRepository>();
                var overReadPhysicianId = physicianRepository.GetOverreadPhysician(EventCustomerId);

                var physician = physicianRepository.GetPhysician(physicianId);
                CanPhysicianUpdateResultEntery = physician.UpdateResultEntry;
                if (physicianId == overReadPhysicianId) IsforOveread = true;
                else IsforOveread = false;

                string messageForPhysician = new CommunicationRepository().GetCommentsforPhysician(CustomerId, EventId, physicianId);
                if (!string.IsNullOrEmpty(messageForPhysician))
                {
                    FranchiseeCommentsMessage.ShowSuccessMessage("<b><u>Technician Comments:</u> </b>" + messageForPhysician);
                    FranchiseeCommentsMessage.Visible = true;
                }

                if (overReadPhysicianId > 0)
                {
                    headerifoverreaddiv.Visible = true;
                    headerifoverreaddiv.InnerHtml = IsforOveread ? "<h2> This study is an Overread, and you are the Second Evaluator! </h2>" : "<h2> This study is an Overread, and you are the First Evaluator! </h2>";
                }

                ClientScript.RegisterClientScriptBlock(Page.GetType(), "js_OverRead", (overReadPhysicianId > 0 ? " var isOverReadAvailable = true; " : " var isOverReadAvailable = false; ") + (overReadPhysicianId == physicianId ? "var isCurrentViewforOverread = true;" : "var isCurrentViewforOverread = false;"), true);

                var mediaLocation = IoC.Resolve<IMediaRepository>().GetResultMediaFileLocation(CustomerId, EventId);
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "js_Location_Url", "function getLocationPrefix() { return '" + mediaLocation.PhysicalPath.Replace("\\", "\\\\") + "'; } function getUrlPrefix() { return '" + mediaLocation.Url + "'; }", true);

                var basicBiometricCutOfDate = settings.BasicBiometricCutOfDate;
                var hideBasicBiometric = (EventDate.Date >= basicBiometricCutOfDate);
                BasicBiometric.ShowByCutOffDate = !hideBasicBiometric;

                ShowHideFastingStatus = (EventDate.Date.Date >= settings.FastingStatusDate);

                TestSection.SetSectionShowHideEvaluation(EventId, CustomerId, hideBasicBiometric);

                StartEvaluation();
                GetConductedbyData();

                CreateIfjsArrays();
                CreateJsArrayforIfuCs();

                var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
                var eventHospitalPartner = hospitalPartnerRepository.GetEventHospitalPartnersByEventId(EventId);
                if (eventHospitalPartner != null && eventHospitalPartner.RestrictEvaluation)
                {
                    var eventPhysicianTestRepository = IoC.Resolve<IEventPhysicianTestRepository>();
                    var eventPhysicianTests = eventPhysicianTestRepository.GetByEventIdPhysicianId(EventId, physicianId);
                    if (eventPhysicianTests != null && eventPhysicianTests.Any())
                    {
                        foreach (var eventPhysicianTest in eventPhysicianTests)
                        {
                            ClientScript.RegisterArrayDeclaration("arr_permittedtest", "'" + eventPhysicianTest.TestId + "'");
                        }
                    }
                }
                else
                {
                    var testIds = physicianRepository.GetPermittedTestIdsForPhysician(physicianId);
                    foreach (var testId in testIds)
                    {
                        ClientScript.RegisterArrayDeclaration("arr_permittedtest", "'" + testId + "'");
                    }
                }
            }

            var accountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = accountRepository.GetbyEventId(EventId);
            CaptureHaf = (account == null || account.CaptureHaf);
            IsNewResultFlow = EventDate >= settings.ResultFlowChangeDate;

            QuestionnaireType questionnaireType = QuestionnaireType.None;
            if (account != null && account.IsHealthPlan)
            {
                var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, EventDate);
            }

            ShowHraLink = "none";
            ShowChatLink = "none";

            if (EventCustomerResult == null && EventCustomerId > 0)
            {
                var eventRepository = new EventCustomerResultRepository();
                EventCustomerResult = eventRepository.GetById(EventCustomerId);
            }

            if (EventCustomerResult != null)
            {
                if (!IsforOveread)
                {
                    hfIsPdfVerified.Value = EventCustomerResult.ChatPdfReviewedByPhysicianId.HasValue
                        && EventCustomerResult.ChatPdfReviewedByPhysicianDate.HasValue ? "1" : "0";
                }
                else
                {
                    hfIsPdfVerified.Value = EventCustomerResult.ChatPdfReviewedByOverreadPhysicianId.HasValue
                        && EventCustomerResult.ChatPdfReviewedByOverreadPhysicianDate.HasValue ? "1" : "0";
                }
            }

            if (account != null && account.IsHealthPlan && (questionnaireType == QuestionnaireType.HraQuestionnaire) && EventCustomerId > 0)
            {
                var testResultService = IoC.Resolve<ITestResultService>();
                var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);
                if (IsNewResultFlow)
                {
                    var isEawvPurchased = testResultService.IsTestPurchasedByCustomer(EventCustomerId, (long)TestType.eAWV);
                    if (isEawvPurchased)
                    {
                        var testResultRepository = new EAwvTestRepository();
                        var eawvTestResult = testResultRepository.GetTestResult(eventCustomer.CustomerId, eventCustomer.EventId, (int)TestType.eAWV, IsNewResultFlow);

                        bool iseawvTestMarkedTestNotPerformed = eawvTestResult != null &&
                                                                eawvTestResult.TestNotPerformed != null &&
                                                                eawvTestResult.TestNotPerformed.TestNotPerformedReasonId >
                                                                0;

                        if (!iseawvTestMarkedTestNotPerformed)
                        {
                            if (eventCustomer.AwvVisitId != null)
                            {
                                MedicareVisitId = eventCustomer.AwvVisitId.Value;
                                Tag = account.Tag;
                                var sessionContext = IoC.Resolve<ISessionContext>();
                                HraQuestionerAppUrl = settings.HraQuestionerAppUrl;
                                OrganizationNameForHraQuestioner = settings.OrganizationNameForHraQuestioner;
                                HraToken = (Session.SessionID + "_" + sessionContext.UserSession.UserId + "_" +
                                            sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" +
                                            sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();
                                ShowHraLink = "block";
                            }
                        }
                    }
                }
                else
                {
                    if (eventCustomer.AwvVisitId != null)
                    {
                        MedicareVisitId = eventCustomer.AwvVisitId.Value;
                        Tag = account.Tag;
                        var sessionContext = IoC.Resolve<ISessionContext>();
                        HraQuestionerAppUrl = settings.HraQuestionerAppUrl;
                        OrganizationNameForHraQuestioner = settings.OrganizationNameForHraQuestioner;
                        HraToken = (Session.SessionID + "_" + sessionContext.UserSession.UserId + "_" +
                                    sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" +
                                    sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();
                        ShowHraLink = "block";
                    }
                }
            }
            else if (account != null && account.IsHealthPlan && (questionnaireType == QuestionnaireType.ChatQuestionnaire) && EventCustomerId > 0)
            {
                ChatQuestionerAppUrl = settings.ChatQuestionerAppUrl;
                ShowChatLink = "block";
                ShowChatAssesmentLink = true;
            }

            if (EventDate < settings.ChecklistChangeDate)
                ShowCheckListForm = account != null && account.PrintCheckList;

            if (IsNewResultFlow)
                ClientScript.RegisterHiddenField("IsNewResultFlowInputHidden", "true");
            else
                ClientScript.RegisterHiddenField("IsNewResultFlowInputHidden", "false");
        }

        private void GetConductedbyData()
        {
            var eventStaffAssignementRepository = IoC.Resolve<IEventStaffAssignmentRepository>();
            var staff = eventStaffAssignementRepository.GetForEvent(EventId);
            if (staff != null && staff.Count() > 0)
            {
                var orgRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                var nameIdPairs = orgRoleUserRepository.GetNameIdPairofUsers(
                    staff.Select(s => (s.ActualStaffOrgRoleUserId ?? s.ScheduledStaffOrgRoleUserId)).ToArray());

                Conductedby.DataTextField = "SecondValue";
                Conductedby.DataValueField = "FirstValue";
                Conductedby.DataSource = nameIdPairs;
                Conductedby.DataBind();

                Conductedby.Items.Insert(0, new ListItem("--Conducted By--", "0"));
            }
        }

        private void SetEventBasicInfo(long eventId)
        {
            var eventService = IoC.Resolve<IEventService>();
            var eventBasicInfo = eventService.GetEventBasicInfoFor(eventId);
            EventDate = eventBasicInfo.EventDate;

            screeningdate.InnerText = eventBasicInfo.EventDate.ToShortDateString();
            screeninglocation.InnerText = eventBasicInfo.HostName + " - " + eventBasicInfo.HostAddress.ToString();
            eventvehicle.InnerText = eventBasicInfo.PodNames();
        }

        private void CreateIfjsArrays()
        {
            IIncidentalFindingRepository incidentalFindingrepository = new IncidentalFindingRepository();
            var incidentalFindingGroup = incidentalFindingrepository.GetAllIncidentalFindingGroup();

            var isRegistered = false;
            var incidentalFinding = incidentalFindingrepository.GetAllIncidentalFinding().ToList();

            incidentalFindingGroup.ForEach(ifGroup =>
            {
                if (ifGroup.Id == (int)IncidentalFindingGroupType.SonographicAppearance)
                {
                    ifGroup.GroupItems.ForEach(groupItem =>
                    {
                        Page.ClientScript.RegisterArrayDeclaration("js_arrSonographicAppearanceLabel", "'" + groupItem.Label + "'");
                        Page.ClientScript.RegisterArrayDeclaration("js_arrSonographicAppearanceID", groupItem.Id.ToString());
                    });
                }

                if (ifGroup.Id == (int)IncidentalFindingGroupType.AbdominalLocation || ifGroup.Id == (int)IncidentalFindingGroupType.KidneyLocation
                    || ifGroup.Id == (int)IncidentalFindingGroupType.LiverLocation || ifGroup.Id == (int)IncidentalFindingGroupType.ThyriodLocation)
                {
                    var selectedIfs = incidentalFinding.FindAll(ifinding =>
                    {
                        var findingGroup = ifinding.IncidentalFindingGroups.Find(group => group.Id == ifGroup.Id);
                        if (findingGroup != null) return true;

                        return false;
                    });

                    selectedIfs.ForEach(selectedIf => ifGroup.GroupItems.ForEach(groupItem =>
                    {
                        Page.ClientScript.RegisterArrayDeclaration("js_arrIFLocationsLabel", "'" + groupItem.Label + "'");
                        Page.ClientScript.RegisterArrayDeclaration("js_arrIFLocationsID", groupItem.Id.ToString());
                        Page.ClientScript.RegisterArrayDeclaration("js_arrIFID", selectedIf.Id.ToString());
                    }));
                }

                if (ifGroup.Id == (int)IncidentalFindingGroupType.Size)
                {
                    Page.ClientScript.RegisterHiddenField("js_if_size", ifGroup.GroupItems.First().Id.ToString());
                }
                if (ifGroup.Id == (int)IncidentalFindingGroupType.Notes)
                {
                    var selectedIfs = incidentalFinding.FindAll(ifinding =>
                    {
                        var findingGroup = ifinding.IncidentalFindingGroups.Find(group => group.Id == ifGroup.Id);
                        if (findingGroup != null) return true;
                        return false;
                    });

                    selectedIfs.ForEach(selectedIf => ifGroup.GroupItems.ForEach(groupItem =>
                    {
                        Page.ClientScript.RegisterArrayDeclaration("js_arrIFGroupItemId", "'" + groupItem.Id.ToString() + "'");
                        Page.ClientScript.RegisterArrayDeclaration("js_arrIFGroupId", "'" + ifGroup.Id.ToString() + "'");
                        Page.ClientScript.RegisterArrayDeclaration("js_arrIFID", "'" + selectedIf.Id.ToString() + "'");
                        isRegistered = true;
                    }));

                }
                if (ifGroup.Id == (int)IncidentalFindingGroupType.KidneyStones)
                {
                    Page.ClientScript.RegisterHiddenField("js_if_kidney", ifGroup.GroupItems.First().Id.ToString());
                }
            });

            if (!isRegistered)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "js_Array", "var js_arrIFGroupItemId = new Array(); var js_arrIFGroupId = new Array(); var js_arrIFID = new Array();", true);
            }
        }

        private void CreateJsArrayforIfuCs()
        {
            Page.ClientScript.RegisterArrayDeclaration("js_arrIFUCLabel", "'ucIFCommon.ascx'");
            Page.ClientScript.RegisterArrayDeclaration("js_arrIFUCLabel", "'ucIFLocationWise.ascx'");
            Page.ClientScript.RegisterArrayDeclaration("js_arrIFUCLabel", "'ucIFLocationWiseforKidney.ascx'");
        }


        [WebMethod(EnableSession = true)]
        public static void CompletePhysicianEvaluation(long eventCustomerId, long physicianId, bool isSendForCorrection, bool isNewResultFlow)
        {
            ReleaseLock(eventCustomerId);
            try
            {
                if (isSendForCorrection)
                {
                    IoC.Resolve<IPhysicianEvaluationRepository>().Delete(eventCustomerId, physicianId);
                }
                else
                {
                    StopEvaluation(eventCustomerId, physicianId);

                    var physicianAssignmentService = IoC.Resolve<IPhysicianAssignmentService>();
                    var eventCustomer = IoC.Resolve<IEventCustomerRepository>().GetById(eventCustomerId);
                    var assignedPhysicianIds =
                        physicianAssignmentService.GetPhysicianIdsAssignedtoaCustomer(eventCustomer.EventId, eventCustomer.CustomerId);
                    if (assignedPhysicianIds == null || assignedPhysicianIds.Count() == 0)
                        return;

                    if ((assignedPhysicianIds.Count() == 1 && assignedPhysicianIds.ElementAtOrDefault(0) == physicianId) || assignedPhysicianIds.ElementAtOrDefault(1) == physicianId)
                    {
                        if (!SkipAudit(assignedPhysicianIds) || isNewResultFlow)
                            return;
                        var testResultRepository = new TestResultRepository();
                        testResultRepository.SetResultstoState(eventCustomer.EventId, eventCustomer.CustomerId, (int)TestResultStateNumber.PostAudit, true, physicianId);

                        var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
                        eventCustomerResultRepository.SetEventCustomerResultState(eventCustomer.EventId, eventCustomer.CustomerId);
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                logger.Error("Evaluation EventCustomerId (" + eventCustomerId + ") & PhysicianId (" + physicianId + "). Error occured while executing CompletePhysicianEvaluation. Message: " + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
            }
        }

        [WebMethod(EnableSession = true)]
        public static void ReleaseLock(long eventCustomerId)
        {
            try
            {
                if (eventCustomerId > 0)
                {
                    IoC.Resolve<IPhysicianEvaluationRepository>().ReleasePhysicianEvaluationLock(eventCustomerId);
                }
            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                logger.Error("Evaluation EventCustomerId (" + eventCustomerId + "). Error occured while executing Release Lock. Message: " + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
            }
        }

        [WebMethod(EnableSession = true)]
        public static void RecordNotesforSendDataforCorrection(string physicianNotes, long physicianId, long eventId, long customerId)
        {
            try
            {
                var repository = new CommunicationRepository();
                var orgRoleUser = IoC.Resolve<IOrganizationRoleUserRepository>();
                var organizationRoleUser = orgRoleUser.GetOrganizationRoleUser(physicianId);
                repository.SaveCommunicationDetails(physicianNotes, organizationRoleUser, customerId, eventId);

                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                var notificationModel = emailNotificationModelsFactory.GetRecordSendBackForCorrectionNotificationViewModel(customerId, eventId, physicianId, physicianNotes);

                var notifier = IoC.Resolve<INotifier>();
                notifier.NotifySubscribersViaEmail(NotificationTypeAlias.RecordSendBackForCorrection, EmailTemplateAlias.RecordSendBackForCorrection, notificationModel, 0, organizationRoleUser.OrganizationId, "Record Send Back For Correction");

            }
            catch (Exception ex)
            {
                var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                logger.Error("Evaluation EventId (" + eventId + "), CustomerId (" + customerId + "), PhysicianId (" + physicianId + "). Error occured while executing Recording Physician Remarsk for Send for Correction. Message: " + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
            }
        }

        private void StartEvaluation()
        {
            var physicianId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var physicianEvaluationRepository = IoC.Resolve<IPhysicianEvaluationRepository>();
            var evaluation = physicianEvaluationRepository.GetPhysicianEvaluationinTransaction(EventCustomerId, physicianId);
            if (evaluation == null || evaluation.IsPrimaryEvaluator == IsforOveread)
            {
                evaluation = new PhysicianEvaluation
                                 {
                                     PhysicianId = physicianId,
                                     EventCustomerId = EventCustomerId,
                                     EvaluationStartTime = DateTime.Now,
                                     IpAddress = Request.UserHostAddress,
                                     IsPrimaryEvaluator = !IsforOveread
                                 };
            }
            else
            {
                evaluation.EvaluationStartTime = DateTime.Now;
                evaluation.IpAddress = Request.UserHostAddress;
            }

            physicianEvaluationRepository.Save(evaluation);
        }

        private static void StopEvaluation(long eventCustomerId, long physicianId)
        {
            var physicianEvaluationRepository = IoC.Resolve<IPhysicianEvaluationRepository>();
            var evaluation = physicianEvaluationRepository.GetPhysicianEvaluationinTransaction(eventCustomerId, physicianId);

            if (evaluation != null)
            {
                evaluation.EvaluationEndTime = DateTime.Now;
                physicianEvaluationRepository.Save(evaluation);
            }
        }

        private static bool SkipAudit(IEnumerable<long> physicianIds)
        {
            var physicianRepository = IoC.Resolve<IPhysicianRepository>();
            if (physicianIds.Count() == 1)
            {
                return physicianRepository.GetPhysician(physicianIds.ElementAt(0)).SkipAudit;
            }

            return (physicianRepository.GetPhysician(physicianIds.ElementAt(0)).SkipAudit &&
                    physicianRepository.GetPhysician(physicianIds.ElementAt(1)).SkipAudit);
        }
    }
}